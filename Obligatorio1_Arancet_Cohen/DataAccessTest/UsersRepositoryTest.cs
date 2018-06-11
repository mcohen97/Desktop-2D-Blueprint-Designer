using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;
using Logic.Exceptions;
using DataAccess;
using DomainRepositoryInterface;
using RepositoryInterface;
using System.Collections.Generic;

namespace DataAccessTest
{
    [TestClass]
    public class UsersRepositoryTest
    {
        private User user1;
        private User user2;
        private User user3;
        private User user4;
        private User user5;
        private IRepository<User> repository;

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new UserRepository();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                Console.WriteLine(context.Database.Exists());
            }


            repository.Clear();
            user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            user2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            user3 = new Designer("designer1N", "designer1S", "designer1UN", "designer1P", DateTime.Now);
            user4 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);
            user5 = new Admin("Jorge", "Arais", "adminJorge", "adminJorge", DateTime.Now);
        }

        [TestMethod]
        public void EmptyPorfolioTest()
        {
            repository.Clear();
            Assert.IsTrue(repository.IsEmpty());
        }

        [TestMethod]
        public void AddUserTest()
        {
            repository.Add(user1);
            Assert.IsFalse(repository.IsEmpty());
        }

        [TestMethod]
        public void AddedUserTest()
        {
            repository.Add(user1);
            Assert.IsTrue(repository.Exists(user1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullUserTest()
        {
            repository.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyExistsException))]
        public void AddExistingUser()
        {
            repository.Add(user1);
            repository.Add(user1);
        }

        [TestMethod]
        public void UserNameExistsTest()
        {
            repository.Add(user1);
            Assert.IsTrue(((IUserRepository)repository).ExistsUserName("client1UN"));
        }

        [TestMethod]
        public void UserNameDoesNotExist()
        {
            Assert.IsFalse(((IUserRepository)repository).ExistsUserName("client1UN"));
        }

        [TestMethod]
        public void RemoveExistentUserTest()
        {
            repository.Add(user1);
            repository.Add(user2);
            repository.Delete(user1);
            Assert.IsFalse(repository.Exists(user1));
        }

        [TestMethod]
        public void RemoveNonExistentUserTest()
        {
            repository.Add(user2);
            repository.Delete(user1);
        }

        [TestMethod]
        public void GetUserTest()
        {
            repository.Add(user5);
            User userInfo = ((IUserRepository)repository).Get(user5);
            Assert.AreEqual(user5, userInfo);
        }

        [TestMethod]
        public void GetUserByUserNameTest()
        {
            repository.Add(user5);
            User userInfo = ((IUserRepository)repository).GetUserByUserName(user5.UserName);
            Assert.AreEqual(user5, userInfo);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            repository.Add(user1);
            repository.Add(user2);
            int expectedResult = 3;
            int actualResult = repository.GetAll().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetUsersByPermissionTest()
        {
            repository.Add(user1);
            repository.Add(user3);
            ICollection<User> filtered = ((IUserRepository)repository).GetUsersByPermission(Permission.READ_BLUEPRINT);
            int expectedResult = 2;
            int actualResult = filtered.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RecursiveBlueprintDeletionTest()
        {
            repository.Add(user1);
            repository.Add(user2);
            repository.Add(user3);

            Blueprint blueprint1 = new Blueprint(12, 12, "Blueprint1");
            blueprint1.Owner = user1;
            Blueprint blueprint2 = new Blueprint(12, 12, "Blueprint2");
            blueprint2.Owner = user2;
            Blueprint blueprint3 = new Blueprint(12, 12, "Blueprint3");
            blueprint3.Owner = user1;
            BlueprintPortfolio.Instance.Add(blueprint1);
            BlueprintPortfolio.Instance.Add(blueprint2);
            BlueprintPortfolio.Instance.Add(blueprint3);

            repository.Delete(user1);
            int expectedResult = 1;
            int actualResult = BlueprintPortfolio.Instance.GetAll().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
