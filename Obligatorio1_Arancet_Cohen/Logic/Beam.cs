using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {

    public class Beam : ISinglePointComponent {

        private Point Position { get; set; }
        private float HeightValue { get; set; }
        private float UnitPrice { get; set; }

        public Beam(Point aPlace) {
            Position = aPlace;
            HeightValue = 3;
            UnitPrice = 50;
        }

        public float Height() {
            return HeightValue;
        }

        public Point GetPosition() {
            return Position;
        }

        public float Price() {
            return UnitPrice;
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
    }
}
