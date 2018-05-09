﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Test {

    [TestClass]
    public class BeamTest {

        private Beam instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Beam(new Point(3, 2));
        }

        [TestMethod]
        public void GetHeighTest() {
            float expectedResult = 3;
            float actualResult = instance.Height();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetBeginningTest() {
            int expectedXResult = 3;
            int expectedYResult = 2;
            Point actualResult = instance.GetPosition();
            Assert.IsTrue((actualResult.CoordX == expectedXResult) && (actualResult.CoordY == expectedYResult));
        }

        [TestMethod]
        public void GetPriceTest() {
            float expectedResult = 50;
            float actualResult = instance.Price();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void EqualsTest() {
            Beam otherInstance = new Beam(new Point(3, 2));
            Assert.AreEqual(instance, otherInstance);
        }

        [TestMethod]
        public void NotEqualsTest() {
            Beam otherInstance = new Beam(new Point(3, 5));
            Assert.AreNotEqual(instance, otherInstance);
        }

    }
}