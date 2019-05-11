using System;
using System.Collections.Generic;

namespace DecisionTime.Core
{
    public class Game
    {
        public Player Player { get; set; }
        public List<District> Districts { get; set; }
        public GameLevel Difficulty { get; }

        public Game(GameLevel difficulty = GameLevel.Normal)
        {
            Player = new Player();
            Districts = new List<District>();
            Difficulty = difficulty;
        }

        public void GenerateDistrict()
        {
            List<Citizen> citizens = null;

            switch (Difficulty)
            {
                case GameLevel.Easy:
                    citizens = GenerateFavorableCitizens();
                    break;
                case GameLevel.Normal:
                    citizens = GenerateIndifferentCitizens();
                    break;
                default:
                    break;
            }

            var newDistrict = new District
            {
                Citizens = citizens
            };

            Districts.Add(newDistrict);
        }

        private List<Citizen> GenerateFavorableCitizens()
        {
            return new List<Citizen>
            {
                new Citizen("Bob", Attitude.Favorable),
                new Citizen("Jane", Attitude.Favorable),
                new Citizen("Terry")
            };
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
