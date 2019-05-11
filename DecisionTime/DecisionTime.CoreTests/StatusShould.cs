using DecisionTime.Core;
using Shouldly;
using Xunit;

namespace DecisionTime.CoreTests
{
    public class StatusShould
    {
        [Fact]
        public void HaveIndifferentAttitudeWhenCreatedWithDefault()
        {
            var status = new Status();

            status.Attitude.ShouldBe("Indifferent");
        }

        [Fact]
        public void HaveFavorableAttitudeWhenCreatedWithPositive()
        {
            var status = new Status("Positive");

            status.Attitude.ShouldBe("Favorable");
        }

        [Fact]
        public void HaveUnfavorableAttitudeWhenCreatedNegative()
        {
            var status = new Status("Negative");

            status.Attitude.ShouldBe("Unfavorable");
        }
    }
}
