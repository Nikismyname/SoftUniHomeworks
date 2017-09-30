using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Count_Working_Days
{
    class Program
    {
        static void Main()
        {
            var dateOne = Console.ReadLine().Split('-').Select(int.Parse).ToArray();
            var dateTwo = Console.ReadLine().Split('-').Select(int.Parse).ToArray();

            var startDate = new DateTime(dateOne[2], dateOne[1], dateOne[0]);
            var endDate = new DateTime(dateTwo[2], dateTwo[1], dateTwo[0]);
            int counter = 0;

            /*
            var holyD = Enumerable.Empty<object>()
             .Select(r => new { date = 0, month = 0 }) 
             .ToList();

            holyD.Add(new {date = 1,month = 1});
            holyD.Add(new { date = 3, month = 3 });
            holyD.Add(new { date = 1, month = 5 });
            holyD.Add(new { date = 6, month = 5 });
            holyD.Add(new { date = 24, month = 5 });
            holyD.Add(new { date = 6, month = 9 });
            holyD.Add(new { date = 22, month = 9 });
            holyD.Add(new { date = 1, month = 11 });
            holyD.Add(new { date = 24, month = 12 });
            holyD.Add(new { date = 25, month = 12 });
            holyD.Add(new { date = 26, month = 12 });
            */

            var array = new int[11, 2];
            array[0, 0] = 1; array[0, 1] = 1;
            array[1, 0] = 3; array[1, 1] = 3;
            array[2, 0] = 1; array[2, 1] = 5;
            array[3, 0] = 6; array[3, 1] = 5;
            array[4, 0] = 24; array[4, 1] = 5;
            array[5, 0] = 6; array[5, 1] = 9;
            array[6, 0] = 22; array[6, 1] = 9;
            array[7, 0] = 1; array[7, 1] = 11;
            array[8, 0] = 24; array[8, 1] = 12;
            array[9, 0] = 25; array[9, 1] = 12;
            array[10, 0] = 26; array[10, 1] = 12;

            var cashForEnd = endDate.AddDays(1);

            while (startDate != cashForEnd)
            {
                if (startDate.DayOfWeek.ToString() != "Saturday" && startDate.DayOfWeek.ToString() != "Sunday")
                {
                    bool isHoliday = false;

                    for (int i = 0; i < 11; i++)
                    {
                        if (startDate.Day == array[i,0]
                            && startDate.Month == array[i,1])
                        {
                            isHoliday = true;
                            break;
                        }
                    }
                    if(isHoliday == false)
                    {
                        counter++;
                    }
                }
                startDate = startDate.AddDays(1);
            }
            Console.WriteLine(counter);
           // Console.ReadLine();
        }
    }
}
