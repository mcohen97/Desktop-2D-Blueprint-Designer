using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;
using System.Collections.Generic;

namespace Logic.Test
{
    [TestClass]
    public class BluePrintPortfolioTest
    {

        private IBlueprint blueprint1;
        private IBlueprint blueprint2;
        private IBlueprint blueprint3;
        private BlueprintPortfolio portfolio;


        [TestInitialize]
        public void TestInitialize()
        {
            portfolio = BlueprintPortfolio.Instance;
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
            IEnumerator<IBlueprint> blueprints = portfolio.GetBlueprintsCopy().GetEnumerator();
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
            bool deletionExecuted = portfolio.Delete(blueprint1);
            Assert.IsFalse(deletionExecuted);
        }

        [TestMethod]
        public void GetEnumeratorBlueprintTest()
        {
            portfolio.Add(blueprint1);
            IBlueprint blueprintGot = portfolio.Get(blueprint1);
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
            ICollection<IBlueprint> copy = portfolio.GetBlueprintsCopy();
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
            int actualResult = portfolio.GetBlueprintsCopy().Count;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
