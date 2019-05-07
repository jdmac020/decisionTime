using Xunit;
using Shouldly;
using DecisionTime.Core;
using System.Collections.Generic;

namespace DecisionTime.CoreTests
{
    public class DistrictShould
    {
        [Fact]
        public void HaveListOfCitizens()
        {
            var district = new District();

            district.Citizens.ShouldBeOfType<List<Citizen>>();
        }
    }
}
