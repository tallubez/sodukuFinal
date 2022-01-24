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
            if (!NakedSingles(game_board))
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
        public bool NakedSingles(Board game_board)
        {
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
        public bool Guess(Board game_board, int place_x, int place_y)
        {
            is_guess_flag = true;
            if (solved_flag)
            {
                return true;
            }
            int side_size = game_board.getSize();
            if (place_x == side_size - 1 && place_y == side_size - 1) // end of req
            {
                if (game_board.GetCell(place_x, place_y).get_amount_possible() == 1) //solved
                {
                    Solved(game_board);
                    return true;
                }
            }
            if (game_board.GetCell(place_x, place_y).get_amount_possible() == 1) // if cell is already set
            {
                if (place_x == side_size - 1)
                {
                    return Guess(game_board, 0, place_y + 1);
                }
                else
                {
                    return Guess(game_board, place_x + 1, place_y);
                }
            }
            if (game_board.GetCell(place_x, place_y).get_amount_possible() == 0) //if guess failed
            {
                return false;
            }
            List<int> add_guess_to_cell = new();
            bool can_guess_work_flag;
            if (game_board.GetCell(place_x, place_y).get_amount_possible() != 1)
            {
                List<int> copy_get_possible_nums = new List<int>(game_board.GetCell(place_x, place_y).get_possible_nums());
                foreach (int number in copy_get_possible_nums)
                {
                    add_guess_to_cell.Clear();
                    Board guess_game_board = game_board.Clone() as Board;
                    add_guess_to_cell.Add(number);
                    guess_game_board.GetCell(place_x, place_y).SetPossibleNums(add_guess_to_cell);
                    can_guess_work_flag = number_found(guess_game_board, place_x, place_y);
                    if (can_guess_work_flag)
                    {
                        if (place_x < side_size - 1)
                        {
                            if (Guess(guess_game_board, place_x + 1, place_y))
                            {
                                return true;
                            }
                        }
                        else if (place_y < side_size - 1)
                        {
                            if (Guess(guess_game_board, 0, place_y + 1))
                            {
                                return true;
                            }

                        }
                    }

                }
            }
            return false;

        }

        public bool update_possible_number(Board game_board, int place_x, int place_y)
        {
            is_guess_flag = false;
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
                if (!number_found(game_board, place_x, place_y))
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
                        ch(x_current_point, y_current_point, game_board);
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
        public void ch(int x,int y, Board game_board)
        {
            int current_amount_possible = game_board.GetCell(x, y).get_amount_possible();
            game_board.GetAllEffectedPlaces(x, y);
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


