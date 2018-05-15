using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {

    public class Door : Opening, IDrawable {

        public Door(Point aPlace) : base(aPlace) {
            HeightValue = 2.20F;
            LengthValue = 0.85F;
        }

        public override float CalculateCost() {
            return Constants.costCatalogue[GetComponentType()];
        }

        public override float CalculatePrice() {
            return Constants.priceCatalogue[GetComponentType()];
        }

        public override ComponentType GetComponentType() {
            return ComponentType.DOOR;
        }
    }
}
