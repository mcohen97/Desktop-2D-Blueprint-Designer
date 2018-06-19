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
    }
}
