using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2
{
    class Program
    {
        static int size = 10;           //Panel size
        static int BombCount = 30;      //Number of bombs

        static Grid[,] panel = new Grid[size, size];
        static Grid[,] tempPanel = new Grid[size + 2, size + 2];

        static void Main(string[] args)
        {
            int remainCount = BombCount;
            double probability = 0.0;
            Random r = new Random();

            //Initialize whole panel
            for (int i = 0; i < panel.GetLength(0); i++)
            {
                for (int j = 0; j < panel.GetLength(1); j++)
                {
                    panel[i, j] = new Number("0");
                }
            }

            //Fill all bombs
            while (remainCount>0)
            {
                for (int i = 0; i < panel.GetLength(0); i++)
                {
                    for (int j = 0; j < panel.GetLength(1); j++)
                    {
                        probability = r.NextDouble();
                        if (panel[i, j].Role == "0" && probability >= 0.3 && probability <= 0.6 && remainCount > 0 )
                        {
                            panel[i, j] = new Bomb("b");
                            remainCount--;
                            continue;
                        }
                    }
                }
            }
            
            //Extend the edge of panel with 1
            for (int i = 0; i < tempPanel.GetLength(0); i++)
            {
                for (int j = 0; j < tempPanel.GetLength(1); j++)
                {
                    if (i == 0 || j == 0 || i == tempPanel.GetLength(0) - 1 || j == tempPanel.GetLength(1)-1)
                    {
                        tempPanel[i, j] = new Number("0");
                    }
                    else
                    {
                        tempPanel[i, j] = panel[i-1,j-1];
                    }
                }
            }

            //Calculate the bomb's number of center in a 3x3 kernel
            int count = 0;
            for (int i = 0; i < tempPanel.GetLength(0); i++)
            {
                for (int j = 0; j < tempPanel.GetLength(1); j++)
                {
                    count = 0;
                    if (i == 0 || j == 0 || i == tempPanel.GetLength(0) - 1 || j == tempPanel.GetLength(1) - 1||tempPanel[i,j].Role=="b")
                    {
                        continue;
                    }
                    else
                    {
                        for (int x = -1; x < 2; x++)
                        {
                            for (int y = -1; y < 2; y++)
                            {
                                if (tempPanel[i + x, j + y].Role == "b")
                                {
                                    count++;
                                }
                            }
                        }
                        panel[i - 1, j - 1].Role = count.ToString();
                    }
                }
            }

            //Print the result of temp panel
            //for (int i = 0; i < tempPanel.GetLength(0); i++)
            //{
            //    for (int j = 0; j < tempPanel.GetLength(1); j++)
            //    {
            //        Console.Write(tempPanel[i, j].Role + "  ");
            //    }
            //    Console.WriteLine();
            //}

            //Print the result of panel
            for (int i = 0; i < panel.GetLength(0); i++)
            {
                for (int j = 0; j < panel.GetLength(1); j++)
                {
                    Console.Write(panel[i, j].Role + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            while (true)
            {

            }
        }
    }
}
