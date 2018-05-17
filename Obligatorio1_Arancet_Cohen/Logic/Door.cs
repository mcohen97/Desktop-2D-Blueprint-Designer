using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain {

    public class Door : Opening, IMaterialType {

        public Door(Point aPlace) : base(aPlace) {
            heightValue = 2.20F;
            lengthValue = 0.85F;
        }

        public override float CalculateCost() {
            return Constants.COST_CATALOGUE[GetComponentType()];
        }

        public override float CalculatePrice() {
            return Constants.PRICE_CATALOGUE[GetComponentType()];
        }

        public override ComponentType GetComponentType() {
            return ComponentType.DOOR;
        }
    }
}
