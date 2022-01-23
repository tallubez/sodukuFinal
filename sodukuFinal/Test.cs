using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sodukuFinal
{
    class Test
    {
        public void test()
        {
            Solver solver_service = new Solver();
            string s1 = "4300123000202100";
            solver_service.Solve(s1);
        }
    }
}
