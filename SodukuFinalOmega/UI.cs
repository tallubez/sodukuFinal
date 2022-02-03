﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class UI
    {
        
        public static void Main(string[] args)
        {
            int i;
            UI N = new UI();
            N.NextBoard();

        }
        public void NextBoard()
        {

            string answer;
            do
            {
                Console.WriteLine("Eneter 1 to enter board from console");
                Console.WriteLine("Eneter 2 to enter board from txt File");
                Console.WriteLine("Eneter 3 to end");
                answer = Console.ReadLine();
                HandleChoice(answer);
            }
            while (answer != "3");
            Console.WriteLine("Program finished.");

        }
        public void HandleChoice(string answer)
        {   if (answer != "3")
            {
                if (answer == "1")
                {
                    string new_board = Console.ReadLine();
                    solve(new_board);
                }
                else if (answer == "2")
                {
                    txtFileToString FileOpener = new txtFileToString();
                    string new_board = FileOpener.FileToString();
                    solve(new_board);

                }
                else
                {
                    Console.WriteLine("Input is not valid, try again");
                }
            }
        }
        public void solve(string board)
        {
            Solver solver = new Solver();
            solver.Solve(board);
        }
        

    }
}