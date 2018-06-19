using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRepositoryInterface
{
    public interface IPriceCostRepository
    {
        float GetPrice(int componentType);

        float GetCost(int componentType);

        void SetPrice(int componentType, float price);

        void SetCost(int componentType, float cost);

        void AddCostPrice(int componentType, float cost,float price);

        void Clear();
    }
}
