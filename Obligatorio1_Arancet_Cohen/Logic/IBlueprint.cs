using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public abstract class IBlueprint
    {

        public virtual string Name { get; internal set; }
        public virtual int Length { get; protected set; }
        public virtual int Width { get; protected set; }
        public virtual User Owner { get; set; }   
        private Guid id;
        protected ICollection<Signature> signatures;

        public virtual void Sign(User signer)
        {
            if (signer == null)
            {
                throw new ArgumentNullException();
            }

            Signature signature = new Signature(signer, DateTime.Now);
            signatures.Add(signature);
        }

        public bool IsSigned()
        {
            return signatures.Count != 0;
        }

        public virtual ICollection<Signature> GetSignatures()
        {
            return signatures;
        }

        public abstract void InsertWall(Point from, Point to);

        public abstract void RemoveWall(Point from, Point to);

        public abstract void InsertOpening(Opening newOpening);

        public abstract void RemoveOpening(Opening toRemove);

        public abstract void RemoveColumn(Point position);

        public abstract ICollection<Wall> GetWalls();

        public abstract ICollection<Beam> GetBeams();

        public abstract ICollection<Opening> GetOpenings();

        public abstract ICollection<ISinglePointComponent> GetColumns();

        public abstract void InsertColumn(Point columnPosition);
    }
}
