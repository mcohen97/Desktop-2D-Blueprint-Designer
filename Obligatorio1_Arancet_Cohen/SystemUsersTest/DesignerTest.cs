using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1_Arancet_Cohen;

namespace DesignerTest
{
    [TestClass]
    public class DesignerTest
    {
        [TestMethod]
        public void constructorWithParametersTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.IsNotNull(designer);
        }

        [TestMethod]
        public void getNameTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(name, designer.Name);
        }

        [TestMethod]
        public void setNameTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newName = "Ron";
            designer.Name = newName;

            Assert.AreEqual(newName, designer.Name);
        }

        [TestMethod]
        public void getSurnameTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(surname, designer.Surname);
        }

        [TestMethod]
        public void setSurnameTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newSurname = "Flanders";
            designer.Surname = newSurname;

            Assert.AreEqual(newSurname, designer.Surname);
        }

        [TestMethod]
        public void getUserNameTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(userName, designer.UserName);
        }

        [TestMethod]
        public void setUserNameTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newUserName = "myrock";
            designer.UserName = newUserName;

            Assert.AreEqual(newUserName, designer.UserName);
        }

        [TestMethod]
        public void getPasswordTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(password, designer.Password);
        }

        [TestMethod]
        public void setPasswordTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newPassword = "drofkcormich";
            designer.Password = newPassword;

            Assert.AreEqual(newPassword, designer.Password);
        }

        [TestMethod]
        public void getRegistrationDateTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(registrationDate, designer.RegistrationDate);
        }

        [TestMethod]
        public void setRegistrationDateTest()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            DateTime newRegistrationDate = DateTime.MaxValue;
            designer.RegistrationDate = newRegistrationDate;

            Assert.AreEqual(newRegistrationDate, designer.RegistrationDate);
        }

        [TestMethod]
        public void updateLastLoginDate()
        {
            string name = "Michael";
            string surname = "Rockford";
            string userName = "mirockfo";
            string password = "drofkcor";
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            DateTime dateAssigned = designer.updateLastLoginDate();

            Assert.AreEqual(dateAssigned, designer.LastLoginDate);
        }
    }
}
