using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Nether_Realms
{
    //11:04 - 11:42
    public class Program
    {
        public static void Main()
        {
            var dict = new Dictionary<string, double[]>();
            string[] names;

            try
            {
                names = Console.ReadLine()
                   .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                names = new string[] {"gosho" };
            }

            foreach (var name in names)
            {
                string nonHealth = "*/+-.0123456789";
                string demage = ".0123456789";
                string demage2 = "0123456789";

                var multi = new List<char>();
                var demageParts = new List<double>();
                long health = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    if (!nonHealth.Contains(name[i]))
                    {
                        health += (int)(name[i]);
                    }

                    if(name[i] == '/'||name[i] == '*')
                    {
                        multi.Add(name[i]);
                    }

                    if (demage2.Contains(name[i]))
                    {
                        var chars = new List<char>();

                        if(i-1>=0)
                        if(name[i-1] == '-'|| name[i-1]== '+')
                        {
                            chars.Add(name[i - 1]);
                        } 

                        for (int j = i; j < name.Length; j++)
                        {
                            if (demage.Contains(name[j]))
                            {
                                chars.Add(name[j]);
                            }
                            else
                            {
                                demageParts.Add(double.Parse(new string(chars.ToArray())));
                                i = j - 1;
                                break;
                            }

                            if (j == name.Length - 1)
                            {
                                demageParts.Add(double.Parse(new string(chars.ToArray())));
                                i = j;
                                break;
                            }
                        }
                    }
                }
                double dem = demageParts.Sum();
                foreach (var item in multi)
                {
                    if (item == '/') { dem /= 2; }
                    else if (item == '*'){ dem *= 2; }
                }
                dict[name] = new double[] { health, dem };
            }
            foreach (var item in dict.OrderBy(c=>c.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value[0]} health, {item.Value[1].ToString("0.00")} damage");
            }
            //Console.ReadLine();
        }
    }
}
