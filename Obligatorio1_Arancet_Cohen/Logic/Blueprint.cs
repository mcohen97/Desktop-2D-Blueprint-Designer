using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic {
    public class Blueprint:IBlueprint {

        private int length;//Horizontal X Mesaure
        private int width;//Vertical Y Mesaure
        private BuildingComponentContainer materials;
        private string name;

        public Blueprint(int aLength, int aWidth,string aName) {
            length = aLength;
            width = aWidth;
            name = aName;
            materials = new BuildingComponentContainer();
        }

        public Blueprint(int aLength, int aWidth, BuildingComponentContainer container) {
            length = aLength;
            width = aWidth;
            materials = container;
        }

        public void InsertWall(Point from, Point to) {
            Wall newWall = new Wall(from, to);
            if (!newWall.IsHorizontal() && !newWall.IsVertical()) {
                throw new OutOfRangeComponentException("No es paralela a los ejes");
            } else if (!WallInRange(newWall)) {
                throw new OutOfRangeComponentException();
            } else if (TakesOtherWallsPlace(newWall)) {
                throw new CollinearWallsException();
            } else {
                InsertValidatedWall(newWall);
            }
        }

        public void RemoveWall(Point from, Point to) {
            Wall aWall = new Wall(from, to);
            if (materials.ContainsWall(aWall)) {
                materials.RemoveWall(aWall);
                RemoveOpeningsOfWall(aWall);
                AdjustIntersection(aWall.Beginning());
                AdjustIntersection(aWall.End());
            }
        }

        public void InsertOpening(Opening newOpening) {
            if (!PunctualComponentInRange(newOpening)) {
                throw new OutOfRangeComponentException();
            } else {
                bool belongsToWall = BelongsToAWall(newOpening);
                if (belongsToWall && !OccupiedPosition(newOpening)) {
                    materials.AddOpening(newOpening);
                } else if (!belongsToWall) {
                    throw new ComponentOutOfWallException();
                }
            }
        }

        public void RemoveOpening(Opening anOpening) {
            if (materials.ContainsOpening(anOpening)) {
                materials.RemoveOpening(anOpening);
            }
        }

        //we assume in this method that the wall an be added
        private void InsertValidatedWall(Wall aWall) {
            if (IntersectsOtherWalls(aWall)) {
                FractionNewIntersectedWall(aWall);
            } else if (Oversized(aWall)) {
                InsertOversizedWall(aWall);
            } else {
                PlaceNewWall(aWall);
            }
        }

        private void FractionNewIntersectedWall(Wall aWall) {
            List<Point> intersectionPoints = new List<Point>();
            Point actualIntersection;
            foreach (Wall intersected in WallsIntersectedByThisOne(aWall)) {
                actualIntersection = intersected.GetIntersection(aWall);
                // we are replacing the old walls with two halves
                materials.RemoveWall(intersected);
                RemoveOpeningIfExists(actualIntersection);
                CreateAndPlaceWall(intersected.Beginning(), actualIntersection);
                CreateAndPlaceWall(actualIntersection, intersected.End());
                intersectionPoints.Add(actualIntersection);
            }
            intersectionPoints.Sort();
            SplitWall(aWall, intersectionPoints);
        }

        private void RemoveOpeningIfExists(Point actualIntersection) {
            Opening op = new Door(actualIntersection);
            if (materials.ContainsOpening(op)) {
                materials.RemoveOpening(op);
            }
        }

        private void InsertOversizedWall(Wall newWall) {
            int maxLengthWallsCount = (int)newWall.Length() / 5;
            float lengthOfRemainingWall = newWall.Length() % 5;
            Point vector = newWall.End() - newWall.Beginning();
            Point from = newWall.Beginning();
            Point to;
            for (int i = 0; i < maxLengthWallsCount; i++) {
                to = from.PointInSameLineAtSomeDistance(vector, 5);
                CreateAndPlaceWall(from, to);
                from = to;
            }
            to = from.PointInSameLineAtSomeDistance(vector, lengthOfRemainingWall);
            CreateAndPlaceWall(from, to);

        }

        private void PlaceNewWall(Wall newWall) {
            PlaceUnintersectedWall(newWall);
            AdjustIntersection(newWall.Beginning());
            AdjustIntersection(newWall.End());
        }

        private void PlaceUnintersectedWall(Wall aWall) {
            Beam BeginningBeam = new Beam(aWall.Beginning());
            Beam EndBeam = new Beam(aWall.End());
            PlaceBeamIfNotExists(BeginningBeam);
            PlaceBeamIfNotExists(EndBeam);
            materials.addWall(aWall);
        }

        private void PlaceBeamIfNotExists(Beam aBeam) {
            if (!materials.ContainsBeam(aBeam)) {
                materials.AddBeam(aBeam);
            }
        }

        private void SplitWall(Wall newWall, List<Point> intersectionPoints) {
            CreateAndPlaceWall(newWall.Beginning(), intersectionPoints.First());
            for (int i = 0; i < intersectionPoints.Count - 1; i++) {
                CreateAndPlaceWall(intersectionPoints[i], intersectionPoints[i + 1]);
            }
            CreateAndPlaceWall(intersectionPoints.Last(), newWall.End());

        }

        private void CreateAndPlaceWall(Point from, Point to) {
            try {
                Wall generatedWall = new Wall(from, to);
                if (!Oversized(generatedWall)) {
                    PlaceUnintersectedWall(generatedWall);
                } else {
                    InsertOversizedWall(generatedWall);
                }
            } catch (ZeroLengthWallException) {

            }

        }

        private bool Oversized(Wall aWall) {
            return aWall.Length() > 5;
        }

        private bool WallInRange(Wall newWall) {
            return PointInRange(newWall.Beginning()) && PointInRange(newWall.End());
        }

        private bool PunctualComponentInRange(ISinglePointComponent newComponent) {
            return PointInRange(newComponent.GetPosition());
        }

        private bool PointInRange(Point aPoint) {
            return aPoint.IsInRange(length,width);
        }

        private bool TakesOtherWallsPlace(Wall newWall) {
            bool overlaps = false;
            foreach (Wall existing in materials.GetWalls()) {
                overlaps |= existing.Overlaps(newWall);
            }
            return overlaps;
        }

        private bool IntersectsOtherWalls(Wall aWall) {
            return WallsIntersectedByThisOne(aWall).Any();
        }

        private ICollection<Wall> WallsIntersectedByThisOne(Wall newWall) {
            List<Wall> intersectedWalls = new List<Wall>();

            foreach (Wall existentWall in materials.GetWalls()) {
                if (existentWall.DoesIntersect(newWall)) {
                    intersectedWalls.Add(existentWall);
                }
            }
            return intersectedWalls;
        }

        private bool OccupiedPosition(ISinglePointComponent punctualComponent) {
            bool occupied = false;
            foreach (Opening existing in materials.GetOpenings()) {
                occupied |= punctualComponent.GetPosition().Equals(existing.GetPosition());
            }
            if (!occupied) {
                foreach (Beam existing in materials.GetBeams()) {
                    occupied |= punctualComponent.GetPosition().Equals(existing.GetPosition());
                }
            }
            return occupied;
        }

        private bool BelongsToAWall(Opening newOpening) {
            IEnumerator<Wall> itr = (IEnumerator<Wall>)materials.GetWalls().GetEnumerator();
            bool doesBelong = false;
            Wall existing;
            while (itr.MoveNext() && !doesBelong) {
                existing = itr.Current;
                doesBelong |= existing.DoesContainComponent(newOpening);
            }
            return doesBelong;
        }

        private void RemoveOpeningsOfWall(Wall aWall) {
            foreach (Opening existing in GetOpeningsFromWall(aWall)) {
                materials.RemoveOpening(existing);
            }
        }

        private List<Wall> GetWallsSharingBeam(Beam aBeam) {
            List<Wall> sharingBeam = new List<Wall>();
            foreach (Wall existing in materials.GetWalls()) {
                if (existing.BelongsToEdge(aBeam)) {
                    sharingBeam.Add(existing);
                }
            }
            return sharingBeam;
        }

        private IEnumerable<Opening> GetOpeningsFromWall(Wall aWall) {
            List<Opening> belonging = new List<Opening>();
            foreach (Opening existing in materials.GetOpenings()) {
                if (aWall.DoesContainComponent(existing)) {
                    belonging.Add(existing);
                }
            }
            return belonging.AsEnumerable<Opening>();
        }

        private void AdjustIntersection(Point intersection) {
            Beam affectedBeam = new Beam(intersection);
            List<Wall> involvedWalls = GetWallsSharingBeam(affectedBeam);
            if (!involvedWalls.Any()) {
                materials.RemoveBeam(affectedBeam);
            } else if (involvedWalls.Count == 2) {
                EvaluateMergingWalls(involvedWalls[0], involvedWalls[1]);
            }

        }

        private void EvaluateMergingWalls(Wall wall1, Wall wall2) {
            bool theyAreContinuous = wall1.IsContinuous(wall2);
            bool LengthsSumLessThanLimit = wall1.Length() + wall2.Length() < 5;
            if (theyAreContinuous && LengthsSumLessThanLimit) {
                MergeWalls(wall1, wall2);
            }
        }

        private void MergeWalls(Wall wall1, Wall wall2) {
            //create wall, beginning with the wall closest to origin
            Point newBeginning;
            Point newEnd;
            if (wall1.Beginning().IsCloserToOriginThan(wall2.Beginning())) {
                newBeginning = wall1.Beginning();
                newEnd = wall2.End();
                RemoveBeamInPoint(wall1.End());
            } else {
                newBeginning = wall2.Beginning();
                newEnd = wall2.End();
                RemoveBeamInPoint(wall1.Beginning());
            }
            materials.RemoveWall(wall1);
            materials.RemoveWall(wall2);
            Wall newWall = new Wall(newBeginning, newEnd);
            materials.addWall(newWall);

        }

        private void RemoveBeamInPoint(Point point) {
            Beam toRemove = new Beam(point);
            materials.RemoveBeam(toRemove);
        }

        
    }
}
