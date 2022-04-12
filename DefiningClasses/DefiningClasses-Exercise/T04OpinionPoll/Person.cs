using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age) : this()
        {
            Age = age;
        }

        public Person(string name, int age) : this(age)
        {
            Name = name;

        }

        public string Name
        {
            get { return name; }

            set { name = value; }

        }

        public int Age
        {
            get { return age; }

            set { age = value; }

        }
    }

    public class Family
    {

        public List<Person> allMembers = new List<Person>();

        public void AddMember(Person newMember)
        {
            allMembers.Add(newMember);
        }

        public List<Person> sorted()
        {
            List<Person> sortedMembers = allMembers.Where(x => x.Age > 30).OrderBy(x => x.Name).ToList();
            return sortedMembers;
        }
    }
}
