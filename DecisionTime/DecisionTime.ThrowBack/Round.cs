using DecisionTime.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.ThrowBack
{
    public class Round
    {
        public string PlayerName { get; set; }
        public GameLevel Difficulty { get; set; }

        public Round(string playerName, string level)
        {
            PlayerName = playerName;
            Difficulty = GameLevelHelper.GetGameLevel(level);
        }
    }
}
