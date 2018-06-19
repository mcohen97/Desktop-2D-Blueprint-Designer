using Logic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public class BlueprintCostReport
    {
        private Dictionary<ComponentType, float> catalog;
        public BlueprintCostReport()
        {
            catalog = new Dictionary<ComponentType, float>();
        }

        public void SetTotalCost(ComponentType material, float totalPrice)
        {
            catalog[material] = totalPrice;
        }

        public float GetTotalCost(ComponentType material)
        {
            return catalog[material];
        }


    }
}
