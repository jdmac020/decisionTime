using DecisionTime.Core.Other;
using System.Collections.Generic;

namespace DecisionTime.Core.GameObjects
{
    public class Decision
    {
        public double Value;
        public List<DecisionOption> Options { get; set; }

        public Decision(double value)
        {
            Value = value;
            Options = new List<DecisionOption>();
        }
        
        public void AddOptions(params DecisionOption[] decisionOptions)
        {
            for (var i = 0; i < decisionOptions.Length; i++)
            {
                var option = decisionOptions[i];
                option.Id = i + 1;
                Options.Add(option);
            }
        }
    }
}
