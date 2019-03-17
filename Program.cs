using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
       
        public static void Main()
        {
            int[] number = { 1, 3, 4, 5 };
            int i = 0;
            for (i = 0; i < 4; i++) 
            {
                Console.WriteLine($"{number[i]}");
            }
            i = 0;
            while (i < 4) 
            {
                Console.WriteLine($"{number[i]}");
                i++;
            }
            i = 0;
            do
            {
                Console.WriteLine($"{number[i]}");
                i++;
            } while (i < 4);
        }
}
}
