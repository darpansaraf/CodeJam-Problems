using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam_Problems.SantaDaDhaba
{
    public class SantaDaDhaba
    {
        #region MenuCard
        private static Dictionary<char, int> menuCard = new Dictionary<char, int>(){
                       {'0',0},
                       {'1',1},
                       {'2',2},
                       {'3',3},
                       {'4',4},
                       {'5',5},
                       {'6',6},
                       {'7',7},
                       {'8',8},
                       {'9',9},
                       {'A',10},
                       {'B',11},
                       {'C',12},
                       {'D',13},
                       {'E',14},
                       {'F',15},
                       {'G',16},
                       {'H',17},
                       {'I',18},
                       {'J',19},
                       {'K',20},
                       {'L',21},
                       {'M',22},
                       {'N',23},
                       {'O',24},
                       {'P',25},
                       {'Q',26},
                       {'R',27},
                       {'S',28},
                       {'T',29},
                       {'U',30},
                       {'V',31},
                       {'W',32},
                       {'X',33},
                       {'Y',34},
                       {'Z',35},
                       {'a',36},
                       {'b',37},
                       {'c',38},
                       {'d',39},
                       {'e',40},
                       {'f',41},
                       {'g',42},
                       {'h',43},
                       {'i',44},
                       {'j',45},
                       {'k',46},
                       {'l',47},
                       {'m',48},
                       {'n',49},
                       {'o',50},
                       {'p',51},
                       {'q',52},
                       {'r',53},
                       {'s',54},
                       {'t',55},
                       {'u',56},
                       {'v',57},
                       {'w',58},
                       {'x',59},
                       {'y',60},
                       {'z',61},
            };
        #endregion


        #region Main
        //static void Main(string[] args)
        //{

        //    #region Run Using Input File
        //    /*
        //     * Run Using Input File.

        //    //Path To The Input File
        //    var inputLines = File.ReadAllLines(@"C:\Users\Darpan\Documents\Visual Studio 2012\Projects\SantaDaDhaba\SantaDaDhaba\input.txt");
        //    var prices = new List<string>();
        //    for (int index = 0; index < inputLines.Length; index++)
        //        prices.Add(inputLines[index]);

        //    */
        //    #endregion

        //    #region Run Using Console

        //    //Run Using Console.
        //    Console.WriteLine("Enter the number of elements in price array:");
        //    int countOfPricesArray;
        //    int.TryParse(Console.ReadLine(), out countOfPricesArray);
        //    Console.WriteLine("Enter the elements of the array:");
        //    var prices = new List<string>();
        //    for (int index = 0; index < countOfPricesArray; index++)
        //        prices.Add(Console.ReadLine());

        //    #endregion

        //    Console.WriteLine("\nEnter Banta's budget:");
        //    int budget;
        //    int.TryParse(Console.ReadLine(), out budget);

        //    var maxNumberOfDaysBantaAte = MaxDays(prices, budget);
        //    Console.WriteLine("Maximum Number of days Banta Ate the Food is:" + maxNumberOfDaysBantaAte);
        //    Console.ReadLine();
        //}
        #endregion

        public static int MaxDays(List<string> prices, int budget)
        {
            if (!IsInputValid(prices, budget))
                return -1;

            int expenditure = 0;
            Dictionary<int, int> dayAndPriceIndexMapping = new Dictionary<int, int>();
            char phonetic = 'a';
            for (int dayCount = 1; dayCount <= prices.Count; dayCount++)
            {
                var priceOnCurrentDay = prices[dayCount - 1];
                if (dayCount > 7)
                {
                    var previousWeekDay = dayCount % 7;
                    var indexOfPriceInPreviousWeek = dayAndPriceIndexMapping[previousWeekDay];
                    int price = menuCard[priceOnCurrentDay[indexOfPriceInPreviousWeek]];
                    if (expenditure + price < budget)
                        expenditure += price;
                    else
                        return dayCount - 1;
                    continue;
                }
                var minimumPrice = GetMinimumPrice(priceOnCurrentDay, out phonetic);
                var indexOfMinimumPrice = priceOnCurrentDay.IndexOf(phonetic.ToString());
                if (expenditure + minimumPrice > budget)
                    return dayCount - 1;
                dayAndPriceIndexMapping.Add(dayCount, indexOfMinimumPrice);
                expenditure += minimumPrice;
            }
            return -1;
        }

        private static bool IsInputValid(List<string> prices, int budget)
        {
            if (budget < 0 || budget > 10000)
                return false;

            if (prices == null || prices.Count > 50)
                return false;

            return true;
        }

        private static int GetMinimumPrice(string priceOnCurrentDay, out char phonetic)
        {
            int minimumPrice = 1000;
            char characterForWhichPriceIsMinimum = 'a';
            foreach (var character in priceOnCurrentDay)
            {
                if (menuCard[character] < minimumPrice)
                {
                    minimumPrice = menuCard[character];
                    characterForWhichPriceIsMinimum = character;
                }
            }
            phonetic = characterForWhichPriceIsMinimum;
            return minimumPrice;
        }
    }
}
