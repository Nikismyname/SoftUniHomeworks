using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Greeting
{
    class Program
    {
        static void Main()
        {
            string fName = Console.ReadLine();
            string lName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Hello, {0} {1}. You are {2} years old.",fName,lName,age);
        }
    }
}
