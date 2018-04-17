using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1_Arancet_Cohen;

namespace ClientTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void constructorWithParametersTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.IsNotNull(client);
        }

        [TestMethod]
        public void getNameTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(name, client.Name);
        }

        [TestMethod]
        public void setNameTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newName = "Jhon";
            client.Name = newName;

            Assert.AreEqual(newName, client.Name);
        }

        [TestMethod]
        public void getSurnameTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(surname, client.Surname);
        }

        [TestMethod]
        public void setSurnameTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newSurname = "Wildfield";
            client.Surname = newSurname;

            Assert.AreEqual(newSurname, client.Surname);
        }

        [TestMethod]
        public void getUserNameTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(userName, client.UserName);
        }

        [TestMethod]
        public void setUserNameTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newUserName = "richardspaul";
            client.UserName = newUserName;

            Assert.AreEqual(newUserName, client.UserName);
        }

        [TestMethod]
        public void getPasswordTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(password, client.Password);
        }

        [TestMethod]
        public void setPasswordTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newPassword = "paulDbeast";
            client.Password = newPassword;

            Assert.AreEqual(newPassword, client.Password);
        }

        [TestMethod]
        public void getPhoneTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(phone, client.Phone);
        }

        [TestMethod]
        public void setPhoneTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newPhoneNumber = "099777888";
            client.Phone = newPhoneNumber;

            Assert.AreEqual(newPhoneNumber, client.Phone);
        }

        [TestMethod]
        public void getIdTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(id, client.Id);
        }

        [TestMethod]
        public void setIdTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            string newId = "12223334";
            client.Id = newId;

            Assert.AreEqual(newId, client.Id);
        }

        [TestMethod]
        public void getRegistrationDateTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            Assert.AreEqual(registrationDate, client.RegistrationDate);
        }

        [TestMethod]
        public void setRegistrationDateTest()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            DateTime newRegistrationDate = DateTime.MinValue;
            client.RegistrationDate = newRegistrationDate;

            Assert.AreEqual(newRegistrationDate, client.RegistrationDate);
        }

        [TestMethod]
        public void updateLastLoginDate()
        {
            string name = "Paul";
            string surname = "Richards";
            string userName = "paulrichards";
            string password = "paulrichards1";
            string phone = "099888777";
            string id = "54443332";
            DateTime registrationDate = DateTime.Now;

            Client client = new Client(name, surname, userName, password, phone, id, registrationDate);

            DateTime dateAssigned = client.updateLastLoginDate();

            Assert.AreEqual(dateAssigned, client.LastLoginDate);
        }

    }

    
}
