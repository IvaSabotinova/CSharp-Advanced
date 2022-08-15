using System;
using System.Linq;

namespace T02Parking_Feud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] parkingDimensionsInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int SamLane = int.Parse(Console.ReadLine());
            int totalDistance = 0;
            while (true)
            {
                string[] allParkingCoordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string SamParkingSpot = allParkingCoordinates[SamLane - 1];

                bool IsSamParkingSpotRepetative = false;
                int count = 0;
                string otherCarParkingSpot = null;
                int otherCarWithSameParkingLotLane = 0;
               
                for (int i = 0; i < allParkingCoordinates.Length; i++)
                {
                    if (SamParkingSpot == allParkingCoordinates[i])
                    {
                        count++;
                        if (count >= 1 && SamLane - 1 != i)
                        {
                            IsSamParkingSpotRepetative = true;
                            otherCarWithSameParkingLotLane = i + 1;
                            otherCarParkingSpot = allParkingCoordinates[i];

                        }
                    }
                }
                      
                int currentSamDistance = CalculateDistance(SamLane, SamParkingSpot, parkingDimensionsInput);
               
                if (IsSamParkingSpotRepetative)
                {
                    int otherCarDistance = CalculateDistance(otherCarWithSameParkingLotLane, otherCarParkingSpot, 
                                parkingDimensionsInput);
                    if (otherCarDistance < currentSamDistance)
                    {
                        totalDistance += currentSamDistance * 2;
                    }
                    else
                    {

                        totalDistance += currentSamDistance;
                        Console.WriteLine($"Parked successfully at {SamParkingSpot}.");
                        Console.WriteLine($"Total Distance Passed: {totalDistance}");
                        return;
                    }

                }
                else
                {
                   totalDistance += currentSamDistance;
                    Console.WriteLine($"Parked successfully at {SamParkingSpot}.");
                    Console.WriteLine($"Total Distance Passed: {totalDistance}");
                    return;
                }

            }

        }

        private static int CalculateDistance(int lane, string parkingSpot, int[] parkingDimensionsInput)
        {
            int distance = 0;
            int parkingSpotColumn = parkingSpot[0] - 64;
            int parkingSpotRow = int.Parse(parkingSpot[1].ToString());
            int rowsDifference = Math.Abs(lane - parkingSpotRow);
            if (lane == parkingSpotRow || parkingSpotRow - lane == 1)
            {
                distance = parkingSpotColumn;
            }
            else if (lane > parkingSpotRow)
            {
                if (rowsDifference % 2 == 0) //moves from left to the parking spot
                {
                    distance = rowsDifference * parkingDimensionsInput[1] + rowsDifference * 3 + parkingSpotColumn;
                }
                else //moves from right to the parking spot
                {
                    distance = rowsDifference * parkingDimensionsInput[1]  + rowsDifference * 3 + 
                        parkingDimensionsInput[1] - parkingSpotColumn + 1;
                }
            }
            else if(lane < parkingSpotRow)
            {
                if (rowsDifference % 2 == 0) //moves from right to the parking spot
                {
                    distance = (rowsDifference -1) * parkingDimensionsInput[1] + (rowsDifference - 1) * 3 + 
                        parkingDimensionsInput[1] - parkingSpotColumn + 1;
                }
                else //moves from left to the parking spot
                {
                    distance = (rowsDifference - 1) * parkingDimensionsInput[1] + (rowsDifference - 1) * 3 + 
                            parkingSpotColumn;
                }
            }
                       
            return distance;
        }
    }
}
