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
    }
}
