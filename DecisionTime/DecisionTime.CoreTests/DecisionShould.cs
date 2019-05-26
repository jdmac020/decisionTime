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
        public void HaveAnOptionAddedToIt()
        {
            var testValue = .5;
            var decision = new Decision(testValue);

            decision.AddOptions(new DecisionOption());

            decision.Options.Count.ShouldBe(1);
        }

        [Fact]
        public void HaveMultipleOptionsAddedToIt()
        {
            var testValue = .5;
            var decision = new Decision(testValue);
            var optionOne = new DecisionOption();
            var optionTwo = new DecisionOption();

            decision.AddOptions(optionOne, optionTwo);

            decision.Options.Count.ShouldBe(2);
        }
    }
}
