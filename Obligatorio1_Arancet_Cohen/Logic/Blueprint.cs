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
            if (!InRange(newWall.Beginning()) || !InRange(newWall.End())) {
                throw new OutOfRangeComponentException();
            } else {
                if (!IntersectsOtherWalls(newWall)) {
                    PlaceNewWall(newWall);
                } else {
                    List<Point> intersectionPoints = new List<Point>();
                    Point actualIntersection;
                    foreach (Wall intersected in WallsIntersectedByThisOne(newWall)) {
                        actualIntersection = intersected.GetIntersection(newWall);
                        Wall firstHalf = new Wall(intersected.Beginning(),actualIntersection);
                        Wall secondHalf = new Wall(actualIntersection, intersected.End());
                        materials.RemoveWall(intersected); // we are replacing the old walls with two halfs
                        AdjustWall(firstHalf);
                        AdjustWall(secondHalf);
                        intersectionPoints.Add(actualIntersection);
                    }
                    intersectionPoints.Sort();
                    SplitWall(newWall, intersectionPoints);
                }
            }
        }

        private void PlaceNewWall(Wall newWall) {
            Beam BeginningBeam = new Beam(newWall.Beginning());
            Beam EndBeam = new Beam(newWall.End());
            PlaceBeamIfNotExists(BeginningBeam);
            PlaceBeamIfNotExists(EndBeam);
            materials.addWall(newWall);
        }

        private void PlaceBeamIfNotExists(Beam aBeam) {
            if (!materials.ContainsBeam(aBeam)) {
                materials.AddBeam(aBeam);
            }
        }

        private void SplitWall(Wall newWall, List<Point> intersectionPoints) {
            Wall firstPiece = new Wall(newWall.Beginning(), intersectionPoints.First());
            AdjustWall(firstPiece);
            Wall actualPiece;
            for (int i = 1; i < intersectionPoints.Count-1; i++) {
                actualPiece = new Wall(intersectionPoints[i], intersectionPoints[i + 1]);
                AdjustWall(actualPiece);
            }
            Wall lastPiece = new Wall(intersectionPoints.Last(), newWall.End());
            AdjustWall(lastPiece);
        }

        private void AdjustWall(Wall generatedWall) {
            InsertWall(generatedWall);//pending refactory
        }

        private bool InRange(Point aPoint) {
            bool xInRange = aPoint.CoordX >= 0 && aPoint.CoordY <= Length;
            bool yInRange = aPoint.CoordY >= 0 && aPoint.CoordY <= Width;
            return xInRange && yInRange;
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


        public void InsertOpening(Opening testOpening) {
            throw new NotImplementedException();
        }

        public int OpeningsCount() {
            throw new NotImplementedException();
        }

        public void RemoveWall(Wall testWall) {
            throw new NotImplementedException();
        }
    }
}
