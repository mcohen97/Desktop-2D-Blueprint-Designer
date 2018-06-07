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
            Signature signature = new Signature(user, DateTime.Now);

            Assert.IsNotNull(signature);
        }

        [TestMethod]
        public void GetUserTest()
        {
            Signature signature = new Signature(user, DateTime.Now);
            User userGet = signature.User;

            Assert.AreEqual(user, userGet);
        }

        [TestMethod]
        public void GetDateTest()
        {
            DateTime dateSignature = DateTime.Now;
            Signature signature = new Signature(user, dateSignature);

            DateTime dateSignatureGet = signature.Date;

            Assert.AreEqual(dateSignature, dateSignatureGet);
        }
    }
}
