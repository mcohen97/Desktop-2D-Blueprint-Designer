using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Test
{
    [TestClass]
    public class VigaTest
    {
       private Viga instance; 

        [TestInitialize]
        public void SetUp() {
           instance = new Viga(new Point(3, 2));
        }

        [TestMethod]
        public void GetHeighTest()
        {
            float expectedResult =3;
            float actualResult =instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLengthTest()
        {
            float expectedResult = 0;
            float actualResult =instance.Length();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void GetBeginningTest()
        {
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.Beginning();
            Assert.IsTrue( (actualResult.CoordX == expectedXResult)&&(actualResult.CoordY == expectedYResult) );
        }

        [TestMethod]
        public void GetPriceTest()
        {
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
