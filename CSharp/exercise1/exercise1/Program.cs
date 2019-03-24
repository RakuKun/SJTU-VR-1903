using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise1
{
    class Program
    {
        static string Number2String(int n)
        {
            string temp = "";
            do
            {
                temp = n % 10 + '0' + temp;
                n /= 10;
            }
            while (n != 0);
            return temp;
        }

        static void Reverse(string[] str)
        {
            //元素倒置
            string[] newStr = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                newStr[str.Length - i] = str[i];
            }
            str = newStr;
        }

        static int ReverseOrder(int[] num)
        {
            //元素倒置
            int temp = 0;
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = i + 1; j < num.Length; j++)
                {
                    if (num[i] > num[j])
                    {
                        temp++;
                    }
                }
            }
            return temp;
        }

    }
}
