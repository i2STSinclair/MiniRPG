namespace MiniRPG.Models
{
    /// <summary>
    /// Represents the player character.
    /// </summary>
    public class Player
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
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
