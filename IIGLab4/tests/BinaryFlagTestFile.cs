using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IIG.FileWorker;
using IIG.BinaryFlag;

namespace IIG.Test.PasswordHashingUtils
{
    [TestClass]
    public class BinaryFlagTestFile
    {
        private string output = "F:/IIGLab4/IIGLab4/output/output.txt";
        private string input = "F:/IIGLab4/IIGLab4/input/input.txt";
        private string inputReadAll = "F:/IIGLab4/IIGLab4/input/inputReadAll.txt";
        [TestMethod]
        public void TestMethod1()
        {
            ulong tmp = 42069;
            MultipleBinaryFlag test = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(BaseFileWorker.Write(test.ToString(), output));
        }
        [TestMethod]
        public void TestMethod2()
        {
            ulong tmp = 4;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag test2 = new MultipleBinaryFlag(tmp, false);
            string[] fileContent = BaseFileWorker.ReadLines(input);
            Assert.AreEqual(test1.ToString(), fileContent[0]);
            Assert.AreEqual(test2.ToString(), fileContent[1]);
        }
        [TestMethod]
        public void TestMethod3()
        {
            ulong tmp = 4;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag test2 = new MultipleBinaryFlag(tmp, false);
            string[] fileContent = BaseFileWorker.ReadLines(input);
            Assert.AreNotEqual(test2.ToString(), fileContent[0]);
            Assert.AreNotEqual(test1.ToString(), fileContent[1]);
        }
        [TestMethod]
        public void TestMethod4()
        {
            ulong tmp = 4;
            MultipleBinaryFlag test = new MultipleBinaryFlag(tmp, true);
            string fileContent = BaseFileWorker.ReadAll(inputReadAll);
            Assert.AreEqual(test.ToString(), fileContent);
        }
        [TestMethod]
        public void TestMethod5()
        {
            ulong tmp = 4;
            MultipleBinaryFlag test = new MultipleBinaryFlag(tmp, false);
            string fileContent = BaseFileWorker.ReadAll(inputReadAll);
            Assert.AreNotEqual(test.ToString(), fileContent);
        }
    }
}