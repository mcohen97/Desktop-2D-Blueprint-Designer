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

        [TestInitialize]
        public void GetPriceTest() {
            float expectedResult = 100;
            float actualResult=prices.GetPrice((int)ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestInitialize]
        public void SetPrice() {
            float expectedResult = 120;
            prices.SetPrice((int)ComponentType.WALL,120);
            float actualResult = prices.GetPrice((int)ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestInitialize]
        public void GetCost() {
            float expectedResult = 50;
            float actualresult = prices.GetCost((int)ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualresult);
        }
    }
}
