using System;
using System.Collections.Generic;

namespace T01CubicArtillery
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int bunkersMaximumCapacity = int.Parse(Console.ReadLine());

            Queue<string> bunkers = new Queue<string>();
            Queue<int> weapons = new Queue<int>();
            string inputLine;
            int currentBunkerOccupiedSpace = 0;

            while ((inputLine = Console.ReadLine()) != "Bunker Revision")
            {
                string[] tokens = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tokens.Length; i++)
                {
                    if (Char.IsLetter(tokens[i][0]))
                    {
                        bunkers.Enqueue(tokens[i]);
                    }
                    else if (Char.IsDigit(tokens[i][0]))
                    {
                        int currentWeaponCapacity = int.Parse(tokens[i]);
                        if (currentBunkerOccupiedSpace + currentWeaponCapacity <= bunkersMaximumCapacity)
                        {
                            weapons.Enqueue(currentWeaponCapacity);
                            currentBunkerOccupiedSpace += currentWeaponCapacity;
                        }
                        else
                        {

                            if (bunkers.Count > 1)
                            {
                                string output = weapons.Count > 0 ? $"{bunkers.Dequeue()} -> {string.Join(", ", weapons)}" 
                                    : $"{bunkers.Dequeue()} -> Empty";
                                weapons.Clear();
                                Console.WriteLine(output);
                                currentBunkerOccupiedSpace = 0;

                                if (currentWeaponCapacity <= bunkersMaximumCapacity)
                                {
                                    weapons.Enqueue(currentWeaponCapacity);
                                    currentBunkerOccupiedSpace += currentWeaponCapacity;
                                }
                                else
                                {
                                    while (bunkers.Count > 1)
                                    {
                                        Console.WriteLine($"{bunkers.Dequeue()} -> Empty");

                                    }

                                }

                            }
                            else if (bunkers.Count == 1)
                            {
                                if (currentWeaponCapacity <= bunkersMaximumCapacity)
                                {
                                    while (bunkersMaximumCapacity - currentBunkerOccupiedSpace <  currentWeaponCapacity)
                                    {
                                        currentBunkerOccupiedSpace -= weapons.Dequeue();

                                    }
                                    weapons.Enqueue(currentWeaponCapacity);
                                    currentBunkerOccupiedSpace += currentWeaponCapacity;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                        }

                    }
                }

            }

        }
    }
}
