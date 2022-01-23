using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class BoardPrintert
    {
        public void PrintBoard(Board game_board)
        {
            int side_size = game_board.getSize();
            for (int i=0; i < side_size; i++)
            {
                for (int k = 0; k < side_size; k++)
                { Console.Write("----"); }
                Console.WriteLine();
                for (int j = 0; j < side_size; j++)
                {
                    Console.Write("| " + game_board.GetCell(i, j).get_possible_nums()[0] + " ");
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
