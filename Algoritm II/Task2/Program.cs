while (true)
{
    Console.Write("Enter the number : ");
    int number = Convert.ToInt32(Console.ReadLine());
    int newNumber = 0, multiplier = 1;

    while (number > 0)
    {
        int digit = number % 10;
        number /= 10;
        if (digit % 2 != 0)
        {
            newNumber += digit * multiplier;
            multiplier *= 10;
        }
    }
    Console.WriteLine("The new number : " + newNumber);
}