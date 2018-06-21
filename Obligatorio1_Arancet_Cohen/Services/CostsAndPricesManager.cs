using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;
using DomainRepositoryInterface;
using ServicesExceptions;

namespace Services
{
    public class CostsAndPricesManager
    {
        private Session currentSession;
        IPriceCostRepository catalog;
        public CostsAndPricesManager(Session aSession, IPriceCostRepository aCatalog) {
            currentSession = aSession;
            catalog = aCatalog;
        }

        public float GetPrice(int componentType) {
            return catalog.GetPrice(componentType);
        }

        public void SetPrice(int componentType, float newPrice) {
            if (!currentSession.UserLogged.HasPermission(Permission.MANAGE_COSTS))
            {
                throw new NoPermissionsException();
            }
            catalog.SetPrice(componentType, newPrice);
        }

        public float GetCost(int componentType)
        {
            return catalog.GetCost(componentType);
        }

        public void SetCost(int componentType, float newCost)
        {
            if (!currentSession.UserLogged.HasPermission(Permission.MANAGE_COSTS))
            {
                throw new NoPermissionsException();
            }
            catalog.SetCost(componentType, newCost);
        }
    }
}
