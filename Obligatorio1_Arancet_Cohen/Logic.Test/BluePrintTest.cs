using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace Logic.Test {
    [TestClass]
    public class BlueprintTest {

        private Blueprint instance;

        [TestInitialize]
        public void SetUp() {
            instance = new Blueprint();
        }

        
        //Tests for insertion of walls
        [TestMethod]
        public void InsertFirstWallTest() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8,5));
            instance.InsertWall(testWall);
            ICollection actualWallCollection= instance.GetComponentsContainer().GetWalls();
            Wall actualResultWall = (Wall)actualWallCollection.GetEnumerator().Current;
            Assert.AreEqual(testWall, actualResultWall);
       }

        [TestMethod]
        public void InsertFirstWallCountTest() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            int expectedResult = 1;
            int actualResult = instance.GetComponentsContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertFirstWallBeamsCountTest() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            int expectedResult = 2;
            int actualResult = instance.GetComponentsContainer().BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedWallsCount() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(6, 2), new Point(6, 8));
            instance.InsertWall(testWall);
            int expectedResult = 4;
            int actualResult = instance.GetComponentsContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedWallsBeamsCount() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(6, 2), new Point(6, 8));
            instance.InsertWall(testWall);
            int expectedResult = 5;
            int actualResult = instance.GetComponentsContainer().BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedTShapeWallsCount() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(8, 2), new Point(8, 8));
            instance.InsertWall(testWall);
            int expectedResult = 3;
            int actualResult = instance.GetComponentsContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedTShapeWallsBeamsCount() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(8, 2), new Point(8, 8));
            instance.InsertWall(testWall);
            int expectedResult = 4;
            int actualResult = instance.GetComponentsContainer().BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void InsertNotIntersectedWallsCount() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(5, 3), new Point(8, 3));
            instance.InsertWall(testWall);
            int expectedResult = 2;
            int actualResult = instance.GetComponentsContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertNotIntersectedWallsBeamsCount() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(5, 3), new Point(8, 3));
            instance.InsertWall(testWall);
            int expectedResult = 4;
            int actualResult = instance.GetComponentsContainer().BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOversizedWallCountTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(12, 0));
            instance.InsertWall(testWall);
            int expectedResult = 3;
            int actualResult = instance.GetComponentsContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOversizedWallBeamsCountTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(12, 0));
            instance.InsertWall(testWall);
            int expectedResult = 4;
            int actualResult = instance.GetComponentsContainer().BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ContinuousWallsInsertedMergeTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(3, 0));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(3, 0), new Point(5, 0));
            instance.InsertWall(otherTestWall);
            int expectedResult = 1;
            int actualResult = instance.GetComponentContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ContinuousWallsInsertedNotMergeTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(3, 0));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(3, 0), new Point(7, 0));
            instance.InsertWall(otherTestWall);
            int expectedResult = 2;
            int actualResult = instance.GetComponentContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Tests for removal of walls
        [TestMethod]
        public void RemoveSingleWallCountTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(12, 0));
            instance.InsertWall(testWall);
            instance.RemoveWall(testWall);
            Assert.IsTrue(instance.GetComponentsContainer().isWallsEmpty());
        }

        [TestMethod]
        public void RemoveSingleWallBeamsCountTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(12, 0));
            instance.InsertWall(testWall);
            instance.RemoveWall(testWall);
            Assert.IsTrue(instance.GetComponentsContainer().isBeamsEmpty());
        }

        [TestMethod]
        public void RemoveFromTShapeWallLeavingLShapeTest() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(8, 2), new Point(8, 8));
            instance.InsertWall(testWall);
            Wall removingWall = new Wall(new Point(8, 5), new Point(8, 8));
            instance.RemoveWall(removingWall);
            int expectedResult = 2;
            int actualResult = instance.GetComponentContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveFromTShapeWallMergeTest() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(testWall);
            Wall otherTestWall = new Wall(new Point(8, 3), new Point(8, 8));
            instance.InsertWall(testWall);
            Wall removingWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.RemoveWall(removingWall);
            int expectedResult = 1;
            int actualResult = instance.GetComponentContainer().WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveWallWithOpening() {
            Wall testWall = new Wall(new Point(0, 0), new Point(3, 0));
            instance.InsertWall(testWall);
            Opening testOpening = new Door(new Point(2, 0));
            instance.InsertOpening(testOpening);
            instance.RemoveWall(testWall);
            BuildingComponentContainer structure = instance.GetComponentsContainer();
            Assert.IsTrue(structure.isBeamsEmpty() && structure.isOpeningsEmpty());
        }
    

        //tests for insertion of beams
        [TestMethod]
        public void InsertBeamToWallTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(3, 0));
            instance.InsertWall(testWall);
            Beam testBeam = new Beam(new Point(1, 0));
            Assert.IsTrue(instance.InsertBeam(testBeam));
        }

        [TestMethod]
        public void InsertBeamWithoutWallTest() {
            Beam testBeam = new Beam(new Point(0, 0));
            Assert.IsFalse(instance.InsertBeam(testBeam));
        }

        [TestMethod]
        public void InsertAlreadyExistingBeamTest() {
            Wall testWall = new Wall(new Point(0, 0), new Point(3, 0));
            instance.InsertWall(testWall);
            Beam testBeam = new Beam(new Point(1, 0));
            instance.InsertBeam(testBeam);
            Assert.IsFalse(instance.InsertBeam(testBeam));
        }


        //tests for insertion of openings
        [TestMethod]
        public void InsertOpeningCorrectly() {
            Wall testWall = new Wall(new Point(0, 0), new Point(3, 0));
            instance.InsertWall(testWall);
            Opening testOpening = new Door(new Point(2, 0));
            Assert.IsTrue(instance.InsertOpening(testOpening));
        }

        [TestMethod]
        public void InsertOpeningInNoWall() {
            Opening testOpening = new Door(new Point(2, 0));
            Assert.IsFalse(instance.InsertOpening(testOpening));
        }

        
    }
}
