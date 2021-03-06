using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class HiddenSingleFinder
    {
        //hidden single searches for numbers that only have one place to be in a group (only one cell have the number in his possible number list)
        public bool hidden_single_shell(Board game_board)
        {
            // send all of the groups of cells to search hidden single in them (rows, cols, squares). return false if the board can't be solved.
            int side_size = game_board.getSize();
            for (int i = 0; i < side_size; i++)
            { 
                if (!hidden_single(game_board.GetRow(i), game_board))
                {
                    return false;
                }
                if (!hidden_single(game_board.GetCol(i), game_board))
                {
                    return false;
                }

            }
            int square_size = (int)Math.Sqrt(side_size);
            for (int x = 0; x < side_size; x += square_size)
            {
                for (int y = 0; y < side_size; y += square_size)
                {
                    if (!hidden_single(game_board.GetSquare(x,y), game_board))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool hidden_single(List<int[]> cell_group, Board game_board)
        {
            //searches for hidden single in a cell gruop. if found than activates number found.  return false if the board can't be solved.
            Solver number_found_service = new Solver();
            int side_size = game_board.getSize();
            int[] possible_hidden_numbers = new int[side_size + 1];
            for (int i = 0; i < cell_group.Count; i++)
            {
                List<int> posible_numbers = new List<int>(game_board.GetCell(cell_group[i][0], cell_group[i][1]).get_possible_nums().ToList());
                foreach (int number in posible_numbers)
                {
                    possible_hidden_numbers[number] += 1;
                }
            }
            for (int i = 1; i <= side_size; i++)
            {
                if (possible_hidden_numbers[i] == 1)
                {
                    foreach (int[] place in cell_group)
                    {
                        List<int> posible_numbers = new List<int>(game_board.GetCell(place[0], place[1]).get_possible_nums());
                        if (posible_numbers.Contains(i))
                        {
                            if (posible_numbers.Count != 1)
                            {
                                game_board.GetCell(place[0], place[1]).SetToSpecificNum(i);
                                if (!number_found_service.number_found(game_board, place[0], place[1]))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                if(possible_hidden_numbers[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
