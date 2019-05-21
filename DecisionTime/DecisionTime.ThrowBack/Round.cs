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

        public Round(string playerName, string level)
        {
            PlayerName = playerName;
            var difficulty = GameLevelHelper.GetGameLevel(level);
            Game = new Game(difficulty);
        }
    }
}
