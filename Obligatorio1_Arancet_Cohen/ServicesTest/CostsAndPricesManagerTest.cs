using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using RepositoryInterface;
using Logic.Domain;
using Services;
using DomainRepositoryInterface;

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
            currentSession=connector.LogIn("admin", "admin");
            administrator = new UserAdministrator(currentSession);
            administrator.Add(new Designer("TestDesigner", "TestDesigner", "TestDesigner", "TestDesigner", DateTime.Now));
            pricesNcosts = new PriceCostRepository();
            pricesNcosts.Clear();
            wallType = (int)ComponentType.WALL;
            pricesNcosts.AddCostPrice(wallType, 50, 100);
            manager = new CostsAndPricesManager(currentSession);
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
        

        
    }
}
