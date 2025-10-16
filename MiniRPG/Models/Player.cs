using MiniRPG.ViewModels;

namespace MiniRPG.Models
{
    /// <summary>
    /// Represents the player character.
    /// </summary>
    public class Player : BaseViewModel
    {
        public string Name { get; set; }

        private int _hp;
        public int HP
        {
            get => _hp;
            set { _hp = value; OnPropertyChanged(); }
        }

        private int _maxHP;
        public int MaxHP
        {
            get => _maxHP;
            set { _maxHP = value; OnPropertyChanged(); }
        }

        public int Attack { get; set; }
        public int Defense { get; set; }

        public Player(string name = "Hero")
        {
            Name = name;
            MaxHP = 30;
            HP = MaxHP;
            Attack = 5;
            Defense = 2;
            // TODO: Future - include inventory, experience, and leveling system
        }
    }
}
