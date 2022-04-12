using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                

                string name = input[0];
                int age = int.Parse(input[1]);
                Person newPerson = new Person(name, age);
                family.AddMember(newPerson);
            }

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");



        }
    }
}