using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;

namespace Logic.Test
{
    [TestClass]
    public class SignatureTest
    {
        private User user;

        [TestInitialize]
        public void Initialize()
        {
            user = new Architect("Jorge", "Jamil", "jjmil", "12345", DateTime.Now);
        }

        [TestMethod]
        public void CreateSignatureTest()
        {
            Signature signature = new Signature(user);

            Assert.IsNotNull(signature);
        }

        [TestMethod]
        public void GetUserTest()
        {
            Signature signature = new Signature(user);
            User architectGet = signature.User;

            Assert.AreEqual(user, architectGet);
        }

        [TestMethod]
        public void GetDateTest()
        {
            Signature signature = new Signature(user);
            User architectGet = signature.User;

            Assert.AreEqual(user, architectGet);
        }
    }
}
