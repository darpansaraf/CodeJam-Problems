using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeJam_Tests.DatingTests
{
    [TestClass]
    public class DatingTests
    {
        [TestMethod]
        public void Test_ForAValidInputWeShouldReceiveValidPairsOfDates()
        {
            var expectedOutput = "Hf Gg Fh";
            var inputString = "HGFhgfz";
            int startingPosition = 1;
            var pairs = CodeJam_Problems.Dating.Dating.Dates(inputString,startingPosition);
            Assert.AreEqual(expectedOutput, pairs);
        }
    }
}
