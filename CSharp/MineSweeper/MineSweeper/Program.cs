using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            MineSweeper mine = new MineSweeper(MineSweeper.Difficulty.Normal);
            mine.Output();
            Console.ReadLine();
        }
    }

    class MineSweeper
    {
        public enum Difficulty
        {
           Easy,Normal,Hard
        }
        int[,] board;

        public MineSweeper(Difficulty difficulty)
        {
            Random random = new Random();
            Initialize(random.Next(9, 18), random.Next(9, 18));
            Place(difficulty);
            Calc();
        }
        private void Initialize(int row,int col)
        {
            board = new int[row, col];
        }
        private void Place(Difficulty diff)
        {
            int b = board.Length;
            switch (diff)
            {
                case Difficulty.Easy:
                    b /= 10;
                    break;
                case Difficulty.Normal:
                    b /= 5;
                    break;
                case Difficulty.Hard:
                    b /= 3;
                    break;
                default:
                    break;
            }
            while (b>=0)
            {
                Random r = new Random();
                int d0 = r.Next(board.GetLength(0));
                int d1 = r.Next(board.GetLength(1));
                if (board[d0, d1] != -1) 
                {
                    board[d0, d1] = -1;
                    b--;
                }
            }
        }
        private void Calc()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == -1)
                    {
                        continue;
                    }
                    else
                    {
                        board[i, j] = Count(i, j);
                    }
                }
            }
        }
        private int Count(int pI, int pJ)
        {
            int sum = 0;
            for (int i = pI-1; i <= pI+1; i++)
            {
                if (i<0)
                {
                    continue;
                }
                else if (i>=board.GetLength(0))
                {
                    continue;
                }
                for (int j = pJ-1; j <= pJ+1; j++)
                {
                    if (j < 0)
                    {
                        continue;
                    }
                    else if (j >= board.GetLength(1))
                    {
                        continue;
                    }
                    if (board[i,j]==-1)
                    {
                        sum++;
                    }
                }
            }
            return sum;
        }
        public void Output()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == -1) 
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(board[i, j]);
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
