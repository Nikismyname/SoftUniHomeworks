using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Spyfer
{
    //15:33 - 15:57 24 min
    public class Program
    {
        public static void Main()
        {
            List<int> line = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < line.Count; i++)
            {
                int left = 0;
                int right = 0;
                bool leftThere = false;
                bool rightThere = false;

                if (i - 1 >= 0)
                {
                    left = line[i - 1];
                    leftThere = true;
                }
                if (i + 1 < line.Count)
                {
                    right = line[i + 1];
                    rightThere = true;
                }

                if (line[i] == right + left)
                {
                    if (rightThere)
                    {
                        line.RemoveAt(i + 1);
                    }
                    if (leftThere)
                    {
                        line.RemoveAt(i - 1);
                    }
                    i = -1;
                }
                else
                {

                    if (i == line.Count - 1)
                    {
                        Console.WriteLine(string.Join(" ", line));
                        break;
                    }
                }
            }
            //Console.ReadLine();
        }
    }
}
