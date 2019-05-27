using DecisionTime.Core.Constants;
using DecisionTime.Core.GameObjects;
using Shouldly;
using Xunit;

namespace DecisionTime.CoreTests
{
    public class DecisionOptionShould
    {
        [Fact]
        public void HaveDescriptionAndTypeWhenCreated()
        {
            var description = "Banana Split";
            var type = OptionTypes.Good;
            var option = new DecisionOption(description, type);
            
            option.Description.ShouldBe(description);
            option.OptionType.ShouldBe(type);
        }

        [Fact]
        public void UpdateSelectedStatus()
        {
            var description = "Banana Split";
            var type = OptionTypes.Good;
            var option = new DecisionOption(description, type);

            option.Select();

            option.IsSelected.ShouldBeTrue();
        }
    }
}
