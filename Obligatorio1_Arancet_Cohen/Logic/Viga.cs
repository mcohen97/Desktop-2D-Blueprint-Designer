using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Viga : IBuildingComponent
    {
        private Point Position { get; set; }
        private float HeightValue { get; set; }
        private float WidthValue { get; set; }
        private float UnitPrice { get; set; }

        public Viga(Point aPlace) {
            Position = aPlace;
            HeightValue = 3;
            WidthValue = 0.20F;
            UnitPrice = 50;
        }

        public float Height()
        {
            return HeightValue;
        }

        public float Width()
        {
            return WidthValue;
        }

        public float Length()
        {
            return 0;
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
