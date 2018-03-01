using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Fix_Emails
{
    class Program
    {
        static void Main()
        {
            var endings = new string[] { "uk", "us" };
            var emails = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while(input != "stop")
            {
                string email = Console.ReadLine();
                if (!endings.Contains(email.Substring(email.Length - 2, 2).ToLower()))
                {
                    emails[input] = email;
                }
                input = Console.ReadLine();
            }
            foreach (var email in emails)
            {
                Console.WriteLine($"{email.Key} -> {email.Value}");
            }
            //Console.ReadLine();
        }
    }
}
