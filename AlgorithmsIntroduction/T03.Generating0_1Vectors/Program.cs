
int n = int.Parse(Console.ReadLine());
int[] array = new int[n];
GenerateVector(array, 0);

static void GenerateVector(int[] array, int index)
{
    if (index == array.Length)
    {
        Console.WriteLine(string.Join("", array));
        return;
    }
    for (int i = 0; i <= 1; i++)
    {
        array[index] = i;
        GenerateVector(array, index + 1);
    }
}




