using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem_2___Worm_Ipsum
{
    //11:16 - 11:44 - 28m
    public class Program
    {
        public static void Main()
        {
            string lineValidation = @"^[A-Z][^\.]*?\.$";
            string input = Console.ReadLine();
            while(input != "Worm Ipsum")
            {
                var match = Regex.Match(input,lineValidation);
                if (match.Success)
                {
                    Console.WriteLine(ProcessValidSentance(match.Groups[0].Value));
                }
                input = Console.ReadLine();
            }
            //Console.ReadLine();
        }

        public static string ProcessValidSentance(string sent)
        {
            var words = sent.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(string.Join(" ",words));
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];

                var dict = new Dictionary<char, int>();

                foreach (var letter in word)
                {
                    if (!dict.ContainsKey(letter))
                    {
                        dict[letter] = 0;
                    }
                    dict[letter]++;
                }

                var mostCommonLetter = dict.OrderByDescending(x => x.Value).First();
                if (mostCommonLetter.Value >= 2)
                {
                    if (!Char.IsLetter(word.Last()))
                    {
                        words[i] = new string(mostCommonLetter.Key, words[i].Length - 1) + words[i].Last();
                    }
                    else
                    {
                        words[i] = new string(mostCommonLetter.Key, words[i].Length);
                    }
                }
            }

            return string.Join(" ", words);
        }
    }
}
