namespace DecisionTime.Core
{
    public class Citizen
    {
        public string Name { get; set; }
        public Attitude CurrentAttitude { get; set; }

        public Citizen(string name)
        {
            Name = name;
            CurrentAttitude = Attitude.Indifferent;
        }

        public Citizen(string name, Attitude desiredAttitude) : this(name)
        {
            CurrentAttitude = desiredAttitude;
        }

        public void UpdateAttitude(Attitude newAttitude)
        {
            CurrentAttitude = newAttitude;
        }
    }
}
