using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _5.Key_Replacer
{
    class Program
    {
        static void Main()
        {
            var key = Console.ReadLine();
            var keyPattern = @"^(.+?)[|<\\].*?[|<\\](.+?)$";
            var match = Regex.Match(key,keyPattern);
            var text = Console.ReadLine();
            if (match.Success)
            {
                var start = match.Groups[1].Value;
                var end = match.Groups[2].Value;
                var searchPattern = start + @"(.*?)" + end;
                var matches = Regex.Matches(text, searchPattern);
                var output = new List<string>();
                foreach (Match item in matches)
                {
                    if (item.Groups[1].Value != "")
                    {
                        output.Add(item.Groups[1].Value);
                    }
                }

                if(output.Count == 0)
                {
                    Console.WriteLine("Empty result");
                }

                else
                {
                    Console.WriteLine( string.Join("",output));
                }
            }
            else
            {
                Console.WriteLine("Empty result");
            }
           // Console.ReadLine();
        }
    }
}
