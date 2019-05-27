using System.Collections.Generic;

namespace DecisionTime.Core.GameObjects
{
    public class Decision
    {
        public double Value;
        public List<DecisionOption> Options { get; set; }
        public string Description { get; set; }
        public bool IsResolved { get; set; }

        public Decision(double value, string description)
        {
            Value = value;
            Description = description;
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

        public void Resolve(int optionId)
        {
            var selectedOption = Options.Find(opt => opt.Id.Equals(optionId));
            selectedOption.IsSelected = true;
            IsResolved = true;
        }

        public DecisionOption GetChosenOption()
        {
            return Options.Find(opt => opt.IsSelected);
        }
    }
}
