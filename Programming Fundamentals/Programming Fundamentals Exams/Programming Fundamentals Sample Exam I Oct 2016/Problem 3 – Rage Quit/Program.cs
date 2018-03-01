using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Rage_Quit
{
    //- 17:37
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            List<char> curString = new List<char>();
            StringBuilder result = new StringBuilder();
            var table = new HashSet<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    int num = -1;
                    if (i + 1 < input.Length)
                    {
                        if (Char.IsDigit(input[i + 1]))
                        {
                            num = int.Parse(input.Substring(i, 2));
                            i++;
                        }
                        else
                        {
                            num = int.Parse(input[i].ToString());
                        }
                    }
                    else
                    {
                        num = int.Parse(input[i].ToString());
                    }

                    if (num > 0)
                    {
                        for (int j = 0; j < curString.Count; j++)
                        {
                            table.Add(curString[j]);
                        }
                    }

                    for (int j = 0; j < num; j++)
                    {
                        result.Append(curString.ToArray());
                    }

                    curString.Clear();
                }
                else
                {
                    curString.Add(Char.ToUpper(input[i]));
                }
            }
           
            Console.WriteLine($"Unique symbols used: {table.Count}");
            Console.WriteLine(result);
            //Console.ReadLine();
        }
    }
}
