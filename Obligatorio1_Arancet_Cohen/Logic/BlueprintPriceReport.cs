using Logic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public class BlueprintPriceReport
    {
        private Dictionary<ComponentType, float> catalog;
        public BlueprintPriceReport() {
            catalog = new Dictionary<ComponentType, float>();
        }

        public void SetTotalPrice(ComponentType material, float totalPrice) {
            catalog[material] = totalPrice;
        }

        public float GetTotalPrice(ComponentType material) {
            return catalog[material];
        }


    }
}
