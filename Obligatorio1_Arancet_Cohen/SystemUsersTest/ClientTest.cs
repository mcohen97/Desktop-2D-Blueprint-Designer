using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1_Arancet_Cohen;

namespace ClientTest
{
    [TestClass]
    public class ClientTest
    {
        public string name;
        public string surname;
        public string userName;
        public string password;
        public string phone;
        public string id;
        public DateTime registrationDate;

        [TestInitialize]
        public void TestInitialize()
        {
            name = "Paul";
            surname = "Richards";
            userName = "paulrichards";
            password = "paulrichards1";
            phone = "099888777";
            id = "54443332";
            registrationDate = DateTime.Now;
        }

        [TestMethod]
        public void constructorWithParametersTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void getNameTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(name, client.Name);
        }

        [TestMethod]
        public void setNameTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newName = "Jhon";
            client.Name = newName;

            Assert.AreEqual(newName, client.Name);
        }

        [TestMethod]
        public void getSurnameTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(surname, client.Surname);
        }

        [TestMethod]
        public void setSurnameTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newSurname = "Wildfield";
            client.Surname = newSurname;

            Assert.AreEqual(newSurname, client.Surname);
        }

        [TestMethod]
        public void getUserNameTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(userName, client.UserName);
        }

        [TestMethod]
        public void setUserNameTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newUserName = "richardspaul";
            client.UserName = newUserName;

            Assert.AreEqual(newUserName, client.UserName);
        }

        [TestMethod]
        public void getPasswordTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(password, client.Password);
        }

        [TestMethod]
        public void setPasswordTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newPassword = "paulDbeast";
            client.Password = newPassword;

            Assert.AreEqual(newPassword, client.Password);
        }

        [TestMethod]
        public void getPhoneTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(phone, client.Phone);
        }

        [TestMethod]
        public void setPhoneTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newPhoneNumber = "099777888";
            client.Phone = newPhoneNumber;

            Assert.AreEqual(newPhoneNumber, client.Phone);
        }

        [TestMethod]
        public void getIdTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(id, client.Id);
        }

        [TestMethod]
        public void setIdTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newId = "12223334";
            client.Id = newId;

            Assert.AreEqual(newId, client.Id);
        }

        [TestMethod]
        public void getRegistrationDateTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(registrationDate, client.RegistrationDate);
        }

        [TestMethod]
        public void setRegistrationDateTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            DateTime newRegistrationDate = DateTime.MinValue;
            client.RegistrationDate = newRegistrationDate;

            Assert.AreEqual(newRegistrationDate, client.RegistrationDate);
        }

        [TestMethod]
        public void updateLastLoginDate()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            DateTime dateAssigned = client.updateLastLoginDate();

            Assert.AreEqual(dateAssigned, client.LastLoginDate);
        }

        [TestMethod]
        public void canReadBlueprintTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            bool canReadBlueprint = client.hasPermission(Permission.READ_BLUEPRINT);

            Assert.IsTrue(canReadBlueprint);
        }

        [TestMethod]
        public void canEditBlueprintTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            bool canEditBlueprint = client.hasPermission(Permission.EDIT_BLUEPRINT);

            Assert.IsFalse(canEditBlueprint);
        }

        [TestMethod]
        public void canDeleteBlueprintTest()
        {
            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            bool canDeleteBlueprint = client.hasPermission(Permission.DELETE_BLUEPRINT);

            Assert.IsFalse(canDeleteBlueprint);
        }

    }

    
}
