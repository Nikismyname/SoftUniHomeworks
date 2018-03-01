using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Entertrain
{   //18:19 - 18:35 - 16m;
    public class Program
    {
        public static void Main()
        {
            int power = int.Parse(Console.ReadLine());
            List<int> waggons = new List<int>();
            string input = String.Empty;
            while ((input = Console.ReadLine()) != "All ofboard!")
            {
                int num = int.Parse(input);
                waggons.Add(num);
                if(waggons.Sum()> power)
                {
                    double avarage = waggons.Average();
                    List<double> diff = waggons.Select(x=>Math.Abs(x-avarage)).ToList();
                    double min = diff.Min();
                    int minInd = diff.IndexOf(min);
                    waggons.RemoveAt(minInd);
                }
            }
            waggons.Reverse();
            Console.WriteLine(string.Join(" ",waggons) + " "+power);
            //Console.ReadLine();
        }
    }
}
