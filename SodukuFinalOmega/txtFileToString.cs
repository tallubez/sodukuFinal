using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Forms;



namespace sodukuFinal
{
    public class txtFileToString
    {
        private string path;
        public txtFileToString()
        {
            //get the txt file path
            OpenFileDialog open_file_service = new OpenFileDialog();
            open_file_service.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (open_file_service.ShowDialog() == DialogResult.OK)
                path = open_file_service.FileName;
        }
        public string FileToString()
        {
            //open txt file from file explorer and return it as string
            String borad = File.ReadAllText(path);
            return borad;
        }
        public void SolvedStringToTxtFile(string solved_board )
        {
            //create a file containing the solved board.
            string filename = Path.GetFileName(path);
            string newfile_path = path.Remove(path.Length - 4, 4);
            newfile_path = newfile_path + "solved.txt";
            // Create the file and use streamWriter to write text to it.
            //If the file existence is not check, this will overwrite said file.
            //Use the using block so the file can close and vairable disposed correctly
            using (StreamWriter writer = File.CreateText(newfile_path))
            {

                writer.WriteLine(solved_board);
            }


        }
    

    }
}
