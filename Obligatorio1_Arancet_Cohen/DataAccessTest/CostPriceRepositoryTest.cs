using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainRepositoryInterface;
using Logic.Domain;
using DataAccess;

namespace DataAccessTest
{
    [TestClass]
    public class CostPriceRepositoryTest
    {
        IPriceCostRepository prices = new PriceCostRepository();

        [TestInitialize]
        public void SetUp() {
            prices.Clear();
            prices.AddCostPrice((int)ComponentType.WALL, 50, 100);

        }

        [TestMethod]
        public void GetPriceTest() {
            float expectedResult = 100;
            float actualResult=prices.GetPrice((int)ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SetPriceTest() {
            float expectedResult = 120;
            prices.SetPrice((int)ComponentType.WALL,120);
            float actualResult = prices.GetPrice((int)ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostTest() {
            float expectedResult = 50;
            float actualresult = prices.GetCost((int)ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualresult);
        }

        [TestMethod]
        public void SetCostTest() {
            float expectedResult = 25;
            prices.SetCost((int)ComponentType.WALL, 25);
            float actualResult = prices.GetCost((int)ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
