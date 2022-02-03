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
        public string FileToString()
        {
            OpenFileDialog open_file_service = new OpenFileDialog();
            String path = "";
            open_file_service.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (open_file_service.ShowDialog() == DialogResult.OK)
                path = open_file_service.FileName;
            String borad = File.ReadAllText(path);
            return borad;
        }
    

    }
}
