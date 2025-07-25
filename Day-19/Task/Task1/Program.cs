namespace Task1
{
    using System;
    using System.Collections.Generic;
    

    public class Program
    {
        public static void Main(string[] args)
        {
            var people = new Queue<Person>();
            people.Enqueue(new Person { Name = "test", Gender = "Female" });
            people.Enqueue(new Person { Name = "Ahmed", Gender = "Male" });
            
            
            string firstMale = people.GetName(p => p.Gender == "Male");
            Console.WriteLine(firstMale);

        }
    }
}