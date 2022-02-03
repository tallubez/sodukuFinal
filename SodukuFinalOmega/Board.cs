using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class Board: ICloneable
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
            //return the size of a side of a board
            return side_size;
        }
        public Cell[,] GetCells()
        {
            // return the matrix of cells
            return cells;
        }
        public void SetCells(Cell[,] cells)
        {
            // set the matrix of cells
            for(int i = 0; i < side_size; i++)
            {
                for (int j = 0; j < side_size; j++)
                {
                    this.cells[i, j] = cells[i, j].Clone() as Cell;
                }
            }
        }
        public void setCell(Cell c, int place_x, int place_y)
        {
            // set sepcific cell
            cells[place_x, place_y] = c;
        }
        public Cell GetCell(int place_x, int place_y)
        {
            // get specific cell
            return cells[place_x, place_y];
        }
        public WhatCellSolvedMat GetWhatCellSolvedMat()
        {
            // get the what cell is solved matrix
            return what_cell_is_solved_mat;
        }
        public void SetWhatCellSolvedMat(WhatCellSolvedMat mat)
        {
            // set the what cell is solved matrix
            what_cell_is_solved_mat = mat.Clone() as WhatCellSolvedMat;
        }
        public string GetBoardAsString()
        {
            // return the board as string
            StringToMat board_to_string_service = new StringToMat();
            return board_to_string_service.SolveBoardToString(this);
        }
        public int[] GetSquareStarters(int place_x, int place_y) 
        {
            //returns the place where the square containing the cell beggins
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
            // return a list containing all the effected places (place is an int arrays with 2 vals, first is X second is Y)
            // from a cell (all the places in the same row, col and square)
            List<int[]> all_effected_places = new List<int[]>();
            int[] place = new int[2];
            bool does_exist_flag;
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

                        place[0] = square_start_x + i;
                        place[1] = square_start_y + j;
                        does_exist_flag = false;
                        for(int k =0; k < all_effected_places.Count; k++)
                        {
                            if(place[0] == all_effected_places[k][0] && place[1] == all_effected_places[k][1])
                            {
                                does_exist_flag = true;
                            }
                        }
                        if (!does_exist_flag)
                        { all_effected_places.Add(place.Clone() as int[]); }
                    }
                }
            }
            return all_effected_places;
        }
        public List<int[]> GetRow(int place_x)
        {
            // return a list containing all the places (place is an int arrays with 2 vals, first is X second is Y) from the same row

            List<int[]> cell_list = new List<int[]>();
            int[] place = new int[2];
            place[0] = place_x;
            for (int i = 0; i < side_size; i++)
            {
                place[1] = i;
                cell_list.Add(place.Clone() as int[]);
            }
            return cell_list;
        }
        public List<int[]> GetCol(int place_y)
        {
            // return a list containing all the places (place is an int arrays with 2 vals, first is X second is Y) from the same col
            List<int[]> cell_list = new List<int[]>();
            int[] place = new int[2];
            place[1] = place_y;
            for (int i = 0; i < side_size; i++)
            {
                place[0] = i;
                cell_list.Add(place.Clone() as int[]);
            }
            return cell_list;
        }
        public List<int[]> GetSquare(int place_x, int place_y)
        {
            // return a list containing all the places (place is an int arrays with 2 vals, first is X second is Y) from the same square
            List<int[]> cell_list = new List<int[]>();
            int[] place = new int[2];
            int square_size = (int)Math.Sqrt(side_size);
            int[] square_starter = GetSquareStarters(place_x, place_y);
            for (int i = 0; i < square_size; i++)
            {
                for (int j = 0; j < square_size; j++)
                {

                    place[0] = square_starter[0] + i;
                    place[1] = square_starter[1] + j;
                    cell_list.Add(place.Clone() as int[]);
                }
            }
            return cell_list;
        }
        public int[] GetCellWithMinOption()
        {
            // return the place of the cell with the minimum amount of possible numbers (that isn't solved). if all of the board is solved return null;
            int min = side_size;
            int[] place = new int[2];
            int amount_possible;
            int counter = 0;
            for(int i = 0; i < side_size; i++)
            {
                for(int j = 0; j < side_size; j++)
                {
                    amount_possible = cells[i, j].get_amount_possible();
                    if (amount_possible <= min && amount_possible != 1)  
                    {
                        place[0] = i;
                        place[1] = j;
                        min = amount_possible;
                    }
                    if(amount_possible == 1)
                    {
                        counter++;
                    }
                }
            }
            if(counter == side_size * side_size)
            {
                return null;
            }
            return place;
        }

        public Object Clone()
        {
            //Clone the board
            Board new_board = new Board(side_size);
            new_board.SetCells(cells);
            new_board.SetWhatCellSolvedMat(what_cell_is_solved_mat.Clone() as WhatCellSolvedMat);
            return new_board;
        }
    }
}
