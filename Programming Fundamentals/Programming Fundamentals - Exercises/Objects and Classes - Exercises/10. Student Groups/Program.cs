using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Student_Groups
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Town> towns = new List<Town>();

            while (input!= "End")
            {
                if (input.Contains("=>"))
                {
                    var tokens1 = input.Split(new string[] {"=>"},StringSplitOptions.None);
                    var town = tokens1[0].Trim();
                    var labCap = int.Parse(tokens1[1]
                        .Split(new char[] {' ' },StringSplitOptions.RemoveEmptyEntries)
                        .First());
                    towns.Add(new Town(town,labCap));
                }
                else
                {
                    var tokens = input.Split('|').Select(x => x.Trim()).ToArray();
                    var name = tokens[0];
                    var email = tokens[1];
                    var date = DateTime.Parse(tokens[2]);
                    towns[towns.Count - 1].students.Add(new Student(name,email,date));
                }
                input = Console.ReadLine();
            }
            int nOfGroups = 0;
            foreach (var item in towns)
            {
                nOfGroups += item.NumberOfGroups();
            }
            Console.WriteLine($"Created {nOfGroups} groups in {towns.Count} towns:");

            foreach (var item in towns.OrderBy(x=>x.name))
            {
                item.PrintGroups();
            }
           // Console.ReadLine(); 
        }
    }

    public class Town
    {
        public string name;
        public int labCap;
        public List<Student> students = new List<Student>(); 
        public Town(string Name,int LabCap)
        {
            this.name = Name;
            this.labCap = LabCap;
        }

        public int NumberOfGroups()
        {
            return (int)Math.Ceiling((double)this.students.Count / labCap);
        } 

        public void PrintGroups()
        {
            students =  students
                .OrderBy(x=>x.regDate)
                .ThenBy(x=>x.name)
                .ThenBy(x=>x.email)
                .ToList();
            for (int i = 0; i < NumberOfGroups(); i++)
            {
                var emailsToPrint = students.Skip(labCap * i).Take(labCap).Select(x => x.email).ToArray();
                Console.WriteLine($"{this.name} => {string.Join(", ", emailsToPrint)}");
            }
        }
    }

    public class Student
    {
        public string name;
        public DateTime regDate;
        public string email;
        public Student(string Name, string Email, DateTime RegDate)
        {
            this.name = Name;
            this.email = Email;
            this.regDate = RegDate;
        }
    }
}
