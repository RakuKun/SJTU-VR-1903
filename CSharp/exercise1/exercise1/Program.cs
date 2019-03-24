using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Number2String(133333);
            Console.WriteLine(s1);
            string s2 = Number2String(-1234567);
            Console.WriteLine(s2);

            string[] strs = { "C#", "COBOL", "Java", "C++", "Visual Basic", "Pascal", "Fortran", "Lisp", "J#" };
            foreach (string s in strs)
            {
                Console.Write(s + "  ");
            }
            Console.WriteLine("");
            Reverse(strs);
            foreach (string s in strs)
            {
                Console.Write(s + "  ");
            }


            int[] num = { 1, 2, 4, 6, 3 };
            int order = ReverseOrder(num);
            Console.WriteLine("");
            foreach (int n in num)
            {
                Console.Write(n + "   ");
            }
            Console.WriteLine("逆序数：" + order);
        }

        private static int ReverseOrder(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        private static void Reverse(string[] strs)
        {
            if (strs != null)
            {
                int i = 0, j = strs.Length - 1;
                while (i < j)
                {
                    string t = strs[i];
                    strs[i] = strs[j];
                    strs[j] = t;
                    i++; j--;
                }

            }
        }


        private static string Number2String(int v)
        {
            string str = "";
            bool minus = false;
            if (v < 0)
            {
                minus = true;
                v = -v;
            }
            do
            {
                str = str.Insert(0, "" + (v % 10));
                v /= 10;
            } while (v != 0);

            if (!minus)
            {
                str = str.Insert(0, "-");
            }

            return str;
        }
    }
}

