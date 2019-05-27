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
    }
}
