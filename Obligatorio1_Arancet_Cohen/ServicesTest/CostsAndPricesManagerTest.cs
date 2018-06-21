using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using RepositoryInterface;
using Logic.Domain;
using Services;
using DomainRepositoryInterface;
using ServicesExceptions;

namespace ServicesTest
{
    [TestClass]
    public class CostsAndPricesManagerTest
    {

        IRepository<User> usersStorage;
        UserAdministrator administrator;
        SessionConnector connector;
        Session currentSession;
        IPriceCostRepository pricesNcosts;
        CostsAndPricesManager manager;
        int wallType;

        [TestInitialize]
        public void SetUp() {
            usersStorage = new UserRepository();
            usersStorage.Clear();
            connector = new SessionConnector();
            currentSession=connector.LogIn("admin", "admin", (IUserRepository)usersStorage);
            administrator = new UserAdministrator(currentSession,usersStorage);
            administrator.Add(new Designer("TestDesigner", "TestDesigner", "TestDesigner", "TestDesigner", DateTime.Now));
            pricesNcosts = new PriceCostRepository();
            pricesNcosts.Clear();
            wallType = (int)ComponentType.WALL;
            pricesNcosts.AddCostPrice(wallType, 50, 100);
            manager = new CostsAndPricesManager(currentSession,pricesNcosts);
        }

        [TestMethod]
        public void GetPriceTest() {
            float expectedResult = 100;
            float actualResult=manager.GetPrice(wallType);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SetPriceTest() {
            float expectedResult = 150;
            manager.SetPrice(wallType, 150);
            float actualResult = manager.GetPrice(wallType);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void SetPriceNoPermissionsTest() {
            Session noAdmin = connector.LogIn("TestDesigner", "TestDesigner", (IUserRepository)usersStorage);
            manager = new CostsAndPricesManager(noAdmin,pricesNcosts);
            manager.SetPrice(wallType, 150);
        }

        [TestMethod]
        public void GetCostTest() {
            float expectedResult = 50;
            float actualResult = manager.GetCost(wallType);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SetCostTest() {
            float expectedResult = 75;
            manager.SetCost(wallType, 75);
            float actualResult = manager.GetCost(wallType);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void SetCostNoPermissionsTest()
        {
            Session noAdmin = connector.LogIn("TestDesigner", "TestDesigner", (IUserRepository)usersStorage);
            manager = new CostsAndPricesManager(noAdmin,pricesNcosts);
            manager.SetCost(wallType, 150);
        }





    }
}
