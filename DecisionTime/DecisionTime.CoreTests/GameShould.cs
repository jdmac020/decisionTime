using DecisionTime.Core;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DecisionTime.CoreTests
{
    public class GameShould
    {
        [Fact]
        public void HavePlayer()
        {
            var game = new Game();

            game.Player.ShouldBeOfType<Player>();
        }

        [Fact]
        public void HaveDistrictList()
        {
            var game = new Game();

            game.Districts.ShouldBeOfType<List<District>>();
        }

        [Fact]
        public void PopulateDistricts()
        {
            var game = new Game();

            game.GenerateDistrict();

            game.Districts.Count.ShouldNotBe(0);
        }

        [Fact]
        public void CreateIndifferentDistrictOnNormalDifficulty()
        {
            var game = new Game();

            game.GenerateDistrict();

            game.Districts.First().CurrentStatus.Attitude.ShouldBe(Attitudes.Indifferent);
        }

        [Fact(Skip = "Skipped a test")]
        public void CreateFavorableDistrictInEasyMode()
        {
            var game = new Game(GameLevel.Easy);

            game.GenerateDistrict();

            game.Districts.First().CurrentStatus.Attitude.ShouldBe(Attitudes.Favorable);
        }
    }
}
