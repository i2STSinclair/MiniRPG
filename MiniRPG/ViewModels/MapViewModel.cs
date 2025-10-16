using System;
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
        private ObservableCollection<string> _globalLog;

        // Event/callback for starting battle
        public event Action<string>? OnStartBattle;

        public MapViewModel(ObservableCollection<string> globalLog)
        {
            _globalLog = globalLog;
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
            var msg = $"Starting battle at [{SelectedLocation}]";
            Debug.WriteLine(msg);
            _globalLog.Add(msg);
            OnStartBattle?.Invoke(SelectedLocation ?? "Unknown");
            // TODO: In future, connect to BattleViewModel and load enemy data
        }
    }
}
