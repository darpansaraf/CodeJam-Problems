using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeJam_Problems.Dating
{
    public class Dating
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string Circle:");
            var circle = Console.ReadLine();
            Console.WriteLine("Enter the Position of the first Chooser:");
            int chooserPosition = Int32.Parse(Console.ReadLine());
            string outputString = Dates(circle, chooserPosition);
            Console.WriteLine("The dating pairs are as follows:" + outputString);
            Console.ReadLine();
        }

        public static string Dates(string circle, int k)
        {
            string dates = string.Empty;
            char chooser = '\0', nextCharacterToBeChoosen = '\0';
            int chooserPosition = 0;

            var males = (from charcter in circle where charcter >= 65 && charcter <= 90 select charcter).ToArray();
            var females = (from charcter in circle where charcter >= 97 && charcter <= 122 select charcter).ToArray();

            //We need to sort here because we need to select the most hottest available male/female.
            Array.Sort(males);
            Array.Sort(females);

            while (true)
            {
                if (nextCharacterToBeChoosen == '\0')
                    chooserPosition = (k % circle.Length) - 1;
                else
                {
                    var indexOfNextCharacter = circle.IndexOf(nextCharacterToBeChoosen.ToString());
                    chooserPosition = indexOfNextCharacter + (k % circle.Length) - 1;
                }
                chooser = circle[chooserPosition];
                dates += circle[chooserPosition];
                if (IsChooserMale(circle[chooserPosition]))
                {
                    dates += females[0];
                    circle = circle.Remove(circle.IndexOf(females[0]), 1);
                    females = females.Where(female => female != females[0]).ToArray();
                    males = males.Where(male => male != chooser).ToArray();
                }
                else
                {
                    dates += males[0];
                    females = females.Where(female => female != circle[chooserPosition]).ToArray();
                    circle = circle.Remove(circle.IndexOf(males[0]), 1);
                    males = males.Where(male => male != males[0]).ToArray();
                }
                if (males.Length == 0 || females.Length == 0)
                    break;
                dates += " ";
                nextCharacterToBeChoosen = circle[circle.IndexOf(chooser) + 1];
                circle = circle.Remove(circle.IndexOf(chooser), 1);
            }

            return dates;
        }

        private static bool IsChooserMale(char chooser)
        {
            if (chooser >= 65 && chooser <= 90)
                return true;
            return false;
        }
    }
}
