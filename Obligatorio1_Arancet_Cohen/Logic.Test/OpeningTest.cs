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
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DoesNotBelongToWallTest() {
            Wall testWall = new Wall(new Point(2, 0), new Point(5, 0));
            Assert.IsFalse(testWall.DoesContainComponent(instance));
        }

        [TestMethod]
        public void BelongsToWallTest() {
            Wall testWall = new Wall(new Point(0, 2), new Point(5, 2));
            Assert.IsTrue(testWall.DoesContainComponent(instance));
        }

        [TestMethod]
        public void BelongsToEdgeOfWallTest() {
            Wall testWall = new Wall(new Point(3, 0), new Point(3, 5));
            Assert.IsTrue(testWall.DoesContainComponent(instance));
        }
    }
}
