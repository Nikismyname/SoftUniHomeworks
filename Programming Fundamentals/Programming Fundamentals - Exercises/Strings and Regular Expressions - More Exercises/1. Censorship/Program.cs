using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string toReplace = new string('*',word.Length);
            text = Regex.Replace(text,$@"{word}",toReplace);
            Console.WriteLine(text);
            //Console.ReadLine();
        }
    }
}
