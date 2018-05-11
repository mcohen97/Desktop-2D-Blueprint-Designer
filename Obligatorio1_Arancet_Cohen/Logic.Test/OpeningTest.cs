using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Test {

    [TestClass]
    public class OpeningTest {

        private Opening instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Door(new Point(3, 2));
        }

        [TestMethod]
        public void GetHeighTest() {
            float expectedResult = 2.20F;
            float actualResult = instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLengthTest() {
            float expectedResult = 0.85F;
            float actualResult = instance.Length();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetBeginningTest() {
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.GetPosition();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetPriceTest() {
            float expectedResult = 100;
            float actualResult = instance.CalculatePrice();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostTest() {
            float expectedResult = 50;
            float actualResult = instance.CalculateCost();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EqualsTest() {
            Opening otherInstance = new Window(new Point(3, 2));
            Assert.IsTrue(instance.Equals(otherInstance));
        }

        [TestMethod]
        public void NotEqualsTest() {
            Opening otherInstance = new Window(new Point(3, 8));
            Assert.AreNotEqual(instance, otherInstance);
        }

        [TestMethod]
        public void EqualsNullTest() {
            Assert.AreNotEqual(instance, null);
        }

    }
}
