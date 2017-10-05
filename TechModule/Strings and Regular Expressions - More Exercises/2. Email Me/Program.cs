using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Email_Me
{
    class Program
    {
        static void Main()
        {
            var email = Console.ReadLine();
            var indexOfAt = email.IndexOf('@');
            var sumOne = email.Substring(0,indexOfAt).Sum(x=>x);
            var sumTwo = email.Substring(indexOfAt+1).Sum(x=>x);
            var result = sumOne - sumTwo;
            if(result>= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
            //Console.ReadLine();
        }
    }
}
