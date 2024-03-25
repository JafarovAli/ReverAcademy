int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 5, 9 };
int large = 0, seccondLarge = 0;
for (int i = 0; i < numbers.Length; i++)
{
    if (numbers[i]>large)
    {
        seccondLarge = large;
        large = numbers[i];
    }
    else if (numbers[i] > seccondLarge)
    {
        large = numbers[i];
    }
}
Console.WriteLine(seccondLarge);