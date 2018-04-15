using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;


namespace Logic.Test
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void GetCoordXTest(){
            Point instance = new Point(3, 2);
            int expectedResult = 3;
            int actualResult= instance.CoordX;
            Assert.AreEqual(expectedResult,actualResult);
        }

        [TestMethod]
        public void GetCoordYTest(){
            Point instance = new Point(3, 2);
            int expectedResult = 2;
            int actualResult = instance.CoordY;
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
