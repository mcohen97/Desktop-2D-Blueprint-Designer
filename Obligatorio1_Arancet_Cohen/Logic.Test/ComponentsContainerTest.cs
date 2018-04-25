using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Logic.Test {
    [TestClass]
    public class ComponentsContainerTest {

        BuildingComponentContainer instance;

        [TestInitialize]
        public void TestInitialize() {
            instance = new BuildingComponentContainer();
        }

        [TestMethod]
        public void emptyContainerNoWallsTest() {
            Assert.IsTrue(instance.isWallsEmpty());
        }

        [TestMethod]
        public void emptyContainerNoVigasTest() {
            Assert.IsTrue(instance.isVigasEmpty());
        }

        [TestMethod]
        public void emptyContainerNoOpeningsTest() {
            Assert.IsTrue(instance.isOpeningsEmpty());
        }

        [TestMethod]
        public void addWallTest() {
            Wall testWall = new Wall(new Point(3, 2), new Point(2, 2));
            instance.addWall(testWall);
            int expectedResult = 1;
            int actualResult = instance.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void addNullWallTest() {
            instance.addWall(null);
        }

        [TestMethod]
        public void addVigaTest() {
            Viga testViga = new Viga(new Point(3, 2));
            instance.addViga(testViga);
            int expectedResult = 1;
            int actualResult = instance.VigasCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void addNullVigaTest() {
            instance.addWall(null);
        }

        [TestMethod]
        public void addOpeningTest() {
            Opening testOpening = new Door(new Point(3, 2));
            instance.addOpening(testOpening);
            int expectedResult = 1;
            int actualResult = instance.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void addNullOpeningTest() {
            instance.addOpening(null);
        }

        [TestMethod]
        public void removeWallTest() {
            Wall testWall = new Wall(new Point(3, 2), new Point(2, 2));
            instance.addWall(testWall);
            instance.removeWall(testWall);
            int expectedResult = 0;
            int actualResult = instance.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeNullWallTest() {
            instance.removeWall(null);
        }

        [TestMethod]
        public void removeVigaTest() {
            Viga testViga = new Viga(new Point(3, 2));
            instance.addViga(testViga);
            instance.removeViga(testViga);
            int expectedResult = 0;
            int actualResult = instance.VigasCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeNullVigaTest() {
            instance.removeViga(null);
        }

        [TestMethod]
        public void removeOpeningTest() {
            Opening testOpening = new Door(new Point(3, 2));
            instance.addOpening(testOpening);
            instance.removeOpening(testOpening);
            int expectedResult = 0;
            int actualResult = instance.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void removeNullOpeningTest() {
            instance.removeOpening(null);
        }

        [TestMethod]
        public void getWallsCollectionTest() {
            Wall testWall = new Wall(new Point(3, 2), new Point(2, 2));
            instance.addWall(testWall);
            ICollection<Wall> expectedResult = new List<Wall>();
            expectedResult.Add(testWall);
            ICollection actualResult = instance.GetWalls();
            CollectionAssert.AreEquivalent((ICollection)expectedResult, actualResult);
        }

        [TestMethod]
        public void getVigasCollectionTest() {
            Viga testViga = new Viga(new Point(2, 2));
            instance.addWall(testViga);
            ICollection<Viga> expectedResult = new List<Viga>();
            expectedResult.Add(testViga);
            ICollection actualResult = instance.GetVigas();
            CollectionAssert.AreEquivalent((ICollection)expectedResult, actualResult);
        }

        [TestMethod]
        public void getOpeningsCollectionTest() {
            Opening testOpening = new Door(new Point(2, 2));
            instance.addOpening(testOpening);
            ICollection<Opening> expectedResult = new List<Opening>();
            expectedResult.Add(testOpening);
            ICollection actualResult = instance.GetOpenings();
            CollectionAssert.AreEquivalent((ICollection)expectedResult, actualResult);
        }

        [TestMethod]
        public void containsWallTest() {
            Wall testWall = new Wall(new Point(3, 2), new Point(2, 2));
            instance.addWall(testWall);
            Assert.IsTrue(instance.containsWall(testWall));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void containsNullWallTest() {
            instance.containsWall(null);
        }

        [TestMethod]
        public void containsVigaTest() {
            Viga testViga = new Viga(new Point(3, 2));
            instance.addViga(testViga);
            Assert.IsTrue(instance.containsViga(testViga));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void containsNullVigaTest() {
            instance.containsViga(null);
        }

        [TestMethod]
        public void containsOpeningTest() {
            Opening testOpening = new Door(new Point(3, 2));
            instance.addOpening(testOpening);
            Assert.IsTrue(instance.containsOpening(testOpening));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void containsNullOpeningTest() {
            instance.containsOpening(null);
        }


    }

}
