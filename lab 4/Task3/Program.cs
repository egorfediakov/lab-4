using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            AllProff allProff = new AllProff();
            allProff.MethodD();
            allProff.MethodR();

            GetInfoAboutDProp();

            Console.ReadKey();
        }
        public static void GetInfoAboutDProp()
        {

            Console.WriteLine(new string('-', 30) + "All Properties" + "\n");
            Type type = typeof(Doctors);
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Property {propertyInfo.Name}, Type - {propertyInfo.PropertyType}");

                //Вывод в дебаг
                ConsoleColor tempColor = Console.ForegroundColor;
                StackTrace stackTrace = new StackTrace();
                Console.ForegroundColor = ConsoleColor.Red;
                System.Diagnostics.Debug.WriteLine($"Property {propertyInfo.Name}, Type - {propertyInfo.PropertyType}");
                Console.ForegroundColor = tempColor;
            }
        }
    }
    class Profession
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public string Position { get; set; }
        public string Education { get; set; }
    }
    class Doctors : Profession
    {
        public Doctors(string name, string education, string position)
        {
            this.Name = name;
            this.Education = education;
            this.Position = position;
        }
        public void MethodInfo()
        {
            Console.WriteLine($"Name - {Name}, Education - {Education}, Position - {Position}");
        }

    }
    class Realtors : Profession
    {
        public Realtors(string name, int salary, int exp, string company)
        {
            this.Name = name;
            this.Salary = salary;
            this.Experience = exp;
            this.Company = company;
        }
        public void MethodInfo()
        {
            Console.WriteLine($"Name - {Name}, Salary - {Salary}, Experience - {Experience} years, Company - {Company}");
        }
    }
    class AllProff
    {
        public void MethodD()
        {
            List<Doctors> doctors = new List<Doctors>();
            doctors.Add(new Doctors("Doctor1", "veterinarian", "chief physician"));
            doctors.Add(new Doctors("Doctor2", "gynecologist", "trainee"));

            foreach (Doctors people in doctors)
            {
                people.MethodInfo();
            }
        }
        public void MethodR()
        {
            List<Realtors> realtors = new List<Realtors>();
            realtors.Add(new Realtors("Realtors1", 40000, 5, "Company1"));
            realtors.Add(new Realtors("Realtors2", 20000, 9, "Company2"));

            foreach (Realtors people in realtors)
            {
                people.MethodInfo();

            }
        }
    }
}
