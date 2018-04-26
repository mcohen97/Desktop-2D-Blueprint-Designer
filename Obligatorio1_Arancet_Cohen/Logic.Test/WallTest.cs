using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Test {

    [TestClass]
    public class WallTest {

        private Wall instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Wall(new Point(0, 0), new Point(3, 2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroLengthWall() {
            instance = new Wall(new Point(0, 0), new Point(0, 0));
        }

        [TestMethod]
        public void GetHeighTest() {
            float expectedResult = 3;
            float actualResult = instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetWidthTest() {
            float expectedResult = 0.20F;
            float actualResult = instance.Width();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLengthTest() {
            float expectedResult = (float)Math.Sqrt(13);
            float actualResult = instance.Length();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetBeginningTest() {
            int expectedXResult = 0;
            int expectedYResult = 0;
            Point actualResult = instance.Beginning();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetEndTest() {
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.End();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetPriceTest() {
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsNotHorizontalTest() {
            Assert.IsFalse(instance.IsHorizontal());
        }

        [TestMethod]
        public void IsHorizontalTest() {
            instance = new Wall(new Point(0, 0), new Point(2, 0));
            Assert.IsTrue(instance.IsHorizontal());
        }

        [TestMethod]
        public void IsNotVerticalTest() {
            Assert.IsFalse(instance.IsVertical());
        }

        [TestMethod]
        public void IsVerticalTest() {
            instance = new Wall(new Point(0, 0), new Point(0, 2));
            Assert.IsTrue(instance.IsVertical());
        }

        [TestMethod]
        public void WallsDoNotIntersectTest() {
            Wall otherInstance = new Wall(new Point(0, 1), new Point(3, 3));
            bool doTheyIntersect = instance.DoesIntersect(otherInstance);
            Assert.IsFalse(doTheyIntersect);
        }

        [TestMethod]
        public void SecantWallsDoIntersectTest() {
            Wall otherInstance = new Wall(new Point(0, 1), new Point(1, 0));
            bool doTheyIntersect = instance.DoesIntersect(otherInstance);
            Assert.IsTrue(doTheyIntersect);

        }

        [TestMethod]
        public void TShapeWallsIntersectTest() {
            Wall instance = new Wall(new Point(0, 5), new Point(0, -5));
            Wall otherInstance = new Wall(new Point(5, 0), new Point(0, 0));
            bool doTheyIntersect = instance.DoesIntersect(otherInstance);
            Assert.IsTrue(doTheyIntersect);
        }

        [TestMethod]
        [ExpectedException(typeof(WallsDoNotIntersectException))]
        public void GetIntersectionNotIntersectedWallsTest() {
            Wall otherInstance = new Wall(new Point(1, 0), new Point(2, 0));
            Point intersection = instance.GetIntersection(otherInstance);


        }

        [TestMethod]
        [ExpectedException(typeof(WallsDoNotIntersectException))]
        public void GetIntersectionColinearWallsTest() {
            Point intersection = instance.GetIntersection(instance);
        }

        [TestMethod]
        public void GetIntersectionSecantWallsTest() {
            Wall instance = new Wall(new Point(0, 2), new Point(2, 2));
            Wall otherInstance = new Wall(new Point(1, 0), new Point(1, 4));
            Point expectedResult = new Point(1, 2);
            Point actualResult = instance.GetIntersection(otherInstance);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetIntersectionTshapeWallsTest() {
            Wall insגtance = new Wall(new Point(0, 5), new Point(0, -5));
            Wall otherInstance = new Wall(new Point(5, 0), new Point(0, 0));
            Point intersection = instance.GetIntersection(otherInstance);
            Point expectedResult = new Point(0, 0);
            Point actualResult = instance.GetIntersection(otherInstance);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DoesNotBelongToWallTest() {
            Beam instance = new Beam(new Point(3, 2));
            Wall testWall = new Wall(new Point(2, 0), new Point(5, 0));
            Assert.IsFalse(testWall.DoesContainComponent(instance));
        }

        [TestMethod]
        public void BelongsToWallTest() {
            Beam instance = new Beam(new Point(3, 2));
            Wall testWall = new Wall(new Point(0, 2), new Point(5, 2));
            Assert.IsTrue(testWall.DoesContainComponent(instance));
        }

        [TestMethod]
        public void BelongsToEdgeOfWallTest() {
            Beam instance = new Beam(new Point(3, 2));
            Wall testWall = new Wall(new Point(3, 0), new Point(3, 5));
            Assert.IsTrue(testWall.DoesContainComponent(instance));
        }

    }
}
