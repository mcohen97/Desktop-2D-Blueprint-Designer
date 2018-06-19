using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Logic.Domain;

namespace ServicesTest
{
    [TestClass]
    public class BlueprintReportGeneratorTest
    {
        SessionConnector connector;
        CostsAndPricesManager costsNPrices;
        IBlueprint toReport;
        BlueprintReportGenerator reporter;

        [TestInitialize]
        public void SetUp()
        {
            Session aSession = connector.LogIn("admin", "admin");
            costsNPrices = new CostsAndPricesManager(aSession);
            reporter = new BlueprintReportGenerator();
        }
    }
}
