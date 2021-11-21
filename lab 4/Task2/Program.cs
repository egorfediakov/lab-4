using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            A aclass = new A();
            aclass.Info();
            Console.ReadKey();
        }
    }
    class A
    {
        DetectBook detectBook = new DetectBook("Book1", 1988, "Author1");
        NovBook novBook = new NovBook("Book2", 1928, "Author2");
        FanBook fan = new FanBook("Book3", 1909, "Author3");
        public A()
        { }

        public A(DetectBook detectBook, NovBook novBook, FanBook fanBook)
        {
            this.detectBook = detectBook;
            this.novBook = novBook;
            this.fan = fanBook;
        }

        public void Info()
        {
            detectBook.Detectives();
            Console.Write("\n");
            novBook.Novels();
            Console.Write("\n");
            fan.Fantastic();
        }
    }
    class Library
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public Library(string name, int year, string author)
        {
            this.Name = name;
            this.Year = year;
            this.Author = author;
        }

        public virtual void Detectives()
        {
            Console.WriteLine("Detective adventures are waiting for you");
        }
        public virtual void Novels()
        {
            Console.WriteLine("Any novels you like");
        }
        public virtual void Fantastic()
        {
            Console.WriteLine("Do you like science fiction?");
        }
    }
    class DetectBook : Library
    {
        public DetectBook(string name, int year, string author)
            : base(name, year, author)
        { }

        public override void Detectives()
        {
            base.Detectives();
            Console.WriteLine($"Name - {Name}, Author - {Author} , Year - {Year}");
        }
    }
    class NovBook : Library
    {
        public NovBook(string name, int year, string author)
           : base(name, year, author)
        { }

        public override void Novels()
        {
            base.Novels();
            Console.WriteLine($"Name - {Name}, Author - {Author} , Year - {Year}");
        }

    }
    class FanBook : Library
    {
        public FanBook(string name, int year, string author)
           : base(name, year, author)
        { }
        public override void Fantastic()
        {
            base.Fantastic();
            Console.WriteLine($"Name - {Name}, Author - {Author} , Year - {Year}");
        }

    }
}
