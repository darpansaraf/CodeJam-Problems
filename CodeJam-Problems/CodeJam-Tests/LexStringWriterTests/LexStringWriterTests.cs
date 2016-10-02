using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeJam_Tests
{
    [TestClass]
    public class LexStringWriterTests
    {
        [TestMethod]
        public void Test_ForAValidInputLexStringWriterShouldReturnCorrectNumberOfMinimumMoves()
        {
            var sampleInput = "earth";
            var minimumNumberOfMoves = CodeJam_Problems.LexStringWriter.LexStringWriter.GetMinimumMoves(sampleInput);
            Assert.IsTrue(5 == minimumNumberOfMoves);
        }

        [TestMethod]
        public void Test_ForAnInvalidInputLexStringWriterShouldReturnADefaultInvalidValue()
        {
            var sampleInput = "earth$";
            var minimumNumberOfMoves = CodeJam_Problems.LexStringWriter.LexStringWriter.GetMinimumMoves(sampleInput);
            Assert.IsTrue(-1 == minimumNumberOfMoves);
        }
    }
}
