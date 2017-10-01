using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Letters_Change_Numbers
{
    class Program
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine()
                    .Split(new char[] { ' ' ,'\n','\t'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x=>x.Trim())
                    .ToArray();
 

            double sum = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                char firstLetter = tokens[i][0];
                char secondLetter = tokens[i][tokens[i].Length - 1];
                double number = double.Parse(tokens[i].Substring(1,tokens[i].Length-2));
                
                if (char.IsUpper(firstLetter))
                {
                    int posInA = (int)firstLetter - (int)'A' + 1;
                    number /= posInA;
                }
                if (char.IsLower(firstLetter))
                {
                    int posInA = (int)firstLetter - (int)'a' + 1;
                    number *= posInA;
                }

                if (char.IsUpper(secondLetter))
                {
                    int posInA = (int)secondLetter - (int)'A' + 1;
                    number -= posInA;
                }
                if (char.IsLower(secondLetter))
                {
                    int posInA = (int)secondLetter - (int)'a' + 1;
                    number += posInA;
                }
                sum += number;
            }
            Console.WriteLine(sum.ToString("0.00"));
            //Console.ReadLine();
        }
    }
}
