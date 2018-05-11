using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {

    public abstract class Opening : ISinglePointComponent, IComponent2D, IPriceable {

        protected float HeightValue { get; set; }
        protected float LengthValue { get; set; }
        protected Point Position { get; set; }

        public Opening(Point aPlace) {
            Position = aPlace;
        }

        public float Height() {
            return HeightValue;
        }

        public float Length() {
            return LengthValue;
        }

        public Point GetPosition() {
            return Position;
        }

        public float Price() {
            return UnitPrice;
        }

        public override bool Equals(object obj) {

            bool areEqual;
            if (obj == null) {
                areEqual = false;
            } else {
                Opening otherOpening = (Opening)obj;
                areEqual = Position.Equals(otherOpening.GetPosition());
            }
            return areEqual;
        }

        public override int GetHashCode() {
            return Position.GetHashCode();
        }

        public abstract float CalculatePrice();

        public abstract float CalculateCost();
    }
}
