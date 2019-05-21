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
            GenerateDistrict();
        }

        private void GenerateDistrict()
        {

            var newDistrict = new District
            {
                Citizens = GenerateCitizens()
            };

            Districts.Add(newDistrict);
        }

        private List<Citizen> GenerateCitizens()
        {
            Attitude districtAttitude = Attitude.Indifferent;

            switch (Difficulty)
            {
                case GameLevel.Easy:
                    districtAttitude = Attitude.Favorable;
                    break;
                default:
                    break;
            }

            return new List<Citizen>
            {
                new Citizen("Bob", districtAttitude),
                new Citizen("Jane", districtAttitude),
                new Citizen("Terry", districtAttitude)
            };
        }
    }
}
