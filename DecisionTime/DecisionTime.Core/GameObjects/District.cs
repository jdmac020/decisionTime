using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTime.Core
{
    public class District
    {
        public List<Citizen> Citizens { get; set; }
        public Status CurrentStatus { get; set; }

        public District()
        {
            Citizens = new List<Citizen>();
            CurrentStatus = new Status();
        }

        public void AddCitizen(Citizen newCitizen)
        {
            Citizens.Add(newCitizen);
        }

        public void UpdateAttitude()
        {
            var map = new Dictionary<Attitudes, int>();

            foreach (var citizen in Citizens)
            {
                var attitude = citizen.CurrentStatus.Attitude;
                if (map.ContainsKey(attitude))
                {
                    map[attitude] = map[attitude] + 1;
                }
                else
                {
                    map.Add(attitude, 1);
                }
            }

            var maxValue = map.First();

            foreach (var attitude in map)
            {
                if (attitude.Value > maxValue.Value)
                {
                    maxValue = attitude;
                }
            }

            if (maxValue.Value > Citizens.Count / 2)
            {
                CurrentStatus.Attitude = maxValue.Key;
            }
            else
            {
                CurrentStatus.Attitude = Attitudes.Indifferent;
            }

            //CurrentStatus.Attitude = maxValue.Key;

            //CurrentStatus.Attitude = map.Aggregate((first, next) => 
            //    first.Value > next.Value ? first : next
            //    ).Key;
        }
    }
}
