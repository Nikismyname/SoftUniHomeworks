using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Wormhole
{
    //11:46 - 11:56 - 10 min
    public class Program
    {
        public static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int steps = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != 0)
                {
                    int currInd = i;
                    i = nums[i] - 1;
                    nums[currInd] = 0;
                }
                else
                {
                    if(i == nums.Length-1)
                    {
                        Console.WriteLine(steps+1);
                        break;
                    }

                    steps++;
                }
            }
            //Console.ReadLine();
        }
    }
}
