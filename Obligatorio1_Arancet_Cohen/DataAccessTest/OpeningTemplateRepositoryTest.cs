using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Logic.Domain;
using Logic.Exceptions;
using System.Collections.Generic;

namespace DataAccessTest
{
    [TestClass]
    public class OpeningTemplateRepositoryTest
    {
        OpeningTemplateRepository templatesStorage;
        Template template1;
        Template template2;

        [TestInitialize]
        public void SetUp() {
            templatesStorage = new OpeningTemplateRepository();
            templatesStorage.Clear();
            template1 = new Template("Gate", 2, 0, 2, ComponentType.DOOR);
            template2 = new Template("Hopper", 1, 1, 1, ComponentType.WINDOW);
        }
        public void AddTemplates() {
            
            templatesStorage.Add(template1);
            templatesStorage.Add(template2);

        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(templatesStorage.IsEmpty());
        }

        [TestMethod]
        public void AddNotEmptyTest() {
            AddTemplates();
            Assert.IsFalse(templatesStorage.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(TemplateAlreadyExistsException))]
        public void AddRepeatedTest() {
            AddTemplates();
            templatesStorage.Add(template1);
        }

        [TestMethod]
        public void ClearTest() {
            templatesStorage.Clear();
            Assert.IsTrue(templatesStorage.IsEmpty());
        }

        [TestMethod]
        public void ExistsTest() {
            AddTemplates();
            Assert.IsTrue(templatesStorage.Exists(template1));
        }

        [TestMethod]
        public void DoesNotExistTest() {
            AddTemplates();
            Template template3 = new Template("Sliding-Glass", 1, 1.5F, 1.8F, ComponentType.WINDOW);
            Assert.IsFalse(templatesStorage.Exists(template3));
        }

        [TestMethod]
        public void GetTest() {
            AddTemplates();
            Template retrieved =templatesStorage.Get(template1);
            Assert.AreEqual(retrieved.Name, template1.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(TemplateDoesNotExistException))]
        public void GetNotExistentTest() {
            templatesStorage.Get(template1);
        }

        [TestMethod]
        public void GetByIdTest() {
            AddTemplates();
            Template retrieved = templatesStorage.Get(template1);
            Guid IDtemp1 = retrieved.Id;
            Assert.AreEqual(retrieved.Name, template1.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(TemplateDoesNotExistException))]
        public void GetByIdNotExistentTest()
        {
            templatesStorage.Get(Guid.NewGuid());
        }

        [TestMethod]
        public void GetByNameTest() {
            AddTemplates();
            Template retrieved = templatesStorage.GetTemplateByName("Gate");
            Assert.AreEqual(retrieved.Name,"Gate");
        }

        [TestMethod]
        [ExpectedException(typeof(TemplateDoesNotExistException))]
        public void GetByNameNotExistentTest()
        {
            templatesStorage.GetTemplateByName("Portal");
        }

        [TestMethod]
        public void GetAllEmptyTest() {
            ICollection<Template> query = templatesStorage.GetAll();
            int actualResult = query.Count;
            int expectedResult = 0;
            Assert.AreEqual(actualResult, expectedResult);
        }

        [TestMethod]
        public void GetAllNotEmptyTest()
        {
            AddTemplates();
            ICollection<Template> query = templatesStorage.GetAll();
            int actualResult = query.Count;
            int expectedResult = 2;
            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
