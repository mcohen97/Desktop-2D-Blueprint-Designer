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

        public bool IsHorizontal() {
            return BeginningPoint.CoordY == EndPoint.CoordY;
        }

        public bool IsVertical() {
            return BeginningPoint.CoordX == EndPoint.CoordX;
        }

        
        public bool DoesIntersect(Wall otherWall) {
            float[] equationParameters = AlfaNumerator0_BetaNumerator1_Denominator2(otherWall);

            float alphaNumerator = equationParameters[0];
            float betaNumerator = equationParameters[1];
            float denominator = equationParameters[2];

            bool intersect = IntersectionPointExists(alphaNumerator, betaNumerator, denominator);

            return intersect;
        }

        public Point GetIntersection(Wall otherWall) {
            float[] equationParameters = AlfaNumerator0_BetaNumerator1_Denominator2(otherWall);

            float alphaNumerator = equationParameters[0];
            float betaNumerator = equationParameters[1];
            float denominator = equationParameters[2];

            bool intersect = IntersectionPointExists(alphaNumerator, betaNumerator, denominator);
            if (!intersect) {
                throw new WallsDoNotIntersectException();
            }
            return GetIntersectedPoint(alphaNumerator, denominator);

        }

        public bool IntersectionPointExists(float alphaNumerator, float betaNumerator, float denominator) {
            bool intersect = !CheckForCollinearity(denominator);
            intersect &= CompareNumeratorWithDenominator(alphaNumerator, denominator);
            intersect &= CompareNumeratorWithDenominator(betaNumerator, denominator);
            return intersect;
        }

        private bool CheckForCollinearity(float denominator) {
            return denominator == 0;
        }

        private bool CompareNumeratorWithDenominator(float numerator, float denominator) {
            float division = numerator / denominator;
            return division >= 0 && division <= 1;
        }
        public float[] AlfaNumerator0_BetaNumerator1_Denominator2(Wall otherWall) {

            Point a = EndPoint - BeginningPoint;
            Point b = otherWall.BeginningPoint - otherWall.EndPoint;
            Point c = BeginningPoint - otherWall.BeginningPoint;

            float alphaNumerator = b.CoordY * c.CoordX - b.CoordX * c.CoordY;
            float betaNumerator = a.CoordX * c.CoordY - a.CoordY * c.CoordX;
            float denominator = a.CoordY * b.CoordX - a.CoordX * b.CoordY;

            float[] returnArray = new float[] { alphaNumerator, betaNumerator, denominator };

            return returnArray;
        }

        private Point GetIntersectedPoint(float alphaNumerator, float denominator) {

            float alphaOfIntersection = alphaNumerator / denominator;
            float x = BeginningPoint.CoordX + alphaOfIntersection * (EndPoint.CoordX - BeginningPoint.CoordX);
            float y = BeginningPoint.CoordY + alphaOfIntersection * (EndPoint.CoordY - BeginningPoint.CoordY);
            return new Point(x, y);
        }
    }
}
