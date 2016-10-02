using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeJam_Tests
{
    [TestClass]
    public class SantaDaDhabaTests
    {
        [TestMethod]
        public void Test_ForAValidInputBantaShouldBeAbleToEatForAValidMaximumNumberOfDays()
        {
            var prices = new List<string>{ "26", "14", "72", "39", "32", "85", "06" };
            int budget = 13;
            var maxNumberOfDaysBantaAte = CodeJam_Problems.SantaDaDhaba.SantaDaDhaba.MaxDays(prices,budget);
            Assert.IsTrue(maxNumberOfDaysBantaAte == 5);
        }
    }
}
