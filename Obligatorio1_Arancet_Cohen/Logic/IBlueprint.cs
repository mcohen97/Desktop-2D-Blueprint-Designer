using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic {
    interface IBlueprint {

        void InsertWall(Point from, Point to);

        void RemoveWall(Point from, Point to);

        void InsertOpening(Opening newOpening);

       
    }
}
