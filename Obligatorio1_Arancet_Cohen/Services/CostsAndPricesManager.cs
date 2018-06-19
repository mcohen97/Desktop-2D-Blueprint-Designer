using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;
using DataAccess;
using DomainRepositoryInterface;
using ServicesExceptions;

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

        public void SetPrice(int componentType, float newPrice) {
            if (currentSession.UserLogged.HasPermission(Permission.MANAGE_COSTS))
            {
                throw new NoPermissionsException();
            }
            IPriceCostRepository catalog = new PriceCostRepository();
            catalog.SetPrice(componentType, newPrice);
        }


    }
}
