using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryInterface;
using Logic.Domain;
using Services;
using DataAccess;
using System.Collections.Generic;

namespace ServicesTest
{
    [TestClass]
    public class BlueprintEditorTest
    {

        private IRepository<User> repository;

        private IBlueprint blueprintTest;
        private IBlueprint blueprint2;
        private IBlueprint blueprint3;
        private MaterialContainer materials;

        private User user1;
        private User user2;
        private User user3;
        private User user4;
        private User architect;

        private SessionConnector conn;
        private UserAdministrator administrator;
        private BlueprintPortfolio blueprintPortfolio;

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new UserRepository();
            (repository).Clear();
            blueprintPortfolio = BlueprintPortfolio.Instance;


            conn = new SessionConnector();
            Session session = conn.LogIn("admin", "admin");
            administrator = new UserAdministrator(session);

            user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            user2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            user3 = new Designer("d1", "d1", "designer3", "12345", DateTime.Now);
            user4 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);
            architect = new Architect("Archi", "Tect", "architect", "architect", DateTime.Now);

            blueprintTest = new Blueprint(12, 12, "Blueprint1", materials);
            blueprint2 = new Blueprint(10, 10, "Blueprint2");
            blueprint3 = new Blueprint(11, 11, "Blueprint2");
            materials = new MaterialContainer();

            blueprintTest.Owner = user1;
            blueprint2.Owner = user2;
            blueprint3.Owner = user1;

