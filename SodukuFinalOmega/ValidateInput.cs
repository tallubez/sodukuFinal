using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class ValidateInput
    {
        public bool validate(string str)
        {
            //validate that the input is valid. return true is valid false if not.
            if (!validateSize(str))
            {
                return false;
            }
            return validateCharacters(str);
        }
        public bool validateSize(string str)
        {
            if(str.Length == 0)
            {
                Console.WriteLine("String can't be empty");
                return false;
            }
            //validate that the size is valid.
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
            // validate that all the chars are valid.
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
