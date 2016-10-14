using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeJam_Tests.FriendScoreTests
{
    [TestClass]
    public class FriendScoreTests
    {
        [TestMethod]
        public void Test_ForAValidInputWeMustReceiveAValidFriendScore()
        {
            var friends = File.ReadAllLines(@"FriendScoreInput.txt").ToList();
            int highestScore = CodeJam_Problems.FriendScore.FriendScore.HighestScore(friends);
            //As per the given input the actual value might change. If Input changes please the below value.
            Assert.AreEqual(highestScore, 6);
        }
    }
}
