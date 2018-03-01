using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.SoftUni_Coffee_Orders
{
    //13.43 - 13.57
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal overAllPrice = 0;
            for (int i = 0; i < n; i++)
            {
                decimal pricePCap = decimal.Parse(Console.ReadLine());

                int[] dateTokens = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
                int nOfDays = DateTime.DaysInMonth(dateTokens[2], dateTokens[1]);

                int capCount = int.Parse(Console.ReadLine());
              
                decimal price = (((long)nOfDays * capCount) * pricePCap);
                overAllPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price.ToString("0.00")}");
            }
            Console.WriteLine($"Total: ${overAllPrice.ToString("0.00")}");
            //Console.ReadLine();
        }
    }
}
