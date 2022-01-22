using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class WhatCellSolvedMat
    {
        public bool[,] is_solved_mat;
        public int amount_solved;

        public WhatCellSolvedMat(int side_size)
        {
            bool[,] is_solved_mat = new bool[side_size, side_size];
            amount_solved = 0;
        }
        public void SetCellSolved(int place_x, int place_y)
        {
            is_solved_mat[place_x, place_y] = true;
            amount_solved++;
        }
        public bool IsCellSolved(int place_x, int place_y)
        {
            return is_solved_mat[place_x, place_y];
        }
    }
}
