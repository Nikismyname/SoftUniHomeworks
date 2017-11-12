using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _6.Valid_Usernames
{
    class Program
    {
        static void Main()
        {
            var text = Console.ReadLine();
            string pattern = @"(?:(?:[\/\\() ]+?)|^)([a-zA-Z][\w]{2,24})(?=$| |\/|\\|\(|\))";
            var names = Regex.Matches(text, pattern);
            var cleanList = new List<string>();
            foreach (Match name in names)
            {
                    cleanList.Add(name.Groups[1].Value);
            }
            //Console.WriteLine(string.Join(", ",cleanList));

            int maxSum = 0;
            int ind1 = -1;
            int ind2 = -1;
            for (int i = 1; i < cleanList.Count; i++)
            {
                int sum = cleanList[i - 1].Length + cleanList[i].Length;
                if (sum > maxSum)
                {
                    ind1 = i - 1;
                    ind2 = i;
                    maxSum = sum;
                }
            }
            Console.WriteLine(cleanList[ind1]);
            Console.WriteLine(cleanList[ind2]);
            // Console.ReadLine();
        }
    }
}
