using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _10.Book_Library
{
    public class Program
    {
        public static void Main()
        {
            File.Delete("output.txt");
            var allLines = File.ReadAllLines("input.txt");

            var lib = new Library("test");
            int n = int.Parse(allLines[0]);

            for (int i = 1; i <= n; i++)
            {
                var t = allLines[i].Split().ToArray();
                lib.books.Add(new Book(t[0], t[1], t[2], t[3], t[4], double.Parse(t[5])));
            }

            var beforeDate = allLines.Last().Split('.').Select(int.Parse).ToArray();
            var selectedList = new List<Book>();
            foreach (var item in lib.books)
            {
                bool shouldBeAdded = true;
                if (beforeDate[2] > item.year) { shouldBeAdded = false; };
                if (beforeDate[2] == item.year)
                {
                    if (beforeDate[1] > item.month) { shouldBeAdded = false; };
                    if (beforeDate[1] == item.month)
                    {
                        //?
                        if (beforeDate[0] >= item.day) { shouldBeAdded = false; }
                    }
                }
                if (shouldBeAdded)
                {
                    selectedList.Add(item);
                }
            }

            foreach (var item in selectedList
                .OrderBy(x => x.year)
                .ThenBy(x => x.month)
                .ThenBy(x => x.day)
                .ThenBy(x => x.title))
            {
                File.AppendAllText("output.txt", $"{item.title} -> {item.releaseDate}"+ Environment.NewLine);
            }
        }
    }

    public class Library
    {
        public string name;
        public List<Book> books;
        public Library(string name)
        {
            this.name = name;
            books = new List<Book>();
        }
    }

    public class Book
    {
        public string title;
        public string author;
        public string publisher;
        public string releaseDate;
        public string ISBNnumber;
        public double price;

        public int day;
        public int month;
        public int year;

        public Book(string title, string author, string publisher, string releaseDate, string ISBNnumber, double price)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            releseDateSetter(releaseDate);
            this.ISBNnumber = ISBNnumber;
            this.price = price;
        }

        public void releseDateSetter(string input)
        {
            this.releaseDate = input;
            var tokens = input.Split('.').ToArray();
            this.year = int.Parse(tokens[2]);
            this.month = int.Parse(tokens[1]);
            this.day = int.Parse(tokens[0]);
        }
    }
}
