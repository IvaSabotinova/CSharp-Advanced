using System;

using System.Linq;

namespace T05MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            MergeSort<int> final = new MergeSort<int>();
            int[] result = final.Sort(array);
            Console.WriteLine(string.Join(" ", result));

        }

        public class MergeSort<T> where T : IComparable
        {
            public T[] Sort(T[] array)
            {
                if (array.Length <=1)
                {
                    return array;
                }

                int midIndex = array.Length / 2;
                T[] leftArray = new T[midIndex]; 
                T[] rightArray = new T[array.Length - midIndex];
                Array.ConstrainedCopy(array, 0, leftArray, 0, midIndex);
                Array.ConstrainedCopy(array, midIndex, rightArray, 0, array.Length - midIndex);

                leftArray = Sort(leftArray);
                rightArray = Sort(rightArray);

                T[] sorted = Merge(leftArray, rightArray);
                return sorted;

            }

            public static T[] Merge(T[] leftArr, T[] rightArr)
            {
                T[] mergedArray = new T[leftArr.Length + rightArr.Length];
                int currLeftIndex = 0;
                int currRightIndex = 0;
                int currMergedArrayIndex = 0;

                while (currLeftIndex < leftArr.Length || currRightIndex < rightArr.Length)
                {
                    if (currLeftIndex < leftArr.Length && currRightIndex < rightArr.Length)
                    {
                        if (leftArr[currLeftIndex].CompareTo(rightArr[currRightIndex]) < 0)
                        {
                            mergedArray[currMergedArrayIndex++] = leftArr[currLeftIndex++];
                            

                        }
                        else if (leftArr[currLeftIndex].CompareTo(rightArr[currRightIndex]) > 0)
                        {
                            mergedArray[currMergedArrayIndex++] = rightArr[currRightIndex++];
                            

                        }
                        else
                        {
                            mergedArray[currMergedArrayIndex++] = leftArr[currLeftIndex++];
                            mergedArray[currMergedArrayIndex++] = rightArr[currRightIndex++];
                        }
                    }
                    else if (currLeftIndex<leftArr.Length)
                    {
                        mergedArray[currMergedArrayIndex++] = leftArr[currLeftIndex++];
                    }
                    else if (currRightIndex < rightArr.Length)
                    {
                        mergedArray[currMergedArrayIndex++] = rightArr[currRightIndex++];
                    }
                   
                    
                }

                return mergedArray;
                
            }
        }
    }
}
