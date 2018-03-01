using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Intersection_of_Circles
{
    class Program
    {
        static void Main()
        {
            var one = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var two = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Circle c1 = new Circle(new V2D(one[0],one[1]),one[2]);
            Circle c2 = new Circle(new V2D(two[0], two[1]), two[2]);

            if (doTheyIntersect(c1, c2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            //Console.ReadLine();
        }

        public static bool doTheyIntersect(Circle one, Circle two)
        {
            double distance = Math.Sqrt(Math.Pow(one.center.X - two.center.X,2) + Math.Pow(one.center.Y - two.center.Y, 2));
            if(distance<= one.radious + two.radious)
            {
                return true;
            }
            return false;
        }
    }

    public class Circle
    {
        public V2D center;
        public double radious;
        public Circle(V2D Center, double Radious)
        {
            center = Center;
            radious = Radious;
        }
    }

    public class V2D
    {
        public double X;
        public double Y;
        public V2D(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
