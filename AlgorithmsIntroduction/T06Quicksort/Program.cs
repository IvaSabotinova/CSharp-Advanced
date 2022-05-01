using System;
using System.Linq;


namespace T06QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));
        }
     
        private static void QuickSort<T>(T[] arr, int low, int high) where T: IComparable
        {

            int pivotIndex = low + (high - low) / 2;
            T pivot = arr[low + (high - low) / 2];
            T temp = arr[high];
            arr[high] = pivot;
            arr[pivotIndex] = temp;

            int i = low;
            int j = high;
            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (arr[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp1 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp1;
                    i++;
                    j--;
                }
                
            }

            if (i < high)
            {
                QuickSort(arr, i, high);
            }

            if (j > low)
            {
                QuickSort(arr, low, j);
            }

        }

    }
}
