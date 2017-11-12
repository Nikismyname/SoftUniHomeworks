using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Centuries_to_Minutes
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int years = n*100;
            int days = (int)(years * 365.2422);
            long hours = days * 24;
            long minutes = hours * 60;
            Console.WriteLine($"{n} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
