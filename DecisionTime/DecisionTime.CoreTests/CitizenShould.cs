using Xunit;
using Shouldly;
using DecisionTime.Core;
using DecisionTime.Core.GameObjects;
using DecisionTime.Core.Constants;

namespace DecisionTime.CoreTests
{
    public class CitizenShould
    {
        [Fact]
        public void HaveName()
        {
            var testName = "Bob";
            var citizen = new Citizen(testName);

            citizen.Name.ShouldBe(testName);
        }

        [Fact]
        public void StartWithIndifferentAttitude()
        {
            var testName = "Bob";
            var citizen = new Citizen(testName);

            citizen.CurrentAttitude.ShouldBe(Attitude.Indifferent);
        }

        [Fact]
        public void BeAbleToCreatedWithSpecifiedAttitude()
        {
            var testName = "Bob";
            var desiredAttitude = Attitude.Favorable;
            var citizen = new Citizen(testName, desiredAttitude);
            
            citizen.CurrentAttitude.ShouldBe(desiredAttitude);
        }

        [Fact]
        public void UpdateAttitude()
        {
            var testName = "Bob";
            var citizen = new Citizen(testName);

            citizen.UpdateAttitude(Attitude.Favorable);

            citizen.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }

        [Fact]
        public void UpdateAttitudeWithDecision()
        {
            var testName = "Bob";
            var citizen = new Citizen(testName);
            var goodDecision = new Decision(1, "Taco Tuesday");
            var option = new DecisionOption("Yes", OptionTypes.Good);
            option.IsSelected = true;
            goodDecision.AddOptions(option);
            goodDecision.IsResolved = true;

            citizen.UpdateAttitude(goodDecision);

            citizen.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }
    }
}
