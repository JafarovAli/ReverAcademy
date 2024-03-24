using System;

int number1 = 0, number2 = 1, number3 = 0, count,i=2;
Console.Write("Enter the number of elements: ");
count = Convert.ToInt32(Console.ReadLine());
if (count == 0)
{
    Console.WriteLine(1);
}
else if (count == 1) 
{  
    Console.WriteLine(2);
}
else
{
    while (true)
    {
        number3 = number1 + number2;
        number1 = number2;
        number2 = number3;
        i++;
        if (number3 == count)
        {
            Console.WriteLine($"{count} is located at index {i} in the Fibonacci sequence.");
            break;
        }
        else if (number3 > count)
        {
            Console.WriteLine($"{count} is not part of the Fibonacci sequence.");
            break;
        }
    }
}

