using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class Opening : IBuildingComponent
    {
        private float HeightValue { get; set; }
        private float LengthValue { get; set; }
        private Point Position { get; set; }
        private float UnitPrice { get; set; }

        public Opening(Point aPlace) {
            Position = aPlace;
        }

        public float Height()
        {
            return HeightValue;
        }

        public float Length()
        {
            return LengthValue;
        }

        public Point Beginning()
        {
            return Position;
        }

        public float Price()
        {
            return UnitPrice;
        }
    }
}
