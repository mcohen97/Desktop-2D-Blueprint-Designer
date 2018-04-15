using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1ArancetCohen;

namespace ClientTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ClientConstructorWithParametersTest()
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
