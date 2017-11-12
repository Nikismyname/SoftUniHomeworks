using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem3
{
    class Program
    {
        static void Main()
        {
            string pattern = "(.+?)([0-9]+)";
            string input = Console.ReadLine();

            HashSet<char> uniqueChars = new HashSet<char>();

            var matches = Regex.Matches(input, pattern);

            StringBuilder output = new StringBuilder();

            foreach (Match item in matches)
            {
                string text = item.Groups[1].Value;
                int num = int.Parse(item.Groups[2].Value);

                text = text.ToUpper();

                for (int i = 0; i < num; i++)
                {
                    output.Append(text);
                }
            }

            foreach (var item in output.ToString())
            {
                uniqueChars.Add(item);
            }

            Console.WriteLine($"Unique symbols used: {uniqueChars.Count}");
            Console.WriteLine(output);

            //  Console.ReadLine();
        }
    }
}
