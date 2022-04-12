using System;
using System.Linq;

namespace T06JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int numberOfRows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[numberOfRows][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {

                jaggedArray[i] = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                    .ToArray();
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {

                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    jaggedArray[i] = jaggedArray[i].Select(x => x * 2).ToArray();
                    jaggedArray[i + 1] = jaggedArray[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArray[i] = jaggedArray[i].Select(x => x / 2).ToArray();
                    jaggedArray[i + 1] = jaggedArray[i + 1].Select(x => x / 2).ToArray();
                }
            }

            string command = String.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string manipulation = tokens[0];
                int row = int.Parse(tokens[1]);
                int column = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if ((manipulation != "Add" && manipulation != "Subtract") || row < 0 || row >= jaggedArray.Length ||
                    column < 0 || column >= jaggedArray[row].Length)
                {
                    continue;
                }
                else if (manipulation == "Add")
                {
                    jaggedArray[row][column] += value;
                }
                else if (manipulation == "Subtract")
                {
                    jaggedArray[row][column] -= value;
                }

            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
            
        }
    }
}
