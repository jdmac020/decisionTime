using System.Collections.Generic;

namespace DecisionTime.Core
{
    public class Game
    {
        public Player Player { get; set; }
        public List<District> Districts { get; set; }

        public Game()
        {
            Player = new Player();
            Districts = new List<District>();
        }
    }
}
