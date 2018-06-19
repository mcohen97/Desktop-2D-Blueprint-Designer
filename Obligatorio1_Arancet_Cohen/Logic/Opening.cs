using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Domain
{
    public abstract class Opening : ISinglePointComponent, IComponent2D, IPriceable, IMaterialType
    {


        protected Template dimensions;
        protected Point position;

        public Opening(Point aPlace)
        {
            position = aPlace;
        }

        public Opening(Point aPlace, Template template)
        {
            dimensions = template;
        }

        public float Height()
        {
            return dimensions.Height;
        }

        public float Length()
        {
            return dimensions.Length;
        }

        public float HeightAboveFloor()
        {
            return dimensions.HeightAboveFloor;
        }

        public Point GetPosition()
        {
            return position;
        }

        public override bool Equals(object obj)
        {

            bool areEqual;
            if (obj == null)
            {
                areEqual = false;
            }
            else
            {
                Opening otherOpening = (Opening)obj;
                areEqual = position.Equals(otherOpening.GetPosition());
            }
            return areEqual;
        }

        public override int GetHashCode()
        {
            return position.GetHashCode();
        }

        public abstract float CalculatePrice();

        public abstract float CalculateCost();

        public abstract ComponentType GetComponentType();

        public string getTemplateName() {
            return dimensions.Name;
        }

        public Template getTemplate()
        {
            return dimensions;
        }
    }
}
