using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Trifon_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            long pHealth = long.Parse(Console.ReadLine());
            long[] dimTokens = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long yy = dimTokens[0];
            long xx = dimTokens[1];
            long playerX =0, playerY = 0;
            bool goingDown = true;
            long turns = 0;
            long winningX = xx-1;
            long winningY = -1;

            if(xx%2 == 0)
            {
                winningY = 0;
            }
            else
            {
                winningY = yy - 1;
            }

            char[,] field = new char[yy, xx];
            for (long i = 0; i < yy; i++)
            {
                char[] newLine = Console.ReadLine().ToCharArray();
                for (long j = 0; j < newLine.Length; j++)
                {
                    field[i, j] = newLine[j];
                }
            }

            for (long i = 0; i < xx*yy; i++)
            {
                switch (field[playerY, playerX])
                {
                    case 'F':
                        //Console.WriteLine("FFFFFFFFF");
                        pHealth -= turns / 2;
                        if (pHealth <= 0)
                        {
                            Console.WriteLine($"Died at: [{playerY}, {playerX}]");
                            return;
                        }
                        turns++;
                        break;
                    case 'H':
                        //Console.WriteLine("HHHHHHHHHHH");
                        pHealth += turns / 3;
                        turns++;
                        break;
                    case 'T':
                        //Console.WriteLine("TTTTTTTTTTT");
                        turns += 3;
                        break;
                    case 'E':
                        //Console.WriteLine("EEEEEEEEEEEE");
                        turns++;
                        break;
                }

                if(playerX == winningX&& playerY == winningY)
                {
                    Console.WriteLine($"Quest completed!");
                    Console.WriteLine($"Health: {pHealth}");
                    Console.WriteLine($"Turns: {turns}");
                    break;
                }

                Move();
            }

            void Move()
            {
                if (goingDown)
                {
                    if(playerY == yy - 1)
                    {
                        playerX++;
                        goingDown = false;
                    }
                    else
                    {
                        playerY++;
                    }
                }
                else
                {
                    if(playerY == 0)
                    {
                        playerX++;
                        goingDown = true;
                    }
                    else
                    {
                        playerY--;
                    }
                }
            }
        }
    }
}
