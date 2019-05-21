using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.ThrowBack.Helpers
{
    public static class InputParsers
    {
        public static string IntToLevelName(string entry)
        {
            var difficulty = string.Empty;

            if (entry == "1")
            {
                difficulty = "Easy";
            }
            if (entry == "2")
            {
                difficulty = "normal";
            }

            return difficulty;
        }
    }
}
