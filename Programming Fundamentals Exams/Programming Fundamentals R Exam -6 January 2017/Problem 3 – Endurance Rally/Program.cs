using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Endurance_Rally
{
    //16:16: 16:34
    public class Program
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split();
            double[] startFuel = names.Select(x => x[0]).Select(x => (double)((int)x)).ToArray();
            
            var track = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var checkPoints = Console.ReadLine().Split().Select(int.Parse).ToArray();


            for (int j = 0; j < startFuel.Length; j++)
            {
                for (int i = 0; i < track.Length; i++)
                {

                    if (checkPoints.Contains(i))
                    {
                        startFuel[j] += track[i];
                    }
                    else
                    {
                        startFuel[j] -= track[i];
                    }

                    if (startFuel[j] <= 0)
                    {
                        Console.WriteLine($"{names[j]} - reached {i}");
                        break;
                    }
                }

                if(startFuel[j]> 0)
                {
                    Console.WriteLine($"{names[j]} - fuel left {startFuel[j].ToString("0.00")}");
                }
            }
            //Console.ReadLine();
        }
    }
}
