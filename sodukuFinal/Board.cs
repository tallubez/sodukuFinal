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
        private WhatCellSolvedMat what_cell_is_solved_mat;
        public Board(int side_size)
        {
            this.side_size = side_size;
            cells = new Cell[side_size, side_size];
            what_cell_is_solved_mat = new WhatCellSolvedMat(side_size);
        }

        public int getSize()
        {
            return side_size;
        }
        public Cell[,] GetCells()
        {
            return cells;
        }
        public void setCell(Cell c, int place_x, int place_y)
        {
            cells[place_x, place_y] = c;
        }
        public Cell GetCell(int place_x, int place_y)
        {
            return cells[place_x, place_y];
        }
        public WhatCellSolvedMat GetWhatCellSolvedMat()
        {
            return what_cell_is_solved_mat;
        }
        public int[] GetSquareStarters(int place_x, int place_y) //returns the place where the square containing the cell beggins
        {
            int square_size = (int)Math.Sqrt(side_size);
            int square_start_x = 0;
            int square_start_y = 0;
            while (square_start_x + square_size - 1 < place_x)
            {
                square_start_x += square_size;
            }
            while (square_start_y + square_size - 1 < place_y)
            {
                square_start_y += square_size;
            }
            int[] square_starters = { square_start_x, square_start_y };
            return square_starters;
        }
        public List<int[]> GetAllEffectedPlaces(int place_x, int place_y)
        {
            List<int[]> all_effected_places = new List<int[]>();
            int[] place = new int[2];
            for (int i = 0; i < side_size; i++)
            {
                place[0] = place_x;
                place[1] = i;
                if (i != place_y)
                {
                    all_effected_places.Add(place.Clone() as int[]);
                }
                place[0] = i;
                place[1] = place_y;
                if (i != place_x)
                {
                    all_effected_places.Add(place.Clone() as int[]);
                }
            }
            int square_size = (int)Math.Sqrt(side_size);
            int[] square_staeters = GetSquareStarters(place_x, place_y);
            int square_start_x = square_staeters[0];
            int square_start_y = square_staeters[1];
            for (int i = 0; i < square_size; i++)
            {
                for (int j = 0; j < square_size; j++)
                {
                    if (square_start_x + i != place_x || square_start_y + j != place_y)
                    {
                        place[0] = i;
                        place[1] = j;
                        all_effected_places.Add(place.Clone() as int[]);
                    }
                }
            }
            return all_effected_places;
        }
    }
}
