using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MiniRPG.ViewModels
{
    /// <summary>
    /// MainViewModel manages the current view, global log, and commands for switching views.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged();
                    // Future: Insert transition/animation logic here when switching views
                }
            }
        }

        public ObservableCollection<string> GlobalLog { get; } = new();

        public ICommand ShowMapCommand { get; }
        public ICommand ShowBattleCommand { get; }

        public MainViewModel()
        {
            ShowMapCommand = new RelayCommand(_ => ShowMap());
            ShowBattleCommand = new RelayCommand(_ => ShowBattle());
            ShowMap(); // Default view
        }

        public void AddLog(string message)
        {
            GlobalLog.Add(message);
            OnPropertyChanged(nameof(GlobalLog));
            OnPropertyChanged(nameof(CombinedLog));
        }

        public string CombinedLog => string.Join("\n", GlobalLog);

        private void ShowMap()
        {
            CurrentViewModel = new MapViewModel(GlobalLog);
            AddLog("Switched to MapView");
            // Future: Insert transition/animation logic here for MapView
        }

        private void ShowBattle()
        {
            CurrentViewModel = new BattleViewModel(GlobalLog);
            AddLog("Switched to BattleView");
            // Future: Insert transition/animation logic here for BattleView
        }
    }
}
