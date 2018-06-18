using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;
using DataAccess;
using System.Collections.Generic;
using RepositoryInterface;

namespace DataAccessTest
{
    [TestClass]
    public class BluePrintPortfolioTest
    {

        private IBlueprint blueprint1;
        private IBlueprint blueprint2;
        private IBlueprint blueprint3;
        private BlueprintRepository portfolio;


        [TestInitialize]
        public void TestInitialize()
        {
            portfolio = new BlueprintRepository();
            portfolio.Clear();
            Client user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            blueprint1 = new Blueprint(12, 12, "Blueprint1");
            blueprint2 = new Blueprint(12, 12, "Blueprint2");
            blueprint3 = new Blueprint(12, 12, "Blueprint3");

            blueprint1.Owner = user1;
            blueprint2.Owner = user1;
            blueprint3.Owner = user1;
        }

        [TestMethod]
        public void EmptyPorfolioTest()
        {
            portfolio.Clear();
            Assert.IsTrue(portfolio.IsEmpty());
        }

        [TestMethod]
        public void AddBlueprintTest()
        {
            portfolio.Add(blueprint1);
            Assert.IsFalse(portfolio.IsEmpty());
        }

        [TestMethod]
        public void AddedBlueprintTest()
        {
            portfolio.Add(blueprint1);
            Assert.IsTrue(portfolio.Exists(blueprint1));
        }

        [TestMethod]
        public void GetBlueprintTest()
        {
            portfolio.Add(blueprint1);
            IEnumerator<IBlueprint> blueprints = portfolio.GetAll().GetEnumerator();
            blueprints.MoveNext();
            Assert.IsNotNull(blueprints.Current);
        }

        [TestMethod]
        public void RemoveExistentBlueprintTest()
        {
            portfolio.Add(blueprint1);
            portfolio.Add(blueprint2);
            portfolio.Delete(blueprint1);
            Assert.IsFalse(portfolio.Exists(blueprint1));
        }

        [TestMethod]
        public void RemoveNonExistentBlueprintTest()
        {
            portfolio.Add(blueprint2);
            portfolio.Delete(blueprint1);
            Assert.IsFalse(portfolio.IsEmpty());
        }

        [TestMethod]
        public void GetEnumeratorBlueprintTest()
        {
            portfolio.Add(blueprint1);
            IBlueprint blueprintGot = ((IRepository<IBlueprint>)portfolio).Get(blueprint1);
            Assert.AreEqual(blueprintGot, blueprint1);
        }

        [TestMethod]
        public void GetEnumeratorBlueprintOwnedByUserTest()
        {
            User owner = new Client("Carl", "Ownerhood", "owner", "owner", "12345", "addd", "1234455", DateTime.Now);
            blueprint1.Owner = owner;
            portfolio.Add(blueprint1);
            IEnumerator<IBlueprint> blueprints = portfolio.GetBlueprintsOfUser(owner).GetEnumerator();
            blueprints.MoveNext();
            Assert.AreEqual(blueprints.Current, blueprint1);
        }

        [TestMethod]
        public void GetBlueprintsCopyTest()
        {
            portfolio.Add(blueprint1);
            portfolio.Add(blueprint2);
            ICollection<IBlueprint> copy = portfolio.GetAll();
            copy.Remove(blueprint1);
            Assert.IsTrue(portfolio.Exists(blueprint1));
        }

        [TestMethod]
        public void DeleteUsersBlueprintsTest()
        {
            portfolio.Add(blueprint1);
            portfolio.Add(blueprint2);
            portfolio.Add(blueprint3);
            Client user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            portfolio.DeleteUserBlueprints(user1);
            int expectedResult = 0;
            int actualResult = portfolio.GetAll().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void WallsPersistenceCountTest()
        {
            blueprint1.InsertWall(new Point(2, 2), new Point(3, 2));
            blueprint1.InsertWall(new Point(2, 2), new Point(2, 4));
            portfolio.Add(blueprint1);
            IBlueprint retrieved = portfolio.Get(blueprint1.GetId());
            int expectedResult = 2;
            int actualResult = retrieved.GetWalls().Count;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void OpeningsPersistenceCountTest() {
            Template gate = new Template("Gate", 2, 0, 2, ComponentType.DOOR);
            Opening gateOp = new Door(new Point(1, 1), gate);
            Opening otherGateOp = new Door(new Point(2, 2), gate);

            blueprint1.InsertWall(new Point(0, 2), new Point(4, 2));
            blueprint1.InsertWall(new Point(0, 1), new Point(4, 1));
            blueprint1.InsertOpening(gateOp);
            blueprint1.InsertOpening(otherGateOp);
            portfolio.Add(blueprint1);
            IBlueprint retrieved = portfolio.Get(blueprint1.GetId());
            int expectedResult = 2;
            int actualResult = retrieved.GetWalls().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ColumnsPersistenceCountTest() {
            blueprint1.InsertColumn(new Point(2, 3));
            blueprint1.InsertColumn(new Point(1, 2));
            portfolio.Add(blueprint1);
            IBlueprint retrieved = portfolio.Get(blueprint1.GetId());
            int expectedResult = 2;
            int actualResult = retrieved.GetColumns().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }


        public void BuildTestBlueprint() {
            Template gate = new Template("Gate", 2, 0, 2, ComponentType.DOOR);
            Opening gateOp = new Door(new Point(1, 1), gate);
            Opening otherGateOp = new Door(new Point(2, 2), gate);

            blueprint1.InsertColumn(new Point(2, 3));
            //blueprint1.InsertColumn(new Point(1, 2));

            blueprint1.InsertWall(new Point(0, 2), new Point(4, 2));
            blueprint1.InsertWall(new Point(0, 1), new Point(4, 1));

            blueprint1.InsertOpening(gateOp);
            blueprint1.InsertOpening(otherGateOp);

        }

        [TestMethod]
        public void ModifyDeletionTest() {
            BuildTestBlueprint();

            portfolio.Add(blueprint1);

            blueprint1.RemoveColumn(new Point(2, 3));
            portfolio.Modify(blueprint1);

            blueprint1 = portfolio.Get(blueprint1.GetId());

            int expectedResult = 0;
            int actualResult = blueprint1.GetColumns().Count;
            Assert.AreEqual(expectedResult, actualResult);

        }
        [TestMethod]
        public void ModifyAdditionTest() {
            BuildTestBlueprint();
            portfolio.Add(blueprint1);
            blueprint1.RemoveWall(new Point(0, 2), new Point(4, 2));
            blueprint1.InsertColumn(new Point(3, 3));
            portfolio.Modify(blueprint1);
            blueprint1 = portfolio.Get(blueprint1.GetId());
            bool wallsOk = blueprint1.GetWalls().Count == 1;
            bool openingsOk = blueprint1.GetOpenings().Count == 1;
            bool columnsOk = blueprint1.GetColumns().Count == 2;
            Assert.IsTrue(wallsOk && openingsOk && columnsOk);
        }

    }
}
