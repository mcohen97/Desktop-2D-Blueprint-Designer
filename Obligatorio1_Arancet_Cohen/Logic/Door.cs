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
            return Constants.DOOR_COST;
        }

        public override float CalculatePrice() {
            return Constants.DOOR_PRICE;
        }

        public ComponentType GetComponentType() {
            return ComponentType.DOOR;
        }
    }
}
