using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam_Problems.Anagrams
{
    public class Anagrams
    {
        #region Main
        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Enter a Comma separated string:");
        //    var input = Console.ReadLine();
        //    var listOfWords = input.Split(',');
        //    Console.WriteLine(string.Format("The Maximum length of anagram-free subset is:{0}", GetMaximumSubset(listOfWords)));
        //    Console.ReadLine();
        //}
        #endregion

        public static int GetMaximumSubset(String[] listOfWords)
        {
            var anagramFreeSubset = new List<string>();
            anagramFreeSubset.Add(listOfWords[0]);
            for (int index = 1; index < listOfWords.Count(); index++)
            {
                if (!CheckWhetherCurrentInputWordIsAnagrmaticWithOtherWords(anagramFreeSubset, listOfWords[index]))
                    anagramFreeSubset.Add(listOfWords[index]);
            }
            return anagramFreeSubset.Count;
        }

        private static bool CheckWhetherCurrentInputWordIsAnagrmaticWithOtherWords(List<string> anagramFreeSubset, string word)
        {
            var matchingLengthWords = anagramFreeSubset.FindAll(words => words.Length == word.Length);
            if (matchingLengthWords.Count == 0)
                return false;

            foreach (var currentWord in matchingLengthWords)
            {
                if (CheckWhetherAllCharsArePresent(currentWord.ToCharArray(), word.ToCharArray()))
                    return true;
            }
            return false;
        }

        private static bool CheckWhetherAllCharsArePresent(char[] currentWord, char[] charArray)
        {
            foreach (var character in currentWord)
                if (!charArray.Contains(character))
                    return false;
            return true;
        }
    }
}
