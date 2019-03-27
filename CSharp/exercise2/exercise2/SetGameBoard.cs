using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise2
{
    class SetGameBoard
    {
        public SetGameBoard()
        {
            bool flag;
            Random random = new Random();
            while (rows * columns == 0)
            {
                int i = random.Next(5,15);
                flag = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    if (rows == 0)
                    {
                        rows = i;
                    }
                    else
                    {
                        columns = i;
                    }
                }
            }
        }

      public int rows { get; }
      public int columns { get; }
    }
}
