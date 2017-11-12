using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3
{
    class Program
    {
        static void Main()
        {
            var names = Console.ReadLine().Split();
            double[] track = Console.ReadLine().Split().Select(double.Parse).ToArray();
            int[] checkpoints = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var name in names)
            {
                double fuel = (int)name.First();
                bool madeIt = true;

                for (int i = 0; i < track.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        fuel += track[i];
                    }
                    else
                    {
                        fuel -= track[i];
                    }

                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{name} - reached {i}");
                        madeIt = false;
                        break;
                    }
                }
                if (madeIt)
                {
                    Console.WriteLine($"{name} - fuel left {fuel.ToString("0.00")}");
                }
            }

            //Console.ReadLine();
        }
    }
}
