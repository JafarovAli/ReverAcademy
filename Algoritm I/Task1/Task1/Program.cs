// See https://aka.ms/new-console-template for more information

Console.Write("Enter the number : ");
int number = Convert.ToInt32(Console.ReadLine());
int product = 1;

while (number > 0)
{
    var digit = number % 10;
    number = number / 10;

    if (digit % 5 ==0)
    {
        product *= digit;
    }
}
Console.WriteLine("Product of digits divisible by 5: " + product);
