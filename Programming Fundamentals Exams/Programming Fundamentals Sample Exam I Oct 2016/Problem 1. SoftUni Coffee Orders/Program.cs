using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.SoftUni_Coffee_Orders
{
    //15:25 - 15:45
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCap = decimal.Parse(Console.ReadLine());
                var date = Console.ReadLine();
                var tokens = date.Split('/');
                var month = int.Parse(tokens[1]);
                var year = int.Parse(tokens[2]);

                int capsuleCount = int.Parse(Console.ReadLine());
                decimal price = (decimal)DateTime.DaysInMonth(year,month)*(decimal)capsuleCount*pricePerCap;
                Console.WriteLine($"The price for the coffee is: ${price.ToString("0.00")}");
                totalPrice += price;
            }
            Console.WriteLine($"Total: ${totalPrice.ToString("0.00")}");
            //Console.ReadLine();
        }
    }
}