            administrator.Add(user1);
            administrator.Add(user2);
            administrator.Add(user3);
            administrator.Add(user4);
            administrator.Add(architect);

        }

        [TestCleanup]
        public void CleanUp()
        {
            blueprintPortfolio.Clear();
            repository.Clear();
        }

        private void initializerWithData()
        {
            Session session = conn.LogIn("designer3", "12345");
            BlueprintController controller = new BlueprintController(session);
            controller.Add(blueprintTest);
            controller.Add(blueprint2);
            controller.Add(blueprint3);
        }

        private BlueprintEditor GetInstance()
        {
            Session session = conn.LogIn("designer3", "12345");
            BlueprintEditor newInstance = new BlueprintEditor(session, blueprintTest);
            return newInstance;
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Session session = conn.LogIn("designer3", "12345");
            BlueprintEditor blueEditor = new BlueprintEditor(session, blueprintTest);
            Assert.IsNotNull(blueEditor);
        }


        [TestMethod]
        public void SetNameTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            string expectedResult = blueprintTest.Name;
            string actualResult = blueEditor.GetName();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetEmptyNameTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            blueEditor.SetName("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullNameTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            blueEditor.SetName(null);
        }

        [TestMethod]
        public void SetOwnerTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            blueEditor.SetOwner(user3);
            Assert.AreEqual(blueEditor.GetOwner(), user3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullOwnerTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            blueEditor.SetOwner(null);
        }


        //Tests for insertion of walls
        [TestMethod]
        [ExpectedException(typeof(OutOfRangeComponentException))]
        public void InsertOutOfRangeWallTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            blueEditor.InsertWall(new Point(-5, -20), new Point(20, 100));
        }

        [TestMethod]
        public void InsertFirstWallTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            Wall testWall = new Wall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            ICollection<Wall> actualWallCollection = materials.GetWalls();
            IEnumerator<Wall> itr = actualWallCollection.GetEnumerator();
            itr.MoveNext();
            Wall actualResultWall = (Wall)itr.Current;
            Assert.AreEqual(testWall, actualResultWall);
        }

        [TestMethod]
        public void InsertFirstWallCountTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            int expectedResult = 1;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertFirstWallBeamsCountTest()
        {
            BlueprintEditor blueEditor = GetInstance();
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            int expectedResult = 2;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedXShapeWallsCount()
        {
            BlueprintEditor blueEditor = GetInstance();
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(6, 3), new Point(6, 7));
            int expectedResult = 4;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedXShapeWallsBeamsCount()
        {
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(6, 3), new Point(6, 7));
            int expectedResult = 5;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedTShapeWallsCount()
        {
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(8, 2), new Point(8, 7));
            int expectedResult = 3;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertIntersectedTShapeWallsBeamsCount()
        {
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(8, 2), new Point(8, 7));
            int expectedResult = 4;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(CollinearWallsException))]
        public void InsertCollinearWallTest()
        {
            blueEditor.InsertWall(new Point(1, 0), new Point(5, 0));
            blueEditor.InsertWall(new Point(3, 0), new Point(7, 0));
        }

        [TestMethod]
        public void InsertNotIntersectedWallsCount()
        {
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(5, 3), new Point(8, 3));
            int expectedResult = 2;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertNotIntersectedWallsBeamsCount()
        {
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(5, 3), new Point(8, 3));
            int expectedResult = 4;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOversizedWallCountTest()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(12, 0));
            int expectedResult = 3;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOversizedWallCountTest2()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(10, 0));
            int expectedResult = 2;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOversizedWallBeamsCountTest()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(12, 0));
            int expectedResult = 4;
            int actualResult = materials.BeamsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ColumnInPlaceException))]
        public void InsertWallInColumnPlaceTest()
        {
            blueEditor.InsertColumn(new Point(2, 5));
            blueEditor.InsertWall(new Point(2, 3), new Point(2, 6));
        }

        [TestMethod]
        public void InsertWallInColumnPlaceBorderTest()
        {
            blueEditor.InsertColumn(new Point(2, 3));
            blueEditor.InsertWall(new Point(2, 3), new Point(2, 6));
            Assert.AreEqual(1, blueEditor.GetWalls().Count);
        }

        [TestMethod]
        public void ContinuousWallsInsertedMergeTest()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(3, 0));
            blueEditor.InsertWall(new Point(3, 0), new Point(4, 0));
            int expectedResult = 1;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ContinuousWallsInsertedNotMergeTest()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(3, 0));
            blueEditor.InsertWall(new Point(3, 0), new Point(7, 0));
            int expectedResult = 2;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void InsertOpeningsTest()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(3, 0));
            blueEditor.InsertOpening(new Door(new Point(1, 0)));
            blueEditor.InsertOpening(new Door(new Point(2, 0)));
            int expectedResult = 2;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void OpeningOnIntersectionRemovalTest()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(3, 0));
            blueEditor.InsertOpening(new Door(new Point(1, 0)));
            blueEditor.InsertOpening(new Door(new Point(2, 0)));
            blueEditor.InsertWall(new Point(2, 0), new Point(2, 2));
            int expectedResult = 1;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        //Tests for removal of walls
        [TestMethod]
        public void RemoveSingleWallCountTest()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(5, 0));
            blueEditor.RemoveWall(new Point(0, 0), new Point(5, 0));
            Assert.IsTrue(materials.IsWallsEmpty());
        }

        [TestMethod]
        public void RemoveSingleWallBeamsCountTest()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(5, 0));
            blueEditor.RemoveWall(new Point(0, 0), new Point(5, 0));
            Assert.IsTrue(materials.IsBeamsEmpty());
        }

        [TestMethod]
        public void RemoveFromTShapeWallLeavingLShapeTest()
        {
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(8, 2), new Point(8, 7));
            blueEditor.RemoveWall(new Point(8, 5), new Point(8, 7));
            int expectedResult = 2;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveFromTShapeWallMergeTest()
        {
            blueEditor.InsertWall(new Point(5, 5), new Point(8, 5));
            blueEditor.InsertWall(new Point(8, 3), new Point(8, 7));
            blueEditor.RemoveWall(new Point(5, 5), new Point(8, 5));
            int expectedResult = 1;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveWallWithOpening()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(3, 0));
            Opening testOpening = new Door(new Point(2, 0));
            blueEditor.InsertOpening(testOpening);
            testOpening = new Door(new Point(1, 0));
            blueEditor.InsertOpening(testOpening);
            blueEditor.RemoveWall(new Point(0, 0), new Point(3, 0));
            int actualResult = materials.OpeningsCount();
            int expectedResult = 0;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void MultipleDeletionsTest()
        {
            blueEditor.InsertWall(new Point(2, 1), new Point(2, 4));
            blueEditor.InsertWall(new Point(1, 2), new Point(3, 2));
            blueEditor.InsertWall(new Point(1, 3), new Point(3, 3));

            blueEditor.RemoveWall(new Point(1, 2), new Point(2, 2));
            blueEditor.RemoveWall(new Point(2, 2), new Point(3, 2));

            blueEditor.RemoveWall(new Point(1, 3), new Point(2, 3));
            blueEditor.RemoveWall(new Point(2, 3), new Point(3, 3));

            int expectedResult = 1;
            int actualResult = materials.WallsCount();

            Assert.AreEqual(expectedResult, actualResult);
        }

        //tests for insertion of openings
        [TestMethod]
        [ExpectedException(typeof(OutOfRangeComponentException))]
        public void InsertOpeningOutOfRangeTest()
        {
            Opening testOpening = new Door(new Point(50, -3));
            blueEditor.InsertOpening(testOpening);
        }

        [TestMethod]
        public void InsertOpeningCorrectly()
        {
            blueEditor.InsertWall(new Point(0, 0), new Point(3, 0));
            Opening testOpening = new Door(new Point(2, 0));
            blueEditor.InsertOpening(testOpening);
            int expectedResult = 1;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ComponentOutOfWallException))]
        public void InsertOpeningInNoWall()
        {
            Opening testOpening = new Door(new Point(2, 0));
            blueEditor.InsertOpening(testOpening);
        }

        [TestMethod]
        public void MultipleInsertionsTest()
        {
            blueEditor.InsertWall(new Point(2, 3), new Point(2, 1));
            blueEditor.InsertWall(new Point(8, 1), new Point(8, 3));
            blueEditor.InsertWall(new Point(10, 1), new Point(10, 3));
            blueEditor.InsertWall(new Point(1, 2), new Point(11, 2));
            int expectedResult = 11;
            int actualResult = materials.WallsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveOpeningTest()
        {
            blueEditor.InsertWall(new Point(2, 3), new Point(2, 1));
            blueEditor.InsertOpening(new Door(new Point(2, 2)));
            blueEditor.RemoveOpening(new Door(new Point(2, 2)));
            int expectedResult = 0;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveUnexistentOpening()
        {
            blueEditor.InsertWall(new Point(2, 3), new Point(2, 1));
            blueEditor.RemoveOpening(new Door(new Point(2, 2)));
            int expectedResult = 0;
            int actualResult = materials.OpeningsCount();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IsSignedFalseTest()
        {
            Assert.IsFalse(blueEditor.IsSigned());
        }

        [TestMethod]
        public void IsSignedTrueTest()
        {
            blueEditor.Sign(architect);
            Assert.IsTrue(blueEditor.IsSigned());
        }

        [TestMethod]
        public void GetSignaturesTest()
        {
            blueEditor.Sign(architectA);
            blueEditor.Sign(architectB);
            blueEditor.Sign(architectA);
            ICollection<Signature> signatures = blueEditor.GetSignatures();

            Assert.AreEqual(signatures.Count, 3);
        }

        [TestMethod]
        public void GetLastSignatureTest()
        {
            blueEditor.Sign(architectA);
            blueEditor.Sign(architectB);
            blueEditor.Sign(architectA);
            Signature lastSignature = blueEditor.GetSignatures().Last();

            Assert.AreEqual(lastSignature.User, architectA);
        }

        [TestMethod]
        public void InsertColumnTest()
        {
            ISinglePointComponent column = new Column(new Point(2, 2));
            blueEditor.InsertColumn(column.GetPosition());
            Assert.AreEqual(1, blueEditor.GetColumns().Count);
        }
    }
}
