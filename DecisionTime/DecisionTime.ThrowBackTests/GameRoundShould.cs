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
        
        [Fact]
        public void PresentOnlyDecisionsThatHaveNotBeenResolved()
        {
            SetupNormalRound();
            var resolvedDecision = new Decision(.5, "Release the kraken?");
            resolvedDecision.IsResolved = true;
            var unresolvedDecision = new Decision(.5, "Do you have a very particular set of skills?");
            var decisions = new List<Decision>
            {
                resolvedDecision,
                unresolvedDecision
            };
            _round.LoadDecisions(decisions);

            var result = _round.PresentDecision();

            result.ShouldBe(unresolvedDecision);

        }

        [Fact]
        public void PresentNullWhenAllDecisionResolved()
        {
            SetupNormalRound();
            var resolvedDecision = new Decision(.5, "Release the kraken?");
            resolvedDecision.IsResolved = true;
            var decisions = new List<Decision>
            {
                resolvedDecision
            };
            _round.LoadDecisions(decisions);

            var result = _round.PresentDecision();

            result.ShouldBeNull();
        }

        // Resolve decision
        [Fact]
        public void ResolveTheDecisionWhenSelectionIsMade()
        {
            SetupNormalRound();
            var decision = new Decision(.5, "Release the kraken?");
            decision.AddOptions(new Core.Other.DecisionOption("Hecks Naw", Core.Other.OptionTypes.Bad));
            var decisions = new List<Decision>
            {
                decision
            };
            _round.LoadDecisions(decisions);

            _round.ResolveDecision(decision, 1);

            _round.Decisions.Find(dec => dec.Description.Equals(decision.Description))
                .IsResolved.ShouldBeTrue();
        }
    }
}
