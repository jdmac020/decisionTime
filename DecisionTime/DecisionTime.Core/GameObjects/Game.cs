using System;
using System.Collections.Generic;

namespace DecisionTime.Core
{
    public class Game
    {
        public Player Player { get; set; }
        public List<District> Districts { get; set; }

        public Game(GameLevel difficulty = GameLevel.Normal)
        {
            Player = new Player();
            Districts = new List<District>();
        }

        public void GenerateDistrict()
        {
            var newDistrict = new District
            {
                Citizens = GenerateIndifferentCitizens()
            };

            Districts.Add(newDistrict);
        }

        private List<Citizen> GenerateIndifferentCitizens()
        {
            return new List<Citizen>
            {
                new Citizen("Bob"),
                new Citizen("Jane"),
                new Citizen("Terry")
            };
        }
    }
}
