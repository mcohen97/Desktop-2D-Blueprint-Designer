using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public interface IBlueprint
    {

        void InsertWall(Point from, Point to);

        void RemoveWall(Point from, Point to);

        void InsertOpening(Opening newOpening);

        void RemoveOpening(Opening toRemove);

        void RemoveOpening(Point position);

        User Owner { get; set; }

    }
}
