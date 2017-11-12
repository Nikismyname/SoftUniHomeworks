using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _4.Max_Sequence_of_Equal_Elements
{
    public class Program
    {
        public static void Main()
        {
            File.Delete("output.txt");

            int[] nums = File.ReadAllText("input.txt").Split().Select(int.Parse).ToArray();

            int maxLenght = 0;
            int maxChar = -1;
            int localLenght = 0;
            int localChar = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != localChar)
                {
                    if (maxLenght < localLenght)
                    {
                        maxLenght = localLenght;
                        maxChar = localChar;
                    }

                    localLenght = 1;
                    localChar = nums[i];
                }
                else
                {
                    localLenght++;
                    if (i == nums.Length - 1)
                    {
                        if (maxLenght < localLenght)
                        {
                            maxLenght = localLenght;
                            maxChar = localChar;
                        }
                    }
                }
            }

            string result = string.Empty;
            for (int i = 0; i < maxLenght; i++)
            {
                result += (maxChar + " ");
            }

            File.WriteAllText("output.txt", result);
        }
    }
}
