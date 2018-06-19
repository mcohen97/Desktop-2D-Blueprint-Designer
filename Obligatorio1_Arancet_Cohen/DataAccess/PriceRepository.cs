using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainRepositoryInterface;

namespace DataAccess
{
    public class PriceRepository : IPriceCostRepository
    {
        public void AddCostPrice(int componentType, float cost, float price)
        {
            throw new NotImplementedException();
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
