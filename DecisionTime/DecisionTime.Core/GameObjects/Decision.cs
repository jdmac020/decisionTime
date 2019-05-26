using DecisionTime.Core.Other;
using System;
using System.Collections.Generic;
using System.Text;

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
        
        public void AddOptions(DecisionOption decisionOption)
        {
            Options.Add(decisionOption);
        }
    }
}
