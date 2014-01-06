using System;

namespace _04_Minesweeper
{
    struct PlayerResult
    {
        public string Name { get; set; }
 
        public int Points { get; set; }
 
        public PlayerResult(string name, int points)
            : this()
        {
            this.Name = name;
            this.Points = points;
        }
    }
}
