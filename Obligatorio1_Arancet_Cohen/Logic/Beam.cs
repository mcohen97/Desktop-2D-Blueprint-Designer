using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {

    public class Beam : ISinglePointComponent, IMaterialType, IPriceable {

        private Point position;

        public Beam(Point aPlace) {
            position = aPlace;
        }

        public Point GetPosition() {
            return position;
        }

        public override bool Equals(object obj) {
            bool areEqual;
            if (obj == null || GetType() != obj.GetType()) {
                areEqual = false;
            } else {
                Beam otherBeam = (Beam)obj;
                areEqual = position.Equals(otherBeam.position);
            }
            return areEqual;
        }

        public override int GetHashCode() {
            return position.GetHashCode();
        }

        public ComponentType GetComponentType() {
            return ComponentType.BEAM;
        }

        public float CalculatePrice() {
            return Constants.PRICE_CATALOGUE[GetComponentType()];
        }

        public float CalculateCost() {
            return Constants.COST_CATALOGUE[GetComponentType()];
        }
    }
}
