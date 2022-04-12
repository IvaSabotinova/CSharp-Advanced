using System;
using System.Collections.Generic;
using System.Linq;


namespace T05FilterByAgeVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string currentName = input[0];
                int currentAge = int.Parse(input[1]);
                Person person = new Person();
                person.Name = currentName;
                person.Age = currentAge;
                persons.Add(person);

            }

            string filter = Console.ReadLine();
            int ageToFilter = int.Parse(Console.ReadLine());
            Func<Person, bool> younger = p => true;
            Func<Person, bool> older = p => true;

            if (filter == "younger")
            {
                persons = persons.Where(younger = p => p.Age < ageToFilter).ToList();
            }
            else
            {
                persons = persons.Where(older = p => p.Age >= ageToFilter).ToList();
            }

            string print = Console.ReadLine();

            foreach (Person person in persons)
            {
                if (print == "name")
                {
                    Console.WriteLine($"{person.Name}");
                }
                else if (print == "name age")
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
                else
                {
                    Console.WriteLine($"{person.Age}");
                }
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}

