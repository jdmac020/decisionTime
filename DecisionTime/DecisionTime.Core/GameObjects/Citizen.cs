using System;
using DecisionTime.Core.Constants;
using DecisionTime.Core.GameObjects;

namespace DecisionTime.Core
{
    public class Citizen
    {
        public string Name { get; set; }
        public Attitude CurrentAttitude { get; set; }
        private double _leaderFeels;

        public Citizen(string name)
        {
            Name = name;
            CurrentAttitude = Attitude.Indifferent;
            _leaderFeels = (int)CurrentAttitude;
        }

        public Citizen(string name, Attitude desiredAttitude) : this(name)
        {
            CurrentAttitude = desiredAttitude;
        }

        public void UpdateAttitude(Attitude newAttitude)
        {
            CurrentAttitude = newAttitude;
        }

        public void UpdateAttitude(Decision decision)
        {
            var chosenOption = decision.GetChosenOption();
            
            _leaderFeels += (int)chosenOption.OptionType * decision.Value;

            if (_leaderFeels <= (int)Attitude.Unfavorable)
            {
                CurrentAttitude = Attitude.Unfavorable;
            }
            else if (_leaderFeels > (int)Attitude.Unfavorable && _leaderFeels < (int)Attitude.Favorable)
            {
                CurrentAttitude = Attitude.Indifferent;
            }
            else
            {
                CurrentAttitude = Attitude.Favorable;
            }
        }
    }
}
