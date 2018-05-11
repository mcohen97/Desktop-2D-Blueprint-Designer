using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace SystemLoginTest
{
    [TestClass]
    public class SessionConnectorTest
    {
        [TestMethod]
        public void LogInTest()
        {
            SessionConnector conn = new SessionConnector();
            Session session = conn.LogIn("admin", "admin");

            Assert.IsNotNull(session);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void LogInWrongPasswordTest() {
            SessionConnector conn = new SessionConnector();
            Session session = conn.LogIn("admin", "");
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void LogInNonExistentUserTest() {
            SessionConnector conn = new SessionConnector();
            Session session = conn.LogIn("jorge", "");
        }
    }
}
