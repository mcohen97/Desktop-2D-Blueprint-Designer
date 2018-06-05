using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;

namespace Logic.Test
{
    [TestClass]
    public class ArchitectTest
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
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.IsNotNull(architect);
        }

        [TestMethod]
        public void getNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(name, architect.Name);
        }

        [TestMethod]
        public void setNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newName = "Ron";
            architect.Name = newName;

            Assert.AreEqual(newName, architect.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void setEmptyNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newName = "";
            architect.Name = newName;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void setNullNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newName = null;
            architect.Name = newName;
        }

        [TestMethod]
        public void getSurnameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(surname, architect.Surname);
        }

        [TestMethod]
        public void setSurnameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newSurname = "Flanders";
            architect.Surname = newSurname;

            Assert.AreEqual(newSurname, architect.Surname);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void setEmptySurnameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newSurname = "";
            architect.Surname = newSurname;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void setNullSurnameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newSurname = null;
            architect.Surname = newSurname;
        }

        [TestMethod]
        public void getUserNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(userName, architect.UserName);
        }

        [TestMethod]
        public void getPasswordTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(password, architect.Password);
        }

        [TestMethod]
        public void setPasswordTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newPassword = "drofkcormich";
            architect.Password = newPassword;

            Assert.AreEqual(newPassword, architect.Password);
        }

        [TestMethod]
        public void getRegistrationDateTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(registrationDate, architect.RegistrationDate);
        }

        [TestMethod]
        public void setRegistrationDateTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            DateTime newRegistrationDate = DateTime.MaxValue;
            architect.RegistrationDate = newRegistrationDate;

            Assert.AreEqual(newRegistrationDate, architect.RegistrationDate);
        }

        [TestMethod]
        public void updateLastLoginDateTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            DateTime dateAssigned = architect.UpdateLastLoginDate();

            Assert.AreEqual(dateAssigned, architect.LastLoginDate);
        }

        [TestMethod]
        public void canCreateBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canCreateBlueprint = architect.HasPermission(Permission.CREATE_BLUEPRINT);

            Assert.IsTrue(canCreateBlueprint);
        }

        [TestMethod]
        public void canEditBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canEditBlueprint = architect.HasPermission(Permission.EDIT_BLUEPRINT);

            Assert.IsTrue(canEditBlueprint);
        }

        [TestMethod]
        public void canDeleteBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canDeleteBlueprint = architect.HasPermission(Permission.DELETE_BLUEPRINT);

            Assert.IsTrue(canDeleteBlueprint);
        }

        [TestMethod]
        public void canReadBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canReadBlueprint = architect.HasPermission(Permission.READ_BLUEPRINT);

            Assert.IsTrue(canReadBlueprint);
        }

        [TestMethod]
        public void canSignBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canSignBlueprint = architect.HasPermission(Permission.CAN_SIGN_BLUEPRINT);

            Assert.IsTrue(canSignBlueprint);
        }
    }
}
