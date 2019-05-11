﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.Core
{
    public class Citizen
    {
        public string Name { get; set; }
        public Status CurrentStatus { get; set; }

        public Citizen(string name)
        {
            Name = name;
            CurrentStatus = new Status();
        }

        public Citizen(string name, Attitudes desiredAttitude) : this(name)
        {
            CurrentStatus.Attitude = desiredAttitude;
        }

        public void UpdateAttitude(Attitudes newAttitude)
        {
            CurrentStatus.Attitude = newAttitude;
        }
    }
}
