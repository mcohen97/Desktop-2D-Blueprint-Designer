using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicExceptions;

namespace Logic.Domain
{
    class WallsPositioner
    {
        private MaterialContainer materials;
        private PunctualComponentPositioner openingManager;
        private float Length;
        private float Width;


        public WallsPositioner(MaterialContainer blueprintMaterials, PunctualComponentPositioner anOpeningManager, float aWidth, float aLength) {
            materials = blueprintMaterials;
            openingManager = anOpeningManager;
            Length = aLength;
            Width = aWidth;
        }

        public  void InsertWall(Point from, Point to)
        {
            Wall newWall = new Wall(from, to);
            if (!newWall.IsHorizontal() && !newWall.IsVertical())
            {
                throw new OutOfRangeComponentException();
            }
            else if (!WallInRange(newWall))
            {
                throw new OutOfRangeComponentException();
            }
            else if (TakesOtherWallsPlace(newWall))
            {
                throw new CollinearWallsException();
            }
            else if (TakesAColumnPlace(newWall))
            {
                throw new ColumnInPlaceException();
            }
            else
            {
                InsertValidatedWall(newWall);
            }
        }

        private bool TakesOtherWallsPlace(Wall newWall)
        {
            return materials.GetWalls().Any(wall => wall.Overlaps(newWall));
        }
        public  void RemoveWall(Point from, Point to)
        {
            Wall aWall = new Wall(from, to);
            if (materials.ContainsWall(aWall))
            {
                materials.RemoveWall(aWall);
                openingManager.RemoveOpeningsOfWall(aWall);
                AdjustIntersection(aWall.Beginning());
                AdjustIntersection(aWall.End());
            }
        }

        private bool TakesAColumnPlace(Wall newWall)
        {
            bool existColumnInWallPlace = false;
            foreach (ISinglePointComponent column in materials.GetColumns())
            {
                if (newWall.DoesContainComponent(column) || column.GetPosition().Equals(newWall.End()) || column.GetPosition().Equals(newWall.Beginning()))
                {
                    existColumnInWallPlace = true;
                }
            }
            return existColumnInWallPlace;
        }

        //we assume in this method that the wall can be added
        private void InsertValidatedWall(Wall aWall)
        {
            if (IntersectsOtherWalls(aWall))
            {
                FractionNewIntersectedWall(aWall);
            }
            else
            {
                InsertUnintersectedWall(aWall);
            }
            }


        private void FractionNewIntersectedWall(Wall aWall)
        {
            List<Point> intersectionPoints = new List<Point>();
            foreach (Wall intersected in WallsIntersectedByThisOne(aWall))
            {
                PartIfDoesNotFormCorner(aWall, intersected, intersectionPoints);
            }

            if (IntersectionsExist(intersectionPoints))
            {
                intersectionPoints.Sort();
                SplitWall(aWall, intersectionPoints);
            }
        }

        private void InsertUnintersectedWall(Wall aWall) {
            if (Oversized(aWall))
            {
                InsertOversizedWall(aWall);
            }
            else
            {
                PlaceNewWall(aWall);
            }
        }

        private bool IntersectionsExist(ICollection<Point> intersections)
        {
            return intersections.Any();
        }

        private void PartWall(Wall aWall, Point splitPoint)
        {
            // we are replacing the old walls with two halves
            materials.RemoveWall(aWall);
            openingManager.RemoveOpening(splitPoint);
            CreateAndPlaceWall(aWall.Beginning(), splitPoint);
            CreateAndPlaceWall(splitPoint, aWall.End());
        }

        private void InsertOversizedWall(Wall newWall)
        {
            int maxLengthWallsCount = (int)(newWall.Length() / Constants.MAX_WALL_LENGTH);
            float lengthOfRemainingWall = newWall.Length() % Constants.MAX_WALL_LENGTH;
            Point vector = newWall.End() - newWall.Beginning();
            Point from = newWall.Beginning();
            Point to;
            for (int i = 0; i < maxLengthWallsCount; i++)
            {
                to = from.PointInSameLineAtSomeDistance(vector, Constants.MAX_WALL_LENGTH);
                CreateAndPlaceWall(from, to);
                from = to;
            }
            if (lengthOfRemainingWall > 0)
            {
                to = from.PointInSameLineAtSomeDistance(vector, lengthOfRemainingWall);
                CreateAndPlaceWall(from, to);
            }

        }

        private void PlaceNewWall(Wall newWall)
        {
            PlaceUnintersectedWall(newWall);
            AdjustIntersection(newWall.Beginning());
            AdjustIntersection(newWall.End());
        }

