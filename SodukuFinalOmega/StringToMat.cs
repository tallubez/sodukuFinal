using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class StringToMat
    {
        public Board Create_mat(string str)
        {
            int len = str.Length;
            int side_len = (int)Math.Sqrt(len);
            Board game_mat = new Board(side_len);
            int[] number_line = new int[side_len];
            for(int i = 1; i <= side_len; i++)
            {
                number_line[i - 1] = i;
            }
            char current_c;
            for (int i = 0; i < side_len; i++)
            {
                for (int j = 0; j < side_len; j++)
                {
                    current_c = str[side_len * i + j];
                    if((int)current_c < 48 || (int)current_c > 48 + side_len)
                    {
                        Console.WriteLine("The character" + current_c + "is unavailable, please insert different string");
                        return null;
                    }
                    Cell newCell = new Cell();
                    if (current_c == '0')
                    {
                        newCell.add_possible_nums(number_line);
                    }
                    else
                    {
                        newCell.SetToSpecificNum((int)current_c - '0');
                        game_mat.GetWhatCellSolvedMat().SetCellSolved(i, j);
                    }
                    game_mat.setCell(newCell, i, j);
                    
                }
            }
            return game_mat;
        }

        public String SolveBoardToString(Board game_board)
        {
            String outcome = "";
            int side_size = game_board.getSize();
            for(int i = 0; i < side_size; i++)
            {
                for (int j = 0; j < side_size; j++)
                {
                    outcome = outcome + ((char)(game_board.GetCell(i, j).get_possible_nums()[0] + '0')).ToString();
                }
            }
            return outcome;
        }
    }
}

