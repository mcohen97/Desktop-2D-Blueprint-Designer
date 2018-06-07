﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;
using Logic.Exceptions;
using System.Collections.Generic;

namespace Logic.Test
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
            portfolio.Clear();
            user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            user2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            user3 = new Designer("designer1N", "designer1S", "designer1UN", "designer1P", DateTime.Now);
            user4 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);
            user5 = new Admin("Jorge", "Arais", "adminJorge", "adminJorge", DateTime.Now);
        }

        [TestMethod]
        public void EmptyPorfolioTest()
        {
            portfolio.Clear();
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
            Assert.IsTrue(portfolio.Exists(user1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullUserTest()
        {
            portfolio.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyExistsException))]
        public void AddExistingUser()
        {
            portfolio.Add(user1);
            portfolio.Add(user1);
        }

        [TestMethod]
        public void UserNameExistsTest()
        {
            portfolio.Add(user1);
            Assert.IsTrue(portfolio.ExistsUserName("client1UN"));
        }

        [TestMethod]
        public void UserNameDoesNotExist()
        {
            Assert.IsFalse(portfolio.ExistsUserName("client1UN"));
        }

        [TestMethod]
        public void RemoveExistentUserTest()
        {
            portfolio.Add(user1);
            portfolio.Add(user2);
            portfolio.Delete(user1);
            Assert.IsFalse(portfolio.Exists(user1));
        }

        [TestMethod]
        public void RemoveNonExistentUserTest()
        {
            portfolio.Add(user2);
            bool deletionExecuted = portfolio.Delete(user1);
            Assert.IsFalse(deletionExecuted);
        }

        [TestMethod]
        public void GetUserTest()
        {
            portfolio.Add(user5);
            User userInfo = portfolio.Get(user5);
            Assert.AreEqual(user5, userInfo);
        }

        [TestMethod]
        public void GetUserByUserNameTest()
        {
            portfolio.Add(user5);
            User userInfo = portfolio.GetUserByUserName(user5.UserName);
            Assert.AreEqual(user5, userInfo);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            portfolio.Add(user1);
            portfolio.Add(user2);
            int expectedResult = 3;
            int actualResult = portfolio.GetAll().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetUsersByPermissionTest()
        {
            portfolio.Add(user1);
            portfolio.Add(user3);
            ICollection<User> filtered = portfolio.GetUsersByPermission(Permission.READ_BLUEPRINT);
            int expectedResult = 2;
            int actualResult = filtered.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RecursiveBlueprintDeletionTest()
        {
            portfolio.Add(user1);
            portfolio.Add(user2);
            portfolio.Add(user3);

            Blueprint blueprint1 = new Blueprint(12, 12, "Blueprint1");
            blueprint1.Owner = user1;
            Blueprint blueprint2 = new Blueprint(12, 12, "Blueprint2");
            blueprint2.Owner = user2;
            Blueprint blueprint3 = new Blueprint(12, 12, "Blueprint3");
            blueprint3.Owner = user1;
            BlueprintPortfolio.Instance.Add(blueprint1);
            BlueprintPortfolio.Instance.Add(blueprint2);
            BlueprintPortfolio.Instance.Add(blueprint3);

            portfolio.Delete(user1);
            int expectedResult = 1;
            int actualResult = BlueprintPortfolio.Instance.GetBlueprintsCopy().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
