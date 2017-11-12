using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation_II
{
    class Program
    {
        static void Main()
        {
            ulong nOfDays = ulong.Parse(Console.ReadLine());
            ulong nOfParticipents = ulong.Parse(Console.ReadLine());
            ulong nOfLaps = ulong.Parse(Console.ReadLine());
            ulong trackLenght = ulong.Parse(Console.ReadLine());
            ulong trackCapacity = ulong.Parse(Console.ReadLine());
            //maybe decimal
            double moneyPerKm = double.Parse(Console.ReadLine());

            ulong overAllCapacity = nOfDays * trackCapacity;

            ulong peopleRunning = 0;

            if (overAllCapacity > nOfParticipents)
            {
                peopleRunning = nOfParticipents;
            }
            else
            {
                peopleRunning = overAllCapacity;
            }

            //maybe double
            double kmRan = (double)nOfLaps * trackLenght * peopleRunning / 1000d;

            double moneyMade = moneyPerKm * kmRan;

            Console.WriteLine($"Money raised: {moneyMade.ToString("0.00")}");
            //Console.ReadLine();
        }
    }
}
