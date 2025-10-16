using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MiniRPG.ViewModels
{
    /// <summary>
    /// ViewModel for BattleView. Handles combat actions and combat log.
    /// </summary>
    public class BattleViewModel : BaseViewModel
    {
        private readonly Random _random = new();

        public ObservableCollection<string> CombatLog { get; } = new();
        private ObservableCollection<string> _globalLog;

        public ICommand AttackCommand { get; }
        public ICommand DefendCommand { get; }
        public ICommand RunCommand { get; }

        // TODO: Add player/enemy HP tracking
        // TODO: Add enemy AI logic

        public BattleViewModel(ObservableCollection<string> globalLog)
        {
            _globalLog = globalLog;
            AttackCommand = new RelayCommand(_ => Attack());
            DefendCommand = new RelayCommand(_ => Defend());
            RunCommand = new RelayCommand(_ => Run());
        }

        private void Attack()
        {
            int damage = _random.Next(3, 11); // 3-10 damage
            var msg = $"You attack the enemy for {damage} damage!";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            // TODO: Update enemy HP and check for defeat
        }

        private void Defend()
        {
            int block = _random.Next(1, 6); // 1-5 block
            var msg = $"You defend and block {block} damage!";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            // TODO: Reduce incoming damage, update HP
        }

        private void Run()
        {
            bool success = _random.NextDouble() > 0.5;
            var msg = success ? "You successfully ran away!" : "You failed to escape!";
            CombatLog.Add(msg);
            _globalLog.Add(msg);
            // TODO: Handle run success/failure logic
        }
    }
}
