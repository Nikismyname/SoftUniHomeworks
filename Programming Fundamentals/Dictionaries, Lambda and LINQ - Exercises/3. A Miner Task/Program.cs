using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.A_Miner_Task
{
    class Program
    {
        static void Main()
        {
            var resources = new Dictionary<string, double>();
            string input = Console.ReadLine();
            while(input!= "stop")
            {
                double qtt = double.Parse(Console.ReadLine());
                if (!resources.ContainsKey(input))
                {
                    resources[input] = 0;
                }
                resources[input] += qtt;
                input = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
            //Console.ReadLine();
        }
    }
}
