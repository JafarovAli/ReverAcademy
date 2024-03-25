int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 }, { 9, 7, 3 } };

for (int i = 0; i < numbers.GetLength(0); i++)
{
    for (int j = 0; j < numbers.GetLength(1); j++)
    {
        Console.Write(numbers[i, j] + " ");
    }
    Console.WriteLine();
}