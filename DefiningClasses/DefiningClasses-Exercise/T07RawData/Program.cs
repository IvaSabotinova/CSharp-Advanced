using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int num = int.Parse(Console.ReadLine());
            List<Car> allCars = new List<Car>();

            for (int i = 0; i < num; i++)
            {
                
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tyre1Pressure = double.Parse(input[5]);
                int tyre1Age = int.Parse(input[6]);
                double tyre2Pressure = double.Parse(input[7]);
                int tyre2Age = int.Parse(input[8]);
                double tyre3Pressure = double.Parse(input[9]);
                int tyre3Age = int.Parse(input[10]);
                double tyre4Pressure = double.Parse(input[11]);
                int tyre4Age = int.Parse(input[12]);

                Tyre[] currCarTyres = new Tyre[4]
                {
                    new Tyre(tyre1Age, tyre1Pressure),
                    new Tyre(tyre2Age, tyre2Pressure),
                    new Tyre(tyre3Age, tyre3Pressure),
                    new Tyre(tyre4Age, tyre4Pressure)
                };
                Car currCar = new Car(carModel, new Engine(engineSpeed, enginePower), new Cargo(cargoType, cargoWeight),
                    currCarTyres);
                allCars.Add(currCar);
            }

            string fragileOrFlammable = Console.ReadLine();
            
            foreach (Car car in allCars.Where(x=>x.Cargo.Type == fragileOrFlammable))
            {
                if (fragileOrFlammable == "fragile" && car.Tyres.Any(x=>x.Pressure < 1))
                {
                    Console.WriteLine(car.Model);
                }
                else if (fragileOrFlammable == "flammable" && car.Engine.Power > 250)
                {
                    Console.WriteLine(car.Model);
                }
            }
            

        }
    }
}
