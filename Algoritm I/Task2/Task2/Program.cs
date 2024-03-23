Console.Write("Enter the number : ");
int number = Convert.ToInt32(Console.ReadLine());
int sum = 0;
while (number != 0)
{
    int digit = number % 10;
    sum += digit;
    number /= 10;
}
Console.WriteLine("Sum : " + sum);

if (sum % 2 == 0)
{
    Console.WriteLine("Sum is even");
}
else
{
    Console.WriteLine("Sum is odd");
}