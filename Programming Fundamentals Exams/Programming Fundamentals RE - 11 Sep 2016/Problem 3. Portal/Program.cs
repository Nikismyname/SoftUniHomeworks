using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{   //16:13 - 16:49
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] field = new char[n][];
            for (int i = 0; i < n; i++)
            {
                field[i] = Console.ReadLine().ToCharArray();
            }
            string instr = Console.ReadLine();

            int x = -1;
            int y = -1;

            //finding start pos
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == 'S')
                    {
                        y = i;
                        x = j;
                        break;
                    }
                }
            }
            int count = 0;
            bool success = false;

            foreach (char c in instr)
            {
                switch (c)
                {
                    case 'D':
                        MoveDown();
                        break;
                    case 'U':
                        MoveUp();
                        break;
                    case 'L':
                        MoveLeft();
                        break;
                    case 'R':
                        MoveRight();
                        break;
                }
                count++;

                //Console.WriteLine($"y:{y} x:{x} comm:{c}");
                if(field[y][x] == 'E')
                {
                    Console.WriteLine($"Experiment successful. {count} turns required.");
                    success = true;
                    break;
                }
            }

            if (!success)
            {
                Console.WriteLine($"Robot stuck at {y} {x}. Experiment failed.");
            }

            //Console.ReadLine();

            void MoveDown()
            {
                int ind = y + 1;
                while (true)
                {
                    if(ind == field.Length)
                    {
                        ind = 0;
                    }

                    if(field[ind].Length-1>= x)
                    {
                        y = ind;
                        break;
                    }
                    ind++;
                }
            }

            void MoveUp()
            {
                int ind = y - 1;
                while (true)
                {
                    if (ind == -1)
                    {
                        ind = field.Length-1;
                    }

                    if (field[ind].Length-1 >= x)
                    {
                        y = ind;
                        break;
                    }
                    ind--;
                }
            }

            void MoveRight()
            {
                if(x == field[y].Length-1)
                {
                    x = 0;
                    return;
                }
                else
                {
                    x++;
                    return;
                }
            }

            void MoveLeft()
            { 
                if (x == 0)
                {
                    x = field[y].Length-1;
                    return;
                }
                else
                {
                    x--;
                    return;
                }
            }
        }
    }
}
