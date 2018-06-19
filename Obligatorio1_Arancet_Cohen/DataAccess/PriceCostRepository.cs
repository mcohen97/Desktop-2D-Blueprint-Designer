using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRepositoryInterface;
using Entities;

namespace DataAccess
{
    public class PriceCostRepository : IPriceCostRepository
    {
        public void AddCostPrice(int componentType, float cost, float price)
        {
            CostPriceEntity toSave = new CostPriceEntity()
            {
                ComponentType = componentType,
                Cost = cost,
                Price = price
            };
            
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                context.CostsAndPrices.Add(toSave);
                context.SaveChanges();
            }
        }

        public void Clear()
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                foreach (CostPriceEntity record in context.CostsAndPrices) {
                    context.CostsAndPrices.Remove(record);
                }
                context.SaveChanges();
            }
        }

        public float GetCost(int componentType)
        {
            float cost;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                cost = context.CostsAndPrices.FirstOrDefault(cp => cp.ComponentType== componentType).Cost;
            }
            return cost;
        }

        public float GetPrice(int componentType)
        {
            float price;
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                price = context.CostsAndPrices.FirstOrDefault(cp=> cp.ComponentType== componentType).Price;
            }
            return price;
        }

        public void SetCost(int componentType, float cost)
        {
            throw new NotImplementedException();
        }

        public void SetPrice(int componentType, float newPrice)
        {
            using (BlueBuilderDBContext context = new BlueBuilderDBContext()) {
                CostPriceEntity record = context.CostsAndPrices.FirstOrDefault(cp => cp.ComponentType == componentType);
                record.Price = newPrice;
                context.SaveChanges();
            }
        }
    }
}
