using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {

    public class Wall:IComponent3D {

        public Wall(Point from, Point to) {
            if (from.Equals(to)) {
                throw new ZeroLengthWallException();
            }
            HeightValue = 3;
            WidthValue = 0.20F;
            if (from.IsCloserToOriginThan(to)) {
                BeginningPoint = from;
                EndPoint = to;
            } else {
                BeginningPoint = to;
                EndPoint = from;
            }
            UnitPriceValue = 50;
        }

        private float HeightValue { set; get; }
        private float WidthValue { set; get; }
        private Point BeginningPoint { set; get; }
        private Point EndPoint { set; get; }
        private float UnitPriceValue { set; get; }

        public float Height() {
            return HeightValue;
        }

        public float Width() {
            return WidthValue;
        }

        public float Length() {
            return Beginning().DistanceToPoint(End());
        }

        public Point Beginning() {
            return BeginningPoint;
        }

        public Point End() {
            return EndPoint;
        }

        public float Price() {
            return UnitPriceValue;
        }

        public bool IsHorizontal() {
            return BeginningPoint.CoordY == EndPoint.CoordY;
        }

        public bool IsVertical() {
            return BeginningPoint.CoordX == EndPoint.CoordX;
        }

        public bool DoesIntersect(Wall otherWall) {
            bool intersects;
            try {
                GetIntersection(otherWall);
                intersects = true;
            } catch(CollinearWallsException) {
                intersects = false;

            } catch (WallsDoNotIntersectException) {
                intersects = false;
            }
            return intersects;
        }

        public Point GetIntersection(Wall otherWall) {

            Point a = EndPoint - BeginningPoint;
            Point b = otherWall.BeginningPoint - otherWall.EndPoint;
            Point c = BeginningPoint - otherWall.BeginningPoint;

            float alphaNumerator = b.CoordY * c.CoordX - b.CoordX * c.CoordY;
            float betaNumerator = a.CoordX * c.CoordY - a.CoordY * c.CoordX;
            float denominator = a.CoordY * b.CoordX - a.CoordX * b.CoordY;

            bool parallel = CheckForParalelism(denominator);
            
            if (parallel && SharesSpace(otherWall)) { 
                //if they are parallel and share points, they are collinear
                throw new CollinearWallsException();
            } else {
                bool intersect = IntersectionPointExists(alphaNumerator, betaNumerator, denominator);
                if (!intersect) {
                    throw new WallsDoNotIntersectException();
                } else {
                    return GetIntersectedPoint(alphaNumerator, denominator);
                }
            }


        }

        private bool SharesSpace(Wall otherWall) {
            bool overlaps = Equals(otherWall);
            overlaps |= DoesContainPoint(otherWall.Beginning()) || DoesContainPoint(otherWall.End());
            overlaps |= otherWall.DoesContainPoint(Beginning()) || otherWall.DoesContainPoint(End());
            return overlaps;
        }

        public bool Overlaps(Wall aWall) {
            return !DoesIntersect(aWall) && SharesSpace(aWall);
        }

        public bool IntersectionPointExists(float alphaNumerator, float betaNumerator, float denominator) {
            bool intersect = CompareNumeratorWithDenominator(alphaNumerator, denominator);
            intersect &= CompareNumeratorWithDenominator(betaNumerator, denominator);
            return intersect;
        }

        private bool CheckForParalelism(float denominator) {
            return denominator == 0;
        }

        private bool CompareNumeratorWithDenominator(float numerator, float denominator) {
            float division = numerator / denominator;
            return division >= 0 && division <= 1;
        }

        private Point GetIntersectedPoint(float alphaNumerator, float denominator) {

            float alphaOfIntersection = alphaNumerator / denominator;
            float x = BeginningPoint.CoordX + alphaOfIntersection * (EndPoint.CoordX - BeginningPoint.CoordX);
            float y = BeginningPoint.CoordY + alphaOfIntersection * (EndPoint.CoordY - BeginningPoint.CoordY);
            return new Point(x, y);
        }

        public bool DoesContainComponent(ISinglePointComponent component) {
            return DoesContainPoint(component.GetPosition());
        }

        private bool DoesContainPoint(Point aPoint) {
            bool isContained;
            if (BelongsToEdge(aPoint)) {
                isContained = false;
            } else {

                float distanceAC = Beginning().DistanceToPoint(aPoint);
                float distanceCB = End().DistanceToPoint(aPoint);
                float distanceAB = Length();
                isContained = Math.Abs((distanceAC + distanceCB) - distanceAB)<0.1;
                //should be a ==, but minimal difference is generated
            }
            return isContained;

        }

        public bool BelongsToEdge(Point aPoint) {
            return aPoint.Equals(Beginning()) || aPoint.Equals(End());
        }

        public bool BelongsToEdge(ISinglePointComponent punctualComponent) {
            return BelongsToEdge(punctualComponent.GetPosition());
        }

        public override bool Equals(object obj) {

            bool areEqual;
            if (obj == null || GetType() != obj.GetType()) {
                areEqual = false;
            } else {
                Wall otherWall = (Wall)obj;

                //they are equal if they have the same two points
                areEqual = BeginningPoint.Equals(otherWall.BeginningPoint) && EndPoint.Equals(otherWall.EndPoint);
                areEqual |= EndPoint.Equals(otherWall.BeginningPoint) && BeginningPoint.Equals(otherWall.EndPoint);
            }
            return areEqual;
        }

        public override int GetHashCode() {
            return BeginningPoint.GetHashCode() * EndPoint.GetHashCode();
        }

        public bool IsContinuous(Wall otherWall) {
            Wall auxWall = new Wall(Beginning(),otherWall.End());
            //this wall should contain the other wall, if they are collinear
            return IsConnected(otherWall) && auxWall.Overlaps(otherWall);
        }

        public bool IsConnected(Wall otherWall) {
            return BelongsToEdge(otherWall.Beginning()) || BelongsToEdge(otherWall.End());
        }
    }
}
