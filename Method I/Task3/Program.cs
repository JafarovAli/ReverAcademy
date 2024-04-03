using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input: ");
            string input = Console.ReadLine();
            PrintStrongNess(input);
        }
        public static void PrintStrongNess(string input)
        {
            int n = input.Length;
            bool hasLower = false, hasUpper = false,hasDigit = false;

            foreach (char i in input.ToCharArray())
            {
                if (char.IsLower(i))
                    hasLower = true;
                if (char.IsUpper(i))
                    hasUpper = true;
                if (char.IsDigit(i))
                    hasDigit = true;
            }

            if (hasDigit && hasLower && hasUpper)
                Console.Write(true);
            else
                Console.Write(false);
        }
    }
}
