using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1___Wormtest
{
    //10:48 - 11:04 - 16 min

    public class Program
    {
        public static void Main()
        {
            int lengthInM = int.Parse(Console.ReadLine());
            double widthInCm = double.Parse(Console.ReadLine());

            long lengthInCm = (long)lengthInM * 100;
            double remainder = (double)lengthInCm % widthInCm;
            if (remainder == 0 || widthInCm == 0)
            {
                double product = lengthInCm * widthInCm;
                Console.WriteLine(product.ToString("f2"));
            }
            else
            {
                double percentage = (double)lengthInCm  /widthInCm  * 100;
                Console.WriteLine(percentage.ToString("f2")+ "%");
            }
           // Console.ReadLine();
        }
    }
}
