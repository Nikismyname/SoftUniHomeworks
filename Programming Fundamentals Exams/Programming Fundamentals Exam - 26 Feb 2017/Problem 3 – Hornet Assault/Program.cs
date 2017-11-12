using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Hornet_Assault
{
    //13:44 13:57 13m
    class Program
    {
        static void Main()
        {
            var beeAray = Console.ReadLine().Split().Select(long.Parse).ToArray();
            var hornetArray = Console.ReadLine().Split().Select(long.Parse).ToList();

            for (int i = 0; i < beeAray.Length; i++)
            {
                long hornetPower = hornetArray.Sum(); 
                if(hornetPower <= beeAray[i])
                {
                    hornetArray.RemoveAt(0);
                }

                if(hornetPower> beeAray[i])
                {
                    beeAray[i] = 0;
                }
                else
                {
                    beeAray[i] -= (long)(hornetPower);
                }

                if(hornetArray.Count == 0)
                {
                    break;
                }
            }
            if (beeAray.Any(x => x > 0))
            {
                Console.WriteLine(string.Join(" ",beeAray.Where(x=>x>0)));
            }
            else
            {
                Console.WriteLine(string.Join(" ",hornetArray));
            }
            //Console.ReadLine();
        }
    }
}
