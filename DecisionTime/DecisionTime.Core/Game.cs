using System;

namespace DecisionTime.Core
{
    public class Game
    {
        public Player Player { get; set; }

        public Game()
        {
            Player = new Player();
        }
    }
}
