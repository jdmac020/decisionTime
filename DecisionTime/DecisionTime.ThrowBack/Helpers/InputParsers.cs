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

        public static int ParseInt(string entryString)
        {
            var isParsed = false;
            var returnInt = 0;

            isParsed = int.TryParse(entryString, out returnInt);

            while (isParsed.Equals(false))
            {
                Console.Write("Sorry, that wasn't a number. Try again? ");
                entryString = Console.ReadLine();
                isParsed = int.TryParse(entryString, out returnInt);
            }

            return returnInt;
        }
    }
}
