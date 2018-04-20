using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {

    public class Point {

        public int CoordX { set; get; }
        public int CoordY { set; get; }

        public Point(int x, int y) {
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
            return CoordX * CoordY;
        }

        public static Point operator -(Point first, Point second) {
            return new Point(first.CoordX - second.CoordX, first.CoordY - second.CoordY);
        }
    }
}
