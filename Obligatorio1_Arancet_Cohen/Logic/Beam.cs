using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesExceptions;


namespace Logic.Domain
{

    public class Beam : ISinglePointComponent, IMaterialType
    {

        private Point position;

        public Beam(Point aPlace)
        {
            position = aPlace;
        }

        public Point GetPosition()
        {
            return position;
        }

        public override bool Equals(object obj)
        {
            bool areEqual;
            if (obj == null || GetType() != obj.GetType())
            {
                areEqual = false;
            }
            else
            {
                Beam otherBeam = (Beam)obj;
                areEqual = position.Equals(otherBeam.position);
            }
            return areEqual;
        }

        public override int GetHashCode()
        {
            return position.GetHashCode();
        }

        public ComponentType GetComponentType()
        {
            return ComponentType.BEAM;
        }

    }
}
