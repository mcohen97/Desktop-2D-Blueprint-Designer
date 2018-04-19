using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Test
{
    [TestClass]
    public class WallTest
    {
        private Wall instance;

        [TestInitialize]
        public void SetUp()
        {
            instance = new Wall(new Point(0, 0), new Point(3, 2));
        }

        [TestMethod]
        public void GetHeighTest(){
            float expectedResult = 3;
            float actualResult = instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetWidthTest(){
            float expectedResult = 0.20F;
            float actualResult = instance.Width();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLengthTest(){
            float expectedResult =(float)Math.Sqrt(13);
            float actualResult = instance.Length();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetBeginningTest(){
            int expectedXResult = 0;
            int expectedYResult = 0;
            Point actualResult = instance.Beginning();
            Assert.IsTrue((actualResult.CoordX == expectedXResult)&&(actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetEndTest(){
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.End();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetPriceTest(){
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
