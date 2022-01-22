using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class Cell
    {
        private List<int> possible_nums;

        public Cell(int line_size)
        {
            List<int> possinle_nums = new List<int>();
        }
        public int get_size()
        {
            return possible_nums.Count;
        }
        public List<int> get_possible_nums()
        {
            return possible_nums;
        }
        public void remove_possible_nums(int[] nums)
        {
            foreach(int number in nums)
            {
                if (possible_nums.Contains(number))
                {
                    possible_nums.Remove(number);
                }
            }
        }
        public void add_possible_nums(int[] nums)
        {
            foreach (int number in nums)
            {
                if (!possible_nums.Contains(number))
                {
                    possible_nums.Add(number);
                }
            }
        }
    }

}
