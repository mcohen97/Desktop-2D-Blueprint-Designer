using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace Test
{
    [TestClass]
    public class DesignerTest
    {
        string name;
        string surname;
        string userName;
        string password;
        DateTime registrationDate;

        [TestInitialize]
        public void TestInitialize()
        {
            name = "Michael";
            surname = "Rockford";
            userName = "mirockfo";
            password = "drofkcor";
            registrationDate = DateTime.Now;
        }

        [TestMethod]
        public void constructorWithParametersTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.IsNotNull(designer);
        }

        [TestMethod]
        public void getNameTest()
        {
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(name, designer.Name);
        }

        [TestMethod]
        public void setNameTest()
        {
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newName = "Ron";
            designer.Name = newName;

            Assert.AreEqual(newName, designer.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void setEmptyNameTest() {
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newName = "";
            designer.Name = newName;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void setNullNameTest() {
            DateTime registrationDate = DateTime.Now;

            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newName = null;
            designer.Name = newName;
        }

        [TestMethod]
        public void getSurnameTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(surname, designer.Surname);
        }

        [TestMethod]
        public void setSurnameTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newSurname = "Flanders";
            designer.Surname = newSurname;

            Assert.AreEqual(newSurname, designer.Surname);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void setEmptySurnameTest() {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newSurname = "";
            designer.Surname = newSurname;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void setNullSurnameTest() {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newSurname = null;
            designer.Surname = newSurname;
        }

        [TestMethod]
        public void getUserNameTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(userName, designer.UserName);
        }

        [TestMethod]
        public void getPasswordTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(password, designer.Password);
        }

        [TestMethod]
        public void setPasswordTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newPassword = "drofkcormich";
            designer.Password = newPassword;

            Assert.AreEqual(newPassword, designer.Password);
        }

        [TestMethod]
        public void getRegistrationDateTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(registrationDate, designer.RegistrationDate);
        }

        [TestMethod]
        public void setRegistrationDateTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            DateTime newRegistrationDate = DateTime.MaxValue;
            designer.RegistrationDate = newRegistrationDate;

            Assert.AreEqual(newRegistrationDate, designer.RegistrationDate);
        }

        [TestMethod]
        public void updateLastLoginDateTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            DateTime dateAssigned = designer.UpdateLastLoginDate();

            Assert.AreEqual(dateAssigned, designer.LastLoginDate);
        }

        [TestMethod]
        public void canCreateBlueprintTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            bool canCreateBlueprint = designer.HasPermission(Permission.CREATE_BLUEPRINT);

            Assert.IsTrue(canCreateBlueprint);
        }

        [TestMethod]
        public void canEditBlueprintTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            bool canEditBlueprint = designer.HasPermission(Permission.EDIT_BLUEPRINT);

            Assert.IsTrue(canEditBlueprint);
        }

        [TestMethod]
        public void canDeleteBlueprintTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            bool canDeleteBlueprint = designer.HasPermission(Permission.DELETE_BLUEPRINT);

            Assert.IsTrue(canDeleteBlueprint);
        }

        [TestMethod]
        public void canReadBlueprintTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            bool canReadBlueprint = designer.HasPermission(Permission.READ_BLUEPRINT);

            Assert.IsTrue(canReadBlueprint);
        }
    }
}