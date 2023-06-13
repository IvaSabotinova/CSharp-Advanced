
int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

InsertionSort(numbers);

Console.WriteLine(string.Join(" ", numbers));
static void InsertionSort(int[] numbers)
{
    for (int i = 1; i < numbers.Length; i++)
    {
        int j = i;
        while (j > 0 && numbers[j - 1] > numbers[j])
        {
            Swap(numbers, j - 1, j);
            j--;
        }

    }
}

static void Swap(int[] numbers, int firstNumIndex, int secondNumIndex)
{
    int temp = numbers[firstNumIndex];
    numbers[firstNumIndex] = numbers[secondNumIndex];
    numbers[secondNumIndex] = temp;

}