using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Icarus
{
    //10:35 - 10:47 - 12min
    public class Program
    {
        public static void Main()
        {
            int[] planes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int ind = int.Parse(Console.ReadLine());
            int demage = 1;

            string input = Console.ReadLine();
            while(input != "Supernova")
            {
                string[] tokens = input.Split();

                if(tokens[0] == "right")
                {
                    MoveRight(int.Parse(tokens[1])); 
                }
                else
                {
                    MoveLeft(int.Parse(tokens[1]));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",planes));
            //Console.ReadLine();

            void MoveRight(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    ind++;
                    if(ind == planes.Length)
                    {
                        ind = 0;
                        demage++;
                    }

                    planes[ind] -= demage; 
                }
            }

            void MoveLeft(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    ind--;
                    if (ind ==-1)
                    {
                        ind = planes.Length-1;
                        demage++;
                    }

                    planes[ind] -= demage;
                }
            }
        }
    }
}
