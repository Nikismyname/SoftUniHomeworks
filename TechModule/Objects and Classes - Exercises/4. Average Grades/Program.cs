using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Average_Grades
{
    class Program
    {
        static void Main()
        {
            var studentsList = new List<Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().ToArray();
                studentsList.Add(new Student(
                    tokens[0],
                    tokens.Skip(1).Select(double.Parse).ToList()
                    ));
            }

            var toPrint = studentsList.Where(x => x.averageGrade >= 5)
                .OrderBy(x => x.name)
                .ThenByDescending(x => x.averageGrade);

            foreach (var item in toPrint)
            {
                Console.WriteLine($"{item.name} -> {item.averageGrade.ToString("0.00")}");
            }
           // Console.ReadLine();
        }
    }
    public class Student
    {
        public string name;
        public List<double> grades;
        public Student(string Name, List<double> Grades)
        {
            name = Name;
            grades = Grades;
        }
        public double averageGrade
        {
            get
            {
                return grades.Sum(x => x) / grades.Count;
            }
        }
    }
}
