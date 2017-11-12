using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem_3___Rage_Quit
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string regex = @"([^0-9]+)([0-9]+)";
            List<char> curString = new List<char>();
            StringBuilder result = new StringBuilder();
            List<char> chars = new List<char>();

            var matches = Regex.Matches(input,regex);
            foreach (Match item in matches)
            {
                int num = int.Parse(item.Groups[2].Value);
                string str = item.Groups[1].Value.ToUpper();

                if (num > 0)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (!chars.Contains(str[i]))
                        {
                            chars.Add(str[i]);
                        }
                    }
                }

                for (int i = 0; i < num; i++)
                {
                    result.Append(str);
                }
            }
            
            Console.WriteLine($"Unique symbols used: {chars.Count}");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
