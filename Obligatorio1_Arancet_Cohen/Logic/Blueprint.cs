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
        }

        public BuildingComponentContainer GetComponentsContainer() {
            throw new NotImplementedException();
        }

        public void InsertWall(Wall aWall) {
            if (!InRange(aWall.Beginning()) || !InRange(aWall.End())) {
                throw new OutOfRangeComponentException();
            } else {
                if (!IntersectsOtherWalls(aWall)) {
                    materials.addWall(aWall);
                }
            }
        }

        private bool InRange(Point aPoint) {
            bool xInRange = aPoint.CoordX >= 0 && aPoint.CoordY <= Length;
            bool yInRange = aPoint.CoordY >= 0 && aPoint.CoordY <= Width;
            return xInRange && yInRange;
        }

        private bool IntersectsOtherWalls(Wall aWall) {
            return WallsIntersectedByNewOne(aWall).Any();
        }

        private ICollection<Wall> WallsIntersectedByNewOne(Wall newWall) {
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
