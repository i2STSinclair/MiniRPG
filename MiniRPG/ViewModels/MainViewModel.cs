using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

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
            var mapVM = new MapViewModel(GlobalLog);
            mapVM.OnStartBattle += async location =>
            {
                var battleVM = new BattleViewModel(GlobalLog);
                // Optionally pass location to BattleViewModel here
                battleVM.BattleEnded += async result =>
                {
                    AddLog($"Battle ended with result: {result}");
                    // TODO: Later, implement rewards and experience points after victory
                    await Task.Delay(1000);
                    ShowMap();
                };
                CurrentViewModel = battleVM;
                AddLog($"Entering battle at {location}");
                // TODO: Later - fade transition and music change between map and battle
            };
            CurrentViewModel = mapVM;
            AddLog("Switched to MapView");
            // Future: Insert transition/animation logic here for MapView
        }

        private void ShowBattle()
        {
            var battleVM = new BattleViewModel(GlobalLog);
            battleVM.BattleEnded += async result =>
            {
                AddLog($"Battle ended with result: {result}");
                // TODO: Later, implement rewards and experience points after victory
                await Task.Delay(1000);
                ShowMap();
            };
            CurrentViewModel = battleVM;
            AddLog("Switched to BattleView");
            // Future: Insert transition/animation logic here for BattleView
        }
    }
}
