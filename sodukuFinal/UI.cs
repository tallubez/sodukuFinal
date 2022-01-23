using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class UI
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.test();

        }
        public void NextBoard()
        {
            Console.WriteLine("Eneter 1 to enter board from console");
            Console.WriteLine("Eneter 2 to enter board from txt File");
            Console.WriteLine("Eneter 3 to end");
        }

    }
}
