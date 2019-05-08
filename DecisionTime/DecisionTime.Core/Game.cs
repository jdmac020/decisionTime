using System;
using System.Collections.Generic;

namespace DecisionTime.Core
{
    public class Game
    {
        public Player Player { get; set; }
        public List<District> Districts { get; set; }

        public Game()
        {
            Player = new Player();
            Districts = new List<District>();
        }

        public void GenerateDistricts()
        {
            var newDistrict = new District
            {
                Citizens = new List<Citizen>
                {
                    new Citizen("Bob"),
                    new Citizen("Jane")
                }
            };

            Districts.Add(newDistrict);
        }
    }
}
