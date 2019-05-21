using DecisionTime.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.ThrowBack.Helpers
{
    public static class DialogueHelper
    {
        public static string WelcomeDialogueHelper(string playerName, GameLevel level)
        {
            var response = $"Very well, Councilor {playerName}; ";

            if (level == GameLevel.Easy)
            {
                response += "we shall take it easy on you.";
            }
            else
            {
                response += "we shall treat you as one of us.";
            }

            return response;
        }
    }
}
