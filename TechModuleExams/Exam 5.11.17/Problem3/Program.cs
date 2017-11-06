using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem3
{
    public static class Program
    {
        public static void Main()
        {
            string wordPattern = @"([a-zA-Z]+)(.+)\1";
            string line = Console.ReadLine();

            var vals = Console.ReadLine()
                .Split(new char[] { '}', '{' }
                    ,StringSplitOptions.RemoveEmptyEntries);

            var matches = Regex.Matches(line, wordPattern);
            int pointer = 0;

            int adjustment = 0;

            foreach (Match match in matches)
            {
               // Console.WriteLine(match.Groups[0]);

                var m = match.Groups[2];

                string firstPart = line.Substring(0,m.Index+ adjustment);
                string secondPart = line.Substring(m.Index+m.Length+ adjustment);

                if(pointer < vals.Length)
                {
                    int oldLineLength = line.Length;
                    line = string.Concat(firstPart,vals[pointer],secondPart);
                    pointer++;
                    adjustment =  line.Length - oldLineLength;
                }
            }
            Console.WriteLine(line);
            //Console.ReadLine();
        }
    }
}
