﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1_Arancet_Cohen;

namespace AdminTest
{
    [TestClass]
    public class AdminTest
    {
        public string name;
        public string surname;
        public string userName;
        public string password;
        public DateTime registrationDate;
        public Client client;

        [TestInitialize]
        public void TestInitialize()
        {
            name = "Joe";
            surname = "Jaguar";
            userName = "jjadmin";
            password = "iamthejaguar";
            registrationDate = DateTime.Now;

            string nameClient = "Paul";
            string surnameClient = "Richards";
            string userNameClient = "paulrichards";
            string passwordClient = "paulrichards1";
            string phoneClient = "099888777";
            string addressClient = "MyAddress 2233";
            string idClient = "54443332";
            DateTime registrationDateClient = DateTime.Now;
            client = new Client(nameClient, surnameClient, userNameClient, passwordClient, phoneClient, addressClient, idClient, registrationDateClient);
        }

        [TestMethod]
        public void constructorWithParameters()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.IsNotNull(admin);
        }

        [TestMethod]
        public void getNameTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(name, admin.Name);
        }

        [TestMethod]
        public void setNameTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            string newName = "Angelo";
            admin.Name = newName;

            Assert.AreEqual(newName, admin.Name);
        }

        [TestMethod]
        public void getSurnameTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(surname, admin.Surname);
        }

        [TestMethod]
        public void setSurnameTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            string newSurname = "Panter";
            admin.Surname = newSurname;

            Assert.AreEqual(newSurname, admin.Surname);
        }

        [TestMethod]
        public void getUserNameTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(userName, admin.UserName);
        }

        [TestMethod]
        public void setUserNameTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            string newUserName = "jaguarmin";
            admin.UserName = newUserName;

            Assert.AreEqual(newUserName, admin.UserName);
        }

        [TestMethod]
        public void getPasswordTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(password, admin.Password);
        }

        [TestMethod]
        public void setPasswordTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            string newPassword = "iamthegreatjaguar";
            admin.Password = newPassword;

            Assert.AreEqual(newPassword, admin.Password);
        }

        [TestMethod]
        public void getRegistrationDateTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            Assert.AreEqual(registrationDate, admin.RegistrationDate);
        }

        [TestMethod]
        public void setRegistrationDateTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            DateTime newRegistrationDate = DateTime.MinValue;
            admin.RegistrationDate = newRegistrationDate;

            Assert.AreEqual(newRegistrationDate, admin.RegistrationDate);
        }

        [TestMethod]
        public void updateLastLoginDate()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            DateTime dateAssigned = admin.updateLastLoginDate();

            Assert.AreEqual(dateAssigned, admin.LastLoginDate);
        }

        [TestMethod]
        public void enableClient()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            admin.registClient(client);

            Assert.IsTrue(admin.isClientRegistered(client));
        }

        [TestMethod]
        public void assignPasswordToClientTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            string passwordAssignedByAdmin = "thisIsYourNewPass";
            admin.assignPasswordToClient(client, passwordAssignedByAdmin);
            
            Assert.AreEqual(client.Password, passwordAssignedByAdmin);
        }

        [TestMethod]
        public void updateClientInfoTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);

            string passwordAssignedByAdmin = "thisIsYourNewPass";
            admin.assignPasswordToClient(client, passwordAssignedByAdmin);

            Assert.AreEqual(client.Password, passwordAssignedByAdmin);
        }

        [TestMethod]
        public void canCreateUsersTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);
            bool canCreateUsers = admin.hasPermission(Permission.CREATE_USER);

            Assert.IsTrue(canCreateUsers);
        }

        [TestMethod]
        public void canEditUsersTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);
            bool canEditUsers = admin.hasPermission(Permission.EDIT_USER);

            Assert.IsTrue(canEditUsers);
        }

        [TestMethod]
        public void canDeleteUsersTest()
        {
            Admin admin = new Admin(name, surname, userName, password, registrationDate);
            bool canDeleteUsers = admin.hasPermission(Permission.REMOVE_USER);

            Assert.IsTrue(canDeleteUsers);
        }

        [TestMethod]
        public void compareEqualTest()
        {
            Admin admin1 = new Admin(name, surname, userName, password, registrationDate);
            Admin admin2 = new Admin(name, surname, userName, password, registrationDate);
            Assert.AreEqual(admin1, admin2);
        }

        [TestMethod]
        public void compareNotEqualTest()
        {
            Admin admin1 = new Admin(name, surname, userName, password, registrationDate);
            Admin admin2 = new Admin(name, surname, "adminUsername", password, registrationDate);
            Assert.AreNotEqual(admin1, admin2);
        }
    }
}
