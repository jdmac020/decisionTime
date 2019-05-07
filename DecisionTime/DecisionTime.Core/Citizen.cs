using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.Core
{
    public class Citizen
    {
        public object Name { get; set; }

        public Citizen(string name)
        {
            Name = name;
        }
    }
}
