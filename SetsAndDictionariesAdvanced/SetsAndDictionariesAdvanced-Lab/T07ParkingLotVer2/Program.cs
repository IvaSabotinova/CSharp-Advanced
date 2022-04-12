using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T07ParkingLotVer2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            HashSet<string> carPlatesNumbers = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {

                string[] tokens = Regex.Split(input, ", ");
                if (tokens[0] == "IN")
                {
                    carPlatesNumbers.Add(tokens[1]);
                }
                else
                {
                    carPlatesNumbers.Remove(tokens[1]);
                }


            }

            if (carPlatesNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string car in carPlatesNumbers)
                {
                    Console.WriteLine(car);
                }
            }






        }
    }
}
