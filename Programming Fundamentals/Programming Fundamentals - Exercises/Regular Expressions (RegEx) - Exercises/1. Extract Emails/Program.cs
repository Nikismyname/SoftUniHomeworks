using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _1.Extract_Emails
{
    class Program
    {
        static void Main()
        {
             string pattern = @"(?<=\s|^)\b[a-zA-Z0-9]+([_.-][a-zA-Z0-9]+)*@[a-zA-Z]+(\-[a-zA-Z]+)*(\.[a-zA-Z]+(\-[a-zA-Z]+)*)+\b(?=\s|\.|$|\,)";

            string input = Console.ReadLine();
            var matches = Regex.Matches(input,pattern);
            for (int i = 0; i < matches.Count; i++)
            { 
                Console.WriteLine(matches[i].Groups[0].Value.Trim());
            }
            //Console.ReadLine();
        }
    }
}
