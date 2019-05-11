using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTime.Core
{
    public class District
    {
        public List<Citizen> Citizens { get; set; }
        public Status Status { get; set; }

        public District()
        {
            Citizens = new List<Citizen>();
            Status = new Status();
        }

        public void AddCitizen(Citizen newCitizen)
        {
            Citizens.Add(newCitizen);
        }

        public void UpdateAttitude()
        {
            Status.Attitude = Citizens.First().CurrentStatus.Attitude;
        }
    }
}
