using DecisionTime.Core.Constants;
using DecisionTime.Core.GameObjects;

namespace DecisionTime.Core
{
    public class Citizen : IObserver
    {
        public string Name { get; set; }
        public Attitude CurrentAttitude { get { return GetAttitude(); } }
        public IObservable Councilor { get; set; }

        private double _leaderFeels;

        public Citizen(string name)
        {
            Name = name;
            _leaderFeels = (int)Attitude.Indifferent;
        }

        public Citizen(string name, Attitude desiredAttitude) : this(name)
        {
            _leaderFeels = (int)desiredAttitude;
        }

        public void UpdateAttitude(Attitude newAttitude)
        {
            _leaderFeels = (int)newAttitude;
        }

        public void ReactTo(Decision decision)
        {
            var chosenOption = decision.GetChosenOption();
            
            _leaderFeels += (int)chosenOption.OptionType * decision.Value;
        }

        private Attitude GetAttitude()
        {
            if (_leaderFeels <= (int)Attitude.Unfavorable)
            {
                return Attitude.Unfavorable;
            }
            else if (_leaderFeels > (int)Attitude.Unfavorable && _leaderFeels < (int)Attitude.Favorable)
            {
                return Attitude.Indifferent;
            }
            else
            {
                return Attitude.Favorable;
            }
        }

        public void Register(IObservable subject)
        {
            subject.Subscribe(this);
            Councilor = subject;
        }

        public void Notify(object decision)
        {
            ReactTo((Decision)decision);
        }
    }
}
