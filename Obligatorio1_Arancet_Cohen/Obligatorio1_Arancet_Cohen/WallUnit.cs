using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic{

    class WallUnit : IBuildingComponent{

        public WallUnit(Point from) {
            HeightValue = 3;
            WidthValue = 0.20F;
            LengthValue = 1;
            BeginningValue =from;
            UnitPriceValue =50;
        }

        private float HeightValue {set; get; }
        private float WidthValue {set; get; }
        public float LengthValue {set; get; }
        private Point BeginningValue {set; get; }
        private Point EndValue {set; get; }
        private float UnitPriceValue {set; get; }

        public float Height(){
            return HeightValue;
        }

        public float Width(){
            return WidthValue;
        }

        public float Length(){
            return LengthValue;
        }

        public Point Beginning(){
            return BeginningValue;
        }

        public float UnitPrice(){
            return UnitPriceValue;
        }
    }
}
