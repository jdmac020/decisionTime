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

            status.Attitude.ShouldBe(Attitudes.Indifferent);
        }

        [Fact]
        public void HaveFavorableAttitudeWhenCreatedWithPositive()
        {
            var status = new Status(Attitudes.Favorable);

            status.Attitude.ShouldBe(Attitudes.Favorable);
        }

        [Fact]
        public void HaveUnfavorableAttitudeWhenCreatedNegative()
        {
            var status = new Status(Attitudes.Unfavorable);

            status.Attitude.ShouldBe(Attitudes.Unfavorable);
        }
    }
}
