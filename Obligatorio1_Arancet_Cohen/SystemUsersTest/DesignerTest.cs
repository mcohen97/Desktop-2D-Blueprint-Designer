using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1ArancetCohen;

namespace DesignerTest
{
    [TestClass]
    public class DesignerTest
    {
        [TestMethod]
        public void DesignerConstructorWithParametersTest()
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
