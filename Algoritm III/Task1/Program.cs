while (true)
{
    Console.Write("Enter the number : ");
    int number = Convert.ToInt32(Console.ReadLine());
    int copyNumber = number;
    int count = 0;
    while (number > 0 && number !=1 && number%2==0)
    {
        number /= 2;
    }
    if (number == 1)
    {
        while (copyNumber > 0 && copyNumber % 2 == 0)
        {
            copyNumber /= 2;
            count++;
        }
        Console.WriteLine("2^" + count);
    }
    else
        Console.WriteLine("The number is not a power of 2");
}