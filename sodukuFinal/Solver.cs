using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class Solver
    {
 
        public void update_possible_number(Board game_board, int place_x, int place_y)
        {
            List<int[]> all_effected_places = game_board.GetAllEffectedPlaces(place_x, place_y);
            int number_to_remove;
            int x_current_point, y_current_point;
            for(int i=0; i < all_effected_places.Count; i++)
            {
                x_current_point = all_effected_places[i][0];
                y_current_point = all_effected_places[i][1];
                if (game_board.GetCell(x_current_point, y_current_point).get_amount_possible() == 1)
                {
                    number_to_remove = game_board.GetCell(x_current_point,y_current_point).get_possible_nums()[0];
                    game_board.GetCell(place_x, place_y).remove_possible_nums(number_to_remove);
                }
            }
            if(game_board.GetCell(place_x, place_y).get_amount_possible() == 1)
            {
                number_found(game_board, place_x, place_y);
            }
        }

        public void number_found(Board game_board, int place_x, int place_y)
        {
            if (!game_board.GetWhatCellSolvedMat().IsCellSolved(place_x, place_y))
            {
                game_board.GetWhatCellSolvedMat().SetCellSolved(place_x, place_y);
                if (game_board.GetWhatCellSolvedMat().GetAmountSolved() == game_board.getSize() * game_board.getSize())
                {
                    solved(game_board);
                }
                List<int[]> all_effected_places = game_board.GetAllEffectedPlaces(place_x, place_y);
                int number_to_remove = game_board.GetCell(place_x, place_y).get_possible_nums()[0];
                int x_current_point, y_current_point;
                for (int i = 0; i < all_effected_places.Count; i++)
                {
                    x_current_point = all_effected_places[i][0];
                    y_current_point = all_effected_places[i][1];
                    game_board.GetCell(x_current_point, y_current_point).remove_possible_nums(number_to_remove);
                    if (game_board.GetCell(x_current_point, y_current_point).get_amount_possible() == 1)
                    {
                        number_found(game_board, x_current_point, y_current_point);
                    }
                }
            }
        }
        public void solved(Board game_board)
        {

        }


    }
}
