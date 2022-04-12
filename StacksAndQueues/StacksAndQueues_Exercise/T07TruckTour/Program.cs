using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T07TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStops = int.Parse(Console.ReadLine());

            Queue<int[]> fuel_Distance = new Queue<int[]>();


            for (int i = 0; i < numberOfStops; i++)
            {
                int[] petrolInPump_Distance = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                fuel_Distance.Enqueue(petrolInPump_Distance);
            }

            int index = 0;

            while (true)
            {
                int currentFuel = 0;
                foreach (int[] petrolStation in fuel_Distance)
                {
                    currentFuel += petrolStation[0];
                    if (currentFuel - petrolStation[1] >= 0)
                    {

                        currentFuel -= petrolStation[1];

                    }
                    else
                    {
                        currentFuel -= petrolStation[1];
                        fuel_Distance.Enqueue(fuel_Distance.Dequeue());
                        index++;
                        break;
                    }

                }

                if (currentFuel >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);


        }
    }
}
