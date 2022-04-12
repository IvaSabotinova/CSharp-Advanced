using System;
using System.Collections.Generic;

using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());

            List<Car> allCars = new List<Car>();

            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car newCar = new Car(model, fuelAmount, fuelConsumption);
                allCars.Add(newCar);
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = tokens[1];
                int amountOfKm = int.Parse(tokens[2]);

                Car car = allCars.Where(x => x.Model == carModel).FirstOrDefault();

                car.Drive(amountOfKm);


            }

            foreach (Car car in allCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }


        }
    }
}
