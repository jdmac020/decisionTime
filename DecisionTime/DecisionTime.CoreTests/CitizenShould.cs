using Xunit;
using Shouldly;
using DecisionTime.Core;
using DecisionTime.Core.GameObjects;
using DecisionTime.Core.Constants;

namespace DecisionTime.CoreTests
{
    public class CitizenShould
    {
        private const string testNameBob = "Bob";
        private Citizen _citizen;

        private void CreateIndifferentCitizenNamedBob()
        {
            _citizen = new Citizen(testNameBob);
        }

        [Fact]
        public void HaveName()
        {
            CreateIndifferentCitizenNamedBob();

            _citizen.Name.ShouldBe(testNameBob);
        }

        [Fact]
        public void StartWithIndifferentAttitude()
        {
            CreateIndifferentCitizenNamedBob();

            _citizen.CurrentAttitude.ShouldBe(Attitude.Indifferent);
        }

        [Fact]
        public void BeAbleToCreatedWithSpecifiedAttitude()
        {
            var desiredAttitude = Attitude.Favorable;
            var citizen = new Citizen(testNameBob, desiredAttitude);
            
            citizen.CurrentAttitude.ShouldBe(desiredAttitude);
        }

        [Fact]
        public void UpdateAttitude()
        {
            CreateIndifferentCitizenNamedBob();

            _citizen.UpdateAttitude(Attitude.Favorable);

            _citizen.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }

        [Fact]
        public void UpdateAttitudeWithDecision()
        {
            CreateIndifferentCitizenNamedBob();
            var goodDecision = new Decision(1, "Taco Tuesday");
            var option = new DecisionOption("Yes", OptionTypes.Good);
            option.IsSelected = true;
            goodDecision.AddOptions(option);
            goodDecision.IsResolved = true;

            _citizen.UpdateAttitude(goodDecision);

            _citizen.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }

        [Fact (Skip = "Logic error")]
        public void UpdateAttitudeWithTwoLowValueDecisions()
        {
            CreateIndifferentCitizenNamedBob();
            var goodDecisionOne = new Decision(.5, "Taco Tuesday");
            var optionOne = new DecisionOption("Yes", OptionTypes.Good);
            optionOne.IsSelected = true;
            goodDecisionOne.AddOptions(optionOne);
            goodDecisionOne.IsResolved = true;
            var goodDecisionTwo = new Decision(.5, "Taco Wednesday");
            var optionTwo = new DecisionOption("Yes", OptionTypes.Good);
            optionTwo.IsSelected = true;
            goodDecisionTwo.AddOptions(optionTwo);
            goodDecisionTwo.IsResolved = true;

            _citizen.UpdateAttitude(goodDecisionOne);
            _citizen.UpdateAttitude(goodDecisionTwo);

            _citizen.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }
    }
}
