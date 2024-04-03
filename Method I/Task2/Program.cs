using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter : ");
            string str = Console.ReadLine();
            Console.WriteLine(FirstString(str));
        }

        public static string FirstString(string str)
        {
            char[] charValue = str.ToCharArray();
            for (int i = 0; i < charValue.Length; i++)
            {
                int k = i;
                while (i < charValue.Length && charValue[i] != ' ')
                    i++;

                charValue[k] = (char)(charValue[k] is >= 'a' and <= 'z'
                                ? (charValue[k] - 32)
                                : charValue[k]);
            }
            var newString = new string(charValue);

            foreach (var i in newString)
            {
                Console.Write(i);
                if (i==' ')
                {
                    break;
                }
            }
            return "";

        }
    }
}
