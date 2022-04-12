using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            Color = color;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.EngineModel}:");
            sb.AppendLine($"    Power: {Engine.EnginePower}");
            if (Engine.Displacement == 0)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {Engine.Displacement}");
            }

            if (Engine.Efficiency == null)
            {
                sb.AppendLine($"    Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
            }

            if (Weight == 0)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {Weight}");
            }

            if (Color == null)
            {
                sb.AppendLine($"  Color: n/a");
            }
            else
            {
                sb.AppendLine($"  Color: {Color}");
            }

            return sb.ToString().TrimEnd();
        }
    }

    public class Engine
    {

        public string EngineModel { get; set; }
        public int EnginePower { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }


        public Engine(string engineModel, int enginePower)
        {
            EngineModel = engineModel;
            EnginePower = enginePower;
        }

        public Engine(string engineModel, int enginePower, int engineDisplacement) : this(engineModel, enginePower)
        {
            Displacement = engineDisplacement;
        }

        public Engine(string engineModel, int enginePower, string efficiency) : this(engineModel, enginePower)
        {
            Efficiency = efficiency;
        }

        public Engine(string engineModel, int enginePower, int engineDisplacement, string engineEfficiency) : this(engineModel, enginePower, engineDisplacement)
        {
            Efficiency = engineEfficiency;
        }
    }
}
