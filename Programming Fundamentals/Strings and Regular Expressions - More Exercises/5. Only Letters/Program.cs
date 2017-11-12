using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _5.Only_Letters
{
    class Program
    {
        static void Main()
        {
            var text1 = Console.ReadLine();
            text1 = Regex.Replace(text1,@"[0-9]+(?=[^0-9])","1");
            var text = text1.ToCharArray();
            
            for (int i = 0; i < text.Length; i++)
            {
                char lChar = text[i];
                if (Char.IsDigit(lChar))
                {
                    for (int j = i+1; j < text.Length; j++)
                    {
                        if (Char.IsLetter(text[j]))
                        {
                            text[i] = text[j];
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join("", text));
           // Console.ReadLine();
        }
    }
}
