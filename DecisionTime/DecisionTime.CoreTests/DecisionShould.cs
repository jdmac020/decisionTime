using DecisionTime.Core.GameObjects;
using DecisionTime.Core.Other;
using Shouldly;
using Xunit;

namespace DecisionTime.CoreTests
{
    public class DecisionShould
    {
        [Fact]
        public void BeCreatedWithValue()
        {
            var testValue = .5;
            var decision = new Decision(testValue);

            decision.Value.ShouldBe(testValue);
        }

        [Fact]
        public void HaveOptionsAddedToIt()
        {
            var testValue = .5;
            var decision = new Decision(testValue);

            decision.AddOptions(new DecisionOption());

            decision.Options.Count.ShouldBe(1);
        }
    }
}
