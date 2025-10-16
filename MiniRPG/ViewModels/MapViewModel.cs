using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MiniRPG.ViewModels
{
    /// <summary>
    /// ViewModel for MapView. Holds battle locations and command to start battle.
    /// </summary>
    public class MapViewModel : BaseViewModel
    {
        private ObservableCollection<string> _locations;
        public ObservableCollection<string> Locations
        {
            get => _locations;
            set { _locations = value; OnPropertyChanged(); }
        }

        public ICommand StartBattleCommand { get; }

        public MapViewModel()
        {
            Locations = new ObservableCollection<string>
            {
                "Forest",
                "Cave",
                "Castle",
                "Village"
            };
            StartBattleCommand = new RelayCommand(_ => StartBattle());
        }

        private void StartBattle()
        {
            // TODO: Implement battle start logic
            // Future: Insert transition/animation logic here
        }
    }
}
