using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Test
{
    [TestClass]
    public class WindowTest
    {
        Window instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Window(new Point(3, 2));
        }

        [TestMethod]
        public void GetHeightAboveFloorTest() {
            float expectedResullt = 1;
            float actualResult = instance.HeightAboveFloor;
            Assert.AreEqual(expectedResullt, actualResult);
        }

        [TestMethod]
        public void GetComponentTypeTest() {
            Assert.AreEqual(ComponentType.WINDOW, instance.GetComponentType());
        }

        [TestMethod]
        public void GetPriceTest() {
            float expectedResult = 75;
            float actualResult = instance.CalculatePrice();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostTest() {
            float expectedResult = 50;
            float actualResult = instance.CalculateCost();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
