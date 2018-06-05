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
        public void ConstructorWithParametersTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.IsNotNull(architect);
        }

        [TestMethod]
        public void GetNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(name, architect.Name);
        }

        [TestMethod]
        public void SetNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newName = "Ron";
            architect.Name = newName;

            Assert.AreEqual(newName, architect.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetEmptyNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newName = "";
            architect.Name = newName;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newName = null;
            architect.Name = newName;
        }

        [TestMethod]
        public void GetSurnameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(surname, architect.Surname);
        }

        [TestMethod]
        public void SetSurnameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newSurname = "Flanders";
            architect.Surname = newSurname;

            Assert.AreEqual(newSurname, architect.Surname);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetEmptySurnameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newSurname = "";
            architect.Surname = newSurname;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullSurnameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newSurname = null;
            architect.Surname = newSurname;
        }

        [TestMethod]
        public void GetUserNameTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(userName, architect.UserName);
        }

        [TestMethod]
        public void GetPasswordTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(password, architect.Password);
        }

        [TestMethod]
        public void SetPasswordTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            string newPassword = "drofkcormich";
            architect.Password = newPassword;

            Assert.AreEqual(newPassword, architect.Password);
        }

        [TestMethod]
        public void GetRegistrationDateTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            Assert.AreEqual(registrationDate, architect.RegistrationDate);
        }

        [TestMethod]
        public void SetRegistrationDateTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            DateTime newRegistrationDate = DateTime.MaxValue;
            architect.RegistrationDate = newRegistrationDate;

            Assert.AreEqual(newRegistrationDate, architect.RegistrationDate);
        }

        [TestMethod]
        public void UpdateLastLoginDateTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            DateTime dateAssigned = architect.UpdateLastLoginDate();

            Assert.AreEqual(dateAssigned, architect.LastLoginDate);
        }

        [TestMethod]
        public void CanCreateBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canCreateBlueprint = architect.HasPermission(Permission.CREATE_BLUEPRINT);

            Assert.IsTrue(canCreateBlueprint);
        }

        [TestMethod]
        public void CanEditBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canEditBlueprint = architect.HasPermission(Permission.EDIT_BLUEPRINT);

            Assert.IsTrue(canEditBlueprint);
        }

        [TestMethod]
        public void CanDeleteBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canDeleteBlueprint = architect.HasPermission(Permission.DELETE_BLUEPRINT);

            Assert.IsTrue(canDeleteBlueprint);
        }

        [TestMethod]
        public void CanReadBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canReadBlueprint = architect.HasPermission(Permission.READ_BLUEPRINT);

            Assert.IsTrue(canReadBlueprint);
        }

        [TestMethod]
        public void CanSignBlueprintTest()
        {
            Architect architect = new Architect(name, surname, userName, password, registrationDate);

            bool canSignBlueprint = architect.HasPermission(Permission.CAN_SIGN_BLUEPRINT);

            Assert.IsTrue(canSignBlueprint);
        }
    }
}
