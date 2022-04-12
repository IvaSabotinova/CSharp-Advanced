using System;


namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public Tyre[] Tyres { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tyre[] tyres)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tyres = tyres;
        }

     }

    public class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }
        public int Speed { get; set; }
        public int Power { get; set; }

    }


    public class Cargo
    {
        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }
        public string Type { get; set; }
        public int Weight { get; set; }

    }

    public class Tyre
    {
      
        public Tyre(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }
        public int Age { get; set; }
        public double Pressure { get; set; }

    }

}

