using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;
using DataAccessExceptions;
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
        private IRepository<User> usersStorage;

        [TestInitialize]
        public void TestInitialize()
        {
            usersStorage = new UserRepository();
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                Console.WriteLine(context.Database.Exists());
            }


            usersStorage.Clear();
            user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            user2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            user3 = new Designer("designer1N", "designer1S", "designer1UN", "designer1P", DateTime.Now);
            user4 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);
            user5 = new Admin("Jorge", "Arais", "adminJorge", "adminJorge", DateTime.Now);
        }

        [TestMethod]
        public void EmptyPorfolioTest()
        {
            usersStorage.Clear();
            Assert.IsTrue(usersStorage.IsEmpty());
        }

        [TestMethod]
        public void AddUserTest()
        {
            usersStorage.Add(user1);
            Assert.IsFalse(usersStorage.IsEmpty());
        }

        [TestMethod]
        public void AddedUserTest()
        {
            usersStorage.Add(user1);
            Assert.IsTrue(usersStorage.Exists(user1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullUserTest()
        {
            usersStorage.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UserAlreadyExistsException))]
        public void AddExistingUser()
        {
            usersStorage.Add(user1);
            usersStorage.Add(user1);
        }

        [TestMethod]
        public void UserNameExistsTest()
        {
            usersStorage.Add(user1);
            Assert.IsTrue(((IUserRepository)usersStorage).ExistsUserName("client1UN"));
        }

        [TestMethod]
        public void UserNameDoesNotExist()
        {
            Assert.IsFalse(((IUserRepository)usersStorage).ExistsUserName("client1UN"));
        }

        [TestMethod]
        public void RemoveExistentUserTest()
        {
            usersStorage.Add(user1);
            usersStorage.Add(user2);
            usersStorage.Delete(user1);
            Assert.IsFalse(usersStorage.Exists(user1));
        }

        [TestMethod]
        public void RemoveNonExistentUserTest()
        {
            usersStorage.Add(user2);
            usersStorage.Delete(user1);
        }

        [TestMethod]
        public void GetUserTest()
        {
            usersStorage.Add(user5);
            User userInfo = ((IUserRepository)usersStorage).Get(user5);
            Assert.AreEqual(user5, userInfo);
        }

        [TestMethod]
        public void GetUserByUserNameTest()
        {
            usersStorage.Add(user5);
            User userInfo = ((IUserRepository)usersStorage).GetUserByUserName(user5.UserName);
            Assert.AreEqual(user5, userInfo);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            usersStorage.Add(user1);
            usersStorage.Add(user2);
            int expectedResult = 3;
            int actualResult = usersStorage.GetAll().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetUsersByPermissionTest()
        {
            usersStorage.Add(user1);
            usersStorage.Add(user3);
            ICollection<User> filtered = ((IUserRepository)usersStorage).GetUsersByPermission(Permission.READ_BLUEPRINT);
            int expectedResult = 2;
            int actualResult = filtered.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RecursiveBlueprintDeletionTest()
        {
            usersStorage.Add(user1);
            usersStorage.Add(user2);
            usersStorage.Add(user3);

            BlueprintRepository blueprintsStorage = new BlueprintRepository();

            IBlueprint blueprint1 = new Blueprint(12, 12, "Blueprint1");
            blueprint1.Owner = user1;
            IBlueprint blueprint2 = new Blueprint(12, 12, "Blueprint2");
            blueprint2.Owner = user2;
            IBlueprint blueprint3 = new Blueprint(12, 12, "Blueprint3");
            blueprint3.Owner = user1;

            blueprintsStorage.Add(blueprint1);
            blueprintsStorage.Add(blueprint2);
            blueprintsStorage.Add(blueprint3);

            usersStorage.Delete(user1);
            int expectedResult = 1;
            int actualResult =blueprintsStorage.GetAll().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
