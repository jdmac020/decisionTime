using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTime.Core
{
    public class District
    {
        public List<Citizen> Citizens { get; set; }
        public Attitude CurrentAttitude { get; set; }

        public District()
        {
            Citizens = new List<Citizen>();
            CurrentAttitude = Attitude.Indifferent;
        }

        public void AddCitizen(Citizen newCitizen)
        {
            Citizens.Add(newCitizen);
        }

        public void UpdateAttitude()
        {
            var map = new Dictionary<Attitude, int>();
            LoadAttitudeMap(map);

            var prevalentAttitude = GetPrevalentAttitude(map);

            SetDistrictAttitude(prevalentAttitude);
        }
        
        private void LoadAttitudeMap(Dictionary<Attitude, int> map)
        {
            foreach (var citizen in Citizens)
            {
                var attitude = citizen.CurrentAttitude;
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

        private KeyValuePair<Attitude,int> GetPrevalentAttitude(Dictionary<Attitude, int> map)
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

        private void SetDistrictAttitude(KeyValuePair<Attitude, int> prevalentAttitude)
        {
            if (prevalentAttitude.Value > Citizens.Count / 2)
            {
                CurrentAttitude = prevalentAttitude.Key;
            }
            else
            {
                CurrentAttitude = Attitude.Indifferent;
            }
        }
    }
}
