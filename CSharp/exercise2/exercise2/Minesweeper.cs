using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2
{
    class Minesweeper
    {
        private int rows;
        private int columns;
        private int level = 1;
        private int BoomsNum;
        private int[,] Map;
        public Minesweeper(int level)
        {
            SetGameBoard board = new SetGameBoard();
            this.rows = board.rows;
            this.columns = board.columns;
            this.level = level;
            Map = new int[rows, columns];
            SetBoomsNum();
        }

        private void SetBoomsNum()
        {
            switch (level)
            {
                case 1:
                    {
                        BoomsNum = (int)(rows * columns * 0.2);
                        break;
                    }
                case 2:
                    {
                        BoomsNum = (int)(rows * columns * 0.4);
                        break;
                    }
                case 3:
                    {
                        BoomsNum = (int)(rows * columns * 0.6);
                        break;
                    }
                   
            }
        }

        public void SetMap()
        {
            //设置炸弹位置
            Random random = new Random();
            for(int i = 1; i <= BoomsNum;)
            {
                int B_Row = random.Next(0, rows - 1);
                int B_Column = random.Next(0, columns - 1);
                //防止在重复位置设置炸弹
                if (Map[B_Row, B_Column] != -1)
                {
                    Map[B_Row,B_Column] = -1;
                    i++;
                }
                else continue;
            }

            //计算剩余位置的数字
            for(int i = 0; i < Map.GetLength(0); i++)
            {
                for(int j =0;j < Map.GetLength(1); j++)
                {
                    if (Map[i, j] != -1)//选择非雷的位置进行计算
                    {
                        int sum = 0;
                        bool up = true;
                        bool down = true;

                        //判断上行是否存在
                        if (i-1 >= 0)
                        { if (Map[i - 1, j] == -1) sum++; }
                        else up = false;

                        //判断下行是否存在

                        if (i + 1 < rows)
                        { if (Map[i + 1, j] == -1) sum++; }
                        else down = false;


                        //判断左列是否存在
                        if (j - 1 >= 0)
                        {
                            if (Map[i, j - 1] == -1) sum++;
                            if (up)
                            { if (Map[i - 1, j - 1] == -1) sum++; }

                            if (down)
                            { if (Map[i + 1, j - 1] == -1) sum++; }
                        }


                        //判断右列是否存在
                        if (j+1 < columns)
                        {
                            if (Map[i, j + 1] == -1) sum++;
                            if (up)
                            { if (Map[i - 1, j + 1] == -1) sum++; }

                            if (down)
                            { if (Map[i + 1, j + 1] == -1) sum++; }
                        }

                        Map[i, j] = sum;

                    }
                }
            }
        }

        public void DrawMap()
        {
            Console.WriteLine("BoardSize:"+ rows + "*"+ columns);
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for(int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.Write(Map[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
