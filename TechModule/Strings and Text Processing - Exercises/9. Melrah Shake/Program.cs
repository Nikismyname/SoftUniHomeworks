using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Melrah_Shake
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();

            int counter = 0;
            while (true)
            {
                counter++;
                if (counter > 1000)
                {
                    Console.WriteLine("ct");
                    break;
                }

                int firstOcc = text.IndexOf(pattern);
                int lastOcc = text.LastIndexOf(pattern);

                if(firstOcc != lastOcc)
                {
                    string firstSafePart = text.Substring(0,firstOcc);
                    string secondSafePart = text.Substring(firstOcc+ pattern.Length, lastOcc - (firstOcc + pattern.Length));
                    string thirdSafePart = text.Substring(lastOcc + pattern.Length, text.Length - (lastOcc + pattern.Length));

                    text = string.Concat(firstSafePart, secondSafePart, thirdSafePart);

                    List<char> newPattern = new List<char>();
                    int mid = (int)pattern.Length / 2;
                    for (int i = 0; i < pattern.Length; i++)
                    {
                        if(i!= mid)
                        {
                            newPattern.Add(pattern[i]);
                        }
                    }
                    pattern = new string(newPattern.ToArray());
                    Console.WriteLine("Shaked it.");

                    if(pattern.Length == 0)
                    {
                        Console.WriteLine("No shake.");
                        Console.WriteLine(text);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(text);
                    break;
                }
            }
            //Console.ReadLine();
        }
    }
}
