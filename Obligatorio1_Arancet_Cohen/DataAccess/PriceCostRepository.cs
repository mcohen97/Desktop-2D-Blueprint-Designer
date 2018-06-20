using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRepositoryInterface;
using Entities;
using System.Data.Common;
using DataAccessExceptions;

namespace DataAccess
{
    public class PriceCostRepository : IPriceCostRepository
    {
        public void AddCostPrice(int componentType, float cost, float price)
        {
            CostPriceEntity toSave = BuildCostPriceEntity(componentType, cost, price);
            try {
                TryAddPrice(toSave);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }


        }
        private CostPriceEntity BuildCostPriceEntity(int componentType, float cost, float price) {
            CostPriceEntity toSave = new CostPriceEntity()
            {
                ComponentType = componentType,
                Cost = cost,
                Price = price
            };
            return toSave;
        }

        private void TryAddPrice(CostPriceEntity toSave) {

            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                context.CostsAndPrices.Add(toSave);
                context.SaveChanges();
            }
        }



        public void Clear()
        {
            try
            {
                TryToClear();
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
        }

        private void TryToClear() {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                foreach (CostPriceEntity record in context.CostsAndPrices)
                {
                    context.CostsAndPrices.Remove(record);
                }
                context.SaveChanges();
            }
        }

        public float GetCost(int componentType)
        {
            float cost;
            try
            {
                cost = TryGettingCost(componentType);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return cost;
        }

        private float TryGettingCost(int componentType) {
            float cost;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                cost = context.CostsAndPrices.FirstOrDefault(cp => cp.ComponentType == componentType).Cost;
            }
            return cost;
        }

        public float GetPrice(int componentType)
        {
            float price;
            try {
                price = TryGettingPrice(componentType);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
            return price;
        }

        private float TryGettingPrice(int componentType) {
            float price;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                price = context.CostsAndPrices.FirstOrDefault(cp => cp.ComponentType == componentType).Price;
            }
            return price;

        }

        public void SetCost(int componentType, float newCost)
        {
            try
            {
                TrySettingCost(componentType, newCost);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
        }

        private void TrySettingCost(int componentType, float newCost) {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                CostPriceEntity record = context.CostsAndPrices.FirstOrDefault(cp => cp.ComponentType == componentType);
                record.Cost = newCost;
                context.SaveChanges();
            }
        }

        public void SetPrice(int componentType, float newPrice)
        {
            try
            {
                TrySettingPrice(componentType, newPrice);
            }
            catch (DbException) {
                throw new InaccessibleDataException();
            }
        }

        private void TrySettingPrice(int componentType, float newPrice) {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext())
            {
                CostPriceEntity record = context.CostsAndPrices.FirstOrDefault(cp => cp.ComponentType == componentType);
                record.Price = newPrice;
                context.SaveChanges();
            }
        }
    }
}
