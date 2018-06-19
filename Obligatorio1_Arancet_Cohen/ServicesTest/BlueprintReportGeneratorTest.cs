using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using Logic.Domain;
using DomainRepositoryInterface;
using DataAccess;
using Logic;

namespace ServicesTest
{
    [TestClass]
    public class BlueprintReportGeneratorTest
    {
        SessionConnector connector;
        CostsAndPricesManager costsNPrices;
        IBlueprint toReport;
        BlueprintReportGenerator reporter;
        IPriceCostRepository storage;

        [TestInitialize]
        public void SetUp()
        {
            connector = new SessionConnector();
            Session aSession = connector.LogIn("admin", "admin");
            costsNPrices = new CostsAndPricesManager(aSession);
            reporter = new BlueprintReportGenerator();
            toReport = new Blueprint(10,10,"TestBlueprint");
            SetBlueprint();
            storage = new PriceCostRepository();
            AddPrices();
            

        }

        private void SetBlueprint() {
            toReport.InsertWall(new Point(0, 0), new Point(5,0));
            toReport.InsertWall(new Point(0, 0), new Point(0, 5));
            toReport.InsertColumn(new Point(1, 1));
            toReport.InsertColumn(new Point(1, 2));
            Template temp = new Template("Slider", 2, 1, 2, ComponentType.WINDOW);
            Opening window1 = new Window(new Point(0, 2), temp);
            Opening window2 = new Window(new Point(2, 0), temp);
            toReport.InsertOpening(window1);
            toReport.InsertOpening(window2);
        }

        private void AddPrices() {
            storage.Clear();
            storage.AddCostPrice((int)ComponentType.WALL,50,100);
            storage.AddCostPrice((int)ComponentType.BEAM,50,75);
            storage.AddCostPrice((int)ComponentType.COLUMN,50,75);
            storage.AddCostPrice((int)ComponentType.WINDOW,50,75);
            storage.AddCostPrice((int)ComponentType.DOOR,50,100);
        }

        [TestMethod]
        public void GetPriceWallsTest() {
            BlueprintPriceReport report = reporter.GeneratePriceReport(toReport);
            float expectedResult = 1000;
            float actualResult = report.GetTotalPrice(ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetPriceBeamsTest() {
            BlueprintPriceReport report = reporter.GeneratePriceReport(toReport);
            float expectedResult = 225;
            float actualResult = report.GetTotalPrice(ComponentType.BEAM);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetPriceColumnsTest() {
            BlueprintPriceReport report = reporter.GeneratePriceReport(toReport);
            float expectedResult = 150;
            float actualResult = report.GetTotalPrice(ComponentType.COLUMN);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetPriceWindowsTest()
        {
            BlueprintPriceReport report = reporter.GeneratePriceReport(toReport);
            float expectedResult = 150;
            float actualResult = report.GetTotalPrice(ComponentType.WINDOW);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetPriceDoorsTest()
        {
            BlueprintPriceReport report = reporter.GeneratePriceReport(toReport);
            float expectedResult = 0;
            float actualResult = report.GetTotalPrice(ComponentType.DOOR);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostWallsTest()
        {
            BlueprintCostReport report = reporter.GenerateCostReport(toReport);
            float expectedResult = 1000;
            float actualResult = report.GetTotalCost(ComponentType.WALL);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostBeamsTest()
        {
            BlueprintCostReport report = reporter.GenerateCostReport(toReport);
            float expectedResult = 225;
            float actualResult = report.GetTotalCost(ComponentType.BEAM);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostColumnsTest()
        {
            BlueprintCostReport report = reporter.GenerateCostReport(toReport);
            float expectedResult = 150;
            float actualResult = report.GetTotalCost(ComponentType.COLUMN);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostWindowsTest()
        {
            BlueprintCostReport report = reporter.GenerateCostReport(toReport);
            float expectedResult = 150;
            float actualResult = report.GetTotalCost(ComponentType.WINDOW);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetCostDoorsTest()
        {
            BlueprintCostReport report = reporter.GenerateCostReport(toReport);
            float expectedResult = 0;
            float actualResult = report.GetTotalCost(ComponentType.DOOR);
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
