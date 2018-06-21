using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;
using ServicesExceptions;
using DataAccessExceptions;
using Services;
using DataAccess;
using DomainRepositoryInterface;

namespace ServicesTest
{
    [TestClass]
    public class SessionConnectorTest
    {
        [TestMethod]
        public void LogInTest()
        {
            SessionConnector conn = new SessionConnector();
            IUserRepository userStorage = new UserRepository();
            Session session = conn.LogIn("admin", "admin",userStorage);

            Assert.IsNotNull(session);
        }

        [TestMethod]
        [ExpectedException(typeof(WrongPasswordException))]
        public void LogInWrongPasswordTest()
        {
            SessionConnector conn = new SessionConnector();
            IUserRepository userStorage = new UserRepository();
            Session session = conn.LogIn("admin", "",userStorage);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void LogInNonExistentUserTest()
        {
            SessionConnector conn = new SessionConnector();
            IUserRepository userStorage = new UserRepository();
            Session session = conn.LogIn("jorge", "",userStorage);
        }
    }
}
