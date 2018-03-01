using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    public static class Program
    {
        public static void Main()
        {
            var field = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToList();
            //Console.WriteLine(string.Join(" ", field));
            string input = Console.ReadLine();
            while(input!= "3:1")
            {
                var tokens = input.Split();
                var comm = tokens[0];
                int ind1 = int.Parse(tokens[1]);
                int ind2 = int.Parse(tokens[2]);
                if(comm == "merge")
                {
                    if(ind1> field.Count-1||ind2 < 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if(ind1 < 0)
                    {
                        ind1 = 0;
                    }
                    if(ind2 >= field.Count)
                    {
                        ind2 = field.Count - 1;
                    }

                    for (int i = ind1+1; i <= ind2; i++)
                    {
                        field[ind1] = string.Concat(field[ind1], field[i]);
                    }
                    for (int i = ind2; i > ind1; i--)
                    {
                        field.RemoveAt(i);
                    }

                }
                if(comm == "divide")
                {
                    int part = ind2;
                    string toDivide = field[ind1];
                    if (toDivide.Length == 0)
                    {
                        //?????????
                    }
                    double numsPerPartition = (double)toDivide.Length / part;
                    List<string> result = new List<string>();
                    if(numsPerPartition%1 == 0)
                    {
                        for (int i = 0; i < part; i++)
                        {
                            result.Add(toDivide.Substring(i*(int)numsPerPartition,(int)numsPerPartition));
                        }
                    }
                    else
                    {
                        int floor = (int)Math.Floor(numsPerPartition);
                        for (int i = 0; i < part-1; i++)
                        {
                            result.Add(toDivide.Substring(i * floor, floor));
                        }
                        int taken = floor * (part - 1);
                        result.Add(toDivide.Substring(taken));
                    }

                    field.RemoveAt(ind1);
                    field.InsertRange(ind1,result);

                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",field));
            //Console.ReadLine();
        }
    }
}
