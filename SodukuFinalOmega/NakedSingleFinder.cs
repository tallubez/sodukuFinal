using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class NakedSingleFinder
    {
        //naked single is when a cell only has one number option. (when all of the known numbers remove all the options exept one.
        public bool NakedSingles(Board game_board)
        {
            //for each cell send it to update possible num.
            int side_size = game_board.getSize();
            for (int i = 0; i < side_size; i++)
            {
                for (int j = 0; j < side_size; j++)
                {
                    if (!update_possible_number(game_board, i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool update_possible_number(Board game_board, int place_x, int place_y)
        {
            //remove from a cell option all the solved number from the same row, col and box.
            Solver number_found_service = new Solver();
            List<int[]> all_effected_places = game_board.GetAllEffectedPlaces(place_x, place_y);
            int number_to_remove;
            int x_current_point, y_current_point;
            for (int i = 0; i < all_effected_places.Count; i++)
            {
                x_current_point = all_effected_places[i][0];
                y_current_point = all_effected_places[i][1];
                if (game_board.GetCell(x_current_point, y_current_point).get_amount_possible() == 1)
                {
                    number_to_remove = game_board.GetCell(x_current_point, y_current_point).get_possible_nums()[0];
                    game_board.GetCell(place_x, place_y).remove_possible_nums(number_to_remove);
                }
            }
            if (game_board.GetCell(place_x, place_y).get_amount_possible() == 1)
            {
                if (!number_found_service.number_found(game_board, place_x, place_y))
                {
                    return false;
                }
            }
            if (game_board.GetCell(place_x, place_y).get_amount_possible() == 0)
            {
                return false;
            }
            return true;
        }
    }
}
