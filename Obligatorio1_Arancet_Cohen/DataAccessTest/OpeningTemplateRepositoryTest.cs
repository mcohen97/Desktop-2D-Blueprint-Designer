using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;

namespace DataAccessTest
{
    [TestClass]
    public class OpeningTemplateRepositoryTest
    {
        OpeningTemplateRepository templatesStorage;
        [TestInitialize]
        public void SetUp() {
            templatesStorage = new OpeningTemplateRepository();
        }


        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(templatesStorage.IsEmpty());
        }
    }
}
