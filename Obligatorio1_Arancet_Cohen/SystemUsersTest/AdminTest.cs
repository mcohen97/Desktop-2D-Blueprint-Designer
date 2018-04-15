using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1ArancetCohen;

namespace AdminTest
{
    [TestClass]
    public class AdminTest
    {
        [TestMethod]
        public void AdminConstructorWithParameters()
        {
            string name = "Joe";
            string surname = "Jaguar";
            string userName = "jjadmin";
            string password = "iamthejaguar";
            DateTime registrationDate = DateTime.Now;

            Admin admin = new Admin(name, surname, userName, password, registrationDate);

        }

        [TestMethod]
        public void getNameTest()
        {
            string name = "Joe";
            string surname = "Jaguar";
            string userName = "jjadmin";
            string password = "iamthejaguar";
            DateTime registrationDate = DateTime.Now;

            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(name, admin.Name);
        }

        [TestMethod]
        public void getSurnameTest()
        {
            string name = "Joe";
            string surname = "Jaguar";
            string userName = "jjadmin";
            string password = "iamthejaguar";
            DateTime registrationDate = DateTime.Now;

            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(surname, admin.Surname);
        }

        [TestMethod]
        public void getUserNameTest()
        {
            string name = "Joe";
            string surname = "Jaguar";
            string userName = "jjadmin";
            string password = "iamthejaguar";
            DateTime registrationDate = DateTime.Now;

            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(userName, admin.UserName);
        }

        [TestMethod]
        public void getPasswordTest()
        {
            string name = "Joe";
            string surname = "Jaguar";
            string userName = "jjadmin";
            string password = "iamthejaguar";
            DateTime registrationDate = DateTime.Now;

            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(password, admin.Password);
        }

        [TestMethod]
        public void getRegistrationDateTest()
        {
            string name = "Joe";
            string surname = "Jaguar";
            string userName = "jjadmin";
            string password = "iamthejaguar";
            DateTime registrationDate = DateTime.Now;

            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(registrationDate, admin.RegistrationDate);
        }

        [TestMethod]
        public void updateLastLoginDate()
        {
            string name = "Joe";
            string surname = "Jaguar";
            string userName = "jjadmin";
            string password = "iamthejaguar";
            DateTime registrationDate = DateTime.Now;

            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            DateTime dateAssigned = admin.updateLastLoginDate();

            Assert.AreEqual(dateAssigned, admin.LastLoginDate);
        }

        [TestMethod]
        public void enableClient()
        {
            string nameAdmin = "Joe";
            string surnameAdmin = "Jaguar";
            string userNameAdmin = "jjadmin";
            string passwordAdmin = "iamthejaguar";
            DateTime registrationDateAdmin = DateTime.Now;
            Admin admin = new Admin(nameAdmin, surnameAdmin, userNameAdmin, passwordAdmin, registrationDateAdmin);

            string nameClient = "Paul";
            string surnameClient = "Richards";
            string userNameClient = "paulrichards";
            string passwordClient = "paulrichards1";
            string phoneClient = "099888777";
            string idClient = "54443332";
            DateTime registrationDateClient = DateTime.Now;
            Client client = new Client(nameClient, surnameClient, userNameClient, passwordClient, phoneClient, idClient, registrationDateClient);

            admin.enableClient(client);

            Assert.IsTrue(admin.isClientEnabled(client));
        }

        [TestMethod]
        public void assignPasswordToClientTest()
        {
            string nameAdmin = "Joe";
            string surnameAdmin = "Jaguar";
            string userNameAdmin = "jjadmin";
            string passwordAdmin = "iamthejaguar";
            DateTime registrationDateAdmin = DateTime.Now;
            Admin admin = new Admin(nameAdmin, surnameAdmin, userNameAdmin, passwordAdmin, registrationDateAdmin);

            string nameClient = "Paul";
            string surnameClient = "Richards";
            string userNameClient = "paulrichards";
            string passwordClient = "paulrichards1";
            string phoneClient = "099888777";
            string idClient = "54443332";
            DateTime registrationDateClient = DateTime.Now;
            Client client = new Client(nameClient, surnameClient, userNameClient, passwordClient, phoneClient, idClient, registrationDateClient);

            string passwordAssignedByAdmin = "thisIsYourNewPass";
            admin.assignPasswordToClient(client, passwordAssignedByAdmin);
            
            Assert.AreEqual(client.Password, passwordAssignedByAdmin);
        }
    }
}
