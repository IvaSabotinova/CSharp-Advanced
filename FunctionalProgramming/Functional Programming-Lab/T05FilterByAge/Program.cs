using System;
using System.Collections.Generic;
using System.Linq;


namespace T05FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<(string name, int age), int, bool> filterYounger = (person, ageFilter) => person.age < ageFilter;
            Func<(string nameof, int age), int, bool> filterOlder = (person, ageFilter) => person.age >= ageFilter;

            int number = int.Parse(Console.ReadLine());

            List<(string name, int age)> persons = new List<(string name, int age)>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string currentName = input[0];
                int currentAge = int.Parse(input[1]);

                persons.Add((currentName, currentAge));
            }

            string filterByAge = Console.ReadLine();

            int ageToFilter = int.Parse(Console.ReadLine());

            string printFormat = Console.ReadLine();

            if (filterByAge == "younger")
            {
                persons = persons.Where(p => filterYounger(p, ageToFilter)).ToList();
            }
            else
            {
                persons = persons.Where(p => filterOlder(p, ageToFilter)).ToList();
            }

            foreach ((string name, int age) person in persons)
            {
                List<string> outPut = new List<string>();
                if (printFormat == "name")
                {
                    outPut.Add(person.name);
                }
                else if (printFormat == "name age")
                {
                    outPut.Add(person.name);
                    outPut.Add(person.age.ToString());
                }
                else if (printFormat == "age")
                {
                    outPut.Add(person.age.ToString());
                }

                Console.WriteLine(string.Join(" - ", outPut));

            }

        }
    }
}

