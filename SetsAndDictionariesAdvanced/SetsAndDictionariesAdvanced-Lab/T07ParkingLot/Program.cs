using System;
using System.Collections.Generic;

namespace T07ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = String.Empty;
            HashSet<string> carsPlateNumbers = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = tokens[0];
                string carPlateNumber = tokens[1];

                if (direction == "IN")
                {
                    carsPlateNumbers.Add(carPlateNumber);
                }
                else
                {
                    carsPlateNumbers.Remove(carPlateNumber);
                }
            }

            if (carsPlateNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (string car in carsPlateNumbers)
            {
                Console.WriteLine(car);
            }
            
        }
    }
}
