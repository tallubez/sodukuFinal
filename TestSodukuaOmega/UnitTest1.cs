using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using sodukuFinal;

namespace TestSodukuaOmega
{
 
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solver solver_service = new Solver();
            BoardValidation check_board_service = new BoardValidation();
            foreach (string string_to_test in GetValidSolvableString())
            {
                Assert.IsTrue(check_board_service.IsBoardCorrect(solver_service.Solve(string_to_test)));
            }
        }
        public List<string> GetValidSolvableString()
        {
            List<string> valid_solveable = new List<string>();
            string empty1x1 = "0";
            valid_solveable.Add(empty1x1);
            string empty4x4 = "0000000000000000";
            valid_solveable.Add(empty4x4);
            string empty9x9 = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            valid_solveable.Add(empty9x9);
            string empty16x16 = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                                "000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                                "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            valid_solveable.Add(empty16x16);
            string full1x1 = "1";
            valid_solveable.Add(full1x1);
            string normal4x4 = "4300123000202100";
            valid_solveable.Add(normal4x4);
            string easy9x9 = "410007560800009401500040000730000600946000813005000042000030004601200007094100086";
            valid_solveable.Add(easy9x9);
            string moderate9x9 = "060403020400109006001506400627000318000000000583000974006708200200304009010602040";
            valid_solveable.Add(moderate9x9);
            string hard9x9 = "020005900109308400603900000300004001000209000700100009000001604001406205004500080";
            valid_solveable.Add(hard9x9);
            string easy16x16 = "000=000000000000000000000000000220<00000000000007000?00060001000" +
                               "000>00000000030000000>000000<900000000000000000600000000000000@0" +
                               "00>00000000000000000600000000000000000000006000000000000<3000600" +
                               "=0000000000000;0000000@0020000000000000?000000000000000000100000";
            valid_solveable.Add(easy16x16);
            string modarate16x16 = "102000;680054<00>00;08:0<09007000<00000002700?090090070000:0>" +
                                   "85;0:0@1002;40600080300000900000000;942050>00=030000000008@392" +
                                   "0040000100:?39600000000060900@0<02;4>00000000200000102000@0>8100" +
                                   "=<06054?10>0000600@0060@00250000000<000<00@0:0710=00400:>?00;43000501";
            valid_solveable.Add(modarate16x16);
            string hard16x16 = "040080@0;010060>30090?04:70=00<006002;0080003000?000000=00>00204" +
                              "0008030070005000000000>0000:0@0=009250000800;000<010000@00=00030" +
                              "000<?0000600=047@1=0:00300700900600000;04009002:03000@000>800;00" +
                              "5;3:000800<400010>00;9000=?04050=040600000020<090<0@0=00010060?0";
            valid_solveable.Add(hard16x16);
            return valid_solveable;
        }
    }
}
