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
        public void HavePlayerName()
        {
            var player = "Cassandra";
            var difficulty = "Normal";

            var round = new Round(player, difficulty);

            round.PlayerName.ShouldBe(player);
        }

        [Fact]
        public void HaveGameObject()
        {
            var player = "Cassandra";
            var difficulty = "normal";

            var round = new Round(player, difficulty);

            round.Game.Difficulty.ShouldBe(GameLevel.Normal);
        }

        [Fact]
        public void IncrementTurnNumberWhenEndTurnIsCalled()
        {
            var player = "Cassandra";
            var difficulty = "normal";
            var round = new Round(player, difficulty);

            round.EndTurn();

            round.Turn.ShouldBe(2);
        }
    }
}
