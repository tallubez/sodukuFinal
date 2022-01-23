using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            int side_size = 9;
            string s = "1234123412341234";
            StringToMat string_to_mat_service = new StringToMat();
            Board b = string_to_mat_service.Create_mat(s);
            BoardPrintert bp = new BoardPrintert();
            bp.PrintBoard(b);

        }
        public void save()
        {
            int side_size = 9;
            string s = "1234123412341234";
            StringToMat string_to_mat_service = new StringToMat();
            Board b = string_to_mat_service.Create_mat(s);
            BoardPrintert bp = new BoardPrintert();
            bp.PrintBoard(b);
        }
    }
}
