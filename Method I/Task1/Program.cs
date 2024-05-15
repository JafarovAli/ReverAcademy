using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Enter the text: ");
            string s = Console.ReadLine();
            Console.WriteLine(LengthOfLongestSubstring(s));

            //removeSpaces(ref str);

            //Console.WriteLine(str);
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode ptr = result;
            int carry = 0 ;
            while (l1 != null || l2 != null)
            {
                int sum = 0 + carry;
                if (l1!=null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                carry = sum / 10;
                sum = sum % 10;
                ptr.next = new ListNode(sum);
                ptr = ptr.next;
            }
            if (carry==1)
            {
                ptr.next = new ListNode(1);
            }
            return result.next;
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
        public static int LengthOfLongestSubstring(string s)
        {
            int count = 0;

            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

            for (int end = 0, start = 0; end < s.Length; end++)
            {
                if (charIndexMap.ContainsKey(s[end]))
                {
                    start = Math.Max(charIndexMap[s[end]] + 1, start);
                }

                count = Math.Max(count, end - start + 1);
                charIndexMap[s[end]] = end;
            }


            return count;
        }
    }
}
