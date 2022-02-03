using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class BoardPrinter
    {
        public void PrintStartBoard(Board game_board)
        {
            // print the board before solving
            int side_size = game_board.getSize();
            Console.WriteLine("Starting board:");
            for (int i = 0; i < side_size; i++)
            {
                for (int k = 0; k < side_size; k++)
                { Console.Write("----"); }
                Console.WriteLine();
                for (int j = 0; j < side_size; j++)
                {
                    if (game_board.GetCell(i, j).get_amount_possible() != 1 || side_size == 1)
                    {
                        Console.Write("|   ");
                    }
                    else

                    {
                        Console.Write("|");
                        if(game_board.GetCell(i, j).get_possible_nums()[0] < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(game_board.GetCell(i, j).get_possible_nums()[0] + " ");
                    }
                }
                Console.Write("|");
                Console.WriteLine();
            }
            for (int i = 0; i < side_size; i++)
            { Console.Write("----"); }
            Console.WriteLine();
        }
        public void PrintSolvedBoard(Board game_board)
        {
            //print the board when solvedS
            Console.WriteLine("Solved board:");
            int side_size = game_board.getSize();
            for (int i = 0; i < side_size; i++)
            {
                for (int k = 0; k < side_size; k++)
                { Console.Write("----"); }
                Console.WriteLine();
                for (int j = 0; j < side_size; j++)
                {
                    Console.Write("|");
                    if (game_board.GetCell(i, j).get_possible_nums()[0] < 10)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(game_board.GetCell(i, j).get_possible_nums()[0] + " ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
            for (int i = 0; i < side_size; i++)
            { Console.Write("----"); }
            Console.WriteLine();

        }
    }
}
