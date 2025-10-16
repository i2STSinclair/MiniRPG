using System.Collections.ObjectModel;
using System.Diagnostics;
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

        private string? _selectedLocation;
        public string? SelectedLocation
        {
            get => _selectedLocation;
            set { _selectedLocation = value; OnPropertyChanged(); }
        }

        public ICommand StartBattleCommand { get; }

        public MapViewModel()
        {
            Locations = new ObservableCollection<string>
            {
                "Forest",
                "Cave",
                "Ruins"
            };
            StartBattleCommand = new RelayCommand(_ => StartBattle());
        }

        private void StartBattle()
        {
            Debug.WriteLine($"Starting battle at [{SelectedLocation}]");
            // TODO: In future, connect to BattleViewModel and load enemy data
        }
    }
}
