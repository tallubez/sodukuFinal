using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class Solver
    {
        private bool is_guess_flag;
        private bool solved_flag;
        private string solved_board;
        public bool NoGuessSolver(Board game_board)
        {
            int side_size = game_board.getSize();
            NakedSingleFinder nakedSingleFinder_service = new NakedSingleFinder();
            if (!nakedSingleFinder_service.NakedSingles(game_board))
            {
                return false;
            }
            HiddenSingleFinder hiddenSingleFinder_service = new HiddenSingleFinder();
            if (!hiddenSingleFinder_service.hidden_single_shell(game_board))
            { 
                return false;
            }
            return true;
        }


        public bool Guess(Board game_board, int place_x, int place_y)
        {
            if (solved_flag)
            {
                return true;
            }
            int side_size = game_board.getSize();
            if (place_x == side_size)
            {
                Solved(game_board);
                return true;
            }

                if (place_x > side_size)
            {
                Console.WriteLine("BIG PROBLEM");
                return false;
            }

            if (game_board.GetCell(place_x, place_y).get_amount_possible() > 0)
            {
                List<int> copy_get_possible_nums = new List<int>(game_board.GetCell(place_x, place_y).get_possible_nums().ToList());
                foreach (int number in copy_get_possible_nums)
                {
                    Board guess_game_board = game_board.Clone() as Board;
                    guess_game_board.GetCell(place_x, place_y).SetToSpecificNum(number);
                    if(number_found(guess_game_board, place_x, place_y))
                    { 
                        if (place_y < side_size-1)
                        {
                            if (Guess(guess_game_board, place_x, place_y+1))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Guess(guess_game_board, place_x + 1, 0))
                            {
                                return true;
                            }

                        }
                    }

                }
            }
            return false;
        }

        
       
        public Boolean number_found(Board game_board, int place_x, int place_y)
        {
            if (!game_board.GetWhatCellSolvedMat().IsCellSolved(place_x, place_y))
            {
                game_board.GetWhatCellSolvedMat().SetCellSolved(place_x, place_y);
                if (game_board.GetWhatCellSolvedMat().GetAmountSolved() == game_board.getSize() * game_board.getSize())
                {
                    Solved(game_board);
                    return true;

                }
                List<int[]> all_effected_places = game_board.GetAllEffectedPlaces(place_x, place_y);
                int number_to_remove = game_board.GetCell(place_x, place_y).get_possible_nums()[0];
                int x_current_point, y_current_point, current_amount_possible;
                for (int i = 0; i < all_effected_places.Count; i++)
                {
                    x_current_point = all_effected_places[i][0];
                    y_current_point = all_effected_places[i][1];
                    game_board.GetCell(x_current_point, y_current_point).remove_possible_nums(number_to_remove);
                    current_amount_possible = game_board.GetCell(x_current_point, y_current_point).get_amount_possible();
                    if (current_amount_possible == 1)
                    {
                        if(!number_found(game_board, x_current_point, y_current_point))
                        {
                            return false;
                        }
                    }
                    else if (current_amount_possible == 0)
                    {
                        return false;

                    }
                }
            }
            return true;
        }

        public void Solved(Board game_board)
        {
            BoardPrinter board_printing_service = new BoardPrinter();
            board_printing_service.PrintSolvedBoard(game_board);
            solved_flag = true;
            
        }
        public String Solve(String s)
        {

            is_guess_flag = false;
            solved_flag = false;
            StringToMat stringToMat_service = new StringToMat();
            Board game_board = stringToMat_service.Create_mat(s);
            BoardPrinter board_printing_service = new BoardPrinter();
            board_printing_service.PrintStartBoard(game_board);
            if (!NoGuessSolver(game_board))
            {
                board_printing_service.PrintStartBoard(game_board);
                Console.WriteLine("This board can't be solved");
                return null;
            }
            if (solved_flag)
            {
                return "yes";
            }
            Console.WriteLine("board before trying to guess:");
            board_printing_service.PrintStartBoard(game_board);
            is_guess_flag = true;
            if (!Guess(game_board, 0, 0))
            {

                Console.WriteLine("This board can't be solved");
                return null;
            }
            return "?";

        }
    }
}


