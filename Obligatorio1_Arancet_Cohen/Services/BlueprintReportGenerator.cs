using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;
using DataAccess;
using DomainRepositoryInterface;

namespace Services
{
    public class BlueprintReportGenerator
    {
        public BlueprintPriceReport GeneratePriceReport(IBlueprint aBlueprint)
        {
            IPriceCostRepository costsNPrices = new PriceCostRepository();
            BlueprintPriceReport report = new BlueprintPriceReport();
            AddWallsPrice(report, aBlueprint, costsNPrices);
            AddBeamsPrice(report, aBlueprint, costsNPrices);
            AddColumnsPrice(report, aBlueprint, costsNPrices);
            AddWindowsPrice(report, aBlueprint, costsNPrices);
            AddDoorsPrice(report, aBlueprint, costsNPrices);
            return report;
        }

        private void AddWallsPrice(BlueprintPriceReport report, IBlueprint aBlueprint,IPriceCostRepository costsNPrices) {
            float wallMetersCount = 0;
            foreach (Wall existent in aBlueprint.GetWalls()) {
                wallMetersCount += existent.Length();
            }
            float wallPrice = costsNPrices.GetPrice((int)ComponentType.WALL);
            report.SetTotalPrice(ComponentType.WALL, wallMetersCount * wallPrice);
        }

        private void AddBeamsPrice(BlueprintPriceReport report, IBlueprint aBlueprint, IPriceCostRepository costsNPrices) {
            int beamsCount = aBlueprint.GetBeams().Count;
            float beamPrice = costsNPrices.GetPrice((int)ComponentType.BEAM);
            report.SetTotalPrice(ComponentType.BEAM, beamsCount * beamPrice);
        }

        private void AddColumnsPrice(BlueprintPriceReport report, IBlueprint aBlueprint, IPriceCostRepository costsNPrices) {
            int columnsCount = aBlueprint.GetColumns().Count;
            float columnPrice = costsNPrices.GetPrice((int)ComponentType.COLUMN);
            report.SetTotalPrice(ComponentType.COLUMN, columnsCount * columnPrice);
        }

        private void AddWindowsPrice(BlueprintPriceReport report, IBlueprint aBlueprint, IPriceCostRepository costsNPrices) {
            int windowsCount = aBlueprint.GetOpenings().Count(o => o.GetComponentType().Equals(ComponentType.WINDOW));
            float windowsPrice = costsNPrices.GetPrice((int)ComponentType.WINDOW);
            report.SetTotalPrice(ComponentType.WINDOW, windowsCount * windowsPrice);
        }

        private void AddDoorsPrice(BlueprintPriceReport report, IBlueprint aBlueprint, IPriceCostRepository costsNPrices) {
            int doorsCount = aBlueprint.GetOpenings().Count(o => o.GetComponentType().Equals(ComponentType.DOOR));
            float doorsPrice = costsNPrices.GetPrice((int)ComponentType.DOOR);
            report.SetTotalPrice(ComponentType.DOOR, doorsCount * doorsPrice);
        }

    }
}
