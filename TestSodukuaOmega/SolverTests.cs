using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sodukuFinal;

namespace TestSodukuaOmega
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void Solve_Valid1zero_true()
        {
            //Arrange
            string empty = "0";
            Solver s = new Solver();
            BoardValidation check_ans = new BoardValidation();
            //Act
            string solved = s.Solve(empty);
            bool flag = solved == "1";
            //Assert
            Assert.IsTrue(flag);

        }
        [TestMethod]
        public void Solve_Valid16x16zeros_true()
        {
            //Arrange
            string empty16x16 = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                                "000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                                "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            Solver s = new Solver();
            BoardValidation check_ans = new BoardValidation();
            //Act
            string solved = s.Solve(empty16x16);
            bool flag = check_ans.IsBoardCorrect(solved);
            //Assert
            Assert.IsTrue(flag);

        }
        [TestMethod]
        public void Solve_Valid4x4_true()
        {
            //Arrange
            string normal4x4 = "4300123000202100";
            Solver s = new Solver();
            BoardValidation check_ans = new BoardValidation();
            //Act
            string solved = s.Solve(normal4x4);
            bool flag = check_ans.IsBoardCorrect(solved);
            //Assert
            Assert.IsTrue(flag);
            
        }
        [TestMethod]
        public void Solve_Valid9x9_true()
        {
            //Arrange
            string normal9x9 = "060403020400109006001506400627000318000000000583000974006708200200304009010602040";
            Solver s = new Solver();
            BoardValidation check_ans = new BoardValidation();
            //Act
            string solved = s.Solve(normal9x9);
            bool flag = check_ans.IsBoardCorrect(solved);
            //Assert
            Assert.IsTrue(flag);

        }
        [TestMethod]
        public void Solve_Valid16x16_true()
        {
            //Arrange
            string normal16x16 = "000=000000000000000000000000000220<00000000000007000?00060001000" +
                               "000>00000000030000000>000000<900000000000000000600000000000000@0" +
                               "00>00000000000000000600000000000000000000006000000000000<3000600" +
                               "=0000000000000;0000000@0020000000000000?000000000000000000100000";
            Solver s = new Solver();
            BoardValidation check_ans = new BoardValidation();
            //Act
            string solved = s.Solve(normal16x16);
            bool flag = check_ans.IsBoardCorrect(solved);
            //Assert
            Assert.IsTrue(flag);

        }
        [TestMethod]
        public void Solve_ValidHard16x16_true()
        {
            //Arrange
            string hard16x16 = "040080@0;010060>30090?04:70=00<006002;0080003000?000000=00>00204" +
                           "0008030070005000000000>0000:0@0=009250000800;000<010000@00=00030" +
                           "000<?0000600=047@1=0:00300700900600000;04009002:03000@000>800;00" +
                           "5;3:000800<400010>00;9000=?04050=040600000020<090<0@0=00010060?0";
            Solver s = new Solver();
            BoardValidation check_ans = new BoardValidation();
            //Act
            string solved = s.Solve(hard16x16);
            bool flag = check_ans.IsBoardCorrect(solved);
            //Assert
            Assert.IsTrue(flag);

        }
        [TestMethod]
        public void Solve_NotValid1x1_true()
        {
            //Arrange
            string NotValid1x1 = "2";
            Solver s = new Solver();
            //Act
            bool flag = s.Solve(NotValid1x1) == null;
            //Assert
            Assert.IsTrue(flag);

        }
        [TestMethod]
        public void Solve_NotValid4x4_true()
        {
            //Arrange
            string NotValid4x4 = "1230000400000000";
            Solver s = new Solver();
            //Act
            bool flag = s.Solve(NotValid4x4) == null;
            //Assert
            Assert.IsTrue(flag);

        }
        [TestMethod]
        public void Solve_NotValid9x9_true()
        {
            //Arrange
            string NotValid9x9 = "123456780000000009000506400627000318000000000583000974006708200200304009010602040";
            Solver s = new Solver();
            //Act
            bool flag = s.Solve(NotValid9x9) == null;
            //Assert
            Assert.IsTrue(flag);

        }
        [TestMethod]
        public void Solve_NotValid16x16_true()
        {
            //Arrange
            string NotValid16x16 = "000000000000000000000000000000000000000000000000000" + 
                "00000000000000000000000000000000000000000000000000000000000000000000000" +
                "00000000000000000000000000000000000000000000000000000000000000000000000" +
                "00000000000000000000000000000000000000000000000123456789:;<=>? 000000000" +
                "0000000000000000000000000000000000000000000000000000000000000000000000000" + 
                "00000000000000000000000000000000000000000000000000000000000000000000000000" + 
                "000000000000000000000000000000000000000000000000000000000000000000000000000000000000@";
            Solver s = new Solver();
            //Act
            bool flag = s.Solve(NotValid16x16) == null;
            //Assert
            Assert.IsTrue(flag);

        }

    }
}
