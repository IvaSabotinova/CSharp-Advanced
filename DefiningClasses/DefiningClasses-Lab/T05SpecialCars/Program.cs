using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string command1;
            List<Tire[]> alltyres = new List<Tire[]>();

            while ((command1 = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = command1.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(tokens[0]), double.Parse(tokens[1])),
                    new Tire(int.Parse(tokens[2]), double.Parse(tokens[3])),
                    new Tire(int.Parse(tokens[4]), double.Parse(tokens[5])),
                    new Tire(int.Parse(tokens[6]), double.Parse(tokens[7]))
                };
                alltyres.Add(tires);
            }

            string command2;

            List<Engine> allEngines = new List<Engine>();

            while ((command2 = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = command2.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine newEngine = new Engine(int.Parse(tokens[0]), double.Parse(tokens[1]));

                allEngines.Add(newEngine);
            }

            string command3;

            List<Car> allCars = new List<Car>();

            while ((command3 = Console.ReadLine()) != "Show special")
            {
                string[] tokens = command3.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carMake = tokens[0];
                string carModel = tokens[1];
                int carYear = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car newCar = new Car(carMake, carModel, carYear, fuelQuantity, fuelConsumption, allEngines[engineIndex],
                    alltyres[tiresIndex]);

                allCars.Add(newCar);
            }

            List<Car> filteredCars = allCars.Where(x =>
                x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >= 9 &&
                x.Tires.Sum(y => y.Pressure) <= 10).ToList();

            foreach (Car car in filteredCars)
            {
                car.FuelQuantity -= car.FuelConsumption / 100 * 20;

                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");

            }

        }
    }
}
