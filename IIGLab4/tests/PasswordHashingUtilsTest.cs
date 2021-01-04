using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IIG.PasswordHashingUtils;

namespace IIG.Test.PasswordHashingUtils
{
    [TestClass]
    public class PasswordHashingUtilsTest
    {
        [TestMethod]
        public void TestCase_GetHash_0_1_2_4_5()
        {
            string password = "password42069";
            Assert.IsNotNull(PasswordHasher.GetHash(password));
            password = "";
            Assert.IsNotNull(PasswordHasher.GetHash(password));
            password = " ";
            Assert.IsNotNull(PasswordHasher.GetHash(password));
            password = "password42069";
            Assert.IsNotNull(PasswordHasher.GetHash(password, "", 42069));
            password = "password42069";
            Assert.IsNotNull(PasswordHasher.GetHash(password, "nice"));
            password = "password42069";
            Assert.IsNotNull(PasswordHasher.GetHash(password, "nice", 0));
            password = "password42069";
            Assert.IsNotNull(PasswordHasher.GetHash(password, " ", 69));
            password = "password42069";
            Assert.AreEqual(PasswordHasher.GetHash(password, "nice", 69).Length, 64);

        }

        [TestMethod]
        public void TestCase_GetHash_0_1_2_5()
        {
            string password = null;
            Assert.ThrowsException<System.ArgumentNullException>(() => PasswordHasher.GetHash(password));
        }

        [TestMethod]
        public void TestCase_GetHash_0_1_2_3_4_5()
        {
            string password = "复";
            Assert.IsNotNull(PasswordHasher.GetHash(password));
            Assert.AreEqual(PasswordHasher.GetHash(password).Length, 64);
        }

        [TestMethod]
        public void TestCase_Init_0_1_2_3()
        {
            string password = "password42069";
            Assert.AreEqual(PasswordHasher.GetHash(password, "", 42069), PasswordHasher.GetHash(password, "", 42069));
            string password1 = "password42069";
            string password2 = "password42069";
            Assert.AreEqual(PasswordHasher.GetHash(password1, "", 42069), PasswordHasher.GetHash(password2, "", 42069));
            password1 = "password42069";
            password2 = "password4206969";
            Assert.AreNotEqual(PasswordHasher.GetHash(password1, "", 42069), PasswordHasher.GetHash(password2, "", 42069));
            password = "password42069";
            Assert.AreNotEqual(PasswordHasher.GetHash(password, "", 42069), PasswordHasher.GetHash(password, "", 69));
            password1 = "password42069";
            password2 = "password4206969";
            Assert.AreEqual(PasswordHasher.GetHash(password1, "nice", 69).Length, PasswordHasher.GetHash(password2, "nice", 69).Length);
            password = "password42069";
            Assert.AreEqual(PasswordHasher.GetHash(password, "nice", 69).Length, PasswordHasher.GetHash(password, "nice42069", 69).Length);

        }

        [TestMethod]
        public void TestCase_Init_0_1_3()
        {
            string password = "password42069";
            Assert.AreEqual(PasswordHasher.GetHash(password, "nice"), PasswordHasher.GetHash(password, "nice"));
            password = "password42069";
            Assert.AreNotEqual(PasswordHasher.GetHash(password, "nice"), PasswordHasher.GetHash(password, "nice69"));
            password = "password42069";
            Assert.AreNotEqual(PasswordHasher.GetHash(password, "nice"), PasswordHasher.GetHash(password, "nice "));
            password = "password42069";
            PasswordHasher.Init("nice", 0);
            Assert.IsNotNull(PasswordHasher.GetHash(password));
            password = "password42069";
            PasswordHasher.Init("nice", 0);
            string hash1 = PasswordHasher.GetHash(password);
            string hash2 = PasswordHasher.GetHash(password, "nice", 0);
            Assert.AreEqual(hash1, hash2);
            password = "password42069";
            PasswordHasher.Init("nice", 0);
            hash1 = PasswordHasher.GetHash(password);
            hash2 = PasswordHasher.GetHash(password, "nice69", 0);
            Assert.AreNotEqual(hash1, hash2);

        }

        [TestMethod]
        public void TestCase_Init_0_2_3()
        {
            string password = "password42069";
            Assert.IsNotNull(PasswordHasher.GetHash(password, null, 42069));
            Assert.AreNotEqual(PasswordHasher.GetHash(password, null, 42069), PasswordHasher.GetHash(password, "nice", 42069));
        }

        [TestMethod]
        public void TestCase_Init_0_3()
        {
            string password = "password42069";
            Assert.IsNotNull(PasswordHasher.GetHash(password));
            Assert.AreNotEqual(PasswordHasher.GetHash(password), PasswordHasher.GetHash(password, "nice", 42069));
        }
    }
}
