using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _3.Equal_Sums
{
    public class Program
    {
        public static void Main()
        {
            File.Delete("output.txt");
            var nums = File.ReadAllText("input.txt").Split().Select(int.Parse).ToArray();
            var l = nums.Length;
            bool gotOne = false;
            for (int i = 0; i < l; i++)
            {
                int left = 0;
                int right = 0;

                for (int j = 0; j < i; j++)
                {
                    left += nums[j];
                }

                for (int j = i + 1; j < l; j++)
                {
                    right += nums[j];
                }

                if (right == left)
                {
                    gotOne = true;
                    Console.WriteLine(i);
                    File.WriteAllText("output.txt",i.ToString());
                    break;
                }
            }
            if (!gotOne)
            {
                File.WriteAllText("output.txt", "no");
            }
        }
    }
}
