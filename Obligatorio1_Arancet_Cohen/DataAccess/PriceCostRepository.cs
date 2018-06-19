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

        public float GetCost(int componentType)
        {
            throw new NotImplementedException();
        }

        public float GetPrice(int componentType)
        {
            throw new NotImplementedException();
        }

        public void SetCost(int componentType, float cost)
        {
            throw new NotImplementedException();
        }

        public void SetPrice(int componentType, float price)
        {
            throw new NotImplementedException();
        }
    }
}
