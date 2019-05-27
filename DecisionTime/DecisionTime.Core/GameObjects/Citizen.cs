using System;
using DecisionTime.Core.Constants;
using DecisionTime.Core.GameObjects;

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

        public void UpdateAttitude(Decision decision)
        {
            var chosenOption = decision.GetChosenOption();

            double feeling = (int)CurrentAttitude;
            feeling += (int)chosenOption.OptionType * decision.Value;

            if (feeling <= (int)Attitude.Unfavorable)
            {
                CurrentAttitude = Attitude.Unfavorable;
            }
            else if (feeling > (int)Attitude.Unfavorable && feeling < (int)Attitude.Favorable)
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
