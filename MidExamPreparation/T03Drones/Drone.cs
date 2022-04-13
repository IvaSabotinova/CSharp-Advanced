using System.Text;

namespace Drones
{
    public class Drone
    {
        private bool available;

        public string Name { get; set; }
        public string Brand { get;set;}
        public int Range { get; set; }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Available = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {Name}");
            sb.AppendLine($"Manufactured by: {Brand}");
            sb.Append($"Range: {Range} kilometers");
            return sb.ToString();
        }
    }
}
