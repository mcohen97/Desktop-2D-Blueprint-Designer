using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicExceptions;

namespace Logic.Domain
{

    public class Wall : IComponent3D, IMaterialType
    {

        private float heightValue;
        private float widthValue;
        private Point beginningPoint;
        private Point endPoint;

        public Wall(Point from, Point to)
        {
            if (from.Equals(to))
            {
                throw new ZeroLengthWallException();
            }
            heightValue = 3;
            widthValue = 0.20F;
            if (from.IsCloserToOriginThan(to))
            {
                beginningPoint = from;
                endPoint = to;
            }
            else
            {
                beginningPoint = to;
                endPoint = from;
            }
        }

        public float Height()
        {
            return heightValue;
        }

        public float Width()
        {
            return widthValue;
        }

        public float Length()
        {
            return Beginning().DistanceToPoint(End());
        }

        public Point Beginning()
        {
            return beginningPoint;
        }

        public Point End()
        {
            return endPoint;
        }

        public bool IsHorizontal()
        {
            return beginningPoint.CoordY == endPoint.CoordY;
        }

        public bool IsVertical()
        {
            return beginningPoint.CoordX == endPoint.CoordX;
        }

        public bool DoesIntersect(Wall otherWall)
        {
            return !IsConnected(otherWall) && CalculateIfIntersects(otherWall);
            
        }

        private bool CalculateIfIntersects(Wall otherWall) {
            float[] equationVariables = AlfaNumerator_BetaNumerator_Denominator(otherWall);

            float alphaNumerator = equationVariables[0];
            float betaNumerator = equationVariables[1];
            float denominator = equationVariables[2];

            bool intersect = !CheckForParallelism(denominator);
            intersect &= CompareNumeratorWithDenominator(alphaNumerator, denominator);
            intersect &= CompareNumeratorWithDenominator(betaNumerator, denominator);

            return intersect;

        }

        public Point GetIntersection(Wall otherWall)
        {

            float[] equationVariables = AlfaNumerator_BetaNumerator_Denominator(otherWall);

            float alphaNumerator = equationVariables[0];
            float betaNumerator = equationVariables[1];
            float denominator = equationVariables[2];

            bool parallel = CheckForParallelism(denominator);

            if (parallel && SharesSpace(otherWall))
            {
                //if they are parallel and share points, they are collinear
                throw new CollinearWallsException();
            }
            else
            {
                bool intersect = IntersectionPointExists(alphaNumerator, betaNumerator, denominator);
                if (!intersect)
                {
                    throw new WallsDoNotIntersectException();
                }
                else
                {
                    return GetIntersectedPoint(alphaNumerator, denominator);
                }
            }


        }

        private float[] AlfaNumerator_BetaNumerator_Denominator(Wall aWall)
        {
            float[] variables = new float[3];

            Point a = endPoint - beginningPoint;
            Point b = aWall.beginningPoint - aWall.endPoint;
            Point c = beginningPoint - aWall.beginningPoint;

            variables[0] = b.CoordY * c.CoordX - b.CoordX * c.CoordY;
            variables[1] = a.CoordX * c.CoordY - a.CoordY * c.CoordX;
            variables[2] = a.CoordY * b.CoordX - a.CoordX * b.CoordY;

            return variables;
        }

        private bool SharesSpace(Wall otherWall)
        {
            bool overlaps = Equals(otherWall);
            overlaps |= DoesContainPoint(otherWall.Beginning()) || DoesContainPoint(otherWall.End());
            overlaps |= otherWall.DoesContainPoint(Beginning()) || otherWall.DoesContainPoint(End());
            return overlaps;
        }

        public bool Overlaps(Wall aWall)
        {
            return !DoesIntersect(aWall) && SharesSpace(aWall);
        }

        private bool IntersectionPointExists(float alphaNumerator, float betaNumerator, float denominator)
        {
            bool intersect = CompareNumeratorWithDenominator(alphaNumerator, denominator);
            intersect &= CompareNumeratorWithDenominator(betaNumerator, denominator);
            return intersect;
        }

        private bool CheckForParallelism(float denominator)
        {
            return denominator == 0;
        }

        private bool CompareNumeratorWithDenominator(float numerator, float denominator)
        {
            float division = numerator / denominator;
            return division >= 0 && division <= 1;
        }

        private Point GetIntersectedPoint(float alphaNumerator, float denominator)
        {

            float alphaOfIntersection = alphaNumerator / denominator;
            float x = beginningPoint.CoordX + alphaOfIntersection * (endPoint.CoordX - beginningPoint.CoordX);
            float y = beginningPoint.CoordY + alphaOfIntersection * (endPoint.CoordY - beginningPoint.CoordY);
            return new Point(x, y);
        }

        public bool DoesContainComponent(ISinglePointComponent component)
        {
            return DoesContainPoint(component.GetPosition());
        }

        public bool DoesContainPoint(Point aPoint)
        {
            bool isContained;
            if (BelongsToEdge(aPoint))
            {
                isContained = false;
            }
            else
            {

                float distanceAC = Beginning().DistanceToPoint(aPoint);
                float distanceCB = End().DistanceToPoint(aPoint);
                float distanceAB = Length();
                isContained = Math.Abs((distanceAC + distanceCB) - distanceAB) < 0.1;
                //should be a ==, but minimal difference is generated
            }
            return isContained;

        }

        public bool BelongsToEdge(ISinglePointComponent punctualComponent)
        {
            return BelongsToEdge(punctualComponent.GetPosition());
        }

        private bool BelongsToEdge(Point aPoint)
        {
            return aPoint.Equals(Beginning()) || aPoint.Equals(End());
        }


        public bool IsCollinearContinuous(Wall otherWall)
        {
            bool continuous = false;
            if (IsConnected(otherWall))
            {
                Wall merge = MergeCollinearContinuous(otherWall);
                continuous = merge.Length() == (Length() + otherWall.Length());
            }
            return continuous;
        }

        public bool IsConnected(Wall otherWall)
        {
            return BelongsToEdge(otherWall.Beginning()) || BelongsToEdge(otherWall.End());
        }

        public Wall MergeCollinearContinuous(Wall otherWall)
        {//as beginning is closer to origin than end, this logic always work
            Point newBeginning;
            Point newEnd;
            if (Beginning().IsCloserToOriginThan(otherWall.Beginning()))
            {
                newBeginning = Beginning();
                newEnd = otherWall.End();
            }
            else
            {
                newBeginning = otherWall.Beginning();
                newEnd = End();
            }
            return new Wall(newBeginning, newEnd);
        }


        public ComponentType GetComponentType()
        {
            return ComponentType.WALL;
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
                Wall otherWall = (Wall)obj;

                //they are equal if they have the same two points
                areEqual = beginningPoint.Equals(otherWall.beginningPoint) && endPoint.Equals(otherWall.endPoint);
                areEqual |= endPoint.Equals(otherWall.beginningPoint) && beginningPoint.Equals(otherWall.endPoint);
            }
            return areEqual;
        }

        public override int GetHashCode()
        {
            return beginningPoint.GetHashCode() * endPoint.GetHashCode();
        }

    }
}
