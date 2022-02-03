using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    public class Cell: ICloneable
    {
        private List<int> possible_nums;

        public Cell()
        {
            possible_nums = new List<int>();
        }
        public int get_amount_possible()
        {
            return possible_nums.Count;
        }
        public List<int> get_possible_nums()
        {
            return possible_nums;
        }
        public void SetPossibleNums(List<int> possible)
        {
            this.possible_nums.Clear();
            for(int i=0; i< possible.Count; i++)
            {
                possible_nums.Add(possible[i]);
            }
        }
        public void SetToSpecificNum(int number)
        {
            possible_nums.Clear();
            possible_nums.Add(number);
        }
        public bool remove_possible_nums(int number)
        {
            if (possible_nums.Contains(number))
            {
                possible_nums.Remove(number);
                return true;
            }
            return false;
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
        public object Clone()
        {
            Cell copy_c = new Cell();
            List<int> possible = new List<int>(get_possible_nums());
            copy_c.SetPossibleNums(possible);
            return copy_c;
        }
    }

}
