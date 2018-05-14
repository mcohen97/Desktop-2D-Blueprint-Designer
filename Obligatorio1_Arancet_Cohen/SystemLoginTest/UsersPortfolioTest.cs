using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace SystemLoginTest
{
    [TestClass]
    public class UsersPortfolioTest
    {
        private User user1;
        private User user2;
        private User user3;
        private User user4;
        private User user5;
        private UsersPortfolio portfolio;

        [TestInitialize]
        public void TestInitialize()
        {
            portfolio = UsersPortfolio.Instance;
            portfolio.Empty();
            user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            user2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            user3 = new Designer("designer1N", "designer1S", "designer1UN", "designer1P", DateTime.Now);
            user4 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);
            user5 = new Admin("Jorge", "Arais", "adminJorge", "adminJorge", DateTime.Now);
        }

        [TestMethod]
        public void EmptyPorfolioTest() {
            portfolio.Empty();
            Assert.IsTrue(portfolio.IsEmpty());
        }

        [TestMethod]
        public void AddUserTest()
        {
            portfolio.Add(user1);
            Assert.IsFalse(portfolio.IsEmpty());
        }

        [TestMethod]
        public void AddedUserTest()
        {
            portfolio.Add(user1);
            Assert.IsTrue(portfolio.Exist(user1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullUserTest() {
            portfolio.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyExistsException))]
        public void AddExistingUser() {
            portfolio.Add(user1);
            portfolio.Add(user1);
        }

        [TestMethod]
        public void GetUsersTest()
        {
            portfolio.Add(user1);
            IEnumerator<User> users = portfolio.GetEnumerator();
            users.MoveNext();
            Assert.IsNotNull(users.Current);
        }

        [TestMethod]
        public void RemoveExistentUserTest()
        {
            portfolio.Add(user1);
            portfolio.Add(user2);
            portfolio.Remove(user1);
            Assert.IsFalse(portfolio.Exist(user1));
        }

        [TestMethod]
        public void RemoveNonExistentUserTest()
        {
            portfolio.Add(user2);
            bool deletionExecuted = portfolio.Remove(user1);
            Assert.IsFalse(deletionExecuted);
        }

        [TestMethod]
        public void GetClientTest() {
            portfolio.Add(user2);
            Client clientInfo = portfolio.GetClient(user2);
            Assert.AreEqual(user2, clientInfo);
        }

        [TestMethod]
        public void GetDesignerTest() {
            portfolio.Add(user3);
            Designer designerInfo = portfolio.GetDesigner(user3);
            Assert.AreEqual(user3, designerInfo);
        }

        [TestMethod]
        public void GetAdminTest() {
            portfolio.Add(user5);
            Admin clientInfo = portfolio.GetAdmin(user5);
            Assert.AreEqual(user5, clientInfo);
        }

        [TestMethod]
        public void GetUserTest() {
            portfolio.Add(user5);
            User userInfo = portfolio.GetUser(user5);
            Assert.AreEqual(user5, userInfo);
        }

        [TestMethod]
        public void GetUserByUserNameTest() {
            portfolio.Add(user5);
            User userInfo = portfolio.GetUserByUserName(user5.UserName);
            Assert.AreEqual(user5, userInfo);
        }

        [TestMethod]
        public void GetAllUsersTest() {
            portfolio.Add(user1);
            portfolio.Add(user2);
            int expectedResult = 2;
            int actualResult = portfolio.GetUsers().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetUsersByPermissionTest() {
            portfolio.Add(user1);
            portfolio.Add(user3);
            ICollection<User> filtered = portfolio.GetUsersByPermission(Permission.READ_BLUEPRINT);
            int expectedResult = 1;
            int actualResult = filtered.Count;
            Assert.AreEqual(expectedResult,actualResult);
        }
    }
}
