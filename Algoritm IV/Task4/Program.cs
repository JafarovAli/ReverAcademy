int[] numbers = { 0, 1, 2, 3, 4, 5, 0, 0, 0 };
int largestNumber = numbers[0];

for (int i = 0; i < numbers.Length; i++)
{
    if (largestNumber < numbers[i])
    {
        largestNumber = numbers[i];
    }
}
for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i]==0)
    {
        numbers[i] = largestNumber;
    }
}
foreach (var number in numbers)
{
    Console.Write(number + " ");
}