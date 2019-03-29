using System;

namespace exercise2
{
    public class Cell
    {
        public bool isMine { get; set; }
        public int NumOfMineAround{ get; set; }

        public Cell()
        {
            isMine = false;
            NumOfMineAround = 0;
        }
    }
}