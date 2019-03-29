using System;

namespace exercise2
{
    public class Frame
    {
        //行
        private int row;
        //列
        private int column;
        /**
         * cells[row, column]
         */
        private Cell[,] cells;
        /*
         * easy, normal, hard
         * 9*9, 16*16, 16*30
         * 10, 40, 99
         */
        private string difficulty;
        private int numOfMine;

        public Frame()
        {
            Console.WriteLine("please input difficulty");
            Console.WriteLine("difficulty: easy or normal or hard");

            bool inputRight = false;

            while (!inputRight)
            {
                string inputDifficulty = Console.ReadLine();
                this.difficulty = inputDifficulty;

                if (difficulty.Equals("easy"))
                {
                    row = 9;
                    column = 9;
                    numOfMine = 10;
                    inputRight = true;
                }
                else if (difficulty.Equals("normal"))
                {
                    row = 16;
                    column = 16;
                    numOfMine = 40;
                    inputRight = true;
                }
                else if (difficulty.Equals("hard"))
                {
                    row = 16;
                    column = 30;
                    numOfMine = 99;
                    inputRight = true;
                }
                else
                {
                    Console.WriteLine("input difficulty is error");
                }
            }
            
            cells = new Cell[row, column];
            FrameInitialization();
            createMine();
        }

        public void getRowAndColumn()
        {
            Console.WriteLine(row);
            Console.WriteLine(column);
        }

        public void FrameInitialization()
        {
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    cells[r, c] = new Cell();
                }
            }
        }
        
        public void printFrame()
        {
            Console.WriteLine("print mine:");
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    if (cells[r, c].isMine == true)
                        Console.Write("X ");
                    else
                        Console.Write("0 ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("print num of mine around:");
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    if (cells[r, c].isMine == true)
                        Console.Write("X");
                    else 
                        Console.Write(cells[r, c].NumOfMineAround);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public void createMine()
        {
            Random random = new Random();
            
            for (int i = 0; i < numOfMine;)
            {
                int r = random.Next(0, row);
                int c = random.Next(0, column);

                //该位置无地雷时放置
                if (cells[r, c].isMine == false)
                {
                    cells[r, c].isMine = true;
                    i++;


                    if (r - 1 >= 0)
                    {
                        if (c - 1 >= 0 && cells[r - 1, c - 1].isMine == false)
                        {
                            cells[r - 1, c - 1].NumOfMineAround++;
                        }

                        if (cells[r - 1, c].isMine == false)
                        {
                            cells[r - 1, c].NumOfMineAround++;
                        }
                        if (c + 1 < column && cells[r - 1, c + 1].isMine == false)
                        {
                            cells[r - 1, c + 1].NumOfMineAround++;
                        }
                    }

                    if (r >= 0)
                    {
                        if (c - 1 >= 0 && cells[r, c - 1].isMine == false)
                        {
                            cells[r, c - 1].NumOfMineAround++;
                        }
                        if (c + 1 < column && cells[r, c + 1].isMine == false)
                        {
                            cells[r, c + 1].NumOfMineAround++;
                        }
                    }
                    
                    if (r + 1 < row)
                    {
                        if (c - 1 >= 0 && cells[r + 1, c - 1].isMine == false)
                        {
                            cells[r + 1, c - 1].NumOfMineAround++;
                        }

                        if (cells[r + 1, c].isMine == false)
                        {
                            cells[r + 1, c].NumOfMineAround++;
                        }
                        if (c + 1 < column && cells[r + 1, c + 1].isMine == false)
                        {
                            cells[r + 1, c + 1].NumOfMineAround++;
                        }
                    }
                }
            }
        }
    }
}