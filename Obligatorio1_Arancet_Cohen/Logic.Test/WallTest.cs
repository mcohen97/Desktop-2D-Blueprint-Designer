using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Exceptions;

namespace Test {

    [TestClass]
    public class WallTest {

        private Wall instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Wall(new Point(0, 0), new Point(3, 2));
        }

        [TestMethod]
        public void ConstructorSortedPointsTest() {
            Wall testWall= new Wall(new Point(3, 2), new Point(1, 1));
            bool beginningOk = testWall.Beginning().Equals(new Point(1, 1));
            bool endOk = testWall.End().Equals(new Point(3, 2));
            Assert.IsTrue(beginningOk && endOk);
        }

        [TestMethod]
        [ExpectedException(typeof(ZeroLengthWallException))]
        public void ZeroLengthWallTest() {
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
            float expectedResult = 100 * (float)(Math.Sqrt(13));
            float actualResult = instance.CalculatePrice();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostTest() {
            float expectedResult = 50* (float)(Math.Sqrt(13));
            float actualResult = instance.CalculateCost();
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
        public void GetIntersectionContinuousWalls() {
            Wall testWall = new Wall(new Point(3,2), new Point(5,4));
            Point expectedResult = new Point(3, 2);
            Point actualResult=instance.GetIntersection(testWall);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(CollinearWallsException))]
        public void GetIntersectionCollinearWallsTest() {
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
        public void OverlapsWallTest() {
            Wall testWall = new Wall(new Point(1, 1), new Point(3, 3));
            Wall otherTestWall = new Wall(new Point(2, 2), new Point(3, 3));
            Assert.IsTrue(otherTestWall.Overlaps(testWall));
        }

        [TestMethod]
        public void DoesNotOverlapWallTest() {
            Wall testWall = new Wall(new Point(0, 1), new Point(0, 2));
            Assert.IsFalse(instance.Overlaps(testWall));
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
            Beam instance = new Beam(new Point(3, 5));
            Wall testWall = new Wall(new Point(3, 0), new Point(3, 5));
            Assert.IsFalse(testWall.DoesContainComponent(instance));
        }

        [TestMethod]
        public void EqualsTest() {
            Wall otherInstance = new Wall(new Point(0,0), new Point(3,2));
            Assert.AreEqual(instance, otherInstance);
        }

        [TestMethod]
        public void NotEqualsTest() {
            Wall otherInstance = new Wall(new Point(0, 0), new Point(3, 8));
            Assert.AreNotEqual(instance, otherInstance);
        }

        [TestMethod]
        public void EqualsNullTest() {
            Assert.AreNotEqual(instance, null);
        }

        [TestMethod]
        public void EqualsOtherTypeTest() {
            Assert.AreNotEqual(instance, new Window(new Point(0,0)));
        }

        [TestMethod]
        public void AreContinuousTest() {
            Wall testWall = new Wall(new Point(1, 0), new Point(3, 0));
            Wall otherTestWall = new Wall(new Point(3,0), new Point(5,0));
            Assert.IsTrue(testWall.IsCollinearContinuous(otherTestWall));
        }

        [TestMethod]
        public void AreNotContinuousTest() {
            Wall testWall = new Wall(new Point(1,0), new Point(3,0));
            Wall otherTestWall = new Wall(new Point(4,0), new Point(5,0));
            Assert.IsFalse(testWall.IsCollinearContinuous(otherTestWall));
        }

        [TestMethod]
        public void AreConnectedContinuousTest() {
            Wall testWall = new Wall(new Point(1, 0), new Point(3, 0));
            Wall otherTestWall = new Wall(new Point(3, 0), new Point(5, 0));
            Assert.IsTrue(testWall.IsConnected(otherTestWall));
        }

        [TestMethod]
        public void AreConnectedLShapeTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(0, 2));
            Wall otherTestWall = new Wall(new Point(2, 0), new Point(0, 0));
            Assert.IsTrue(testWall.IsConnected(otherTestWall));
        }

        [TestMethod]
        public void AreNotConnectedTest() {
            Wall testWall = new Wall(new Point(1, 0), new Point(3, 0));
            Wall otherTestWall = new Wall(new Point(4, 0), new Point(5, 0));
            Assert.IsFalse(testWall.IsConnected(otherTestWall));
        }

        [TestMethod]
        public void GetComponentTypeTest() {
            Assert.AreEqual(ComponentType.WALL, instance.GetComponentType());
        }

        [TestMethod]
        public void MergeContinuousCollinearWallsTest() {
            Wall testWall = new Wall(new Point(1, 0), new Point(3, 0));
            Wall otherTestWall = new Wall(new Point(3, 0), new Point(5, 0));
            Wall expectedResult = new Wall(new Point(1,0), new Point(5,0));
            Wall actualResult = testWall.MergeCollinearContinuous(otherTestWall);
            Assert.AreEqual(expectedResult, actualResult);
        }

        }
}
