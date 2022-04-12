using System;
using System.Collections.Generic;
using System.Linq;

namespace T10Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            string input = String.Empty;
            Queue<string> cars = new Queue<string>();
            int passedCarsCount = 0;

            while ((input = Console.ReadLine()) != "END")
            {

                if (input == "green")
                {
                    int leftSeconds = greenLightDuration;
                    for (int i = 0; i < leftSeconds; i++)
                    {
                        if (cars.Any())
                        {

                            if (cars.Peek().Length < leftSeconds)
                            {
                                leftSeconds -= cars.Peek().Length;
                                cars.Dequeue();
                                passedCarsCount++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    leftSeconds += freeWindowDuration;

                    if (cars.Any())
                    {
                        string currentCar = cars.Peek();
                        if (cars.Peek().Length > leftSeconds)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[leftSeconds]}.");
                            return;
                        }
                        else
                        {
                            cars.Dequeue();
                            passedCarsCount++;

                        }
                    }

                }
                else
                {
                    cars.Enqueue(input);
                }

            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
        }
    }
}
