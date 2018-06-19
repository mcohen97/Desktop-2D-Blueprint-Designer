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
    public class CostsAndPricesManager
    {
        private Session currentSession;

        public CostsAndPricesManager(Session aSession) {
            currentSession = aSession;
        }

        public float GetPrice(int componentType) {
            IPriceCostRepository catalog = new PriceCostRepository();
            return catalog.GetPrice(componentType);
        }


    }
}
