using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace SystemUsersTest {
    [TestClass]
    public class BluePrintPortfolioTest {

        private IBlueprint blueprint1;
        private IBlueprint blueprint2;
        private IBlueprint blueprint3;
        private BlueprintPortfolio portfolio;


        [TestInitialize]
        public void TestInitialize() {
            portfolio = BlueprintPortfolio.Instance;
            portfolio.Empty();

            blueprint1 = new Blueprint(12, 12, "Blueprint1");
            blueprint2 = new Blueprint(12, 12, "Blueprint2");
            blueprint3 = new Blueprint(12, 12, "Blueprint3");
        }

        [TestMethod]
        public void EmptyPorfolioTest() {
            portfolio.Empty();
            Assert.IsTrue(portfolio.IsEmpty());
        }

        [TestMethod]
        public void AddBlueprintTest() {
            portfolio.Add(blueprint1);
            Assert.IsFalse(portfolio.IsEmpty());
        }

        [TestMethod]
        public void AddedBlueprintTest() {
            portfolio.Add(blueprint1);
            Assert.IsTrue(portfolio.Exist(blueprint1));
        }

        [TestMethod]
        public void GetBlueprintTest() {
            portfolio.Add(blueprint1);
            IEnumerator<IBlueprint> blueprints = portfolio.GetBlueprintsCopy().GetEnumerator();
            blueprints.MoveNext();
            Assert.IsNotNull(blueprints.Current);
        }

        [TestMethod]
        public void RemoveExistentBlueprintTest() {
            portfolio.Add(blueprint1);
            portfolio.Add(blueprint2);
            portfolio.Remove(blueprint1);
            Assert.IsFalse(portfolio.Exist(blueprint1));
        }

        [TestMethod]
        public void RemoveNonExistentBlueprintTest() {
            portfolio.Add(blueprint2);
            bool deletionExecuted = portfolio.Remove(blueprint1);
            Assert.IsFalse(deletionExecuted);
        }

        [TestMethod]
        public void GetEnumeratorBlueprintTest() {
            portfolio.Add(blueprint1);
            IBlueprint blueprintGot = portfolio.GetBlueprint(blueprint1);
            Assert.AreEqual(blueprintGot, blueprint1);
        }

        [TestMethod]
        public void GetEnumeratorBlueprintOwnedByUserTest() {
            User owner = new Client("Carl", "Ownerhood", "owner", "owner", "12345", "addd", "1234455", DateTime.Now);
            blueprint1.Owner = owner;
            portfolio.Add(blueprint1);
            IEnumerator<IBlueprint> blueprints = portfolio.GetBlueprintsOfUser(owner).GetEnumerator();
            blueprints.MoveNext();
            Assert.AreEqual(blueprints.Current, blueprint1);
        }

        [TestMethod]
        public void GetBlueprintsCopyTest() {
            portfolio.Add(blueprint1);
            portfolio.Add(blueprint2);
            ICollection<IBlueprint> copy = portfolio.GetBlueprintsCopy();
            copy.Remove(blueprint1);
            Assert.IsTrue(portfolio.Exist(blueprint1));
        }


        [TestMethod]
        public void GetOriginalNotSameTest() {
            portfolio.Add(blueprint1);
            IBlueprint fake = (IBlueprint)blueprint1.Clone();
            IBlueprint original = portfolio.GetOriginal(fake);
            Assert.AreNotSame(original, fake);
        }

        [TestMethod]
        public void GetOriginalEqualsTest() {
            portfolio.Add(blueprint2);
            IBlueprint fake = (IBlueprint)blueprint2.Clone();
            IBlueprint original = portfolio.GetOriginal(fake);
            Assert.AreEqual(original, fake);
        }
    }
}
