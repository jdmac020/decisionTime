using DecisionTime.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.ThrowBack
{
    public class Round
    {
        public string PlayerName { get; set; }
        public Game Game { get; set; }
        public int Turn { get; set; } = 1;

        public Round(string playerName, string level)
        {
            PlayerName = playerName;
            var difficulty = GameLevelHelper.GetGameLevel(level);
            Game = new Game(difficulty);
        }

        public void EndTurn()
        {
            // Do end of turn calcs
            Turn++;
        }
    }
}
