using Xunit;
using Shouldly;
using DecisionTime.Core;
using DecisionTime.Core.GameObjects;
using DecisionTime.Core.Constants;
using NSubstitute;

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

        private Decision CreateDecisionWithSelectedOption(double decisionValue, string decisiondescription,
            string optionDescription, OptionTypes optionType)
        {
            var goodDecision = new Decision(decisionValue, decisiondescription);
            var option = new DecisionOption(optionDescription, optionType);
            option.IsSelected = true;
            goodDecision.AddOptions(option);
            goodDecision.IsResolved = true;
            return goodDecision;
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
            var goodDecision = CreateDecisionWithSelectedOption(1, "Taco Tuesday", "Yes", OptionTypes.Good);

            _citizen.ReactTo(goodDecision);

            _citizen.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }
        
        [Fact]
        public void UpdateAttitudeWithTwoLowValueDecisions()
        {
            CreateIndifferentCitizenNamedBob();
            var goodDecisionOne = CreateDecisionWithSelectedOption(.5, "Taco Tuesday", "Yes", OptionTypes.Good);
            var goodDecisionTwo = CreateDecisionWithSelectedOption(.5, "Taco Wednesday", "Yes", OptionTypes.Good);
            
            _citizen.ReactTo(goodDecisionOne);
            _citizen.ReactTo(goodDecisionTwo);

            _citizen.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }

        [Fact]
        public void SubscribeToObservable()
        {
            CreateIndifferentCitizenNamedBob();
            var observable = Substitute.For<IObservable>();

            _citizen.Register(observable);

            observable.Received().Subscribe(_citizen);
            _citizen.Councillor.ShouldBe(observable);
        }

        [Fact]
        public void UpdateLeaderFeelsWhenNotifyIsCalled()
        {
            CreateIndifferentCitizenNamedBob();
            var decision = CreateDecisionWithSelectedOption(1, "Do the thing?", "Yes", OptionTypes.Good);

            _citizen.Notify(decision);

            _citizen.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }
    }
}
