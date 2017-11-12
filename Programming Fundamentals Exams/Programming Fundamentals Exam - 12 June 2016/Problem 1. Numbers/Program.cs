using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Numbers
{
    //13:34 - 13:41
    public class Program
    {
        public static void Main()
        {
            int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] selectedIndts = ints.Where(x=>x > ints.Average()).OrderByDescending(x=>x).Take(5).ToArray();

            if (selectedIndts.Length == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine(string.Join(" ", selectedIndts));
            }
               
            //Console.ReadLine();
        }
    }
}
