while (true)
{
    Console.Write("Enter the number : ");
    int number = Convert.ToInt32(Console.ReadLine());
    int sum = 0;

    while (number > 0)
    {
        var digit = number % 10;
        number = number / 10;

        if (digit % 2 == 0)
        {
            sum += digit;
        }
    }
    if (sum > 0)
    {
        if (sum % 4 == 0 && sum % 3 == 0)
            Console.WriteLine(true);
        else
            Console.WriteLine(false);
    }
    else
        Console.WriteLine("Sum is 0.");
}