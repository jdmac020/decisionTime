﻿using System.Collections.Generic;

namespace DecisionTime.Core
{
    public class District
    {
        public List<Citizen> Citizens { get; set; }

        public District()
        {
            Citizens = new List<Citizen>();
        }

        public void AddCitizen(Citizen newCitizen)
        {
            Citizens.Add(newCitizen);
        }
    }
}