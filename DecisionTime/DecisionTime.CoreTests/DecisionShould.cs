using DecisionTime.Core.GameObjects;
using DecisionTime.Core.Other;
using Shouldly;
using Xunit;

namespace DecisionTime.CoreTests
{
    public class DecisionShould
    {
        private DecisionOption CreateDefaultOption()
        {
            return new DecisionOption("Banana Split", OptionTypes.Bad);
        }

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

            decision.AddOptions(CreateDefaultOption());

            decision.Options.Count.ShouldBe(1);
        }

        [Fact]
        public void HaveMultipleOptionsAddedToIt()
        {
            var testValue = .5;
            var decision = new Decision(testValue);
            var optionOne = CreateDefaultOption();
            var optionTwo = CreateDefaultOption();

            decision.AddOptions(optionOne, optionTwo);
            
            decision.Options.Count.ShouldBe(2);
        }

        [Fact]
        public void HaveMultipleOptionsWithUniqueIds()
        {
            var testValue = .5;
            var decision = new Decision(testValue);
            var optionOne = CreateDefaultOption();
            var optionTwo = CreateDefaultOption();

            decision.AddOptions(optionOne, optionTwo);

            var idOne = decision.Options[0].Id;
            var idTwo = decision.Options[1].Id;

            idOne.ShouldNotBe(idTwo);
        }

        [Fact (Skip = "Need to test DecisionOption first")]
        public void UpdateOptionWhenSelected()
        {

        }
    }
}
