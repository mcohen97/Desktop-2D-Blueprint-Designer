using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorio1_Arancet_Cohen;

namespace SystemUsersTest
{
    [TestClass]
    public class ProjectTest
    {
        private Client client;
        private Designer designer;

        [TestInitialize]
        public void Initialize()
        {
            client = new Client("Bob","Whiteman","bowhiman","white1985man","099999222","12345678",DateTime.Now);
            designer = new Designer("Bob", "Whiteman", "bowhiman", "white1985man", DateTime.Now);
        }
        [TestMethod]
        public void constructorWithParameters()
        {
            Project project = new Project(client, designer);

            Assert.IsNotNull(project);
        }
    }
}
