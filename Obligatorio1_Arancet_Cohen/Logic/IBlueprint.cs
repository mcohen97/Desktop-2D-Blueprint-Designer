using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public abstract class IBlueprint
    {

        public abstract void InsertWall(Point from, Point to);

        public abstract void RemoveWall(Point from, Point to);

        public abstract void InsertOpening(Opening newOpening);

        public abstract void RemoveOpening(Opening toRemove);

        public abstract void RemoveOpening(Point position);

        public virtual User Owner { get; set; }

        public virtual User Signature { get; set; }

        public virtual DateTime LastSignDate { get; set; }

        public bool IsSigned()
        {
            return Signature != null;
        }
    }
}
