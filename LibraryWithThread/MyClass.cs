using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithThread
{
    class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public Book(int id, string title)
        {
            BookId = id;
            Title = title;
        }

    }

    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        List<Book> BooksBorrowed = new List<Book>();


        public Student(int id, string name)
        {
            StudentId = id;
            Name = name;
        }

        public Student()
        {
        }
    }
}
