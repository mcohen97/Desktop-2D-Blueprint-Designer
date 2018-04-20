﻿using System;
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
            Wall otherInstance = new Wall(instance,instance);
            Assert.AreNotEqual(instance, otherInstance);
        }

        [TestMethod]
        public void MinusOperatorTest() {
            Point otherInstance = new Point(2, 1);
            Point expectedResult = new Point(1, 1);
            Point actualResult = instance - otherInstance;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
