using System;

public class BubbleSort
{
    public static void Main()
    {
        int[] array = { 5, 2, 8, 1, 3 };

        Console.WriteLine("Array before sorting:");
        PrintArray(array);

        BubbleSortAlgorithm(array);

        Console.WriteLine("Array after sorting:");
        PrintArray(array);
    }

    public static void BubbleSortAlgorithm(int[] array)
    {
        int n = array.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                    swapped = true;
                }
            }

            // If no two elements were swapped in the inner loop,
            // the array is already sorted, and we can break out of the outer loop.
            if (!swapped)
                break;
        }
    }

    public static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    public static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
