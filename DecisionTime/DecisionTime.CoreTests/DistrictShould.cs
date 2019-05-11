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
            var testCitizen = new Citizen("Bob");

            district.AddCitizen(testCitizen);

            district.Citizens.Count.ShouldBe(1);
        }

        [Fact]
        public void StartWithIndifferentAttitude()
        {
            var district = new District();

            district.CurrentStatus.Attitude.ShouldBe(Attitudes.Indifferent);
        }

        [Fact]
        public void UpdateAttitudeBasedOnOneCitizen()
        {
            var district = new District();
            var citizen = new Citizen("Bob");
            citizen.CurrentStatus.Attitude = Attitudes.Favorable;
            district.Citizens = new List<Citizen>
            {
                citizen
            };

            district.UpdateAttitude();

            district.CurrentStatus.Attitude.ShouldBe(Attitudes.Favorable);
        }

        private Citizen CreateCitizen(string name, Attitudes initialAttitude = Attitudes.Indifferent)
        {
            if (initialAttitude == Attitudes.Indifferent)
            {
                return new Citizen(name);
            }
            else
            {
                var citizen = new Citizen(name);
                citizen.CurrentStatus.Attitude = initialAttitude;
                return citizen;
            }
        }

        [Fact]
        public void UpdateAttitudeBasedOnThreeCitizensClearWinner()
        {
            var district = new District();
            district.AddCitizen(CreateCitizen("Bob"));
            district.AddCitizen(CreateCitizen("Jane", Attitudes.Unfavorable));
            district.AddCitizen(CreateCitizen("Terry", Attitudes.Unfavorable));

            district.UpdateAttitude();

            district.CurrentStatus.Attitude.ShouldBe(Attitudes.Unfavorable);
        }

        [Fact]
        public void UpdateAttitudeBasedOnThreeCitizensNoWinner()
        {
            var district = new District();
            district.AddCitizen(CreateCitizen("Bob"));
            district.AddCitizen(CreateCitizen("Jane", Attitudes.Unfavorable));
            district.AddCitizen(CreateCitizen("Terry", Attitudes.Favorable));

            district.UpdateAttitude();

            district.CurrentStatus.Attitude.ShouldBe(Attitudes.Indifferent);
        }
    }
}
