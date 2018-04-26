using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic  {

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

    }
}
