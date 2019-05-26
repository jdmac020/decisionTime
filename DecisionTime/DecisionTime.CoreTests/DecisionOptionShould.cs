using DecisionTime.Core.Other;
using Shouldly;
using Xunit;

namespace DecisionTime.CoreTests
{
    public class DecisionOptionShould
    {
        [Fact]
        public void HaveDescriptionAndIdWhenCreated()
        {
            var description = "Banana Split";
            var id = 1;
            var option = new DecisionOption(id, description);

            option.Id.ShouldBe(id);
            option.Description.ShouldBe(description);
        }

        [Fact]
        public void UpdateSelectedStatus()
        {
            var option = new DecisionOption();

            option.Select();

            option.IsSelected.ShouldBeTrue();
        }
    }
}
