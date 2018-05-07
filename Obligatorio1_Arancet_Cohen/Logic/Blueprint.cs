using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {
    public class Blueprint {

        private int Length;//Horizontal X Mesaure
        private int Width;//Vertical Y Mesaure
        private BuildingComponentContainer materials;

        public Blueprint(int aLength, int aWidth) {
            Length = aLength;
            Width = aWidth;
            materials = new BuildingComponentContainer();
        }

        public BuildingComponentContainer GetComponentsContainer() {
            return materials;
        }

        public void InsertWall(Wall newWall) {
            if (!WallInRange(newWall)) {
                throw new OutOfRangeComponentException();
            } else if (TakesOtherWallsPlace(newWall)) {
                throw new CollinearWallsException();
            } else if (newWall.Length()>5) {
                InsertOversizedWall(newWall);
            }else{
                InsertValidatedWall(newWall);
            }
        }

        private void InsertOversizedWall(Wall newWall) {
            int maxLengthWallsCount = (int)newWall.Length() / 5;
            float lengthOfRemainingWall= newWall.Length() % 5;
            Point vector = newWall.End()-newWall.Beginning();
            Point from=newWall.Beginning();
            Point to;
            Wall newFraction;
            for (int i = 0; i < maxLengthWallsCount; i++) {
                to = from.PointInSameLineAtSomeDistance(vector, 5);
                newFraction = new Wall(from, to);
                InsertValidatedWall(newFraction);
                from = to;
            }
            to = from.PointInSameLineAtSomeDistance(vector, lengthOfRemainingWall);
            newFraction = new Wall(from, to);
            InsertValidatedWall(newFraction);
        }

        //we assume in this method that the wall an be added
        private void InsertValidatedWall(Wall aWall) {
            if (!IntersectsOtherWalls(aWall)) {
                PlaceNewWall(aWall);
            } else {
                List<Point> intersectionPoints = new List<Point>();
                Point actualIntersection;
                foreach (Wall intersected in WallsIntersectedByThisOne(aWall)) {
                    actualIntersection = intersected.GetIntersection(aWall);
                    CreateFractionWall(intersected.Beginning(), actualIntersection);
                    CreateFractionWall(actualIntersection, intersected.End());
                    materials.RemoveWall(intersected); // we are replacing the old walls with two halves
                    intersectionPoints.Add(actualIntersection);
                }
                intersectionPoints.Sort();
                SplitWall(aWall, intersectionPoints);

            }
        }

        private void PlaceNewWall(Wall newWall) {
            if (newWall.Length() <= 5) {
                Beam BeginningBeam = new Beam(newWall.Beginning());
                Beam EndBeam = new Beam(newWall.End());
                PlaceBeamIfNotExists(BeginningBeam);
                PlaceBeamIfNotExists(EndBeam);
                materials.addWall(newWall);
            } else {

            }
        }

        private void PlaceBeamIfNotExists(Beam aBeam) {
            if (!materials.ContainsBeam(aBeam)) {
                materials.AddBeam(aBeam);
            }
        }

        private void SplitWall(Wall newWall, List<Point> intersectionPoints) {
            CreateFractionWall(newWall.Beginning(), intersectionPoints.First());
            for (int i = 1; i < intersectionPoints.Count-1; i++) {
                CreateFractionWall(intersectionPoints[i], intersectionPoints[i + 1]);
            }
            CreateFractionWall(intersectionPoints.Last(), newWall.End());
           
        }

        private void CreateFractionWall(Point from, Point to) {
            try {
                Wall generatedWall = new Wall(from, to);
                PlaceNewWall(generatedWall);//pending refactory
            } catch (ZeroLengthWallException) {
            }
        }

        private bool WallInRange(Wall newWall) {
            return PointInRange(newWall.Beginning()) && PointInRange(newWall.End());
        }

        private bool PunctualComponentInRange(ISinglePointComponent newComponent) {
            return PointInRange(newComponent.GetPosition());
        }

        private bool PointInRange(Point aPoint) {
            bool xInRange = aPoint.CoordX >= 0 && aPoint.CoordY <= Length;
            bool yInRange = aPoint.CoordY >= 0 && aPoint.CoordY <= Width;
            return xInRange && yInRange;
        }

        private bool TakesOtherWallsPlace(Wall newWall) {
            bool overlaps = false;
            IEnumerator<Wall> itr = (IEnumerator<Wall>)materials.GetWalls().GetEnumerator();
            Wall existing;
            while (itr.MoveNext() && !overlaps) {
                existing = itr.Current;
                overlaps |= existing.Overlaps(newWall);
            }
            return overlaps;
        }

        private bool IntersectsOtherWalls(Wall aWall) {
            return WallsIntersectedByThisOne(aWall).Any();
        }

        private ICollection<Wall> WallsIntersectedByThisOne(Wall newWall){
            List<Wall> intersectedWalls = new List<Wall>();
           
                foreach (Wall existentWall in materials.GetWalls()) {
                    if (existentWall.DoesIntersect(newWall)) {
                        intersectedWalls.Add(existentWall);
                    }
                }
            return intersectedWalls;
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
        
        private bool OccupiedPosition(ISinglePointComponent punctualComponent) {
            bool occupied=false;
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

        public void RemoveWall(Wall aWall) {
            if (materials.ContainsWall(aWall)) {
                materials.RemoveWall(aWall);
                RemoveOpeningsOfWall(aWall);
                MergeAdjacentWallsIfNeeded(aWall);
            }
        }

        private void MergeAdjacentWallsIfNeeded(Wall aWall) {
            Beam from = new Beam(aWall.Beginning());
            Beam to = new Beam(aWall.End());
            if (materials.ContainsBeam(from)) {
                AdjustToRemoval(from);
            }
            if (materials.ContainsBeam(to)) {
                AdjustToRemoval(to);
            }
            
        }

        private void RemoveOrphanBeams(Wall aWall) {
            Beam from = new Beam(aWall.Beginning());
            Beam to = new Beam(aWall.End());
            RemoveIfOrphan(from);
            RemoveIfOrphan(to);
        }

        private void RemoveIfOrphan(Beam aBeam) {
            if (!GetWallsSharingBeam(aBeam).Any()) {
                materials.RemoveBeam(aBeam);
            }
        }

        private void RemoveOpeningsOfWall(Wall aWall) {
            foreach (Opening existing in GetOpeningsFromWall(aWall)) {
                materials.RemoveOpening(existing);
            }
        }


        private IEnumerable<Wall> GetWallsSharingBeam(Beam aBeam) {
            List<Wall> sharingBeam = new List<Wall>();
            foreach(Wall existing in materials.GetWalls()) {
                if (existing.BelongsToEdge(aBeam)) {
                    sharingBeam.Add(existing);
                }
            }
            return sharingBeam.AsEnumerable<Wall>(); 
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

        private void AdjustToRemoval(Beam affectedBeam) {
            List<Wall> involvedWalls = new List<Wall>();
            foreach (Wall existingWall in materials.GetWalls()) {
                if (existingWall.BelongsToEdge(affectedBeam)) {
                    involvedWalls.Add(existingWall);
                }
            }
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
