using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using Logic.Domain;
using Logic.Exceptions;

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

    }
}
