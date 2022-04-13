using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish = new List<Fish>();

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;

        }
        public IReadOnlyCollection<Fish> Fish => fish;

        public string Material { get; set; }
        public int Capacity { get; set; }

        public int Count => fish.Count;


        public string AddFish(Fish currfish)
        {
            if (Capacity == Count)
            {
                return "Fishing net is full.";
            }
            if (string.IsNullOrEmpty(currfish.FishType) || currfish.Length <= 0 || currfish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            fish.Add(currfish);
            return $"Successfully added {currfish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            return fish.Remove(fish.FirstOrDefault(x => x.Weight == weight));
        }

        public Fish GetFish(string fishType)
        {
            return fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            Fish biggest = fish.OrderByDescending(x => x.Length).FirstOrDefault();
            return biggest;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (Fish item in fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();

        }

    }
}
