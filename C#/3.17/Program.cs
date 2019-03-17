using System;

namespace Desktop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ToUpper("hello!world"));

        }

        static string ToUpper(string s)
        {
            string s1 = null;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (s[i] >= 'a' && s[i] <= 'z')
                {
                    c = (char)(s[i] - 32);
                }
                s1 += c;
            }
            return s1;
        }
    }
}
