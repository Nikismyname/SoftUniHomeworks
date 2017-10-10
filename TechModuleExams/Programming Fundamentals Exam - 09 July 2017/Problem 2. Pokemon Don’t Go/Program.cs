using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Pokemon_Don_t_Go
{ 
    //18:11 18:35 bug hunting 18:40 got it 29m
    public class Program
    {
        public static void Main()
        {
            List<long> dist = Console.ReadLine()
                .Split(new char[] {' ','\t','\n'},StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            long sum = 0;

            while (dist.Count>0)
            {
                int ind = int.Parse(Console.ReadLine());
                if (ind < 0)
                {
                    long val = dist[0];
                    sum += val;


                    dist[0] = dist[dist.Count - 1];


                    Adjust(val);
                }
                
                if(ind >= dist.Count)
                {
                    long val = dist[dist.Count-1];
                    sum += val;
                    try
                    {
                        dist[dist.Count - 1] = dist[0];
                    }
                    catch { }
                    Adjust(val);
                }

                if(ind>=0 && ind< dist.Count)
                {
                    long val = dist[ind];
                    sum += val;
                    try
                    {
                        dist.RemoveAt(ind);
                    }
                    catch { }
                    Adjust(val);
                }
                //Console.WriteLine(string.Join(" ", dist));
            }

            Console.WriteLine(sum);
            //Console.ReadLine();

            void Adjust(long n)
            {
                for (int i = 0; i < dist.Count; i++)
                {
                    if(dist[i] <= n)
                    {
                        dist[i] += n;
                    }
                    else
                    {
                        dist[i] -= n;
                    }
                }
            }
        }
    }
}
