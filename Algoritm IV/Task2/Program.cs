int[] numbers = { 2, 9, 4, 3, 5, 1, 7 };
int temp = 0;

for (int i = 0; i <= numbers.Length - 1; i++)
{
    for (int j = i + 1; j < numbers.Length; j++)
    {
        if (numbers[i] < numbers[j])
        {
            temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
Console.WriteLine("Array sort in descending order");
foreach (var number in numbers)
{
    Console.WriteLine(number);
}