using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;

namespace Logic.Test
{
    [TestClass]
    public class ColumnTest
    {
        Column instance;
        Blueprint blueprint;

        [TestInitialize]
        public void SetUp()
        {
            instance = new Column(new Point(3, 2));
            blueprint = new Blueprint(20, 20, "blueprint");
            blueprint.InsertWall(new Point(5,5), new Point(5,9));
        }


        [TestMethod]
        public void GetComponentTypeTest()
        {
            Assert.AreEqual(ComponentType.COLUMN, instance.GetComponentType());
        }

        [TestMethod]
        public void GetPriceTest()
        {
            float expectedResult = 50;
            float actualResult = instance.CalculatePrice();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostTest()
        {
            float expectedResult = 25;
            float actualResult = instance.CalculateCost();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLengthTest()
        {
            float expectedResult = 0.5f;
            float actualResult = instance.Length();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetWidthTest()
        {
            float expectedResult = 0.5f;
            float actualResult = instance.Width();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetHeightTest()
        {
            float expectedResult = 3;
            float actualResult = instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
