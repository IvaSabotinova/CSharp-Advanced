using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            Data = new List<Pet>();
            Capacity = capacity;
        }
        public List<Pet> Data { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                Data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (Data.Any(x => x.Name == name))
            {
                Pet pet = Data.First(x => x.Name == name);
                Data.Remove(pet);
                return true;
            }

            return false;
        }
       
        public Pet GetPet(string name, string owner)
        {
            Pet pet = Data.FirstOrDefault(x => x.Name == name && x.Owner == owner);
                return pet;
        }
       
        public Pet GetOldestPet()
        {
            Pet oldest = Data.OrderBy(x => x.Age).Last();
            return oldest;
        }
      
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in Data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
