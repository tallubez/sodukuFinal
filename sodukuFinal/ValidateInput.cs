using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class ValidateInput
    {
        public bool validate(string str)
        {
            if (!validateSize(str))
            {
                return false;
            }
            return validateCharacters(str);
        }
        public bool validateSize(string str)
        {
            double string_len = str.Length;
            double side_size = Math.Sqrt(string_len);
            if (side_size % 1 != 0)
            {
                Console.WriteLine("The string leangth is not valid");
                return false;
            }
            double square_size = Math.Sqrt(side_size);
            if (square_size % 1 != 0)
            {
                Console.WriteLine("The string leangth is not valid");
                return false;
            }
            return true;
        }
        public bool validateCharacters(string str)
        {
            double side_size = Math.Sqrt(str.Length);
            foreach (char ch in str)
            {
                if ((int)ch < (int)'0' || (int)ch > (int)'0' + side_size)
                {
                    Console.WriteLine("The character " + ch + " is not valid");
                    return false;
                }
            }
            return true;
        }

    }
}
