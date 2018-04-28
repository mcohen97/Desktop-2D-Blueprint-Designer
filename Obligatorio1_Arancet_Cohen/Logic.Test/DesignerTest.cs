using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1_Arancet_Cohen;

namespace DesignerTest
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
        public void getUserNameTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            Assert.AreEqual(userName, designer.UserName);
        }

        [TestMethod]
        public void setUserNameTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            string newUserName = "myrock";
            designer.UserName = newUserName;

            Assert.AreEqual(newUserName, designer.UserName);
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

            DateTime dateAssigned = designer.updateLastLoginDate();

            Assert.AreEqual(dateAssigned, designer.LastLoginDate);
        }

        [TestMethod]
        public void canCreateBlueprintTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            bool canCreateBlueprint = designer.hasPermission(Permission.CREATE_BLUEPRINT);

            Assert.IsTrue(canCreateBlueprint);
        }

        [TestMethod]
        public void canEditBlueprintTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            bool canEditBlueprint = designer.hasPermission(Permission.EDIT_BLUEPRINT);

            Assert.IsTrue(canEditBlueprint);
        }

        [TestMethod]
        public void canDeleteBlueprintTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            bool canDeleteBlueprint = designer.hasPermission(Permission.DELETE_BLUEPRINT);

            Assert.IsTrue(canDeleteBlueprint);
        }

        [TestMethod]
        public void canReadBlueprintTest()
        {
            Designer designer = new Designer(name, surname, userName, password, registrationDate);

            bool canReadBlueprint = designer.hasPermission(Permission.READ_BLUEPRINT);

            Assert.IsTrue(canReadBlueprint);
        }
    }
}