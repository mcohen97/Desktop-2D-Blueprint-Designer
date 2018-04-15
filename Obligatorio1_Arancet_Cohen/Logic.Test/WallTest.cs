using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Test
{
    [TestClass]
    public class WallTest
    {
        [TestMethod]
        public void GetHeighTest(){
            Wall instance = new Wall(new Point(0, 0), new Point(3, 2));
            float expectedResult = 3;
            float actualResult = instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetWidthTest(){
            Wall instance = new Wall(new Point(0, 0), new Point(3, 2));
            float expectedResult = 0.20F;
            float actualResult = instance.Width();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLengthTest(){
            Wall instance = new Wall(new Point(0, 0), new Point(0, 2));
            float expectedResult =2;
            float actualResult = instance.Length();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetBeginningTest(){
            Wall instance = new Wall(new Point(0, 0), new Point(0, 2));
            int expectedXResult = 0;
            int expectedYResult = 0;
            Point actualResult = instance.Beginning();
            Assert.IsTrue((actualResult.CoordX == expectedXResult)&&(actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetEndTest(){
            Wall instance = new Wall(new Point(0, 0), new Point(0, 2));
            int expectedXResult = 0;
            int expectedYResult = 2;
            Point actualResult = instance.End();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetPriceTest(){
            Wall instance = new Wall(new Point(0, 0), new Point(0, 2));
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
