using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class HiddenSingleFinder
    {
        public bool hidden_single_shell(Board game_board)
        {
            int side_size = game_board.getSize();
            List<int[]> cells_to_search = new List<int[]>();
            int[] place = new int[2];
            List<int> amount_number_can_apear = new List<int>();
            for (int i = 0; i < side_size; i++)
            {
                cells_to_search.Clear();
                place[0] = i;
                for (int j = 0; j < side_size; j++)
                {
                    place[1] = j;
                    cells_to_search.Add(place.Clone() as int[]);
                }
                if (!hidden_single(cells_to_search, game_board))
                {
                    return false;
                }
                cells_to_search.Clear();
                place[1] = i;
                for (int j = 0; j < side_size; j++)
                {
                    place[0] = j;
                    cells_to_search.Add(place.Clone() as int[]);
                }
                
                if (!hidden_single(cells_to_search, game_board))
                {
                    return false;
                }

            }
            int square_size = (int)Math.Sqrt(side_size);
            for (int x = 0; x < side_size; x += square_size)
            {
                for (int y = 0; y < side_size; y += square_size)
                {
                    cells_to_search.Clear();
                    for (int i = 0; i < square_size; i++)
                    {

                        for (int j = 0; j < square_size; j++)
                        {

                            place[0] = x + i;
                            place[1] = y + j;
                            cells_to_search.Add(place.Clone() as int[]);
                        }
                    }
                    if (!hidden_single(cells_to_search, game_board))
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public bool hidden_single(List<int[]> cell_group, Board game_board)
        {
            Solver number_found_service = new Solver();
            game_board.GetCell(0, 1).get_possible_nums();
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
            game_board.GetCell(0, 1).get_possible_nums();
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
