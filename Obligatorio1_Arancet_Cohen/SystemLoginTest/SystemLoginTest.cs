using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1_Arancet_Cohen;
using Logic;

namespace LoginTest
{
    [TestClass]
    public class SystemLoginTest
    {
        public User defaultAdmin;
        public User client1;
        public User client2;
        public User client3;
        public User designer1;
        public User designer2;
        public User designer3;

        [TestInitialize]
        public void TestInitialize()
        {
            defaultAdmin = new Admin("admin", "admin", "admin", "defaultAdmin1234", DateTime.Now);
            client1 = new Client("client1N", "client1S", "client1UN", "client1P", "999000111", "dir", "55555555", DateTime.Now);
            client2 = new Client("client2N", "client2S", "client2UN", "client2P", "999000111", "dir", "55555556", DateTime.Now);
            client3 = new Client("client3N", "client3S", "client3UN", "client3P", "999000111", "dir", "55555557", DateTime.Now);
            designer1 = new Designer("designer1N", "designer1S", "designer1UN", "designer1P", DateTime.Now);
            designer2 = new Designer("designer2N", "designer2S", "designer2UN", "designer2P", DateTime.Now);
            designer3 = new Designer("designer3N", "designer3S", "designer3UN", "designer3P", DateTime.Now);
        }

        [TestMethod]
        public void loggedUserTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);

            Assert.IsFalse(system.IsUserLogged());
        }

        [TestMethod]
        public void LoginTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);

            system.Login(defaultAdmin.UserName, defaultAdmin.Password);

            Assert.IsTrue(system.IsUserLogged());
        }

        [TestMethod]
        public void LogOutTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);

            system.Login(defaultAdmin.UserName, defaultAdmin.Password);
            system.Logout();

            Assert.IsFalse(system.IsUserLogged());
        }

        [TestMethod]
        public void registUserClientTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);

            system.Login(defaultAdmin.UserName, defaultAdmin.Password);
            system.Regist(client1);

            Assert.IsTrue(system.IsUserRegistered(client1));
        }

        [TestMethod]
        public void registUserDesignerTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);

            system.Login(defaultAdmin.UserName, defaultAdmin.Password);
            system.Regist(designer1);
            system.Regist(designer2);

            Assert.IsTrue(system.IsUserRegistered(designer1));
        }

        [TestMethod]
        public void userNotRegisteredTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            Assert.IsFalse(system.IsUserRegistered(client2));
        }

        [TestMethod]
        public void registUserNotLoggedInTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            system.Regist(client1);
            Assert.IsFalse(system.IsUserRegistered(client1));
        }

        [TestMethod]
        public void deleteUserTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            system.Login(defaultAdmin.Name, defaultAdmin.Password);
            system.Regist(client1);
            system.Regist(client2);
            system.Regist(client3);
            system.RemoveUser(client2);

            Assert.IsFalse(system.IsUserRegistered(client2));
        }

        [TestMethod]
        public void deleteDefaultAdminTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            system.Login(defaultAdmin.Name, defaultAdmin.Password);
            system.Regist(client1);
            system.Regist(client2);
            system.Regist(client3);
            system.RemoveUser(defaultAdmin);

            Assert.IsTrue(system.IsUserRegistered(defaultAdmin));
        }

        [TestMethod]
        public void getClientInfoTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            system.Login(defaultAdmin.UserName, defaultAdmin.Password);
            system.Regist(client1);
            system.Regist(client2);
            system.Regist(client3);

            Client clientInfo = system.GetClientInfo(client1);

            Assert.AreEqual(client1, clientInfo);
        }

        [TestMethod]
        public void getDesignerInfoTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            system.Login(defaultAdmin.UserName, defaultAdmin.Password);
            system.Regist(designer1);
            system.Regist(client2);
            system.Regist(designer3);

            Designer designerInfo = system.GetDesignerInfo(designer3);

            Assert.AreEqual(designer3, designerInfo);
        }

        [TestMethod]
        public void getAdminInfoTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            system.Login(defaultAdmin.UserName, defaultAdmin.Password);
            system.Regist(designer1);
            system.Regist(client2);
            system.Regist(designer3);

            Admin adminInfo = system.GetAdminInfo(defaultAdmin);

            Assert.AreEqual(defaultAdmin, adminInfo);
        }

        [TestMethod]
        public void getLoggedUserInfoTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            system.Login(defaultAdmin.UserName, defaultAdmin.Password);
            system.Regist(designer1);
            system.Regist(client2);
            system.Regist(designer3);
            system.Logout();
            system.Login(designer1.UserName, designer1.Password);

            User loggedUser = system.GetLoggedUserInfo();

            Assert.AreEqual(designer1, loggedUser);
        }

        [TestMethod]
        public void getLoggedUserInfoWithoutUserLoggedTest()
        {
            UserAdministrator system = new UserAdministrator(defaultAdmin);
            system.Login(defaultAdmin.UserName, defaultAdmin.Password);
            system.Regist(designer1);
            system.Regist(client2);
            system.Regist(designer3);
            system.Logout();

            User loggedUser = system.GetLoggedUserInfo();

            Assert.IsNull(loggedUser);
        }
    }
}
