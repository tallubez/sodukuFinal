using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class WhatCellSolvedMat: ICloneable
    {
        //Class that contains a mat and a counnter to keep track of what and how many cells are sloved.
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
            //return amount solved.
            return amount_solved;
        }
        public void SetAmountSolved(int amount)
        {
            //set amount solved.
            this.amount_solved = amount;
        }
        public void SetCellSolved(int place_x, int place_y)
        {
            //set cell solved.
            is_solved_mat[place_x, place_y] = true;
            amount_solved++;
        }
        public bool IsCellSolved(int place_x, int place_y)
        {
            //return if a specific cell is solved.
            return is_solved_mat[place_x, place_y];
        }

        public object Clone()
        {
            //clone by value.
            WhatCellSolvedMat new_mat = new WhatCellSolvedMat(side_size);
            new_mat.amount_solved = amount_solved;
            for(int i = 0; i < side_size; i++)
            {
                for(int j = 0; j < side_size; j++)
                {
                    new_mat.is_solved_mat[i, j] = is_solved_mat[i, j];
                }
            }
            return new_mat;
        }
    }
}
