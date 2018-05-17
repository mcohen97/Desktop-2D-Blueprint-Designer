﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exceptions;
using Domain;
using System.Collections.Generic;

namespace Logic.Test {
    [TestClass]
    public class BlueprintControllerTest {

        private IBlueprint blueprint1;
        private IBlueprint blueprint2;
        private IBlueprint blueprint3;

        private User user1;
        private User user2;
        private User user3;
        private User user4;

        private SessionConnector conn;
        private UserAdministrator administrator;
        private BlueprintPortfolio blueprintPortfolio;

        [TestInitialize]
        public void TestInitialize() {
            UsersPortfolio.Instance.Empty();
            blueprintPortfolio = BlueprintPortfolio.Instance;
            
            
            conn = new SessionConnector();
            Session session = conn.LogIn("admin", "admin");
            administrator = new UserAdministrator(session);
            
            user1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            user2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            user3 = new Designer("designer1N", "designer1S", "designer1UN", "designer1P", DateTime.Now);
            user4 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);

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
        }

        [TestCleanup]
        public void CleanUp() {
            blueprintPortfolio.Empty();
            UsersPortfolio.Instance.Empty();
        }

        private void initializerWithData() {
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Add(blueprint1);
            controller.Add(blueprint2);
            controller.Add(blueprint3);
        }

        [TestMethod]
        public void NewBlueprintControllerTest() {
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void AddBlueprintTest() {
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Add(blueprint1);
            Assert.IsTrue(controller.Exist(blueprint1));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void AddBlueprintNoPermissionsTest() {
            Session session = conn.LogIn("client1UN", "client1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Add(blueprint3);
        }

        [TestMethod]
        public void GetBlueprintAsDesignerTest() {
            initializerWithData();
            Session session = conn.LogIn("client1UN", "client1P");
            BlueprintController controller = new BlueprintController(session);
            ICollection<IBlueprint> blueprints = controller.GetBlueprints(user1);
            int expectedResult = 2;
            int actualResult = blueprints.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DeleteBlueprintAsDesignerTest() {

            initializerWithData();
            Session session = conn.LogIn("designer1UN", "designer1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Remove(blueprint1);
            Assert.IsFalse(controller.Exist(blueprint1));
        }

        [TestMethod]
        [ExpectedException(typeof(NoPermissionsException))]
        public void DeleteBlueprintNoPermissionTest() {
            initializerWithData();
            Session session = conn.LogIn("client1UN", "client1P");
            BlueprintController controller = new BlueprintController(session);
            controller.Remove(blueprint1);
        }

    }
}