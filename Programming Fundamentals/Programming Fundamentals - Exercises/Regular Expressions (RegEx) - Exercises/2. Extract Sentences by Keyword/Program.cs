using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _2.Extract_Sentences_by_Keyword
{
    class Program
    {
        static void Main()
        {
            var kWord = Console.ReadLine();
            var text = Console.ReadLine();
            var pattern = $@"(?<=^|\!|\.|\?)([^!?.]*?\b{kWord}\b[^!?.]*?)((?=\!|\.|\?))";
            var matches = Regex.Matches(text,pattern);

            foreach (Match item in matches)
            {
                Console.WriteLine(item.Groups[0].Value.Trim());
            }
           
            //Console.ReadLine();
        }
    }
}
