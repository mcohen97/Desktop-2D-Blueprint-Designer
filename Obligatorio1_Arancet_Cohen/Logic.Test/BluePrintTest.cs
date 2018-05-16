using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Logic.Test {
    [TestClass]
    public class BlueprintTest {

        private Blueprint instance;
        private BuildingComponentContainer materials;
        Client owner;
        [TestInitialize]
        public void SetUp() {
           owner = new Client("Carl", "Ownerhood", "owner", "owner", "12345", "addd", "1234455", DateTime.Now);
            materials = new BuildingComponentContainer();
            instance = new Blueprint(20,20,"TestBlueprint",materials);
        }

        [TestMethod]
        public void SetNameTest() {
            string expectedResult = "TestBlueprint";
            string actualResult = instance.Name;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetEmptyNameTest() {
            instance = new Blueprint(20, 20, "" ,materials);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullNameTest() {
            instance = new Blueprint(20, 20, null,materials);
        }

        [TestMethod]
        public void SetLengthTest() {
            int expectedResult = 20;
            int actualResult = instance.Length;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetZeroLengthTest() {
            instance = new Blueprint(0, 20, "TestBlueprint" ,materials);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNegativeLengthTest() {
            instance = new Blueprint(-20, 20, "TestBlueprint" ,materials);
        }

        [TestMethod]
        public void SetWidthTest() {
            int expectedResult = 20;
            int actualResult = instance.Width;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetZeroWidthTest() {
            instance = new Blueprint(20, 0, "TestBlueprint" ,materials);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetveNegativeWidthTest() {
            instance = new Blueprint(20, -20, "TestBlueprint" ,materials);
        }

        [TestMethod]
        public void SetOwnerTest() {
            User owner = new Client("Carl", "Ownerhood", "owner", "owner", "12345", "addd", "1234455", DateTime.Now);
            instance.Owner = owner;
            Assert.AreEqual(instance.Owner, owner);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullOwnerTest() {
            instance.Owner = null;
        }


        //Tests for insertion of walls
        [TestMethod]
        [ExpectedException(typeof(OutOfRangeComponentException))]
        public void InsertOutOfRangeWallTest() {
            instance.InsertWall(new Point(-5, -20), new Point(20, 100));
        }

        [TestMethod]
        public void InsertFirstWallTest() {
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            ICollection<Wall> actualWallCollection= materials.GetWalls();
            IEnumerator<Wall> itr = actualWallCollection.GetEnumerator();
            itr.MoveNext();
            Wall actualResultWall = (Wall)itr.Current;
            Assert.AreEqual(testWall, actualResultWall);
       }

        [TestMethod]
        public void InsertFirstWallCountTest() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            int expectedResult = 1;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertFirstWallBeamsCountTest() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            int expectedResult = 2;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedXShapeWallsCount() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(6, 3), new Point(6, 7));
            int expectedResult = 4;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedXShapeWallsBeamsCount() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(6, 3), new Point(6, 7));
            int expectedResult = 5;
            int actualResult =materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedTShapeWallsCount() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(8, 2), new Point(8, 7));
            int expectedResult = 3;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedTShapeWallsBeamsCount() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(8, 2), new Point(8, 7));
            int expectedResult = 4;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(CollinearWallsException))]
        public void InsertCollinearWallTest() {
            instance.InsertWall(new Point(1, 0), new Point(5, 0));
            instance.InsertWall(new Point(3, 0), new Point(7, 0));
        }

        [TestMethod]
        public void InsertNotIntersectedWallsCount() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(5, 3), new Point(8, 3));
            int expectedResult = 2;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertNotIntersectedWallsBeamsCount() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(5, 3), new Point(8, 3));
            int expectedResult = 4;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOversizedWallCountTest() {
            instance.InsertWall(new Point(0, 0), new Point(12, 0));
            int expectedResult = 3;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOversizedWallCountTest2() {
            instance.InsertWall(new Point(0, 0), new Point(10, 0));
            int expectedResult = 2;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOversizedWallBeamsCountTest() {
            instance.InsertWall(new Point(0, 0), new Point(12, 0));
            int expectedResult = 4;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        

        [TestMethod]
        public void ContinuousWallsInsertedMergeTest() {
            instance.InsertWall(new Point(0, 0), new Point(3, 0));
            instance.InsertWall(new Point(3, 0), new Point(4, 0));
            int expectedResult = 1;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ContinuousWallsInsertedNotMergeTest() {
            instance.InsertWall(new Point(0, 0), new Point(3, 0));
            instance.InsertWall(new Point(3, 0), new Point(7, 0));
            int expectedResult = 2;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOpeningsTest() {
            instance.InsertWall(new Point(0, 0), new Point(3, 0));
            instance.InsertOpening(new Door(new Point(1, 0)));
            instance.InsertOpening(new Door(new Point(2, 0)));
            int expectedResult = 2;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OpeningOnIntersectionRemovalTest() {
            instance.InsertWall(new Point(0, 0), new Point(3, 0));
            instance.InsertOpening(new Door(new Point(1, 0)));
            instance.InsertOpening(new Door(new Point(2, 0)));
            instance.InsertWall(new Point(2, 0), new Point(2, 2));
            int expectedResult = 1;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Tests for removal of walls
        [TestMethod]
        public void RemoveSingleWallCountTest() {
            instance.InsertWall(new Point(0, 0), new Point(5, 0));
            instance.RemoveWall(new Point(0, 0), new Point(5, 0));
            Assert.IsTrue(materials.IsWallsEmpty());
        }

        [TestMethod]
        public void RemoveSingleWallBeamsCountTest() {
            instance.InsertWall(new Point(0, 0), new Point(5, 0));
            instance.RemoveWall(new Point(0, 0), new Point(5, 0));
            Assert.IsTrue(materials.IsBeamsEmpty());
        }

        [TestMethod]
        public void RemoveFromTShapeWallLeavingLShapeTest() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(8, 2), new Point(8, 7));
            instance.RemoveWall(new Point(8, 5), new Point(8, 7));
            int expectedResult = 2;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveFromTShapeWallMergeTest() {
            instance.InsertWall(new Point(5, 5), new Point(8, 5));
            instance.InsertWall(new Point(8, 3), new Point(8, 7));
            instance.RemoveWall(new Point(5, 5), new Point(8, 5));
            int expectedResult = 1;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveWallWithOpening() {
            instance.InsertWall(new Point(0, 0), new Point(3, 0));
            Opening testOpening = new Door(new Point(2, 0));
            instance.InsertOpening(testOpening);
            testOpening=new Door(new Point(1, 0));
            instance.InsertOpening(testOpening);
            instance.RemoveWall(new Point(0, 0), new Point(3, 0));
            int actualResult=materials.OpeningsCount();
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MultipleDeletionsTest() {
            instance.InsertWall(new Point(2, 1), new Point(2, 4));
            instance.InsertWall(new Point(1, 2), new Point(3, 2));
            instance.InsertWall(new Point(1, 3), new Point(3, 3));

            instance.RemoveWall(new Point(1, 2), new Point(2, 2));
            instance.RemoveWall(new Point(2, 2), new Point(3, 2));

            instance.RemoveWall(new Point(1, 3), new Point(2, 3));
            instance.RemoveWall(new Point(2, 3), new Point(3, 3));

            int expectedResult = 1;
            int actualResult = materials.WallsCount();

            Assert.AreEqual(expectedResult, actualResult);
        }

        //tests for insertion of openings
        [TestMethod]
        [ExpectedException(typeof(OutOfRangeComponentException))]
        public void InsertOpeningOutOfRangeTest() {
            Opening testOpening = new Door(new Point(50, -3));
            instance.InsertOpening(testOpening);
        }

        [TestMethod]
        public void InsertOpeningCorrectly() {
            instance.InsertWall(new Point(0, 0), new Point(3, 0));
            Opening testOpening = new Door(new Point(2, 0));
            instance.InsertOpening(testOpening);
            int expectedResult = 1;
            int actualResult=materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof (ComponentOutOfWallException))]
        public void InsertOpeningInNoWall() {
            Opening testOpening = new Door(new Point(2, 0));
            instance.InsertOpening(testOpening);
        }

        [TestMethod]
        public void MultipleInsertionsTest() {
            instance.InsertWall(new Point(2,3), new Point(2,1));
            instance.InsertWall(new Point(8, 1), new Point(8, 3));
            instance.InsertWall(new Point(10, 1), new Point(10, 3));
            instance.InsertWall(new Point(1,2), new Point(11,2));
            int expectedResult = 11;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveOpeningTest() {
            instance.InsertWall(new Point(2, 3), new Point(2, 1));
            instance.InsertOpening(new Door(new Point(2, 2)));
            instance.RemoveOpening(new Door(new Point(2,2)));
            int expectedResult = 0;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveUnexistentOpening() {
            instance.InsertWall(new Point(2, 3), new Point(2, 1));
            instance.RemoveOpening(new Door(new Point(2, 2)));
            int expectedResult = 0;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }


    }

    
}
