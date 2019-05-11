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
            LoadAttitudeMap(map);

            var prevalentAttitude = GetPrevalentAttitude(map);

            if (prevalentAttitude.Value > Citizens.Count / 2)
            {
                CurrentStatus.Attitude = prevalentAttitude.Key;
            }
            else
            {
                CurrentStatus.Attitude = Attitudes.Indifferent;
            }
        }

        private void LoadAttitudeMap(Dictionary<Attitudes, int> map)
        {
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
        }

        private KeyValuePair<Attitudes,int> GetPrevalentAttitude(Dictionary<Attitudes, int> map)
        {
            var prevalentAttitude = map.First();

            foreach (var attitude in map)
            {
                if (attitude.Value > prevalentAttitude.Value)
                {
                    prevalentAttitude = attitude;
                }
            }

            return prevalentAttitude;
        }
    }
}
