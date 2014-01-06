using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook;
using System.IO;

namespace PhonebookTests
{
    [TestClass]
    public class PhonebookApplicationTests
    {
        [TestMethod]
        public void PhonebookApplicationExternalTest0()
        {
            ExternalTest(0);
        }

        [TestMethod]
        public void PhonebookApplicationExternalTest1()
        {
            ExternalTest(1);
        }

        [TestMethod]
        public void PhonebookApplicationExternalTest2()
        {
            ExternalTest(2);
        }

        [TestMethod]
        public void PhonebookApplicationExternalTest3()
        {
            ExternalTest(3);
        }

        [TestMethod]
        public void PhonebookApplicationExternalTest4()
        {
            ExternalTest(4);
        }

        [TestMethod]
        public void PhonebookApplicationExternalTest5()
        {
            ExternalTest(5);
        }

        // The following 5 test would last too long to wait
        // approx. 1-2 min per test
        /*
        [TestMethod]
        public void PhonebookApplicationExternalTest6()
        {
            ExternalTest(6);
        }

        [TestMethod]
        public void PhonebookApplicationExternalTest7()
        {
            ExternalTest(7);
        }

        [TestMethod]
        public void PhonebookApplicationExternalTest8()
        {
            ExternalTest(8);
        }
         
        [TestMethod]
        public void PhonebookApplicationExternalTest9()
        {
            ExternalTest(9);
        }
         
        [TestMethod]
        public void PhonebookApplicationExternalTest10()
        {
            ExternalTest(10);
        }
        */

        public void ExternalTest(int index)
        {
            string[,] tests = {
                {"test.000.001.in.txt", "test.000.001.out.txt"},
                {"test.001.in.txt", "test.001.out.txt"},
                {"test.002.in.txt", "test.002.out.txt"},
                {"test.003.in.txt", "test.003.out.txt"},
                {"test.004.in.txt", "test.004.out.txt"},
                {"test.005.in.txt", "test.005.out.txt"},
                {"test.006.in.txt", "test.006.out.txt"},
                {"test.007.in.txt", "test.007.out.txt"},
                {"test.008.in.txt", "test.008.out.txt"},
                {"test.009.in.txt", "test.009.out.txt"},
                {"test.010.in.txt", "test.010.out.txt"}
            };

            string path = @"..\..\..\";
            string expected = "";
            string outputFilename = path + tests[index, 1];
            Assert.IsTrue(File.Exists(outputFilename));
            StreamReader outTest = new StreamReader(outputFilename);
            using (outTest)
            {
                expected = outTest.ReadToEnd();
            }

            string inputFilename = path + tests[index, 0];
            Assert.IsTrue(File.Exists(inputFilename));
            StreamReader inTest = new StreamReader(inputFilename);
            StringWriter applicationOutput = new StringWriter();
            using (inTest)
            {
                Console.SetIn(inTest); // redirects console input from test file
                Console.SetOut(applicationOutput);
                PhonebookApplication.Main();
                Console.SetIn(Console.In); // returns standard behavior
                Console.SetOut(Console.Out);
            }
        }
    }
}
