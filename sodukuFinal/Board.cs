using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class Board
    {
        private int side_size;
        private Cell[,] cells;
        public Board(int side_size)
        {
            this.side_size = side_size;
            Cell[,] cells = new Cell[side_size, side_size];
        }

    }
}
