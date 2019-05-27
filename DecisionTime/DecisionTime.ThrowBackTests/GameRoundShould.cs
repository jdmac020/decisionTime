using Xunit;
using DecisionTime.ThrowBack;
using Shouldly;
using DecisionTime.Core.GameObjects;
using System.Collections.Generic;
using DecisionTime.Core.Constants;
using NSubstitute;

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

        [Fact]
        public void UpdateFarewellTitle()
        {
            SetupNormalRound();
            var title = "Brave";

            _round.UpdateTitle(title);

            _round.Title.ShouldBe("Brave");
        }

        [Fact]
        public void SwitchEndGameFlagWhenNoMoreDecisions()
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
            _round.GameOver.ShouldBeTrue();
        }

        [Fact]
        public void ResolveDecisions()
        {
            SetupNormalRound();
            var decision = new Decision(1, "Boo");
            var option = new DecisionOption("Dude", OptionTypes.Neutral);
            decision.AddOptions(option);
            var decisions = new List<Decision>
            {
                decision
            };
            _round.LoadDecisions(decisions);

            _round.ResolveDecision(decision, 1);

            _round.Decisions[0].IsResolved.ShouldBeTrue();
            _round.Decisions[0].GetChosenOption().Description.ShouldBe("Dude");
        }

        [Fact]
        public void AddSubscribers()
        {
            SetupNormalRound();
            var subscriber = Substitute.For<IObserver>();

            _round.Subscribe(subscriber);

            _round.Subscribers.Count.ShouldBe(1);
        }

        [Fact]
        public void UpdateSubscribersWhenDecisionIsResolved()
        {
            SetupNormalRound();
            var subscriber = Substitute.For<IObserver>();
            _round.Subscribe(subscriber);
            var decision = new Decision(1, "Boo");
            var option = new DecisionOption("Dude", OptionTypes.Neutral);
            decision.AddOptions(option);
            var optionSelection = 1;

            _round.ResolveDecision(decision, optionSelection);

            subscriber.Received().Notify(decision);
        }
    }
}
