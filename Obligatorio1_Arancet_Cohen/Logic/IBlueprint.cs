using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public abstract class IBlueprint
    {
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

        public abstract void RemoveOpening(Point position);

        public virtual User Owner { get; set; }
    }
}
