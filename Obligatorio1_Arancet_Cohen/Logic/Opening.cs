using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {

    public abstract class Opening : IBuildingComponent {

        protected float HeightValue { get; set; }
        protected float LengthValue { get; set; }
        protected Point Position { get; set; }
        protected float UnitPrice { get; set; }

        public Opening(Point aPlace) {
            Position = aPlace;
        }

        public float Height() {
            return HeightValue;
        }

        public float Length() {
            return LengthValue;
        }

        public Point Beginning() {
            return Position;
        }

        public float Price() {
            return UnitPrice;
        }
    }
}
