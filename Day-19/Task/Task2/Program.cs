namespace Task2
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new Stack<string>();
            people.Push("Ahmed");
            people.Push("Mohammed");
            people.Push("noouh");


            Console.WriteLine(people.GetNameMo(p=>p == "Mohammed"));

        }
    }
}