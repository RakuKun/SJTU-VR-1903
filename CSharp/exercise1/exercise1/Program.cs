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
            #region NumberToString
            string s1 = Number2String(13333);
            Console.WriteLine(s1);
            string s2 = Number2String(-123567);
            Console.WriteLine(s2);
            #endregion

            #region ReverseStringArray
            string[] strs = { "C#", "COBOL", "Java", "C++", "VisualBasic", "Pascal", "Fortran", "List", "J#" };
            foreach (var s in strs)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            string[] reverseStrs = Reverse(strs);
            foreach (var s in reverseStrs)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            #endregion

            #region ReverseOrder
            int[] ints = { 2, 3, 4, 5, 1 };
            Console.WriteLine(ReverseOrder(ints));
            #endregion

            while (true);
        }

        static string Number2String(int n)
        {
            string result = "";

            if (n > 0)
            {
                while (n / 10 != 0)
                {
                    result = result.Insert(0, "" + (n % 10));
                    n /= 10;
                }
                result = result.Insert(0, "" + (n % 10));
            }
            else if (n < 0)
            {
                n = Math.Abs(n);
                while (n / 10 != 0)
                {
                    result = result.Insert(0, "" + (n % 10));
                    n /= 10;
                }
                result = result.Insert(0, "" + (n % 10));
                result = result.Insert(0, "-");
            }
            else
            {
                result = "0";
            }

            return result;
        }
        static string[] Reverse(string[] strArr)
        {
            string[] result = new string[strArr.Length];

            for (int i = strArr.Length - 1; i >= 0; i--)
            {
                result[strArr.Length - 1 - i] = strArr[i];
            }

            return result;
        }
        static int ReverseOrder(int[] intArr)
        {
            int result = 0;

            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = i + 1; j < intArr.Length; j++)
                {
                    if (intArr[i] > intArr[j])
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
