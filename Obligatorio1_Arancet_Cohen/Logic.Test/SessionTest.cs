using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Test{
    [TestClass]
    public class SessionTest {

        private User user1;

        [TestInitialize]
        public void TestInitialize() {
            user1 = new Admin("admin", "admin", "admin", "defaultAdmin1234", DateTime.Now);
            
        }

        [TestMethod]
        public void NewSessionTest() {
            Session session = new Session(user1);

            Assert.IsNotNull(session);
        }

        [TestMethod]
        public void UserSessionTest() {
            Session session = new Session(user1);
            User userLogged = session.UserLogged;
            Assert.AreEqual(userLogged, user1);
        }

        [TestMethod]
        public void isFirstLoginTrueTest() {
            Session session = new Session(user1);
            Assert.IsTrue(session.FirstLogin);
        }

        [TestMethod]
        public void isFirstLoginFalseTest() {
            user1.UpdateLastLoginDate();
            Session session = new Session(user1);
            Assert.IsFalse(session.FirstLogin);
        }
    }
}
