using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public interface IBlueprint {

        void InsertWall(Point from, Point to);

        void RemoveWall(Point from, Point to);

        void InsertOpening(Opening newOpening);

        User Owner { get; set; }

    }
}
