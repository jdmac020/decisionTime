using DecisionTime.Core.GameObjects;
using DecisionTime.Core.Constants;
using System.Collections.Generic;

namespace DecisionTime.ThrowBack
{
    public static class DecisionFactory
    {
        public static List<Decision> CreateDefaultDecisions()
        {
            var decision = new Decision(1, "The People Want to Meet You!");
            var optionOne = new DecisionOption("Why would I waste time with the commoners?", OptionTypes.Bad);
            var optionTwo = new DecisionOption("Of course! Let's go say hi.", OptionTypes.Good);
            decision.AddOptions(optionOne, optionTwo);

            return new List<Decision>
            {
                decision
            };
        }
    }
}
