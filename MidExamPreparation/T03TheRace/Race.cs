using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
       
        private List<Racer> data;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public List<Racer> Data
        {
            get { return this.data; }
            //set { data = value; }
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Racer Racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racerToRemove = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(racerToRemove);
        }

        public Racer GetOldestRacer()
        {
            Racer oldestRacer = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            Racer racer = data.FirstOrDefault(x => x.Name == name);
            return racer;
        }

        public Racer GetFastestRacer()
        {
            Racer fastestCarRacer = data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
            return fastestCarRacer;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (Racer racer in data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
        
    }
}
