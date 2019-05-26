using System;
using Xunit;
using DecisionTime.Core;
using DecisionTime.ThrowBack;
using Shouldly;
using DecisionTime.Core.GameObjects;
using System.Collections.Generic;

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

        [Fact]
        public void LoadDecisions()
        {
            SetupNormalRound();
            var decisionList = new List<Decision>
            {
                new Decision(.5, string.Empty)
            };

            _round.LoadDecisions(decisionList);

            _round.Decisions.Count.ShouldBe(decisionList.Count);
        }
        
        [Fact]
        public void PresentDecision()
        {
            SetupNormalRound();
            var decision = new Decision(.5, "Release the kraken?");
            var decisionList = new List<Decision>
            {
                decision
            };
            _round.LoadDecisions(decisionList);

            var result = _round.PresentDecision();

            result.ShouldBe(decision);
        }

        // Present decisions that have not been asked

        // Resolve decision
    }
}
