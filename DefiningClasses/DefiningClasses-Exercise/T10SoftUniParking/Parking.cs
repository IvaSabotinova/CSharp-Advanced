using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> allCars;

        private int capacity;
        public int Count => allCars.Count;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            allCars = new List<Car>();
        }

        public string AddCar(Car car)
        {

            if (allCars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (allCars.Count >= capacity)
            {
                return "Parking is full!";
            }

            allCars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (!allCars.Any(x => x.RegistrationNumber == RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            Car car = allCars.First(x => x.RegistrationNumber == RegistrationNumber);
            allCars.Remove(car);
            return $"Successfully removed {RegistrationNumber}";

        }

        public Car GetCar(string RegistrationNumber)
        {
            Car car = allCars.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumber);
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < RegistrationNumbers.Count; i++)
            {
                Car car = allCars.FirstOrDefault(x => x.RegistrationNumber == RegistrationNumbers[i]);
                allCars.Remove(car);
            }

        }

    }
}
