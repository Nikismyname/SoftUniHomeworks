using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Charity_Marathon
{
    //18:59 - 19:12;
    public class Program
    {
        public static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            int nOfRunners = int.Parse(Console.ReadLine());
            int averageNumOfLaps = int.Parse(Console.ReadLine());
            int lenghtOfTrack = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            int maxRunners = days * capacity;
            int runningPeople = maxRunners < nOfRunners ? maxRunners : nOfRunners;
            double kilomRan = runningPeople * averageNumOfLaps * ((double)lenghtOfTrack / 1000);
            double money = moneyPerKm * kilomRan;
            Console.WriteLine("Money raised: "+money.ToString("0.00"));
            //Console.ReadLine();
        }
    }
}
