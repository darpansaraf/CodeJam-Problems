using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeJam_Problems.Anagrams;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeJam_Tests.AnagramsTests
{
    [TestClass]
    public class AnagramsTests
    {
        [TestMethod]
        public void Test_ForAValidSetOfStringsWeShouldGetAMaximumValidSetOfAnagramFreeStrings()
        {
            var inputString = "creation,sentence,reaction,sneak,star,rats,snake";
            var setOfWords = inputString.Split(',');
            var anagramFreeSubsetCount = CodeJam_Problems.Anagrams.Anagrams.GetMaximumSubset(setOfWords);
            //In this case the Anagram Free Subset would be: {creation,sentence,sneak,star}
            Assert.AreEqual(anagramFreeSubsetCount, 4);
        }
    }
}
