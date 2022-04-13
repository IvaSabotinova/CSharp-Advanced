using System;
using System.Collections.Generic;

namespace T05ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            List<Person> allPersons = new List<Person>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person newPerson = new Person(name, age, town);

                allPersons.Add(newPerson);
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            int equal = 0;
            int unequal = 0;

            foreach (Person person in allPersons)
            {
                if (allPersons[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                {
                    unequal++;
                }
            }

            if (equal == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {unequal} {allPersons.Count}");
            }
            
        }
    }
}
