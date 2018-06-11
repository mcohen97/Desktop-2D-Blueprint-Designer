using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Exceptions;
using Logic.Domain;
using System.Collections.Generic;
using System.Linq;
using Services;
using DataAccess;
using DomainRepositoryInterface;
using RepositoryInterface;



namespace ServicesTest
{
    [TestClass]
    public class BlueprintControllerTest
    {
        private IRepository<User> repository;

        private IBlueprint blueprint1;
        private IBlueprint blueprint2;
        private IBlueprint blueprint3;

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
            repository.Clear();
            blueprintPortfolio = BlueprintPortfolio.Instance;


            conn = new SessionConnector();
            Session session = conn.LogIn("admin", "admin");
            administrator = new UserAdministrator(session);

            user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            user2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            user3 = new Designer("designer1N", "designer1S", "designer1UN", "designer1P", DateTime.Now);
            user4 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);
            architect = new Architect("Archi", "Tect", "architect", "architect", DateTime.Now);

            blueprint1 = new Blueprint(12, 12, "Blueprint1");
            blueprint2 = new Blueprint(10, 10, "Blueprint2");
            blueprint3 = new Blueprint(11, 11, "Blueprint2");

            blueprint1.Owner = user1;
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
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Add(blueprint1);
            controller.Add(blueprint2);
            controller.Add(blueprint3);
        }

        [TestMethod]
        public void NewBlueprintControllerTest()
        {
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void AddBlueprintTest()
        {
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Add(blueprint1);
            Assert.IsTrue(controller.Exist(blueprint1));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void AddBlueprintNoPermissionsTest()
        {
            Session session = conn.LogIn("client1UN", "client1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Add(blueprint3);
        }

        [TestMethod]
        public void GetBlueprintAsDesignerTest()
        {
            initializerWithData();
            Session session = conn.LogIn("client1UN", "client1P");
            BlueprintController controller = new BlueprintController(session);
            ICollection<IBlueprint> blueprints = controller.GetBlueprints(user1);
            int expectedResult = 2;
            int actualResult = blueprints.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeleteBlueprintAsDesignerTest()
        {

            initializerWithData();
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Remove(blueprint1);
            Assert.IsFalse(controller.Exist(blueprint1));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void DeleteBlueprintNoPermissionTest()
        {
            initializerWithData();
            Session session = conn.LogIn("client1UN", "client1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Remove(blueprint1);
        }

        [TestMethod]
        public void SignBlueprintTest()
        {
            initializerWithData();
            Session session = conn.LogIn("architect", "architect");
            BlueprintController controller = new BlueprintController(session);
            IBlueprint aBlueprint = controller.GetBlueprints().First();
            controller.Sign(aBlueprint);
            Assert.IsTrue(aBlueprint.IsSigned());
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void SignBlueprintNoPermissionTest()
        {
            initializerWithData();
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            IBlueprint aBlueprint = controller.GetBlueprints().First();
            controller.Sign(aBlueprint);
        }

    }
}
