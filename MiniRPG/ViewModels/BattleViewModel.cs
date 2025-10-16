using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MiniRPG.Services;

namespace MiniRPG.ViewModels
{
    /// <summary>
    /// ViewModel for BattleView. Handles combat actions and combat log.
    /// </summary>
    public class BattleViewModel : BaseViewModel
    {
        public ObservableCollection<string> CombatLog { get; } = new();
        private ObservableCollection<string> _globalLog;

        private string _currentEnemy;
        public string CurrentEnemy
        {
            get => _currentEnemy;
            set { _currentEnemy = value; OnPropertyChanged(); }
        }

        public ICommand AttackCommand { get; }
        public ICommand DefendCommand { get; }
        public ICommand RunCommand { get; }

        private bool _canAct = true;

        // TODO: Future - implement enemy turn and HP logic

        public BattleViewModel(ObservableCollection<string> globalLog)
        {
            _globalLog = globalLog;
            CurrentEnemy = GameService.GetRandomEnemy();
            AttackCommand = new RelayCommand(_ => Attack(), _ => _canAct);
            DefendCommand = new RelayCommand(_ => Defend(), _ => _canAct);
            RunCommand = new RelayCommand(_ => Run(), _ => _canAct);
        }

        private void Attack()
        {
            int dmg = GameService.CalculateDamage();
            var msg = $"You hit {CurrentEnemy} for {dmg} damage!";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            // TODO: Future - implement enemy turn and HP logic
        }

        private void Defend()
        {
            var msg = "You brace for the next attack!";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            // TODO: Future - implement enemy turn and HP logic
        }

        private void Run()
        {
            var msg = "You fled from battle!";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            _canAct = false;
            OnPropertyChanged(nameof(AttackCommand));
            OnPropertyChanged(nameof(DefendCommand));
            OnPropertyChanged(nameof(RunCommand));
            // TODO: Future - implement enemy turn and HP logic
        }
    }
}
