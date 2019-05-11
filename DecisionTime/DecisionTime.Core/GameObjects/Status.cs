using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace DecisionTime.Core
{
    public class Status
    {
        public Attitudes Attitude { get; set; }

        public Status(Attitudes initialAttitude = Attitudes.Indifferent)
        {
            Attitude = initialAttitude;
        }
    }
}
