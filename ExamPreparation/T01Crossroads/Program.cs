using System;
using System.Collections.Generic;
using System.Linq;

namespace T01Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string command;

            int numOfCarsThatPassesCrossroad = 0;


            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    int leftSeconds = greenLightDuration;

                    while (leftSeconds > 0)
                    {
                        if (cars.Any())
                        {
                            if (cars.Peek().Length < leftSeconds)
                            {
                                numOfCarsThatPassesCrossroad++;
                                leftSeconds -= cars.Dequeue().Length;
                            }
                            else
                            {
                                break;

                            }
                            
                        }
                        else
                        {
                            break;
                        }
                    }


                    leftSeconds += freeWindowDuration;
                    if (cars.Any())
                    {
                        if (leftSeconds >= cars.Peek().Length)
                        {
                            numOfCarsThatPassesCrossroad++;
                            leftSeconds -= cars.Dequeue().Length;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{cars.Peek()} was hit at {cars.Peek()[leftSeconds]}.");
                            return;
                        }
                    }

                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{numOfCarsThatPassesCrossroad} total cars passed the crossroads.");
     

        }
    }
}
