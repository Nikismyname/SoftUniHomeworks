using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation_I
{
    class Program
    {
        static void Main()
        {
            long[] tokens = Console.ReadLine().Split(':').Select(long.Parse).ToArray();
            long nOfSteps = long.Parse(Console.ReadLine());
            long timePerStep = long.Parse(Console.ReadLine());

            long hour = tokens[0];
            long minutes = tokens[1];
            long seconds = tokens[2];

            long timeImSeconds =
                seconds +
                minutes * 60 +
                hour * 3600;

            long secondsOfTrevel = timePerStep * nOfSteps;

            long combinedTime = secondsOfTrevel + timeImSeconds;

            long finalSeconds = (long)(combinedTime % 60);
            combinedTime = combinedTime - finalSeconds;

            long finalMinutesInsSeconds = (long)(combinedTime % 3600);
            combinedTime = combinedTime - finalMinutesInsSeconds;

            long finalMinutes = finalMinutesInsSeconds / 60;

            long finalHours = (long)(combinedTime / 3600);
            finalHours = finalHours % 24;

            Console.WriteLine($"Time Arrival: {finalHours.ToString().PadLeft(2, '0')}:{finalMinutes.ToString().PadLeft(2, '0')}:{finalSeconds.ToString().PadLeft(2, '0')}");

            // Console.ReadLine();
        }
    }
}
