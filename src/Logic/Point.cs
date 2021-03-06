using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{

    public class Point : IComparable<Point>
    {

        public float CoordX { set; get; }
        public float CoordY { set; get; }

        public Point(float x, float y)
        {
            CoordX = x;
            CoordY = y;
        }

        public override bool Equals(object obj)
        {
            bool areEqual;
            if (obj == null || GetType() != obj.GetType())
            {
                areEqual = false;
            }
            else
            {
                Point otherPoint = (Point)obj;
                areEqual = (CoordX == otherPoint.CoordX) && (CoordY == otherPoint.CoordY);
            }
            return areEqual;
        }

        public override int GetHashCode()
        {
            return (int)(CoordX * CoordY);
        }

        public static Point operator -(Point first, Point second)
        {
            return new Point(first.CoordX - second.CoordX, first.CoordY - second.CoordY);
        }

        public static Point operator +(Point first, Point second)
        {
            return new Point(first.CoordX + second.CoordX, first.CoordY + second.CoordY);
        }

        public static Point operator *(float scalar, Point aPoint)
        {
            return new Point(scalar * aPoint.CoordX, scalar * aPoint.CoordY);
        }

        public float DistanceToOrigin()
        {
            return (float)Math.Sqrt(Math.Pow(CoordX, 2) + Math.Pow(CoordY, 2));
        }

        public int CompareTo(Point other)
        {
            float result = DistanceToOrigin() - other.DistanceToOrigin();
            int intAdaptedResult = 0;
            if (result < 0)
            {
                intAdaptedResult = -1;
            }
            if (result > 0)
            {
                intAdaptedResult = 1;
            }
            return intAdaptedResult;
        }

        public bool IsCloserToOriginThan(Point otherPoint)
        {
            return CompareTo(otherPoint) < 0;
        }

        public float DistanceToPoint(Point testPoint)
        {
            float distance = (float)Math.Sqrt(Math.Pow(CoordX - testPoint.CoordX, 2) + Math.Pow(CoordY - testPoint.CoordY, 2));
            return distance;
        }

        public Point PointInSameLineAtSomeDistance(Point vector, float distance)
        {
            float lambda = distance / (float)Math.Sqrt(Math.Pow(vector.CoordX, 2) + Math.Pow(vector.CoordY, 2));
            Point translated = this + lambda * vector;
            return translated;
        }

        public bool IsInRange(float xLimit, float yLimit)
        {
            bool xInRange = CoordX >= 0 && CoordX <= xLimit;
            bool yInRange = CoordY >= 0 && CoordY <= yLimit;
            return yInRange && xInRange;
        }
    }
}
