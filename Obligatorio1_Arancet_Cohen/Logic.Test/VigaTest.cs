using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Test {

    [TestClass]
    public class VigaTest {

        private Viga instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Viga(new Point(3, 2));
        }

        [TestMethod]
        public void GetHeighTest() {
            float expectedResult = 3;
            float actualResult = instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetBeginningTest() {
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.Beginning();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetPriceTest() {
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DoesNotBelongToWallTest() {
            Wall testWall = new Wall(new Point(2, 0), new Point(5, 0));
            Assert.IsTrue(instance.DoesBelongToWall(testWall));
        }

        [TestMethod]
        public void BelongsToWallTest() {
            Wall testWall = new Wall(new Point(0, 2), new Point(5, 2));
            Assert.IsTrue(instance.DoesBelongToWall(testWall));
        }
    }
}
