using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace _4.Morse_Code_Upgraded
{
    class Program
    {
        static void Main()
        {
            var repeatePattern = @"(.)\1+"; 
            string input = Console.ReadLine();
            var numMatches = Regex.Matches(input, @"[01]+");
            var listOfLetters = numMatches
                .Cast<Match>()
                .Select(x=>x.Groups[0].Value.ToCharArray())
                .ToList();

            var letterNums = new List<int>();
            foreach (var item in listOfLetters)
            {
                int scoreOfLetter = 0;
                int numOfZeros = item.Where(x => x == '0').Count();
                int numOfOnes = item.Where(x => x == '1').Count();
                scoreOfLetter += numOfZeros * 3;
                scoreOfLetter += numOfOnes * 5;
                var repeateMatches = Regex.Matches(string.Join("", item), repeatePattern);

                //Console.WriteLine($"------ {string.Join("",item)}");
                foreach (Match match in repeateMatches)
                {

                   // Console.WriteLine(match.Groups[0].Value);
                    scoreOfLetter += match.Groups[0].Value.Length;
                }
                letterNums.Add(scoreOfLetter);
            }
            Console.WriteLine(string.Join("", letterNums.Select(x=>(char)x)));
            //Console.ReadLine();
        }
    }
}
