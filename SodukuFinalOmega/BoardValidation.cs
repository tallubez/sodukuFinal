using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class BoardValidation
    {
        public bool IsBoardCorrect(String game_board_string)
        {
            StringToMat turn_to_board_srvice = new();
            Board game_board = turn_to_board_srvice.Create_mat(game_board_string);
            int side_size = game_board.getSize();
            for (int i = 0; i < side_size; i++)
            {
                if (!IsCellPatchCorrect(game_board.GetRow(i), game_board))
                {
                    return false;
                }
                if (!IsCellPatchCorrect(game_board.GetCol(i), game_board))
                {
                    return false;
                }

            }
            int square_size = (int)Math.Sqrt(side_size);
            for (int x = 0; x < side_size; x += square_size)
            {
                for (int y = 0; y < side_size; y += square_size)
                {
                    if (!IsCellPatchCorrect(game_board.GetSquare(x, y), game_board))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsCellPatchCorrect(List<int[]> cell_group, Board game_board)
        {
            int side_size = game_board.getSize();
            int[] all_number = new int[side_size + 1];
            foreach (int[] place in cell_group)
            {
                all_number[game_board.GetCell(place[0], place[1]).get_possible_nums()[0]]++;
            }
            for (int i = 1; i <= side_size; i++)
            {
                if (all_number[i] != 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
