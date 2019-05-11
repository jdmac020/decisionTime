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

            CurrentStatus.Attitude = map.Aggregate((first, next) => 
                first.Value > next.Value ? first : next
                ).Key;
        }
    }
}
