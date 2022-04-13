using System;
using System.Collections.Generic;
using System.Linq;

namespace T01FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] liliesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] rosesInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


            Stack<int> lilies = new Stack<int>(liliesInput);
            Queue<int> roses = new Queue<int>(rosesInput);

            int flowersSum = 0;
            int countOfWreaths = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                if (lilies.Peek() + roses.Peek() == 15)
                {
                    countOfWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }

                else 
                {
                    flowersSum += lilies.Pop() + roses.Dequeue();
                }

            }

            if (flowersSum > 0)
            {
                countOfWreaths += flowersSum / 15;
            }

            if (countOfWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
            }
            
        }
    }
}
