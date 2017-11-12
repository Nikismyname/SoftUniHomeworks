using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2.Index_of_Letters
{
    public class Program
    {
        public static void Main()
        {
            File.Delete("output.txt");
            var word = File.ReadAllText("input.txt");
            var letterArray = new char[26];
            for (char i = 'a'; i <= 'z'; i++)
            {
                letterArray[(int)i - (int)'a'] = i;
            }

            foreach (var l in word)
            {
                if(Char.IsLetter(l) && Char.IsLower(l))
                {
                    File.AppendAllText("output.txt",$"{l} -> {Array.IndexOf(letterArray, l)}" + Environment.NewLine);
                    //Console.WriteLine($"{l} -> {Array.IndexOf(letterArray,l)}");
                }
            }
            Console.ReadLine();
        }
    }
}
