using System;
using System.Linq;


namespace T06Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {

            int jaggedArraySize = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[jaggedArraySize][];

            for (int i = 0; i < jaggedArraySize; i++)
            {
                int[] currentArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[i] = currentArray;

            }

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] subcommands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(subcommands[1]);
                int column = int.Parse(subcommands[2]);
                int currentValue = int.Parse(subcommands[3]);

                if (row < 0 || row >= jaggedArraySize || column < 0 || column >= jaggedArray[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    switch (subcommands[0])
                    {

                        case "Add":
                            jaggedArray[row][column] += currentValue;
                            break;
                        case "Subtract":
                            jaggedArray[row][column] -= currentValue;
                            break;
                        default: break;

                    }
                }

            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }

            
        }

    }
}
