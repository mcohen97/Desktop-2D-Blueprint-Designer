using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Test
{
    [TestClass]
    public class WindowTest
    {
        Window instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Window(new Point(3, 2));
        }

        [TestMethod]
        public void GetHeightAboveFloorTest() {
            float expectedResullt = 1;
            float actualResult = instance.HeightAboveFloor;
            Assert.AreEqual(expectedResullt, actualResult);
        }
    }
}
