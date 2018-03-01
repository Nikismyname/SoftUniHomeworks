using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    public class Program
    {
        public static void Main()
        {
            long N = long.Parse(Console.ReadLine());
            long FT = long.Parse(Console.ReadLine());
            long FF = long.Parse(Console.ReadLine());
            long UT = long.Parse(Console.ReadLine());

            long timeToFilter = N * FT;
            long NofPForUp = (long)Math.Ceiling((double)N * FF / 100d);
            long uploadTime = UT * NofPForUp;

            long overallTimeSec = timeToFilter + uploadTime;

            long seconds = overallTimeSec % 60;
            overallTimeSec = overallTimeSec - seconds;
            long minutes = (overallTimeSec % 3600) / 60;
            overallTimeSec = overallTimeSec - minutes * 60;
            long hours = (overallTimeSec % (24 * 3600)) / 3600;
            overallTimeSec = overallTimeSec - hours * 3600;
            long days = overallTimeSec / (24 * 3600);

            Console.WriteLine($"{days}:{hours.ToString().PadLeft(2, '0')}:{minutes.ToString().PadLeft(2, '0')}:{seconds.ToString().PadLeft(2, '0')}");


            //  Console.ReadLine();

        }
    }
}
