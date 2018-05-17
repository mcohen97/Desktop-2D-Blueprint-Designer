using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;

namespace Logic.Test
{

    [TestClass]
    public class BeamTest
    {

        private Beam instance;

        [TestInitialize]
        public void SetUp()
        {
            instance = new Beam(new Point(3, 2));
        }

        [TestMethod]
        public void GetBeginningTest()
        {
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.GetPosition();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetPriceTest()
        {
            float expectedResult = 100;
            float actualResult = instance.CalculatePrice();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostTest()
        {
            float expectedResult = 50;
            float actualResult = instance.CalculateCost();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EqualsTest()
        {
            Beam otherInstance = new Beam(new Point(3, 2));
            Assert.AreEqual(instance, otherInstance);
        }

        [TestMethod]
        public void NotEqualsTest()
        {
            Beam otherInstance = new Beam(new Point(3, 5));
            Assert.AreNotEqual(instance, otherInstance);
        }

        [TestMethod]
        public void GetComponentTypeTest()
        {
            Assert.AreEqual(ComponentType.BEAM, instance.GetComponentType());
        }
    }
}
