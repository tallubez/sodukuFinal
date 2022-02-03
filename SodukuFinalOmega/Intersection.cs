using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class Intersection
    {
        public bool IntersectionShell(Board game_board)
        {
            int side_size = game_board.getSize();
            int square_size = (int)Math.Sqrt(side_size);
            for (int x = 0; x < side_size; x += square_size)
            {
                for (int y = 0; y < side_size; y += square_size)
                {
                    if (!FindIntersections(game_board, game_board.GetSquare(x, y)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool FindIntersections(Board game_board, List<int[]> square)
        {
            Solver number_found_service = new Solver();
            int side_size = game_board.getSize();
            int x_option, y_option;
            int amount_y, amount_x;
            HashSet<int> x_in_box = new HashSet<int>();
            HashSet<int> y_in_box = new HashSet<int>();
            for (int i = 1; i <= side_size; i++)
            {
                amount_x = 0;
                amount_y = 0;
                x_option = 0;
                y_option = 0;
                foreach(int[] place in square)
                {
                    x_in_box.Add(place[0]);
                    y_in_box.Add(place[1]);
                    if(game_board.GetCell(place[0], place[1]).get_possible_nums().Contains(i))
                    {
                        if (amount_x == 0)
                        {
                            x_option = place[0];
                            amount_x++;
                        }
                        else if(x_option != place[0])
                        {
                            amount_x++;
                        }
                        if (amount_y == 0)
                        {
                            y_option = place[1];
                            amount_y++;
                        }
                        else if (y_option != place[1])
                        {
                            amount_y++;
                        }
                    }
                }
                if (amount_x == 1) 
                {
                    for (int y = 0; y < side_size; y++) 
                    {
                        if (!y_in_box.Contains(y))
                        {
                            if(game_board.GetCell(x_option, y).remove_possible_nums(i))
                            {
                                if (game_board.GetCell(x_option, y).get_amount_possible() == 1)
                                {
                                    if (!number_found_service.number_found(game_board, x_option, y))
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                }
                if(amount_y == 1)
                {
                    for (int x = 0; x < side_size; x++)
                    {
                        if (!x_in_box.Contains(x))
                        {
                            if(game_board.GetCell(x, y_option).remove_possible_nums(i))
                            { 
                            if (game_board.GetCell(x, y_option).get_amount_possible() == 1)
                            {
                                if (!number_found_service.number_found(game_board, x, y_option))
                                {
                                    return false;
                                }
                            }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