        private void PlaceUnintersectedWall(Wall aWall)
        {
            Beam BeginningBeam = new Beam(aWall.Beginning());
            Beam EndBeam = new Beam(aWall.End());
            PlaceBeamIfNotExists(BeginningBeam);
            PlaceBeamIfNotExists(EndBeam);
            materials.AddWall(aWall);
        }

        private void SplitWall(Wall newWall, List<Point> intersectionPoints)
        {
            if (!newWall.Beginning().Equals(intersectionPoints.First()))
            {
                InsertUnintersectedWall(new Wall(newWall.Beginning(), intersectionPoints.First()));
            }
            for (int i = 0; i < intersectionPoints.Count - 1; i++)
            {
                CreateAndPlaceWall(intersectionPoints[i], intersectionPoints[i + 1]);
            }
            if (!intersectionPoints.Last().Equals(newWall.End())) {
                CreateAndPlaceWall(intersectionPoints.Last(), newWall.End());
            }
        }

        private void CreateAndPlaceWall(Point from, Point to)
        {
            try
            {
                Wall generatedWall = new Wall(from, to);
                if (!Oversized(generatedWall))
                {
                    PlaceUnintersectedWall(generatedWall);
                }
                else
                {
                    InsertOversizedWall(generatedWall);
                }
            }
            catch (ZeroLengthWallException)
            {

            }

        }

        private bool Oversized(Wall aWall)
        {
            return aWall.Length() > Constants.MAX_WALL_LENGTH;
        }

        private bool WallInRange(Wall newWall)
        {
            return PointInRange(newWall.Beginning()) && PointInRange(newWall.End());
        }

        private bool PointInRange(Point aPoint)
        {
            return aPoint.IsInRange(Length, Width);
        }

        private void AdjustIntersection(Point intersection)
        {
            Beam affectedBeam = new Beam(intersection);
            List<Wall> involvedWalls = GetWallsSharingBeam(affectedBeam);
            if (!involvedWalls.Any())
            {
                materials.RemoveBeam(affectedBeam);
            }
            else if (involvedWalls.Count == 2)
            {
                EvaluateMergingWalls(involvedWalls[0], involvedWalls[1]);
            }

        }

        private void EvaluateMergingWalls(Wall wall1, Wall wall2)
        {
            bool theyAreContinuous = wall1.IsCollinearContinuous(wall2);
            bool LengthsSumTheLimitOrLess = wall1.Length() + wall2.Length() <= Constants.MAX_WALL_LENGTH;
            if (theyAreContinuous && LengthsSumTheLimitOrLess)
            {
                MergeWalls(wall1, wall2);
            }
        }

        private void MergeWalls(Wall wall1, Wall wall2)
        {
            Point intersection;
            if (wall1.Beginning().Equals(wall2.Beginning()) || wall1.Beginning().Equals(wall2.End()))
            {
                intersection = wall1.Beginning();
            }
            else
            {
                intersection = wall1.End();
            }

            Wall newWall = wall1.MergeCollinearContinuous(wall2);
            materials.RemoveWall(wall1);
            materials.RemoveWall(wall2);
            RemoveBeamInPoint(intersection);
            materials.AddWall(newWall);

        }
        private void PartIfDoesNotFormCorner(Wall aWall, Wall intersected, List<Point> intersectionPoints)
        {
            if (!aWall.IsConnected(intersected))
            {
                Point actualIntersection;
                actualIntersection = intersected.GetIntersection(aWall);
                PartWall(intersected, actualIntersection);
                intersectionPoints.Add(actualIntersection);
            }
            else
            {
                InsertUnintersectedWall(aWall);
            }

        }
        private void RemoveBeamInPoint(Point point)
        {
            Beam toRemove = new Beam(point);
            materials.RemoveBeam(toRemove);
        }

        private List<Wall> GetWallsSharingBeam(Beam aBeam)
        {
            return materials.GetWalls().Where(wall => wall.BelongsToEdge(aBeam)).ToList();
        }

        private bool IntersectsOtherWalls(Wall aWall)
        {
            return WallsIntersectedByThisOne(aWall).Any();
        }
     
        private ICollection<Wall> WallsIntersectedByThisOne(Wall newWall)
        {
            return materials.GetWalls().Where(wall => wall.DoesIntersect(newWall)).ToList();
        }

        private void PlaceBeamIfNotExists(Beam aBeam)
        {
            if (!materials.ContainsBeam(aBeam))
            {
                materials.AddBeam(aBeam);
            }
        }



    }
}
