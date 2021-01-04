using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IIG.CoSFE.DatabaseUtils;
using IIG.PasswordHashingUtils;

namespace IIG.Test.PasswordHashingUtils
{
    [TestClass]
    public class PasswordHashingUtilsTestDatabase
    {
        private const string Server = @"DESKTOP-OF6PTI3";
        private const string Database = @"IIG.CoSWE.AuthDB";
        private const bool IsTrusted = false;
        private const string Login = @"sa";
        private const string Password = @"02324411";
        private const int ConnectionTime = 75;
        private AuthDatabaseUtils authDB = new AuthDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTime);
        [TestMethod]
        public void TestMethod1()
        {
            string pass1 = "password42069";
            string pass2 = "password69";
            string pass3 = "password420";
            Assert.IsTrue(authDB.AddCredentials("login42069", PasswordHasher.GetHash(pass1)));
            Assert.IsTrue(authDB.AddCredentials("login69", PasswordHasher.GetHash(pass2)));
            Assert.IsTrue(authDB.AddCredentials("login420", PasswordHasher.GetHash(pass3)));

            Assert.IsFalse(authDB.AddCredentials("login42069", PasswordHasher.GetHash(pass3)));
            Assert.IsFalse(authDB.AddCredentials("login4206969", pass3));

            string pass4 = new string('7', 64);
            Assert.IsTrue(authDB.AddCredentials("login4206969", pass4));
        }

        [TestMethod]
        public void TestMethod2()
        {
            string pass1 = "password42069";
            string pass2 = "password69";
            string pass3 = "password420";
            Assert.IsTrue(authDB.CheckCredentials("login42069", PasswordHasher.GetHash(pass1)));
            Assert.IsTrue(authDB.CheckCredentials("login69", PasswordHasher.GetHash(pass2)));
            Assert.IsTrue(authDB.CheckCredentials("login420", PasswordHasher.GetHash(pass3)));

            Assert.IsFalse(authDB.CheckCredentials("login42069", PasswordHasher.GetHash(pass3)));
            Assert.IsFalse(authDB.CheckCredentials("login4206969", PasswordHasher.GetHash(pass3)));

        }

        [TestMethod]
        public void TestMethod3()
        {
            string pass1 = "password42069";
            string pass2 = "password69";
            string pass3 = "password420";
            Assert.IsTrue(authDB.UpdateCredentials("login42069", PasswordHasher.GetHash(pass1), "login42069", PasswordHasher.GetHash(pass1)));
            Assert.IsTrue(authDB.UpdateCredentials("login42069", PasswordHasher.GetHash(pass1), "login420696969", PasswordHasher.GetHash(pass1)));
            Assert.IsTrue(authDB.UpdateCredentials("login69", PasswordHasher.GetHash(pass2), "login69", PasswordHasher.GetHash(pass2 + "69")));
            Assert.IsTrue(authDB.UpdateCredentials("login420", PasswordHasher.GetHash(pass3), "login42069", PasswordHasher.GetHash(pass3 + "420")));

            Assert.IsFalse(authDB.UpdateCredentials("login", PasswordHasher.GetHash(pass3), "login", PasswordHasher.GetHash(pass3)));
            Assert.IsFalse(authDB.UpdateCredentials("login4206969", PasswordHasher.GetHash(pass1), "login69", PasswordHasher.GetHash(pass1)));
            Assert.IsFalse(authDB.UpdateCredentials("login4206969", PasswordHasher.GetHash(pass1), "login", PasswordHasher.GetHash(pass2)));
            Assert.IsFalse(authDB.UpdateCredentials("login69", PasswordHasher.GetHash(pass1), "login", pass1));
        }

        [TestMethod]
        public void TestMethod4()
        {
            string pass2 = "password69";
            string pass3 = "password420";
            Assert.IsTrue(authDB.DeleteCredentials("login69", PasswordHasher.GetHash(pass2 + "69")));
            Assert.IsFalse(authDB.DeleteCredentials("login42069", PasswordHasher.GetHash(pass3)));
            Assert.IsFalse(authDB.DeleteCredentials("login1111", PasswordHasher.GetHash(pass3)));
            Assert.IsFalse(authDB.DeleteCredentials("login69", PasswordHasher.GetHash(pass2 + "69")));
        }
    }
}