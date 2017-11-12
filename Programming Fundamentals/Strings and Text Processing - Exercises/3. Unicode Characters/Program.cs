using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Unicode_Characters
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
      
            var chars = str
                .Select(c => (int)c)
                .Select(c => $@"\u{c:x4}");

            var result = string.Concat(chars);
            Console.WriteLine(result);
            //Console.ReadLine();
        }
    }
}
