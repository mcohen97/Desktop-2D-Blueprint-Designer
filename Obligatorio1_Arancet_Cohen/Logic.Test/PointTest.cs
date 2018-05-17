using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;


namespace Logic.Test
{
    [TestClass]
    public class PointTest
    {
        private Point instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Point(3, 2);
        }

        [TestMethod]
        public void GetCoordXTest(){
            int expectedResult = 3;
            float actualResult= instance.CoordX;
            Assert.AreEqual(expectedResult,actualResult);
        }

        [TestMethod]
        public void GetCoordYTest(){
            int expectedResult = 2;
            float actualResult = instance.CoordY;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EqualsTest() {
            Point otherInstance = new Point(3, 2);
            Assert.AreEqual(instance,otherInstance);
        }

        [TestMethod]
        public void NotEqualsTest() {
            Point otherInstance = new Point(5, 2);
            Assert.AreNotEqual(instance, otherInstance);
        }

        [TestMethod]
        public void EqualsNullTest() {
            Point otherInstance = null;
            Assert.AreNotEqual(instance, otherInstance);
        }

        [TestMethod]
        public void EqualsOtherObjectTest() {
            Wall otherInstance = new Wall(instance,new Point(5,2));
            Assert.AreNotEqual(instance, otherInstance);
        }

        [TestMethod]
        public void MinusOperatorTest() {
            Point otherInstance = new Point(2, 1);
            Point expectedResult = new Point(1, 1);
            Point actualResult = instance - otherInstance;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DistanceToOriginTest() {
            float expectedResult = (float)Math.Sqrt(13);
            float actualResult = instance.DistanceToOrigin();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CompareToTest() {
            Point testPoint = new Point(5,2);
            Assert.IsTrue(instance.CompareTo(testPoint)< 0);
        }

        [TestMethod]
        public void IsCloserToOriginTest() {
            Point testPoint1 = new Point(5, 5);
            Point testPoint2 = new Point(6, 5);
            Assert.IsTrue(testPoint1.IsCloserToOriginThan(testPoint2));
        }
        [TestMethod]
        public void IsNotCloserToOriginTest() {
            Point testPoint = new Point(5, 2);
            Assert.IsFalse(testPoint.IsCloserToOriginThan(instance));
        }

        [TestMethod]
        public void DistanceToOtherPointTest() {
            Point testPoint = new Point(3, 0);
            float expectedResult = 2;
            float actualResult = instance.DistanceToPoint(testPoint);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void PlusOperatorTest() {
            Point otherOperand = new Point(1,1);
            Point expectedResult = new Point(4, 3);
            Point actualResult = instance+otherOperand;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MultipliedByScalarOperatorTest() {
            Point expectedResult = new Point(6, 4);
            Point actualResult = 2 * instance;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PointAtSameHorizontalLineTest() {
            Point a = new Point(2,0);
            Point b = new Point(3, 0);
            Point vector = b - a;
            Point expectedResult = new Point(5, 0);
            Point actualResult = a.PointInSameLineAtSomeDistance(vector, 3);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void PointAtSameLineTest() {
            Point testPoint = new Point(4, 3);
            Point vector = testPoint - instance;
            Point actualResult = instance.PointInSameLineAtSomeDistance(vector, 5);
            float expectedX = 3 + (float)(5 / Math.Sqrt(2));
            float expectedY = 2 + (float)(5 / Math.Sqrt(2));
            Point expectedResult =new Point(expectedX,expectedY);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsInRangeTest() {
            Assert.IsTrue(instance.IsInRange(5,5));
        }

        [TestMethod]
        public void IsNotInRangeTest() {
            Assert.IsFalse(instance.IsInRange(2, 2));
        }
    }
}
