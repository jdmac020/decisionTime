using System;
using Xunit;
using DecisionTime.Core;
using DecisionTime.ThrowBack;
using Shouldly;

namespace DecisionTime.ThrowBackTests
{
    public class GameRoundShould
    {
        [Fact]
        public void HavePlayerNameAndDifficulty()
        {
            var player = "Cassandra";
            var difficulty = "Normal";

            var round = new Round(player, difficulty);

            round.PlayerName.ShouldBe(player);
            round.Difficulty.ShouldBe(GameLevel.Normal);
        }
    }
}
