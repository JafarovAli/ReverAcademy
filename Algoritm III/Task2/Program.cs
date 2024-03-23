int number1 = 0, number2 = 1, number3, number;
int index = 1;
Console.Write("Enter the number of elements: ");
number = Convert.ToInt32(Console.ReadLine());

for (var i = 2; i < number; ++i)  
{
    number3 = number1 + number2;
    number1 = number2;
    number2 = number3;
    index++;
}
if (index != -1)
{
    Console.WriteLine($"{number} is located at index {index} in the Fibonacci sequence.");
}
else
{
    Console.WriteLine($"{number} is not part of the Fibonacci sequence.");
}