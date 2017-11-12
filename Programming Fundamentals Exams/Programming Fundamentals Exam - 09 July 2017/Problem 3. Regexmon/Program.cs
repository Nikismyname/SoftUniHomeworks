using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Problem_3.Regexmon
{
    //18:41 19:13 = 28 -3 = 25
    public class Program
    {
        public static void Main()
        {
            string didiPatt = @"[^a-zA-Z-]+";
            string bojoPatt = @"[a-zA-Z]+-[a-zA-Z]+";

            string str = Console.ReadLine();

            int startIndex = 0;

            while (true)
            {
                var didiMatch = Regex.Match(str.Substring(startIndex), didiPatt);
                if (didiMatch.Success)
                {
                    if(startIndex>= str.Length)
                    {
                        break;
                    }
                    string found = didiMatch.Groups[0].Value;
                    startIndex += didiMatch.Groups[0].Index + didiMatch.Groups[0].Length;
                    //Console.WriteLine(startIndex);
                    Console.WriteLine(found);
                }
                else
                {
                    break;
                }

                var bojoiMatch = Regex.Match(str.Substring(startIndex), bojoPatt);
                if (bojoiMatch.Success)
                {
                    if (startIndex >= str.Length)
                    {
                        break;
                    }
                    string found = bojoiMatch.Groups[0].Value;
                    startIndex += bojoiMatch.Groups[0].Index + bojoiMatch.Groups[0].Length;
                    //Console.WriteLine(startIndex);
                    Console.WriteLine(found);
                }
                else
                {
                    break;
                }
            }
            //Console.ReadLine();
        }
    }
}
