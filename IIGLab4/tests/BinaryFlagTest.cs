using Microsoft.VisualStudio.TestTools.UnitTesting;
using IIG.BinaryFlag;
using System;

namespace Lab2
{
    [TestClass]
    public class BinaryFlagTest
    {

        [TestMethod]
        public void TestConstructorLength1()
        {
            ulong tmp = 42069;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp);
            Assert.IsTrue(test1.GetFlag());
        }

        [TestMethod]
        public void TestFlagTrue()
        {
            ulong tmp = 42069;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(test1.GetFlag());
        }

        [TestMethod]
        public void TestFlagFalse()
        {
            ulong tmp = 42069;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, false);
            Assert.IsFalse(test1.GetFlag());
        }

        [TestMethod]
        public void TestMinValue()
        {
            ulong tmp = UInt64.MinValue;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(test1.GetFlag());
        }

        [TestMethod]
        public void TestMaxValue1()
        {
            ulong tmp = UInt64.MaxValue;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            Assert.IsTrue(test1.GetFlag());
        }

        [TestMethod]
        public void TestMaxValue2()
        {
            ulong tmp1 = 17179868704;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp1, true);
            Assert.IsTrue(test1.GetFlag());
        }

        [TestMethod]
        public void TestFlagLength()
        {
            ulong tmp = 42069;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            Assert.AreEqual(tmp, test1.ToString().Length);
        }

        [TestMethod]
        public void TestFlagToString()
        {
            ulong tmp = 3;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag test2 = new MultipleBinaryFlag(tmp, false);
            Assert.AreEqual(test1.ToString(), "TTT");
            Assert.AreEqual(test2.ToString(), "FFF");
        }

        [TestMethod]
        public void TestObjectReference1()
        {
            ulong tmp = 3;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag test2 = test1;
            Assert.AreEqual(test1, test2);
        }

        [TestMethod]
        public void TestObjectReference2()
        {
            ulong tmp = 3;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            MultipleBinaryFlag test2 = new MultipleBinaryFlag(tmp, true);
            Assert.AreNotEqual(test1, test2);
        }

        [TestMethod]
        public void TestReset1()
        {
            ulong tmp1 = 42069;
            ulong position = 420;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp1, true);
            test1.ResetFlag(position);
            Assert.IsFalse(test1.GetFlag());
        }

        [TestMethod]
        public void TestReset2()
        {
            ulong tmp1 = 9;
            ulong position = 6;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp1, true);
            test1.ResetFlag(position);
            Assert.AreEqual(test1.ToString(), "TTTTTTFTTT");
        }

        [TestMethod]
        public void TestMultipleReset()
        {
            ulong tmp = 2;
            ulong position1 = 0;
            ulong position2 = 1;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            test1.ResetFlag(position1);
            test1.ResetFlag(position2);
            Assert.IsTrue(test1.GetFlag());
            Assert.AreEqual(test1.ToString(), "TT");
        }

        [TestMethod]
        public void TestSetOnFalse()
        {
            ulong tmp = 42069;
            ulong position = 420;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, false);
            test1.SetFlag(position);
            Assert.IsFalse(test1.GetFlag());
        }

        [TestMethod]
        public void TestSetOnTrue()
        {
            ulong tmp = 42069;
            ulong position = 420;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, true);
            test1.SetFlag(position);
            Assert.IsTrue(test1.GetFlag());
        }

        [TestMethod]
        public void TestAllSets()
        {
            ulong tmp = 2;
            ulong position1 = 0;
            ulong position2 = 1;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, false);
            test1.SetFlag(position1);
            test1.SetFlag(position2);
            Assert.IsTrue(test1.GetFlag());
        }

        [TestMethod]
        public void TestSet2()
        {
            ulong tmp = 2;
            ulong position = 0;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, false);
            test1.SetFlag(position);
            Assert.IsFalse(test1.GetFlag());
        }

        [TestMethod]
        public void TestDisposeExcep()
        {
            ulong tmp = 42;
            Exception ex = null;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, false);
            test1.Dispose();
            try
            {
                test1.GetFlag();
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void TestDispose()
        {
            ulong tmp1 = 42069;
            ulong tmp2 = 65;
            ulong tmp3 = 64;
            Exception ex1 = null;
            Exception ex2 = null;
            Exception ex3 = null;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp1, false);
            MultipleBinaryFlag test2 = new MultipleBinaryFlag(tmp2, false);
            MultipleBinaryFlag test3 = new MultipleBinaryFlag(tmp3, false);
            test1.Dispose();
            test2.Dispose();
            test3.Dispose();
            try
            {
                test3.GetFlag();
            }
            catch (Exception e)
            {
                ex3 = e;
            }
            try
            {
                test1.GetFlag();
            }
            catch (Exception e)
            {
                ex1 = e;
            }
            try
            {
                test2.GetFlag();
            }
            catch (Exception e)
            {
                ex2 = e;
            }
            Assert.IsNotNull(ex1);
            Assert.IsNotNull(ex2);
            Assert.IsNull(ex3);
        }

        [TestMethod]
        public void TestMultipleDispose()
        {
            ulong tmp = 42069;
            Exception ex = null;
            MultipleBinaryFlag test1 = new MultipleBinaryFlag(tmp, false);
            test1.Dispose();
            try
            {
                test1.Dispose();
            }
            catch (Exception e)
            {
                ex = e;
            }
            Assert.IsNull(ex);
        }

    }
}
