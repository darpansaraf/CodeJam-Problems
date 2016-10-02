using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeJam_Problems.LexStringWriter
{
    public class LexStringWriter
    {
        //#region MainProgram
        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Enter A String:");
        //    var inputString = Console.ReadLine();
        //    var minimumNumberOfMoves = GetMinimumMoves(inputString);
        //    Console.WriteLine(string.Format("The Minimum Number of moves are:{0}", minimumNumberOfMoves));
        //    Console.ReadLine();
        //}
        //#endregion

        public static int GetMinimumMoves(string inputString)
        {
            if (!ValidateInputString(inputString))
                return -1;
            var arrayToBeSorted = inputString.ToCharArray();
            Array.Sort(arrayToBeSorted);
            int currentPositionOfCursor = 0, nextPositionOfCursor = 0;
            int minimumNumberOfMoves = 0, minimumAbsoluteValueIndex = 0;


            foreach (var character in arrayToBeSorted)
            {
                int minimumAbsoluteValue = int.MaxValue;
                var indexes = GetAllIndexes(inputString, character);
                foreach (var index in indexes)
                {
                    nextPositionOfCursor = index - currentPositionOfCursor;
                    var absoluteValue = Math.Abs(nextPositionOfCursor);
                    if (absoluteValue < minimumAbsoluteValue)
                    {
                        minimumAbsoluteValue = absoluteValue;
                        minimumAbsoluteValueIndex = nextPositionOfCursor;
                    }
                }
                minimumNumberOfMoves += minimumAbsoluteValue;
                currentPositionOfCursor += minimumAbsoluteValueIndex;//move the cursor to the required position
                minimumNumberOfMoves++; //Prints the character
                inputString = ReplaceSingleOccurrence(inputString, ' ', currentPositionOfCursor); // Replace the current character with space.

            }
            return minimumNumberOfMoves;
        }

        private static bool ValidateInputString(string inputString)
        {

            if (inputString.Length > 50)
                return false;

            var smallCaseLettersOnly = new Regex("[a-z]");
            var matchesGroup = smallCaseLettersOnly.Matches(inputString);

            if (matchesGroup.Count != inputString.Length)
                return false;
            return true;
        }

        private static string ReplaceSingleOccurrence(string inputString, char newChar, int index)
        {
            StringBuilder temporaryInputString = new StringBuilder(inputString);
            temporaryInputString[index] = newChar;
            return temporaryInputString.ToString();
        }

        private static List<int> GetAllIndexes(string inputString, char character)
        {
            var foundIndexes = new List<int>();
            for (int index = inputString.IndexOf(character); index > -1; index = inputString.IndexOf(character, index + 1))
                foundIndexes.Add(index);
            return foundIndexes;
        }

        #region QuickSort
        //private static string GetSortedInputString(string inputString)
        //{
        //    //Sort using Quick Sort
        //    var temporaryInputString = inputString.ToCharArray();
        //    quickSort(ref temporaryInputString, 0, temporaryInputString.Length - 1);
        //    return temporaryInputString.ToString();


        //}

        //private static void quickSort(ref char[] inputString, int low, int high)
        //{
        //    if (low < high)
        //    {
        //        int pi = partition(ref inputString, low, high);
        //        quickSort(ref inputString, low, pi - 1);
        //        quickSort(ref inputString, pi + 1, high);
        //    }
        //}

        //private static int partition(ref char[] inputString, int low, int high)
        //{
        //    char pivot = inputString[high];
        //    int index = low - 1;
        //    for (int j = low; j < high - 1; j++)
        //    {
        //        if (inputString[j] <= pivot)
        //        {
        //            index++;
        //            swap(ref inputString[index], ref inputString[high]);
        //        }
        //    }
        //    swap(ref inputString[index + 1], ref inputString[high]);
        //    return index + 1;
        //}

        //private static void swap(ref char a, ref char b)
        //{
        //    char temp;
        //    temp = a;
        //    a = b;
        //    b = temp;
        //}
        #endregion

    }
}
