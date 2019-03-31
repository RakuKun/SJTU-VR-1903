using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise1
{
    class Program
    {
        public static void Main()
        {
            string[] strs = { "C#", "COBOL", "Java", "C++", "Visual Basic", "Pascal", "Fortran", "Lisp", "J#" };
            Reverse(ref strs);
            foreach (var item in strs)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine(Number2String(-166006));
            Console.WriteLine(Number2String(0));
            Console.WriteLine();

            int[] nums = { 1, 2, 3, 5, 4, 7, 9, 8, 6 };
            Console.WriteLine(ReverseOrder(nums));
        }

        static string Number2String(int n)
        {
            string result = "";
            bool neg = false;
            if (n < 0)
            {
                n = -n;
                neg = true;
            }
            else if (n == 0) 
            {
                return "0";
            }
            while (n != 0)
            {
                int rem;
                n = Math.DivRem(n, 10, out rem);
                result = result.Insert(0, rem.ToString());
            }
            if (neg)
            {
                result = result.Insert(0, "-");
            }
            return result;
        }
        static void Reverse(ref string[] strs)
        {
            string[] result = new string[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                result[strs.Length - i - 1] = strs[i];
            }
            strs = result;
            return;
        }
        static int ReverseOrder(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
