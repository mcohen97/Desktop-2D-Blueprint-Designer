using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetHeighTest()
        {
            Viga instance = new Viga(new Point(3, 2));
            float expectedResult =3;
            float actualResult =instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLengthTest()
        {
            Viga instance = new Viga(new Point(3, 2));
            float expectedResult = 0;
            float actualResult =instance.Length();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetBeginningTest()
        {
            Viga instance = new Viga(new Point(3, 2));
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.Beginning();
            Assert.IsTrue( (actualResult.CoordX == expectedXResult)&&(actualResult.CoordY == expectedYResult) );
        }

        [TestMethod]
        public void GetPriceTest()
        {
            Viga instance = new Viga(new Point(3, 2));
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
