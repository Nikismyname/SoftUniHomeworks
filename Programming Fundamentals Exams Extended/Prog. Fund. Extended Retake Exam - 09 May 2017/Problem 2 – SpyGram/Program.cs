using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem_2___SpyGram
{
    //   14:50  - 15:25 - 35 min+
    public class Program
    {
        public static void Main()
        {
            var dict = new List<KeyValuePair<string,string>>();

            string pattern = @"^TO: ([A-Z]+); MESSAGE: (.+?);$";
            int[] key = Console.ReadLine().Trim().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
            string input = Console.ReadLine();
           
                while (input != "END")
                {
                    var match = Regex.Match(input, pattern);
                    if (match.Success)
                    {
                    
                        dict.Add(new KeyValuePair<string, string>( match.Groups[0].Value, match.Groups[1].Value));
                 
                    }
                    input = Console.ReadLine();
                }
          
            foreach (var item in dict.OrderBy(x => x.Value))
                {
                    PrintMessage(item.Key, key);
                }

            //Console.ReadLine();
        }

        public static void PrintMessage(string message,int[] key)
        {

            int pointer = 0;
            string toEnc = message;
            List<char> enc = new List<char>();

            foreach (var c in toEnc)
            {
                if (pointer == key.Length)
                {
                    pointer = 0;
                }

                char curr = (char)(c + key[pointer++]);
                enc.Add(curr);
            }

            Console.WriteLine(string.Join("", enc));
        }

    }
}
