using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.Core
{
    public class Status
    {
        public string Attitude { get; set; }

        public Status(string initialState = "Default")
        {
            if (initialState == "Positive")
            {
                Attitude = "Favorable";
            }
            else if (initialState == "Negative")
            {
                Attitude = "Unfavorable";
            }
            else
            {
                Attitude = "Indifferent";
            }
        }
    }
}
