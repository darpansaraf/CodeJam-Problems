using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam_Problems.StandInLine
{
    public class StandInLine
    {
        #region Main
        //static void Main(string[] args)
        //{
        //    int countOfLeftArray = 0;
        //    Console.WriteLine("Enter the number of elements in the left array:");
        //    int.TryParse(Console.ReadLine(), out countOfLeftArray);
        //    Console.WriteLine("Enter the elements of the left Array:");
        //    int leftArrayElement = 0;
        //    var leftList = new List<int>();
        //    for (int index = 0; index < countOfLeftArray; index++)
        //    {
        //        int.TryParse(Console.ReadLine(), out leftArrayElement);
        //        leftList.Add(leftArrayElement);
        //    }
        //    var positionOfSoldiers = Reconstruct(leftList);
        //    if (positionOfSoldiers != null && positionOfSoldiers.Count > 0)
        //    {
        //        foreach (var position in positionOfSoldiers)
        //            Console.Write(position + "  ");
        //    }
        //    Console.ReadLine();
        //}
        #endregion

        public static List<int> Reconstruct(List<int> left)
        {
            if (!IsInputValid(left))
                return null;

            var countOfLeftArray = left.Count;
            var heightOfSoldiers = new List<int>();
            var heightAndLeftCountDictionary = new Dictionary<int, int>();
            ConstructDictionary(left, heightAndLeftCountDictionary);
            while (true)
            {
                var minimumLeft = FindProbableLeftParticipants(left, heightAndLeftCountDictionary, heightOfSoldiers);

                if (CheckIfCurrentHeightCanBeInserted(left, heightAndLeftCountDictionary, heightOfSoldiers, minimumLeft))
                {
                    var requiredHeight = heightAndLeftCountDictionary.First(keyVal => keyVal.Value == minimumLeft);
                    heightOfSoldiers.Add(requiredHeight.Key);
                    left.Remove(requiredHeight.Value);
                    heightAndLeftCountDictionary.Remove(requiredHeight.Key);
                }
                if (heightOfSoldiers.Count == countOfLeftArray)
                    break;
            }
            return heightOfSoldiers;
        }

        private static bool IsInputValid(List<int> left)
        {
            if (left == null || left.Count == 0 || left.Count > 10)
                return false;

            int countOfElementsInLeft = left.Count;
            for (int index = 0; index < countOfElementsInLeft; index++)
                if (left[index] < 0 || left[index] > countOfElementsInLeft - index - 1)
                    return false;
            return true;

        }

        private static int FindProbableLeftParticipants(List<int> left, Dictionary<int, int> heightAndLeftCountDictionary, List<int> heightOfSoldiers)
        {
            var participants = new List<int>();
            for (int index = 0; index < left.Count; index++)
            {
                var heightOfCurrentLeftIndex = heightAndLeftCountDictionary.First(keyVal => keyVal.Value == left[index]).Key;
                if (heightOfSoldiers.FindAll(heights => heights > heightOfCurrentLeftIndex).Count == left[index])
                {
                    participants.Add(heightOfCurrentLeftIndex);
                }
            }
            var minimumparticipant = participants.Min();
            return heightAndLeftCountDictionary.First(x => x.Key == minimumparticipant).Value;
        }

        private static bool CheckIfCurrentHeightCanBeInserted(List<int> left, Dictionary<int, int> heightAndLeftCountDictionary, List<int> heightOfSoldiers, int minimumLeft)
        {
            var heightOfMinimumLeft = heightAndLeftCountDictionary.First(keyValue => keyValue.Value == minimumLeft);
            if (heightOfSoldiers.FindAll(heights => heights > heightOfMinimumLeft.Key).Count == heightOfMinimumLeft.Value)
                return true;
            return false;
        }

        private static void ConstructDictionary(List<int> left, Dictionary<int, int> heightAndLeftCountDictionary)
        {
            for (int index = 1; index <= left.Count; index++)
            {
                heightAndLeftCountDictionary.Add(index, left[index - 1]);
            }
        }
    }

}
