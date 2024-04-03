using System;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the text: ");
            string str = Console.ReadLine();

            removeSpaces(ref str);

            Console.WriteLine(str);
        }

        public static void removeSpaces(ref string str)
        {
            int n = str.Length;
            int i = 0, j = -1;

            bool spaceFound = false;

            while (++j < n && str[j] == ' ') ;

            while (j < n)
            {
                if (str[j] != ' ')
                {
                    if ((str[j] == '.' || str[j] == ',' ||
                         str[j] == '?') && i - 1 >= 0 &&
                         str[i - 1] == ' ')
                        str = str.Remove(i - 1, 1).Insert(i - 1, str[j++].ToString());
                    else
                    {
                        str = str.Remove(i, 1).Insert(i, str[j++].ToString());
                        i++;
                    }

                    spaceFound = false;
                }
                else if (str[j++] == ' ')
                {
                    if (!spaceFound)
                    {
                        str = str.Remove(i, 0).Insert(i, " ");
                        i++;
                        spaceFound = true;
                    }
                }
            }
            if (i <= 1)
                str = str.Remove(i, n - i);
            else
                str = str.Remove(i - 1, n - i + 1);
        }
    }
}
