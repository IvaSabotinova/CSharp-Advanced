
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones = new List<Drone>();

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;

        }

        public IReadOnlyCollection<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        public int Count => drones.Count;

        public string AddDrone(Drone drone)
        {
            if (drone.Name == null || drone.Brand == null || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (Count == Capacity)
            {
                return "Airfield is full.";
            }
            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (drones.Any(x => x.Name == name))
            {
                Drone droneToRemove = drones.First(x => x.Name == name);
                drones.Remove(droneToRemove);
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int countOfRemovedDrones = 0;
            List<Drone> removedDrones = drones.FindAll(x => x.Brand == brand);
            countOfRemovedDrones = removedDrones.Count;
            drones.RemoveAll(x => x.Brand == brand);
            return countOfRemovedDrones;
        }
        public Drone FlyDrone(string name)
        {
            if (drones.Any(x => x.Name == name))
            {
                Drone drone = drones.First(x => x.Name == name);
                drone.Available = false;
                return drone;
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flownDrones = drones.FindAll(x => x.Range >= range);
            flownDrones.Select(x => x.Available = false).ToList();
            return flownDrones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            List<Drone> dronesToReport = drones.Where(x => x.Available == true).ToList();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (Drone drone in dronesToReport)
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
