using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic.Domain;

namespace Logic.Test
{
    [TestClass]
    public class TemplateTest
    {
        [TestMethod]
        public void TemplateConstructorTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            Assert.IsNotNull(template);
        }

        [TestMethod]
        public void GetNameTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            Assert.AreEqual(name, template.Name);
        }

        [TestMethod]
        public void GetLengthTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            Assert.AreEqual(length, template.Length);
        }

        [TestMethod]
        public void GetHeightTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            Assert.AreEqual(height, template.Height);
        }

        [TestMethod]
        public void GetWidthTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            Assert.AreEqual(width, template.HeightAboveFloor);
        }

        [TestMethod]
        public void GetComponentTypeTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            Assert.AreEqual(type, template.Type);
        }

        [TestMethod]
        public void SetNameTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            string newName = "New custom name";
            template.Name = newName;

            Assert.AreEqual(newName, template.Name);
        }

        [TestMethod]
        public void SetLengthTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            float newLength = 2;
            template.Length = newLength;

            Assert.AreEqual(newLength, template.Length);
        }

        [TestMethod]
        public void SetWidthTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            float newWidth = 0.3f;
            template.HeightAboveFloor = newWidth;

            Assert.AreEqual(newWidth, template.HeightAboveFloor);
        }

        [TestMethod]
        public void SetHeigthTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            float newHeight = 0.3f;
            template.Height = newHeight;

            Assert.AreEqual(newHeight, template.Height);
        }

        [TestMethod]
        public void SetTypeTest()
        {
            string name = "My custom template";
            float length = 1;
            float width = 0.5f;
            float height = 1;
            ComponentType type = ComponentType.WINDOW;
            Template template = new Template(name, length, width, height, type);

            ComponentType newType = ComponentType.DOOR;
            template.Type = newType;

            Assert.AreEqual(newType, template.Type);
        }
    }
}
