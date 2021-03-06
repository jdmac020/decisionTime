﻿using Xunit;
using Shouldly;
using DecisionTime.Core;
using System.Collections.Generic;
using DecisionTime.Core.Constants;

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

            district.CurrentAttitude.ShouldBe(Attitude.Indifferent);
        }

        [Fact]
        public void UpdateAttitudeBasedOnOneCitizen()
        {
            var district = new District();
            var citizen = new Citizen("Bob");
            citizen.UpdateAttitude(Attitude.Favorable);
            district.Citizens = new List<Citizen>
            {
                citizen
            };

            district.CurrentAttitude.ShouldBe(Attitude.Favorable);
        }

        private Citizen CreateCitizen(string name, Attitude initialAttitude = Attitude.Indifferent)
        {
            if (initialAttitude == Attitude.Indifferent)
            {
                return new Citizen(name);
            }
            else
            {
                var citizen = new Citizen(name);
                citizen.UpdateAttitude(initialAttitude);
                return citizen;
            }
        }

        [Fact]
        public void UpdateAttitudeBasedOnThreeCitizensClearWinner()
        {
            var district = new District();
            district.AddCitizen(CreateCitizen("Bob"));
            district.AddCitizen(CreateCitizen("Jane", Attitude.Unfavorable));
            district.AddCitizen(CreateCitizen("Terry", Attitude.Unfavorable));
            
            district.CurrentAttitude.ShouldBe(Attitude.Unfavorable);
        }

        [Fact]
        public void UpdateAttitudeBasedOnThreeCitizensNoWinner()
        {
            var district = new District();
            district.AddCitizen(CreateCitizen("Bob"));
            district.AddCitizen(CreateCitizen("Jane", Attitude.Unfavorable));
            district.AddCitizen(CreateCitizen("Terry", Attitude.Favorable));
            
            district.CurrentAttitude.ShouldBe(Attitude.Indifferent);
        }

        [Fact]
        public void UpdateAttitudeToIndifferentWhenNoMajority()
        {
            var district = new District();
            district.AddCitizen(CreateCitizen("Bob"));
            district.AddCitizen(CreateCitizen("Jane", Attitude.Unfavorable));
            district.AddCitizen(CreateCitizen("Terry", Attitude.Favorable));
            
            district.CurrentAttitude.ShouldBe(Attitude.Indifferent);

        }
    }
}
