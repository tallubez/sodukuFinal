using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sodukuFinal
{
    public class UI
    {
        [STAThread]
        public static void Main(string[] args)
        {
            UI run_program = new UI();

            run_program.NextBoard();
        }
        public void NextBoard()
        {

            //handle the next board.
            try
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
                Console.ReadKey();
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is ArgumentException)
            {
                Console.WriteLine("File Isn't valid - try again");
                NextBoard();
            }
        }
        public void HandleChoice(string answer)
            //handle the choice from console. 1 for borad from console, 2 for board from txt file, 3 to end.
        {   if (answer != "3")
            {
                if (answer == "1")
                {
                    Console.WriteLine("Enter board");
                    string new_board = Console.ReadLine();
                    solve(new_board);
                }
                else if (answer == "2")
                {
                    txtFileToString FileOpener = new txtFileToString();
                    string new_board = FileOpener.FileToString();
                    string solved = solve(new_board);
                    if (solved != null)
                    {
                        FileOpener.SolvedStringToTxtFile(solved);
                    }

                }
                else
                {
                    Console.WriteLine("Input is not valid, try again");
                }
            }
        }
        public string solve(string board)
        {
            Solver solver = new Solver();
            return solver.Solve(board);
        }
        

    }
}
