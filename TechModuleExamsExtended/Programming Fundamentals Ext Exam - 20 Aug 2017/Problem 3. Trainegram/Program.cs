using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem_3.Trainegram
{
    //18:36 - 18:49 - 13m; 
    public class Program
    {
        public static void Main()
        {
            string patt = @"^<\[[^A-Za-z0-9]*\]\.(?:\.\[[a-zA-Z0-9]*\]\.)*$";

            string input = Console.ReadLine();
            while (input!= "Traincode!")
            {
                var match = Regex.Match(input,patt);
                if (match.Success)
                {
                    Console.WriteLine(match.Groups[0].Value);
                }
                input = Console.ReadLine();
            }
            //Console.ReadLine(); 
        }
    }
}
