using System;
using System.Collections.Generic;

namespace T08TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsPassingOnGreen = int.Parse(Console.ReadLine());

            Queue<string> trafficQueue = new Queue<string>();
            string input;
            int numOfCarsPassedCrossroad = 0;

            while ((input = Console.ReadLine()) != "end")
            {

                if (input == "green")
                {
                    for (int i = 0; i < numberOfCarsPassingOnGreen; i++)
                    {
                        if (trafficQueue.Count > 0)
                        {
                            Console.WriteLine($"{trafficQueue.Dequeue()} passed!");
                            numOfCarsPassedCrossroad++;
                        }

                    }

                }
                else
                {
                    trafficQueue.Enqueue(input);
                }


            }

            Console.WriteLine($"{numOfCarsPassedCrossroad} cars passed the crossroads.");





        }
    }
}