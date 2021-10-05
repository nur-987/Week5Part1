using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryWithThread
{
    class Program
    {
        public static List<Book> BookList = new List<Book>();
        public static List<Student> StudentList = new List<Student>();

        static void Main(string[] args)
        {
            AddingBooks(1, "Big Apple");
            AddingBooks(2, "House Renovations");
            AddingBooks(3, "Learning C#");
            AddingBooks(4, "Green PLanate");
            AddingBooks(5, "Money sense");

            AddingStudent(1, "Jane");
            AddingStudent(2, "Harry");
            AddingStudent(3, "Philip");
            AddingStudent(4, "Lea");
            AddingStudent(5, "April");

            Console.WriteLine("Welcome to Library.");

            Console.WriteLine("for loop message start running on thread async");
            Thread td = new Thread(new ThreadStart(Message));
            td.Start();

            bool b = true;
            while (b)
            {
                Console.WriteLine("Would you like to BORROW? Y/N");
                string input = Console.ReadLine();
                if (input == "Y")
                {

                    Console.WriteLine("please input Student ID");
                    object tempId = Int32.Parse(Console.ReadLine());

                    //Use thread to check if student is eligible
                    Thread thParam = new Thread(new ParameterizedThreadStart(CheckEligibility));
                    thParam.Start(tempId);
                    thParam.Join();  //thread must sync with the previous and preceeding function.


                }
                else if (input == "N")
                {
                    b = false;
                    Console.WriteLine("closing...");
                    Console.ReadLine();

                }
                else
                {
                    throw new Exception("Input not applicable. Try again");
                    //wrong input. Not Y or N
                }
            }

        }

        public static void AddingBooks(int id, string title)
        {

            Book newBook = new Book(id, title)
            {
                BookId = id,
                Title = title,
            };
            BookList.Add(newBook);
        }
        public static void AddingStudent(int id, string name)
        {
            Student newStudent = new Student(id, name)
            {
                StudentId = id,
                Name = name
            };
            StudentList.Add(newStudent);
        }

        public static void CheckEligibility(object objId)
        {
            int intId = (int)objId;

            foreach (Student item in StudentList)
            {
                if (item.StudentId == intId)
                {
                    Console.WriteLine("Student is valid. You may proceed to borrow a book");
                    BorrowBook();
                }

            }
        }
        public static void BorrowBook()
        {
            Console.WriteLine("Here are the books available: ");

            foreach (Book item in BookList)
            {
                Console.Write("Book ID: " + item.BookId);
                Console.WriteLine(" - Title: " + item.Title);
            }

            Console.WriteLine("Please input the book ID that you would like to borrow");
            int input = Int32.Parse(Console.ReadLine());
        
            foreach (Book item in BookList)
            {
                if (input == item.BookId)
                {
                    Console.WriteLine("You Chose this book to borow");
                    Console.WriteLine(item.Title);

                    //not geting the current students id

                    //Student currenStud = new Student();
                    //Console.WriteLine(currenStud.StudentId);
                    //Console.WriteLine(currenStud.Name);

                }
            }

        }

        public static void Message()  //running in thread async
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("reading is FUN!");
                Thread.Sleep(2000);

            }
        }

    }
}
