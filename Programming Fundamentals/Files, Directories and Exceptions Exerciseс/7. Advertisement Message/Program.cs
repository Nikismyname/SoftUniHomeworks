using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _7.Advertisement_Message
{
    public class Program
    {
        public static void Main()
        {
            File.Delete("output.txt");

            var phrases = new[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            var events = new[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            var authors = new[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            var cities = new[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int n = int.Parse(File.ReadAllText("input.txt"));

            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                int pInd = rnd.Next(0, phrases.Length);
                int eInd = rnd.Next(0, events.Length);
                int aInd = rnd.Next(0, authors.Length);
                int cInd = rnd.Next(0, cities.Length);

                File.AppendAllText("output.txt",$"{phrases[pInd]} {events[eInd]} {authors[aInd]} – {cities[cInd]}." + Environment.NewLine);
            }
        }
    }
}
