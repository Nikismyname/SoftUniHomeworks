using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _8.Use_Your_Chains__Buddy
{
    class Program
    {
        static void Main()
        {
            string pPattern = @"<p>(.+?)</p>";
            string input = Console.ReadLine();
            var ps = Regex.Matches(input,pPattern);
            var cleanList = new List<string>();
            foreach (Match item in ps)
            {
                string endResult = item.Groups[1].Value;
                endResult = Regex.Replace(endResult, @"[^a-z0-9]", " ");
                endResult = Regex.Replace(endResult,@"\s+", " ");
                cleanList.Add(endResult);
            }
            //Console.WriteLine(string.Join(" ", cleanList));

            for (int i = 0; i < cleanList.Count; i++)
            {
                var target = cleanList[i];
                string decoded = string.Empty;
                for (int j = 0; j < target.Length; j++)
                {
                   
                    char curr = target[j];
                    if (Char.IsLetter(curr))
                    {
                        if (curr < 'n')
                        {
                            curr = (char)(curr + 13);
                        }
                        else
                        {
                            curr = (char)(curr - 13);
                        }
                    }
                    decoded += curr;
                }
                cleanList[i] = decoded;
            }
            Console.WriteLine(string.Join("",cleanList));
            //Console.ReadLine();
        }
    }
}
