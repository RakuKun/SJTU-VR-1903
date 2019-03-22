using System;
using System.Globalization;

namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 13333;
            string s = Number2String(13333);
            Console.WriteLine(s);

            string[] strs = {"C#", "COBOL", "Java", "C++", "Visual Basic", "Pascal", "Fortran", "Lisp", "J#"};
            Reverse(strs);
            foreach (var str in strs)
            {
                Console.WriteLine(str);
            }
            
            int[] nums = {2, 4, 3, 1};
            Console.WriteLine(ReverseOrder(nums));

        }

        static string Number2String(int i)
        {
            int j = 0;
            char[] str = new char[100];
            string nums = "";
            while (i > 0)
            {
                str[j] = (char)(i % 10 + '0');
                i = i / 10;
                j++;
            }

            for (int k = j - 1; k >= 0; k--)
            {
                nums += str[k];
            }

            return nums;
        }

        static void Reverse(string[] strs)
        {
            string test = String.Empty;
            for (int i = 0; i < strs.Length / 2; i++)
            {
                test = strs[i];
                strs[i] = strs[strs.Length - 1 - i];
                strs[strs.Length - 1 - i] = test;
            }
        }

        static int ReverseOrder(int[] nums)
        {
            int num = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        num++;
                    }
                }
            }
            
            return num;
        }
    }
}
