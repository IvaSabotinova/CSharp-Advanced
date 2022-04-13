using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        
        //private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Ski>();
        }
        public List<Ski> Data { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;

        public void Add(Ski ski)
        {
            if (Count < Capacity)
            {
                Data.Add(ski);
            }
        }
       
       
        public bool Remove(string manufacturer, string model)
        {
            if (Data.Any(x=>x.Manufacturer == manufacturer && x.Model == model))
            {
                Ski ski = Data.First(x => x.Manufacturer == manufacturer && x.Model == model);
                Data.Remove(ski);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if (Data.Count > 0)
            {
                Ski skiToRemove = Data.OrderByDescending(x => x.Year).First();
                return skiToRemove;
            }

            return null;
            }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            return ski;
        }
       
       public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");
            foreach (Ski item in Data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
