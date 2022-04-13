using System;
using System.Collections.Generic;

namespace T06EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {

            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            HashSet<Person> peopleSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                Person newPerson = new Person(name, age);
                sortedPeople.Add(newPerson);
                peopleSet.Add(newPerson);

            }

            Console.WriteLine(sortedPeople.Count);

            Console.WriteLine(peopleSet.Count);

        }
    }
}
