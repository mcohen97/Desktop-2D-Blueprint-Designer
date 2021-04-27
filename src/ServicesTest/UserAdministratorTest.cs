using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;
using ServicesExceptions;
using System.Collections.Generic;
using Services;
using DataAccess;
using RepositoryInterface;
using DomainRepositoryInterface;

namespace ServicesTest
{
    [TestClass]
    public class UserAdministratorTest
    {

        private User user1;
        private User user2;
        private User user3;
        private User user4;
        private User user5;
        private IRepository<User> portfolio;
        private SessionConnector conn;

        [TestInitialize]
        public void TestInitialize()
        {
            portfolio = new UserRepository();
            portfolio.Clear();
            conn = new SessionConnector();
            user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            user2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            user3 = new Designer("designer1N", "designer1S", "designer1UN", "designer1P", DateTime.Now);
            user4 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);
            user5 = new Admin("Jorge", "Arais", "adminJorge", "adminJorge", DateTime.Now);
        }

        private void intializerWithData()
        {
            portfolio.Clear();
            Session session = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administator = new UserAdministrator(session,portfolio);
            administator.Add(user1);
            administator.Add(user2);
            administator.Add(user3);
            administator.Add(user4);
            administator.Add(user5);
        }

        [TestMethod]
        public void NewUsersAdministratorTest()
        {
            Session session = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(session,portfolio);
            Assert.IsNotNull(administrator);
        }

        [TestMethod]
        public void AddUserTest()
        {
            Session session = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(session,portfolio);
            administrator.Add(user1);
            Assert.IsTrue(administrator.Exist(user1));
        }

        [TestMethod]
        public void AddUserUpdateLoginDateTest()
        {
            intializerWithData();
            Session session = conn.LogIn("client1UN", "client1P", (IUserRepository)portfolio);
            User actualDBRecord = ((IUserRepository)portfolio).GetUserByUserName("client1UN");
            Assert.AreNotEqual(actualDBRecord, Constants.NEVER);
        }

        [TestMethod]
        public void GetUserTest()
        {
            Session session = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(session,portfolio);
            administrator.Add(user1);
            User userAsked = administrator.GetUser(user1.UserName);
            Assert.AreEqual(userAsked, user1);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            Session session = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(session,portfolio);
            administrator.Add(user1);
            user1.Name = "Miguel";
            administrator.Update(user1);
            User userUpdated = administrator.GetUser(user1.UserName);
            Assert.AreEqual(userUpdated.Name, user1.Name);
        }

        [TestMethod]
        public void RemoveUserTest()
        {
            Session session = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(session,portfolio);
            administrator.Add(user1);
            administrator.Remove(user1);

            Assert.IsFalse(administrator.Exist(user1));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void AddUserNoPermissionTest()
        {
            intializerWithData();
            Session session = conn.LogIn("client1UN", "client1P", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(session,portfolio);
            administrator.Add(new Client("a", "b", "c", "d", "e", "f", "g", DateTime.Now));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void UpdateUserNoPermissionTest()
        {
            intializerWithData();
            Session session = conn.LogIn("client1UN", "client1P", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(session,portfolio);
            administrator.Update(user2);
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void RemoveUserNoPermissionTest()
        {
            intializerWithData();
            Session session = conn.LogIn("client1UN", "client1P", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(session,portfolio);
            administrator.Remove(user2);
        }

        [TestMethod]
        public void GetClientsTest()
        {
            intializerWithData();
            Session aSession = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            ICollection<User> allClients = administrator.GetAllClients();
            int expectedResult = 2;
            int actualResult = allClients.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void GetClientsNoPermissionTest()
        {
            intializerWithData();
            Session aSession = conn.LogIn("client1UN", "client1P", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            ICollection<User> allClients = administrator.GetAllClients();
        }

        [TestMethod]
        public void GetAllUsersExceptMeTest()
        {
            intializerWithData();
            Session aSession = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            ICollection<User> usersMinus1 = administrator.GetAllUsersExceptMe();
            int expectedResult = 5;
            int actualResult = usersMinus1.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void GetUsersExceptMeNoPermissionTest()
        {
            intializerWithData();
            Session aSession = conn.LogIn("client1UN", "client1P", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            ICollection<User> usersMinus1 = administrator.GetAllUsersExceptMe();
        }

        [TestMethod]
        public void ExistsUserNameTest()
        {
            intializerWithData();
            Session aSession = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            Assert.IsTrue(administrator.ExistsUserName("client1UN"));
        }

        [TestMethod]
        public void UserNameDoesNotTest()
        {
            intializerWithData();
            Session aSession = conn.LogIn("admin", "admin", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            Assert.IsFalse(administrator.ExistsUserName("JamesHetfield63"));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void ExistsUserNameNoPermissionTest()
        {
            intializerWithData();
            Session aSession = conn.LogIn("client1UN", "client1P", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            administrator.ExistsUserName("JamesHetfield63");
        }

        [TestMethod]
        public void GetUsersByPermissionTest() {
            intializerWithData();
            Session aSession = conn.LogIn("designer1UN", "designer1P", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            ICollection<User> query =administrator.GetUsersByPermission(Permission.HAVE_BLUEPRINT);
            int expectedResult = 2;
            int actualResult = query.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void GetUsersByPermissionNotAllowedTest()
        {
            intializerWithData();
            Session aSession = conn.LogIn("client1UN", "client1P", (IUserRepository)portfolio);
            UserAdministrator administrator = new UserAdministrator(aSession,portfolio);
            ICollection<User> query = administrator.GetUsersByPermission(Permission.HAVE_BLUEPRINT);

        }

        }
}
