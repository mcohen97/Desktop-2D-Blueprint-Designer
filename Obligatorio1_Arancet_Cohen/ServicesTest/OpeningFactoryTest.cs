using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryInterface;
using Logic.Domain;
using DataAccess;
using Services;
using DataAccessExceptions;

namespace ServicesTest
{
	[TestClass]
	public class OpeningFactoryTest
	{
        private IRepository<Template> templateRepository;
        Template template1;
        Template template2;
        Template template3;

        [TestInitialize]
        public void TestInitialize()
        {
            templateRepository = new OpeningTemplateRepository();
            templateRepository.Clear();

            template1 = new Template("Template window 1", 0.5f, 0.5f, 0.5f, ComponentType.WINDOW);
            template2 = new Template("Template window 2", 0.5f, 0.5f, 0.5f, ComponentType.WINDOW);
            template3 = new Template("Template door 3", 0.5f, 0, 0.5f, ComponentType.DOOR);

            templateRepository.Add(template1);
            templateRepository.Add(template2);
            templateRepository.Add(template3);
        }

        [TestMethod]
		public void ConstructorTest()
		{
            OpeningFactory factory = new OpeningFactory(templateRepository);
            Assert.IsNotNull(factory);
		}

        [TestMethod]
        public void CreateOpeningFromTemplateNameTest()
        {
            OpeningFactory factory = new OpeningFactory(templateRepository);
            Point position = new Point(1, 1);
            Opening expected = new Window(position, template1);
            Opening window1 = factory.CreateFromTemplate(position, template1.Name);
            Assert.AreEqual(expected.getTemplate(), window1.getTemplate());
        }

        [TestMethod]
        [ExpectedException(typeof(TemplateDoesNotExistException))]
        public void CreateOpeningFromNoneExistentTemplateNameTest()
        {
            OpeningFactory factory = new OpeningFactory(templateRepository);
            Point position = new Point(1, 1);
            Opening window1 = factory.CreateFromTemplate(position, "this template does not exist");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateOpeningFromNullTemplateNameTest()
        {
            OpeningFactory factory = new OpeningFactory(templateRepository);
            Point position = new Point(1, 1);
            Opening window1 = factory.CreateFromTemplate(position, null);
        }

    }
}
