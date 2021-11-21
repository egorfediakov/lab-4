using System;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics;
namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listT = new List<int>();
            int[] array = new int[8] { -4, 8, 9, 3, 4, 78, 0, 13 };
            StatMethod(listT, array);

            Console.ReadKey();
        }
        public static void StatMethod(List<int> listT, int[] array)
        {
            GeneralClass generalClass = new GeneralClass(listT, array);
            generalClass.MyMethod();
            Console.Write("\n");
            Console.Write("Possibility of inheritance (yes/no):");

            string answer = Console.ReadLine();
            if (answer == "yes")
            {
                InherMeth(listT, array);
            }
            else
            {
                Console.WriteLine("The end...");
            }

        }
        public static void InherMeth(List<int> listT, int[] array)
        {
            string field = "Inherited class";
            NonGeneral nonGeneral = new NonGeneral(listT, array, field);
            nonGeneral.PropBase();
        }
    }
    class GeneralClass
    {
        List<int> myList { get; set; }
        public int[] Mymassive { get; set; }
        public GeneralClass(List<int> myList, int[] mamas)
        {
            this.myList = myList;
            Mymassive = mamas;
        }
        public void MyMethod()
        {
            myList.AddRange(Mymassive);
            foreach (int i in myList)
            {
                Console.Write(i + "\t");
            }
        }
    }
    class NonGeneral : GeneralClass
    {
        public string Field { get; set; }
        public NonGeneral(List<int> myList, int[] mamas, string field)
            : base(myList, mamas)
        {
            this.Field = field;
        }

        public void PropBase()
        {
            Console.Write("\n");
            Console.WriteLine($"Welcome to {Field}");
            //Рефлексия
            Type type = typeof(NonGeneral);
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
}
