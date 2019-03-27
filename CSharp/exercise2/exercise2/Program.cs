using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            string level;
            Console.WriteLine("Choose The Level:  1.Easy   2.Nomarl   3.Hard");
            level = Console.ReadLine();
            Console.WriteLine();

            Minesweeper minesweeper = new Minesweeper(Int16.Parse(level));
            minesweeper.SetMap();
            minesweeper.DrawMap();
        }
    }
}
