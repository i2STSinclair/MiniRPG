using System.Windows.Input;
using System.Text;

namespace MiniRPG.ViewModels
{
    /// <summary>
    /// ViewModel for BattleView. Handles combat actions and log.
    /// </summary>
    public class BattleViewModel : BaseViewModel
    {
        private string _combatLog = string.Empty;
        public string CombatLog
        {
            get => _combatLog;
            set { _combatLog = value; OnPropertyChanged(); }
        }

        public ICommand AttackCommand { get; }
        public ICommand DefendCommand { get; }
        public ICommand RunCommand { get; }

        public BattleViewModel()
        {
            AttackCommand = new RelayCommand(_ => LogAction("Attack"));
            DefendCommand = new RelayCommand(_ => LogAction("Defend"));
            RunCommand = new RelayCommand(_ => LogAction("Run"));
        }

        private void LogAction(string action)
        {
            CombatLog += $"> {action} action performed.\n";
            // TODO: Insert animation/transition logic for action
        }
    }
}
