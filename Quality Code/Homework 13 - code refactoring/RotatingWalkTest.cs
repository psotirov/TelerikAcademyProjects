using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;
using System.IO;

namespace MatrixTest
{
    /// <summary>
    /// Ensures 100% code coverage as per dotCover statistics
    /// </summary>
    [TestClass]
    public class RotatingWalkTest
    {
        [TestMethod]
        public void TestMatrix6()
        {
            string expected =   "Enter matrix dimension N: " + Environment.NewLine +
                                "    1   16   17   18   19   20" + Environment.NewLine +
                                "   15    2   27   28   29   21" + Environment.NewLine +
                                "   14   31    3   26   30   22" + Environment.NewLine +
                                "   13   36   32    4   25   23" + Environment.NewLine +
                                "   12   35   34   33    5   24" + Environment.NewLine +
                                "   11   10    9    8    7    6" + Environment.NewLine + Environment.NewLine +
                                "Press Enter to finish" + Environment.NewLine;
            StringReader sr = new StringReader("6\n\n");
            StringWriter sw = new StringWriter();

            Console.SetIn(sr);
            Console.SetOut(sw);
            RotatingWalk.Main();
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
            Assert.AreEqual(sw.ToString(), expected);
        }

        [TestMethod]
        public void TestMatrix1()
        {
            string expected =   "Enter matrix dimension N: " + Environment.NewLine +
                                "    1" + Environment.NewLine + Environment.NewLine + 
                                "Press Enter to finish" + Environment.NewLine;
            StringReader sr = new StringReader("1\n\n");
            StringWriter sw = new StringWriter();

            Console.SetIn(sr);
            Console.SetOut(sw);
            RotatingWalk.Main();
            Console.SetIn(Console.In);
            Console.SetOut(Console.Out);
            Assert.AreEqual(sw.ToString(), expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMatrix0()
        {
            StringReader sr = new StringReader("0\n\n");

            Console.SetIn(sr);
            RotatingWalk.Main();
            Console.SetIn(Console.In);
        }
    }
}
