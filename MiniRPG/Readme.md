---

## MainWindow.xaml Layout Update

- Replaced the default Grid in MainWindow.xaml with a modern WPF layout for SimpleRPG prototype.
- Added a top MenuBar with two buttons: "Map" and "Battle".
- Inserted a main ContentControl below the MenuBar to switch between MapView and BattleView.
- Added a bottom multi-line, read-only, scrollable TextBox for combat logs/messages.
- Used proper Grid row definitions and named each control for clarity.
- Commented XAML to indicate where images or art assets can be inserted.

---

## BaseViewModel Added

- Created a new C# class named BaseViewModel in the ViewModels folder.
- Implements INotifyPropertyChanged and provides a protected OnPropertyChanged(string propertyName) method.
- Follows standard MVVM pattern for property change notification.

---

## MainViewModel and Supporting Classes Added

- Created MainViewModel.cs in the ViewModels folder.
  - Inherits from BaseViewModel.
  - Adds CurrentViewModel property (BaseViewModel).
  - Adds ShowMapCommand and ShowBattleCommand properties using RelayCommand.
  - Commands switch CurrentViewModel between new MapViewModel() and new BattleViewModel().
  - Comments added for future transitions/animations.
- Implemented RelayCommand in ViewModels folder for MVVM command binding.
- Added placeholder MapViewModel and BattleViewModel classes inheriting from BaseViewModel.

---

## RelayCommand Refactored

- Refactored RelayCommand in ViewModels folder:
  - Implements ICommand for MVVM button bindings.
  - Constructor accepts Action<object?> execute and optional Func<object?, bool>? canExecute.
  - Implements CanExecuteChanged, CanExecute, and Execute with proper null checking.
  - Added comments for future parameter expansion and context support.

---

## MapView UserControl Added

- Created MapView.xaml and MapView.xaml.cs as a new UserControl.
  - Displays a label "Choose a Battle Location".
  - ListBox named LocationList bound to Locations collection in MapViewModel.
  - "Fight!" button bound to StartBattleCommand.
  - Uses Grid layout and includes comment for future background map art.
- Updated MapViewModel to implement Locations collection and StartBattleCommand for binding.

---

## MapViewModel Updated

- Updated MapViewModel in ViewModels folder:
  - Inherits from BaseViewModel.
  - Adds ObservableCollection<string> Locations, prefilled with "Forest", "Cave", "Ruins".
  - Adds SelectedLocation property.
  - Adds StartBattleCommand (RelayCommand).
  - When executed, logs "Starting battle at [SelectedLocation]" using Debug.WriteLine.
  - Added TODO comment for future connection to BattleViewModel and enemy data loading.

---

## BattleView UserControl Added

- Created BattleView.xaml and BattleView.xaml.cs as a new UserControl.
  - Top TextBlock shows "Battle in Progress".
  - Center StackPanel with three Buttons: "Attack", "Defend", "Run".
  - Bottom TextBox (read-only, multi-line) bound to CombatLog.
  - Comments added for future character/enemy art.
  - All elements named and bound for later logic.
- Updated BattleViewModel to implement CombatLog property and commands for Attack, Defend, Run.

---

## BattleViewModel Refactored

- Refactored BattleViewModel in ViewModels folder:
  - Inherits from BaseViewModel.
  - Adds ObservableCollection<string> CombatLog.
  - Adds three RelayCommands: AttackCommand, DefendCommand, RunCommand.
  - Each command adds a new line to CombatLog describing the action, with random damage/block values.
  - Uses System.Random for simple randomization.
  - Includes TODO comments for future HP tracking and enemy AI logic.

---

## MainWindow MVVM Binding and DataTemplates (Fixed Namespaces)

- Set DataContext = new MainViewModel() in MainWindow.xaml.cs constructor.
- Added DataTemplates for MapViewModel and BattleViewModel in MainWindow.xaml Window.Resources using correct namespaces:
  - xmlns:vm="clr-namespace:MiniRPG.ViewModels"
  - xmlns:v="clr-namespace:MiniRPG"
  - <DataTemplate DataType="{x:Type vm:MapViewModel}"><v:MapView /></DataTemplate>
  - <DataTemplate DataType="{x:Type vm:BattleViewModel}"><v:BattleView /></DataTemplate>
- Bound ContentControl to CurrentViewModel for view switching.
- Added comments for future fade transitions between views.

This line is kept as requested.
