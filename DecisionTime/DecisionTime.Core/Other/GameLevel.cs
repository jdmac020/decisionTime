using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.Core
{
    public enum GameLevel
    {
        Easy,
        Normal
    }

    public static class GameLevelHelper
    {
        public static GameLevel GetGameLevel(string level)
        {
            switch (level.ToLower())
            {
                case "easy":
                    return GameLevel.Easy;
                case "normal":
                    return GameLevel.Normal;
                default:
                    throw new ArgumentException($"{level} is not a valid GameLevel!");
            }
        }
    }

    
}
