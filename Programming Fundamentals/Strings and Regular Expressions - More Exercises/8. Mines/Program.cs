using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _8.Mines
{
    class Program
    {
        static void Main()
        {
            var line = Console.ReadLine().ToCharArray();

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '<' && Char.IsLetter(line[i + 1])
                    && Char.IsLetter(line[i + 2]) && line[i + 3] == '>')
                {
                    int strenght = Math.Abs(line[i + 1] - line[i + 2]);
                    for (int j = i-strenght; j < i+ 4 + strenght; j++)
                    {
                        if(j>=0 && j < line.Length)
                        {
                            line[j] = '_';
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("", line));
            //Console.ReadLine();
        }
    }
}
