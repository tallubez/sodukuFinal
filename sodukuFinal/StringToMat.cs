using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class StringToMat
    {
        public int[,] Create_mat(string str)
        {
            int len = str.Length;
            int side_len = (int)Math.Sqrt(len);
            int[,] game_mat = new int[side_len, side_len];
            char current_c;
            for (int i = 0; i < side_len; i++)
            {
                for (int j = 0; j < side_len; j++)
                {
                    current_c = str[side_len * i + j];
                    if((int)current_c < 48 || (int)current_c > 48 + side_len)
                    {
                        Console.WriteLine("The character" + current_c + "is unavailable, please insert different string");
                        return null;
                    }
                    game_mat[i, j] = (int)current_c - 48; //48 = ascci '0'
                }
            }
            return game_mat;
        }
    }
}

