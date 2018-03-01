using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _7.Hideout
{
    class Program
    {
        static void Main()
        {
            string map = Console.ReadLine();

            while (true)
            {
                var tokens = Console.ReadLine().Split();
                char symb = char.Parse(tokens[0]);
                int min = int.Parse(tokens[1]);

                var serchedString = new string(symb,min);
                int index = map.IndexOf(serchedString);
                if(index!= -1)
                {
                   
                    int length = 0;
                    for (int i = index; i < map.Length; i++)
                    {
                        if (map[i] == symb)
                        {
                            length++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine($"Hideout found at index {index} and it is with size {length}!");
                    return;
                }
            }
        }
    }
}
