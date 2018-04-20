using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {

    public class Point {

        public float CoordX { set; get; }
        public float CoordY { set; get; }

        public Point(float x, float y) {
            CoordX = x;
            CoordY = y;
        }

        public override bool Equals(object obj) {
            bool areEqual;
            if (obj == null || GetType() != obj.GetType()) {
                areEqual = false;
            } else {
                Point otherPoint = (Point)obj;
                areEqual = (CoordX == otherPoint.CoordX) && (CoordY == otherPoint.CoordY);
            }
            return areEqual;
        }

        public override int GetHashCode() {
            return (int)(CoordX * CoordY);
        }

        public static Point operator -(Point first, Point second) {
            return new Point(first.CoordX - second.CoordX, first.CoordY - second.CoordY);
        }
    }
}
