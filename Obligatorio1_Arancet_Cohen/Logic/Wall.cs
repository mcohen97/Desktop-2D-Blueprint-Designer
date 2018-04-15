using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic{

    public class Wall : IBuildingComponent{

        public Wall(Point from, Point to) {
            HeightValue = 3;
            WidthValue = 0.20F;
            BeginningPoint =from;
            EndPoint =to;
            UnitPriceValue =50;
        }

        private float HeightValue {set; get; }
        private float WidthValue {set; get; }
        private Point BeginningPoint {set; get; }
        private Point EndPoint {set; get; }
        private float UnitPriceValue {set; get; }

        public float Height(){
            return HeightValue;
        }

        public float Width(){
            return WidthValue;
        }

        public float Length(){
            float distance= (float)Math.Sqrt( Math.Pow((BeginningPoint.CoordX - EndPoint.CoordX),2) + Math.Pow((BeginningPoint.CoordY - EndPoint.CoordY),2));
            return distance;
        }

        public Point Beginning(){
            return BeginningPoint;
        }

        public Point End(){
            return EndPoint;
        }

        public float Price(){
            return UnitPriceValue;
        }
    }
}
