using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Problem_3.Phoenix_Grid
{
    //10:48 - 11:00 - 12min
    public class Program
    {
        public static void Main()
        {
            string patt = @"^[^\s_]{3}(\.[^\s_]{3})*$";

            string input = Console.ReadLine();
            while(input!= "ReadMe")
            {
                var match = Regex.Match(input,patt);
                if (match.Success)
                {
                    if (IsPalindrom(match.Groups[0].Value))
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                }

                input = Console.ReadLine();
            }

            //Console.ReadLine();
        }

        public static bool IsPalindrom(string str)
        {
            for (int i = 0; i < str.Length/2; i++)
            {
                int oposInd = str.Length - i - 1;
                if(str[i] != str[oposInd])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
