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
        
        [Fact]
        public void AddCitizen()
        {
            var district = new District();
            var testCitizen = new Citizen();

            district.AddCitizen(testCitizen);

            district.Citizens.Count.ShouldBe(1);
        }
    }
}
