using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Pesho", 20);

            Console.WriteLine(person1.Name);
            Console.WriteLine(person1.Age);

           

        }
    }
}