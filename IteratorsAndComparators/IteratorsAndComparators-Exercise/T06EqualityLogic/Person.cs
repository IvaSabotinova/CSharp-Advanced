using System;


namespace T06EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }

            return Age.CompareTo(other.Age);
        }

        public override bool Equals(object obj)
        {
            Person man = obj as Person;
            if (man.Name == Name && man.Age == Age)
            {
                return true;
            }
            return false;

        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
    }
}
