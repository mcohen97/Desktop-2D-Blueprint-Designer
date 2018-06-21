using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;
using DomainRepositoryInterface;

namespace Services
{
    public class BlueprintReportGenerator
    {
        IPriceCostRepository costsNPrices;

        public BlueprintReportGenerator(IPriceCostRepository catalog) {
            costsNPrices = catalog;
        }
        public BlueprintPriceReport GeneratePriceReport(IBlueprint aBlueprint)
        {
            BlueprintPriceReport report = new BlueprintPriceReport();
            AddWallsPrice(report, aBlueprint);
            AddBeamsPrice(report, aBlueprint);
            AddColumnsPrice(report, aBlueprint);
            AddWindowsPrice(report, aBlueprint);
            AddDoorsPrice(report, aBlueprint);
            return report;
        }

        private void AddWallsPrice(BlueprintPriceReport report, IBlueprint aBlueprint) {
            float wallMetersCount = 0;
            foreach (Wall existent in aBlueprint.GetWalls()) {
                wallMetersCount += existent.Length();
            }
            float wallPrice = costsNPrices.GetPrice((int)ComponentType.WALL);
            report.SetTotalPrice(ComponentType.WALL, wallMetersCount * wallPrice);
        }

        private void AddBeamsPrice(BlueprintPriceReport report, IBlueprint aBlueprint) {
            int beamsCount = aBlueprint.GetBeams().Count;
            float beamPrice = costsNPrices.GetPrice((int)ComponentType.BEAM);
            report.SetTotalPrice(ComponentType.BEAM, beamsCount * beamPrice);
        }

        private void AddColumnsPrice(BlueprintPriceReport report, IBlueprint aBlueprint) {
            int columnsCount = aBlueprint.GetColumns().Count;
            float columnPrice = costsNPrices.GetPrice((int)ComponentType.COLUMN);
            report.SetTotalPrice(ComponentType.COLUMN, columnsCount * columnPrice);
        }

        private void AddWindowsPrice(BlueprintPriceReport report, IBlueprint aBlueprint) {
            int windowsCount = aBlueprint.GetOpenings().Count(o => o.GetComponentType().Equals(ComponentType.WINDOW));
            float windowsPrice = costsNPrices.GetPrice((int)ComponentType.WINDOW);
            report.SetTotalPrice(ComponentType.WINDOW, windowsCount * windowsPrice);
        }

        private void AddDoorsPrice(BlueprintPriceReport report, IBlueprint aBlueprint) {
            int doorsCount = aBlueprint.GetOpenings().Count(o => o.GetComponentType().Equals(ComponentType.DOOR));
            float doorsPrice = costsNPrices.GetPrice((int)ComponentType.DOOR);
            report.SetTotalPrice(ComponentType.DOOR, doorsCount * doorsPrice);
        }

        public BlueprintCostReport GenerateCostReport(IBlueprint aBlueprint)
        {
            BlueprintCostReport report = new BlueprintCostReport();
            AddWallsCost(report, aBlueprint);
            AddBeamsCost(report, aBlueprint);
            AddColumnsCost(report, aBlueprint);
            AddWindowsCost(report, aBlueprint);
            AddDoorsCost(report, aBlueprint);
            return report;
        }

        private void AddWallsCost(BlueprintCostReport report, IBlueprint aBlueprint)
        {
            float wallMetersCount = 0;
            foreach (Wall existent in aBlueprint.GetWalls())
            {
                wallMetersCount += existent.Length();
            }
            float wallPrice = costsNPrices.GetCost((int)ComponentType.WALL);
            report.SetTotalCost(ComponentType.WALL, wallMetersCount * wallPrice);
        }

        private void AddBeamsCost(BlueprintCostReport report, IBlueprint aBlueprint)
        {
            int beamsCount = aBlueprint.GetBeams().Count;
            float beamPrice = costsNPrices.GetCost((int)ComponentType.BEAM);
            report.SetTotalCost(ComponentType.BEAM, beamsCount * beamPrice);
        }

        private void AddColumnsCost(BlueprintCostReport report, IBlueprint aBlueprint)
        {
            int columnsCount = aBlueprint.GetColumns().Count;
            float columnPrice = costsNPrices.GetCost((int)ComponentType.COLUMN);
            report.SetTotalCost(ComponentType.COLUMN, columnsCount * columnPrice);
        }

        private void AddWindowsCost(BlueprintCostReport report, IBlueprint aBlueprint)
        {
            int windowsCount = aBlueprint.GetOpenings().Count(o => o.GetComponentType().Equals(ComponentType.WINDOW));
            float windowsPrice = costsNPrices.GetCost((int)ComponentType.WINDOW);
            report.SetTotalCost(ComponentType.WINDOW, windowsCount * windowsPrice);
        }

        private void AddDoorsCost(BlueprintCostReport report, IBlueprint aBlueprint)
        {
            int doorsCount = aBlueprint.GetOpenings().Count(o => o.GetComponentType().Equals(ComponentType.DOOR));
            float doorsPrice = costsNPrices.GetCost((int)ComponentType.DOOR);
            report.SetTotalCost(ComponentType.DOOR, doorsCount * doorsPrice);
        }
    }
}
