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

        internal abstract void Sign(User sign);

        internal abstract User GetSign();

        public virtual DateTime LastSignDate { get; internal set; }

        public bool IsSigned()
        {
            return GetSign() != null;
        }
    }
}
