using DecisionTime.Core;
using Shouldly;
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

            game.Districts.ShouldNotBeNull();
        }
    }
}
