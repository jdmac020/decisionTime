﻿using Xunit;
using Shouldly;
using DecisionTime.Core;

namespace DecisionTime.CoreTests
{
    public class CitizenShould
    {
        [Fact]
        public void HaveName()
        {
            var testName = "Bob";
            var citizen = new Citizen(testName);

            citizen.Name.ShouldBe(testName);
        }
    }
}