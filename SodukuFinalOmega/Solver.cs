using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace sodukuFinal
{
    public class Solver
    {
        private bool solved_flag;
        private bool solved_flag_copy;
        private string solved_board;
        public bool NoGuessSolver(Board game_board)
        {
            //try to solve the board only with solving methods without guessing numbers. return false if board cant be solved.
            if (solved_flag)
            {
                return true;
            }
            int side_size = game_board.getSize();
            HiddenSingleFinder hiddenSingleFinder_service = new HiddenSingleFinder();
            if (!hiddenSingleFinder_service.hidden_single_shell(game_board))
            { 
                return false;
            }
            if (solved_flag)
            {
                return true;
            }
            HiddenClusters hiddenClustersFinder_service = new HiddenClusters();
            if  (!hiddenClustersFinder_service.FindHiddenClusters(game_board))
            {
                return false;
            }
            NakedSingleFinder nakedSingleFinder_service = new NakedSingleFinder();
            if (!nakedSingleFinder_service.NakedSingles(game_board))
            {
                return false;
            }
            Intersection intersection_service = new Intersection();
            if (!intersection_service.IntersectionShell(game_board))
            {
                return false;
            }
            if (solved_flag)
            {
                return true;
            }
            return true;
        }


     
        public bool Guess(Board game_board)
        {
            //try to solve board in this system:
            //1. get board and find the cell (that isn't solved) with minimum options in possible numbers
            //2. randomly guess from one of the option and create a clone of the board but at the cell put the guess instead of the possible numbers.
            //3. try to solved the new board, first with noguesssolver and then with guess.
            //4. if the clone board is solved than the solved board is an answer to the original board
            //5. if the clone board can't be solved try different guess.
            //6. if none of the guesses can be solved than the board can't be solved.
            if (solved_flag || !solved_flag_copy) // if solved
            {
                return true;
            }
            int side_size = game_board.getSize();
            int[] place = game_board.GetCellWithMinOption();
            if(place == null)
            {
                Solved(game_board);
                return true;
            }
            int place_x = place[0];
            int place_y = place[1];
            List<int> copy_get_possible_nums = new List<int>(game_board.GetCell(place_x, place_y).get_possible_nums().ToList());
            for (int i = 0; i < copy_get_possible_nums.Count; i++)
            {

                int number = copy_get_possible_nums[i];
                Board guess_game_board = game_board.Clone() as Board; // clone the board
                guess_game_board.GetCell(place_x, place_y).SetToSpecificNum(number);
   
                if (number_found(guess_game_board, place_x, place_y))
                {
                    if (solved_flag || !solved_flag_copy)
                    {
                        return true;
                    }
                    if (NoGuessSolver(guess_game_board))
                        if (place_y < side_size - 1)
                        {
                            if (Guess(guess_game_board))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Guess(guess_game_board))
                            {
                                return true;
                            }

                        }
                }
            }
            return false;
        }
        

        public Boolean number_found(Board game_board, int place_x, int place_y)
        {
            // when a number is found remove it from the option of all of the cells in the same row, col and squrae.
            // calls number found if while removing the number a new cell is solved.
            //return false if the board can't be solved.
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
            //when board is solved print it, set the answer to the solved board as string and set the solved flag true.
            BoardValidation boardValidation_service = new BoardValidation();

            if (!solved_flag && solved_flag_copy)
            {
                BoardPrinter board_printing_service = new BoardPrinter();
                board_printing_service.PrintSolvedBoard(game_board);
                solved_flag = true;
                solved_flag_copy = false;
                solved_board = game_board.GetBoardAsString();
            }
            solved_flag = true;

        }
        public String Solve(String s)
        {
            //Get board as string and solve it. return solved board as string if board can be solved and rturn null if it can't.
            ValidateInput validateInput_service = new ValidateInput();
            if (!validateInput_service.validate(s))
            {
                return null;
            }
            solved_flag = false;
            solved_flag_copy = true;
            solved_board = "";
            StringToMat stringToMat_service = new StringToMat();
            Board game_board = stringToMat_service.Create_mat(s);
            BoardPrinter board_printing_service = new BoardPrinter();
            board_printing_service.PrintStartBoard(game_board);
            if (!NoGuessSolver(game_board))
            {
                Console.WriteLine("This board can't be solved");
                return null;
            }
            if (solved_flag || !solved_flag_copy)
            {
                return solved_board;
            }

            if (!Guess(game_board))
            {

                Console.WriteLine("This board can't be solved");
                return null;
            }
            return solved_board;

        }
    }
}


