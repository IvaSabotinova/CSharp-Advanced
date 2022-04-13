using System;
using System.Collections.Generic;
using System.Linq;

namespace T01BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] guestsQueue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] platesStack = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> guests = new Queue<int>(guestsQueue);
            Stack<int> plates = new Stack<int>(platesStack);

            int wastedFood = 0;
            while (guests.Count > 0 && plates.Count > 0)
            {

                if (guests.Peek() < plates.Peek())
                {
                    wastedFood += plates.Pop() - guests.Dequeue();
                }
                else if (guests.Peek() > plates.Peek())
                {
                    Queue<int> newGuestsRow = new Queue<int>();
                    newGuestsRow.Enqueue(guests.Dequeue() - plates.Pop());

                    for (int i = 0; i < guests.Count; i++)
                    {
                        newGuestsRow.Enqueue(guests.ElementAt(i));
                    }

                    guests = newGuestsRow;
                }
                else
                {
                    guests.Dequeue();
                    plates.Pop();
                }

            }

            if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }
            else if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
                Console.WriteLine($"Wasted grams of food: {wastedFood}");
            }

        }
    }
}
