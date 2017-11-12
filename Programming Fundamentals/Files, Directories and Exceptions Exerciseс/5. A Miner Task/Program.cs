using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _5.A_Miner_Task
{
    public class Program
    {
        public static void Main()
        {
            File.Delete("output.txt");
            var resources = new Dictionary<string, double>();

            var lines = File.ReadAllLines("input.txt");

            for (int i = 0; i < lines.Length; i+=2)
            {
                var input = lines[i];

                if(input == "stop")
                {
                    break;
                }

                double qtt = double.Parse(lines[i+1]);
                if (!resources.ContainsKey(input))
                {
                    resources[input] = 0;
                }
                resources[input] += qtt;
            }

            foreach (var resource in resources)
            {
                File.AppendAllText("output.txt",$"{resource.Key} -> {resource.Value}" + Environment.NewLine);
            }
        }
    }
}
