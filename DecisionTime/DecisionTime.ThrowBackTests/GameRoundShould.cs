using System;
using Xunit;
using DecisionTime.Core;
using DecisionTime.ThrowBack;
using Shouldly;

namespace DecisionTime.ThrowBackTests
{
    public class GameRoundShould
    {
        private Round _round;

        private void SetupNormalRound()
        {
            var player = "Cassandra";
            var difficulty = "Normal";

            _round = new Round(player, difficulty);
        }

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
            SetupNormalRound();

            _round.Game.Difficulty.ShouldBe(GameLevel.Normal);
        }

        [Fact]
        public void IncrementTurnNumberWhenEndTurnIsCalled()
        {
            SetupNormalRound();

            _round.EndTurn();

            _round.Turn.ShouldBe(2);
        }
    }
}
