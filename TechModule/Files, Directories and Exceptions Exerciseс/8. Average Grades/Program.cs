using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _8.Average_Grades
{
    public class Program
    {
        public static void Main()
        {
            File.Delete("output.txt");
            var allLines = File.ReadAllLines("input.txt");

            var studentsList = new List<Student>();
  
            int n = int.Parse(allLines[0]);

            for (int i = 1; i <= n; i++)
            {
                var tokens = allLines[i].Split().ToArray();
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
                File.AppendAllText("output.txt",$"{item.name} -> {item.averageGrade.ToString("0.00")}" + Environment.NewLine);
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
