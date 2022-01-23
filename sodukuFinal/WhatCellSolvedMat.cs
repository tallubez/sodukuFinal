using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class WhatCellSolvedMat: ICloneable
    {
        private bool[,] is_solved_mat;
        private int amount_solved;
        private int side_size;

        public WhatCellSolvedMat(int side_size)
        {
            is_solved_mat = new bool[side_size, side_size];
            amount_solved = 0;
            this.side_size = side_size;
        }
        public int GetAmountSolved()
        {
            return amount_solved;
        }
        public void SetAmountSolved(int amount)
        {
            this.amount_solved = amount;
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

        public object Clone()
        {
            WhatCellSolvedMat new_mat = new WhatCellSolvedMat(side_size);
            new_mat.amount_solved = amount_solved;
            new_mat.is_solved_mat = is_solved_mat.Clone() as bool[,];
            return new_mat;
        }
    }
}
