using DecisionTime.Core;
using Shouldly;
using System.Collections.Generic;
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

            game.GenerateDistricts();

            game.Districts.Count.ShouldNotBe(0);
        }
    }
}
