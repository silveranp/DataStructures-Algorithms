using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenuPreferences
{
    class Program
    {
        static void Main(string[] args)
        {
            var lunchMenuPairs = new string[3, 2] { { "pizza", "Italian" }, { "Curry", "Indian" },
                                        { "Masala", "Indian" } };
            var cuisinePref = new string[4, 2] { { "Jose", "Italian" }, { "John", "Indian" },
                                        { "Sarah", "*" }, { "Mary", "*" } };

            Console.Read();
        }

        private static String[,] MatchLunches(String[,] lunchMenuPairs, String[,] cuisinePref)
        {
            int n1 = cuisinePref.GetLength(0);
            int n2 = lunchMenuPairs.GetLength(0);
            String[,] output = new String[n1 * n2, 2];

            int index = 0;
            for (int k = 0; k < n1; k++)
            {
                for (int i = 0; i < n2; i++)
                {
                    if (cuisinePref[k, 1] == "*" || string.Compare(lunchMenuPairs[i, 1], cuisinePref[k, 1], true) == 0)
                    {
                        output[index, 0] = cuisinePref[k, 0];
                        output[index, 1] = lunchMenuPairs[i, 0];
                        index++;
                    }
                }
            }

            return output;
        }


    }
}
