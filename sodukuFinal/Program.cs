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
            
            List<int[]> all_effected_places = new List<int[]>();
            int[] place = { 1, 2 };
            all_effected_places.Add(place.Clone() as int[]);
            place[0] = 8;
            all_effected_places.Add(place);
            Console.WriteLine(all_effected_places[0][0]);
            Console.WriteLine(all_effected_places[0][1]);
            Console.WriteLine(all_effected_places[1][0]);
            Console.WriteLine(all_effected_places[1][1]);
            Console.WriteLine(place[0]);


        }
    }
}
