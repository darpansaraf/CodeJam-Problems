using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeJam_Tests
{
    [TestClass]
    public class StandInLineTests
    {
        [TestMethod]
        public void Test_ForAValidInputWeShouldReceiveAListContainingHeightsOfSoldiers()
        {
            var left = new List<int> { 0, 0, 0, 0, 0 };
            var expectedOutput = new List<int> { 1, 2, 3, 4, 5 };
            var heightOfSoldiers = CodeJam_Problems.StandInLine.StandInLine.Reconstruct(left);
            for (int index = 0; index < expectedOutput.Count; index++)
            {
                Assert.IsTrue(expectedOutput[index] == heightOfSoldiers[index]);
            }
        }

        [TestMethod]
        public void Test_ForAnInvalidInputWeShouldReceiveNull()
        {
            var left = new List<int> { 6, 8, 1, 1, 2, 0, 0 };
            var heightOfSoldiers = CodeJam_Problems.StandInLine.StandInLine.Reconstruct(left);
            Assert.IsNull(heightOfSoldiers);
        }

    }
}
