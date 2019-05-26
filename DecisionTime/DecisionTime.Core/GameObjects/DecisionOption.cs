namespace DecisionTime.Core.Other
{
    public class DecisionOption
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
        public OptionTypes OptionType { get; set; }

        public DecisionOption(string description, OptionTypes type)
        {
            Description = description;
            OptionType = type;
        }

        public void Select()
        {
            IsSelected = true;
        }
    }
}
