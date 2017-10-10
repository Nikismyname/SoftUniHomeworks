using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Sino_The_Walker
{
    //14:53 - 15:29
    public class Program
    {
        public static void Main()
        {
            string time = Console.ReadLine();
            int steps = int.Parse(Console.ReadLine());
            int secPerStep = int.Parse(Console.ReadLine());

            long extraSeconds = (long)steps * secPerStep;
            int[] parts = time.Split(':').Select(int.Parse).ToArray();
            long totalSecs =
                (long)parts[2] +
                (long)parts[1] * 60 +
                (long)parts[0] * 3600 
                + extraSeconds;

            long sec = totalSecs % 60;
            totalSecs -= sec;
            long mins = (totalSecs % 3600)/60;
            totalSecs -= mins * 60;
            long hours = totalSecs/3600;
            hours = hours % 24;

            var hoursl = hours.ToString().PadLeft(2, '0');
            var minsl = mins.ToString().PadLeft(2,'0');
            var secl = sec.ToString().PadLeft(2, '0');

            Console.WriteLine($"Time Arrival: {hoursl}:{minsl}:{secl}");
            Console.ReadLine();
        }
    }
}
