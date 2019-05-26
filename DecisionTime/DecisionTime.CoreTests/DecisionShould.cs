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

        private Decision CreateDefaultDecision()
        {
            var testValue = .5;
            return new Decision(testValue, string.Empty);
        }

        [Fact]
        public void BeCreatedWithValueAndDescription()
        {
            var testValue = .5;
            var testDescription = "What ice cream?";
            var decision = new Decision(testValue, testDescription);

            decision.Value.ShouldBe(testValue);
            decision.Description.ShouldBe(testDescription);
        }

        [Fact]
        public void HaveAnOptionAddedToIt()
        {
            var decision = CreateDefaultDecision();

            decision.AddOptions(CreateDefaultOption());

            decision.Options.Count.ShouldBe(1);
        }

        [Fact]
        public void HaveMultipleOptionsAddedToIt()
        {
            var decision = CreateDefaultDecision();
            var optionOne = CreateDefaultOption();
            var optionTwo = CreateDefaultOption();

            decision.AddOptions(optionOne, optionTwo);
            
            decision.Options.Count.ShouldBe(2);
        }

        [Fact]
        public void HaveMultipleOptionsWithUniqueIds()
        {
            var decision = CreateDefaultDecision();
            var optionOne = CreateDefaultOption();
            var optionTwo = CreateDefaultOption();

            decision.AddOptions(optionOne, optionTwo);

            var idOne = decision.Options[0].Id;
            var idTwo = decision.Options[1].Id;
            idOne.ShouldNotBe(idTwo);
        }
    }
}
