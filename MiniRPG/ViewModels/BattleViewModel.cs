using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MiniRPG.Services;

namespace MiniRPG.ViewModels
{
    /// <summary>
    /// ViewModel for BattleView. Handles combat actions, HP, and combat log.
    /// </summary>
    public class BattleViewModel : BaseViewModel
    {
        public ObservableCollection<string> CombatLog { get; } = new();
        private ObservableCollection<string> _globalLog;

        private int _playerHP = 30;
        public int PlayerHP
        {
            get => _playerHP;
            set { _playerHP = value; OnPropertyChanged(); }
        }

        private int _enemyHP = 20;
        public int EnemyHP
        {
            get => _enemyHP;
            set { _enemyHP = value; OnPropertyChanged(); }
        }

        private string _currentEnemy;
        public string CurrentEnemy
        {
            get => _currentEnemy;
            set { _currentEnemy = value; OnPropertyChanged(); }
        }

        private bool _isBattleOver;
        public bool IsBattleOver
        {
            get => _isBattleOver;
            set { _isBattleOver = value; OnPropertyChanged(); }
        }

        private bool _canAct = true;
        private bool _defendNext = false;

        public ICommand AttackCommand { get; }
        public ICommand DefendCommand { get; }
        public ICommand RunCommand { get; }

        // Later: Replace integers with full Stat objects for scaling difficulty

        public BattleViewModel(ObservableCollection<string> globalLog)
        {
            _globalLog = globalLog;
            CurrentEnemy = GameService.GetRandomEnemy();
            PlayerHP = 30;
            EnemyHP = 20;
            IsBattleOver = false;
            AttackCommand = new RelayCommand(_ => Attack(), _ => _canAct && !IsBattleOver);
            DefendCommand = new RelayCommand(_ => Defend(), _ => _canAct && !IsBattleOver);
            RunCommand = new RelayCommand(_ => Run(), _ => _canAct && !IsBattleOver);
        }

        private void Attack()
        {
            int dmg = GameService.CalculateDamage();
            EnemyHP -= dmg;
            var msg = $"You strike {CurrentEnemy} for {dmg} damage! (Enemy HP: {EnemyHP})";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            if (EnemyHP <= 0)
            {
                CombatLog.Add("You defeated the enemy!");
                _globalLog.Add("You defeated the enemy!");
                IsBattleOver = true;
                _canAct = false;
                UpdateCommands();
            }
            else
            {
                EnemyAttack();
            }
        }

        private void Defend()
        {
            _defendNext = true;
            var msg = "You brace for the next attack!";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            EnemyAttack();
        }

        private void Run()
        {
            var msg = "You escaped safely.";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            IsBattleOver = true;
            _canAct = false;
            UpdateCommands();
        }

        private void EnemyAttack()
        {
            int dmg = GameService.CalculateDamage() / 2;
            if (_defendNext)
            {
                dmg /= 2;
                _defendNext = false;
            }
            PlayerHP -= dmg;
            var msg = $"{CurrentEnemy} attacks you for {dmg} damage! (Your HP: {PlayerHP})";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            if (PlayerHP <= 0)
            {
                CombatLog.Add("You were defeated!");
                _globalLog.Add("You were defeated!");
                IsBattleOver = true;
                _canAct = false;
                UpdateCommands();
            }
        }

        private void UpdateCommands()
        {
            OnPropertyChanged(nameof(AttackCommand));
            OnPropertyChanged(nameof(DefendCommand));
            OnPropertyChanged(nameof(RunCommand));
        }
    }
}
