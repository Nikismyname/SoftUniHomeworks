using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Elevator
{
    class Program
    {
        static void Main()
        {
            int nOfP = int.Parse(Console.ReadLine());
            int cap = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling((double)nOfP/cap));
        }
    }
}
