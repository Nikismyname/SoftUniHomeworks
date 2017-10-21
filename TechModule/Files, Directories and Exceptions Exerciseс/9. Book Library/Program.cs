﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _9.Book_Library
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

            var authDict = new Dictionary<string, double>();
            foreach (var item in lib.books)
            {
                if (!authDict.ContainsKey(item.author))
                {
                    authDict[item.author] = 0;
                }
                authDict[item.author] += item.price;
            }

            foreach (var item in authDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                File.AppendAllText("output.txt",$"{item.Key} -> {item.Value.ToString("0.00")}" + Environment.NewLine);
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

        public Book(string title, string author, string publisher, string releaseDate, string ISBNnumber, double price)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.releaseDate = releaseDate;
            this.ISBNnumber = ISBNnumber;
            this.price = price;
        }
    }
}
