using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionTime.Core.Other
{
    public class DecisionOption
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }

        public DecisionOption(int id = -1, string description = "Run Away")
        {
            Id = id;
            Description = description;
        }

        public void Select()
        {
            IsSelected = true;
        }
    }
}
