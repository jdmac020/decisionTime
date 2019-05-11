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

            citizen.CurrentStatus.Attitude.ShouldBe(Attitudes.Indifferent);
        }

        [Fact]
        public void BeAbleToCreatedWithSpecifiedAttitude()
        {
            var testName = "Bob";
            var desiredAttitude = Attitudes.Favorable;
            var citizen = new Citizen(testName, desiredAttitude);
            
            citizen.CurrentStatus.Attitude.ShouldBe(desiredAttitude);
        }

        [Fact]
        public void UpdateAttitude()
        {
            var testName = "Bob";
            var citizen = new Citizen(testName);

            citizen.UpdateAttitude(Attitudes.Favorable);

            citizen.CurrentStatus.Attitude.ShouldBe(Attitudes.Favorable);
        }
    }
}
