using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {
    public class Blueprint {

        private int Length;
        private int Width;
        private BuildingComponentContainer materials;

        public Blueprint(int aLength, int aWidth) {
            Length = aLength;
            Width = aWidth;
        }

        public BuildingComponentContainer GetComponentsContainer() {
            throw new NotImplementedException();
        }

        public void InsertWall(Wall aWall) {
            if (!InRange(aWall.Beginning) || !InRange(aWall.End)) {

            } else {


            }
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
