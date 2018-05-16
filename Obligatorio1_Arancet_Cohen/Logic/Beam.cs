using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {

    public class Beam : ISinglePointComponent, IMaterialType, IPriceable {

        private Point Position { get; set; }

        public Beam(Point aPlace) {
            Position = aPlace;
        }

        public Point GetPosition() {
            return Position;
        }

        public override bool Equals(object obj) {
            bool areEqual;
            if (obj == null || GetType() != obj.GetType()) {
                areEqual = false;
            } else {
                Beam otherBeam = (Beam)obj;
                areEqual = Position.Equals(otherBeam.Position);
            }
            return areEqual;
        }

        public override int GetHashCode() {
            return Position.GetHashCode();
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
