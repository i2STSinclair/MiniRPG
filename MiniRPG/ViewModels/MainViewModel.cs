using System.Windows.Input;

namespace MiniRPG.ViewModels
{
    /// <summary>
    /// MainViewModel manages the current view and commands for switching views.
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

        public ICommand ShowMapCommand { get; }
        public ICommand ShowBattleCommand { get; }

        public MainViewModel()
        {
            ShowMapCommand = new RelayCommand(_ => ShowMap());
            ShowBattleCommand = new RelayCommand(_ => ShowBattle());
            CurrentViewModel = new MapViewModel(); // Default view
        }

        private void ShowMap()
        {
            CurrentViewModel = new MapViewModel();
            // Future: Insert transition/animation logic here for MapView
        }

        private void ShowBattle()
        {
            CurrentViewModel = new BattleViewModel();
            // Future: Insert transition/animation logic here for BattleView
        }
    }
}
