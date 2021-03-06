using DecisionTime.Core;
using DecisionTime.Core.Constants;
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

            game.Districts.Count.ShouldNotBe(0);
        }

        [Fact]
        public void CreateIndifferentDistrictOnNormalDifficulty()
        {
            var game = new Game();

            game.Districts.First().CurrentAttitude.ShouldBe(Attitude.Indifferent);
        }

        [Fact]
        public void CreateFavorableDistrictInEasyMode()
        {
            var game = new Game(GameLevel.Easy);

            game.Districts.First().CurrentAttitude.ShouldBe(Attitude.Favorable);
        }
    }
}
