using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Ladybugs
{
    //19:13 - 19:30
    class Program
    {
        static void Main()
        {
            int[] field = new int[int.Parse(Console.ReadLine())];
            int[] bugs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < field.Length; i++)
            {
                if (bugs.Contains(i))
                {
                    field[i] = 1;
                }
                else
                {
                    field[i] = 0;
                }
            }

            string input = Console.ReadLine();
            while (input != "end")
            {
                var tokens = input.Split();
                int selected = int.Parse(tokens[0]);
                var direction = tokens[1];
                int dir = direction == "right" ? 1 : -1;
                int step = int.Parse(tokens[2]);
                int finalStep = step * dir;

                if (selected < 0|| selected >= field.Length)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (field[selected] != 1)
                {
                    input = Console.ReadLine();
                    continue;
                }

                int newPos = selected;
                field[selected] = 0;
                while (true)
                {
                    newPos += finalStep;
                    if(newPos<0 || newPos >= field.Length)
                    {
                        break;
                    }

                    if(field[newPos] == 0)
                    {
                        field[newPos] = 1;
                        break;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
            //Console.ReadLine();
        }
    }
}
