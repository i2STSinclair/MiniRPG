using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MiniRPG.Models;

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
        public ICommand RestCommand { get; }
        private ObservableCollection<string> _globalLog;

        public Player Player { get; }

        // Event/callback for starting battle
        public event Action<string>? OnStartBattle;

        public MapViewModel(ObservableCollection<string> globalLog, Player player)
        {
            _globalLog = globalLog;
            Player = player;
            Locations = new ObservableCollection<string>
            {
                "Forest",
                "Cave",
                "Ruins"
            };
            StartBattleCommand = new RelayCommand(_ => StartBattle());
            RestCommand = new RelayCommand(_ => Rest());
        }

        public MapViewModel(Player player)
        {
            Player = player;
            Locations = new ObservableCollection<string>
            {
                "Forest",
                "Cave",
                "Ruins"
            };
            StartBattleCommand = new RelayCommand(_ => StartBattle());
            // TODO: Add currency, inventory, and gear tabs next
        }

        private void StartBattle()
        {
            var msg = $"Starting battle at [{SelectedLocation}]";
            Debug.WriteLine(msg);
            _globalLog.Add(msg);
            OnStartBattle?.Invoke(SelectedLocation ?? "Unknown");
            // TODO: In future, connect to BattleViewModel and load enemy data
        }

        private void Rest()
        {
            Player.HP = Player.MaxHP;
            OnPropertyChanged(nameof(Player));
            _globalLog?.Add("You rest and recover all HP.");
            // TODO: Replace with inn scene and cost-based healing later
        }
    }
}
