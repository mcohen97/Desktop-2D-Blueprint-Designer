using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using Logic.Domain;

namespace Logic.Test
{
    [TestClass]
    public class ComponentsContainerTest
    {

        MaterialContainer instance;

        [TestInitialize]
        public void TestInitialize()
        {
            instance = new MaterialContainer();
        }

        [TestMethod]
        public void EmptyContainerNoWallsTest()
        {
            Assert.IsTrue(instance.IsWallsEmpty());
        }

        [TestMethod]
        public void EmptyContainerNoBeamsTest()
        {
            Assert.IsTrue(instance.IsBeamsEmpty());
        }

        [TestMethod]
        public void EmptyContainerNoOpeningsTest()
        {
            Assert.IsTrue(instance.IsOpeningsEmpty());
        }

        [TestMethod]
        public void EmptyContainerNoColumnsTest()
        {
            Assert.IsTrue(instance.IsColumnsEmpty());
        }

        [TestMethod]
        public void AddWallTest()
        {
            Wall testWall = new Wall(new Point(3, 2), new Point(2, 2));
            instance.AddWall(testWall);
            int expectedResult = 1;
            int actualResult = instance.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullWallTest()
        {
            instance.AddWall(null);
        }

        [TestMethod]
        public void AddBeamTest()
        {
            Beam testBeam = new Beam(new Point(3, 2));
            instance.AddBeam(testBeam);
            int expectedResult = 1;
            int actualResult = instance.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddColumnTest()
        {
            Column testColumn = new Column(new Point(3, 2));
            instance.AddColumn(testColumn);
            Assert.IsTrue(instance.ContainsColumn(testColumn));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullColumnTest()
        {
            instance.AddColumn(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullBeamTest()
        {
            instance.AddWall(null);
        }

        [TestMethod]
        public void AddOpeningTest()
        {
            Opening testOpening = new Door(new Point(3, 2));
            instance.AddOpening(testOpening);
            int expectedResult = 1;
            int actualResult = instance.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullOpeningTest()
        {
            instance.AddOpening(null);
        }

        [TestMethod]
        public void RemoveWallTest()
        {
            Wall testWall = new Wall(new Point(3, 2), new Point(2, 2));
            instance.AddWall(testWall);
            instance.RemoveWall(testWall);
            int expectedResult = 0;
            int actualResult = instance.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullWallTest()
        {
            instance.RemoveWall(null);
        }

        [TestMethod]
        public void RemoveColumnTest()
        {
            Column testColumn = new Column(new Point(2, 3));
            instance.AddColumn(testColumn);
            instance.RemoveColumn(testColumn);

            Assert.AreEqual(0, instance.GetColumns().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullColumnTest()
        {
            instance.RemoveColumn(null);
        }

        [TestMethod]
        public void RemoveBeamTest()
        {
            Beam testBeam = new Beam(new Point(3, 2));
            instance.AddBeam(testBeam);
            instance.RemoveBeam(testBeam);
            int expectedResult = 0;
            int actualResult = instance.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullBeamTest()
        {
            instance.RemoveBeam(null);
        }

        [TestMethod]
        public void RemoveOpeningTest()
        {
            Opening testOpening = new Door(new Point(3, 2));
            instance.AddOpening(testOpening);
            instance.RemoveOpening(testOpening);
            int expectedResult = 0;
            int actualResult = instance.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void removeNullOpeningTest()
        {
            instance.RemoveOpening(null);
        }

        [TestMethod]
        public void GetWallsCollectionTest()
        {
            Wall testWall = new Wall(new Point(3, 2), new Point(2, 2));
            instance.AddWall(testWall);
            ICollection<Wall> expectedResult = new List<Wall>();
            expectedResult.Add(testWall);
            ICollection<Wall> actualResult = instance.GetWalls();
            CollectionAssert.AreEquivalent((ICollection)expectedResult, (ICollection)actualResult);
        }

        [TestMethod]
        public void GetBeamsCollectionTest()
        {
            Beam testBeam = new Beam(new Point(2, 2));
            instance.AddBeam(testBeam);
            ICollection<Beam> expectedResult = new List<Beam>();
            expectedResult.Add(testBeam);
            ICollection actualResult = (ICollection)instance.GetBeams();
            CollectionAssert.AreEquivalent((ICollection)expectedResult, actualResult);
        }

        [TestMethod]
        public void GetOpeningsCollectionTest()
        {
            Opening testOpening = new Door(new Point(2, 2));
            instance.AddOpening(testOpening);
            ICollection<Opening> expectedResult = new List<Opening>();
            expectedResult.Add(testOpening);
            ICollection actualResult = (ICollection)instance.GetOpenings();
            CollectionAssert.AreEquivalent((ICollection)expectedResult, actualResult);
        }

        [TestMethod]
        public void GetColumnsCollectionTest()
        {
            Column testColumn = new Column(new Point(2, 2));
            instance.AddColumn(testColumn);
            ICollection<Column> expectedResult = new List<Column>();
            expectedResult.Add(testColumn);
            ICollection actualResult = (ICollection)instance.GetColumns();
            CollectionAssert.AreEquivalent((ICollection)expectedResult, actualResult);
        }

        [TestMethod]
        public void ContainsWallTest()
        {
            Wall testWall = new Wall(new Point(3, 2), new Point(2, 2));
            instance.AddWall(testWall);
            Wall otherTestWall = new Wall(new Point(3, 2), new Point(2, 2));
            Assert.IsTrue(instance.ContainsWall(otherTestWall));
        }

        [TestMethod]
        public void ContainsColumnTest()
        {
            Column testColumn = new Column(new Point(3, 2));
            instance.AddColumn(testColumn);
            Assert.IsTrue(instance.ContainsColumn(testColumn));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNullWallTest()
        {
            instance.ContainsWall(null);
        }

        [TestMethod]
        public void ContainsBeamTest()
        {
            Beam testBeam = new Beam(new Point(3, 2));
            instance.AddBeam(testBeam);
            Beam otherTestBeam = new Beam(new Point(3, 2));
            Assert.IsTrue(instance.ContainsBeam(otherTestBeam));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNullBeamTest()
        {
            instance.ContainsBeam(null);
        }

        [TestMethod]
        public void ContainsOpeningTest()
        {
            Opening testOpening = new Door(new Point(3, 2));
            instance.AddOpening(testOpening);
            Opening otherTestOpening = new Window(new Point(3, 2));
            Assert.IsTrue(instance.ContainsOpening(otherTestOpening));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNullOpeningTest()
        {
            instance.ContainsOpening(null);
        }

    }

}
