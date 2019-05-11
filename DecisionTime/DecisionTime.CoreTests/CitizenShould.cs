using Xunit;
using Shouldly;
using DecisionTime.Core;

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
    }
}
