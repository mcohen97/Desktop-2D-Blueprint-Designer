using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Test
{
    [TestClass]
    public class OpeningTest
    {
        [TestMethod]
        public void GetHeighTest()
        {
            Opening instance = new Door(new Point(3, 2));
            float expectedResult = 2.20F;
            float actualResult = instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLengthTest()
        {
            Opening instance = new Door(new Point(3, 2));
            float expectedResult = 0.85F;
            float actualResult = instance.Length();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetBeginningTest()
        {
            Opening instance = new Door(new Point(3, 2));
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.Beginning();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetPriceTest()
        {
            Opening instance = new Door(new Point(3, 2));
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
