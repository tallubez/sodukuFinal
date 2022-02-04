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
            int square_size = (int)Math.Sqrt(side_size);
            Console.WriteLine("Starting board:");
            for (int i = 0; i < side_size; i++)
            {
                if (i % square_size == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                for (int k = 0; k < side_size; k++)
                { Console.Write("----"); }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                for (int j = 0; j < side_size; j++)
                {
                    if (game_board.GetCell(i, j).get_amount_possible() != 1 || side_size == 1)
                    {
                        if (j % square_size == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write("|   ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else

                    {
                        if (j % square_size == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write("|");
                        Console.ForegroundColor = ConsoleColor.White;
                        if (game_board.GetCell(i, j).get_possible_nums()[0] < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(game_board.GetCell(i, j).get_possible_nums()[0] + " ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < side_size; i++)
            { Console.Write("----"); }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintSolvedBoard(Board game_board)
        {
            //print the board when solved
            Console.WriteLine("Solved board:");
            int side_size = game_board.getSize();
            int square_size = (int)Math.Sqrt(side_size);
            for (int i = 0; i < side_size; i++)
            {
                if (i % square_size == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                for (int k = 0; k < side_size; k++)
                { Console.Write("----"); }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                for (int j = 0; j < side_size; j++)
                {
                    if (j % square_size == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (game_board.GetCell(i, j).get_possible_nums()[0] < 10)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(game_board.GetCell(i, j).get_possible_nums()[0] + " ");
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < side_size; i++)
            { Console.Write("----"); }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}
