using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;


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
            int actualResult= instance.CoordX;
            Assert.AreEqual(expectedResult,actualResult);
        }

        [TestMethod]
        public void GetCoordYTest(){
            int expectedResult = 2;
            int actualResult = instance.CoordY;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EqualsTest() {
            Point otherInstance = new Point(3, 2);
            Assert.AreEqual(instance,otherInstance);
        }
    }
}
