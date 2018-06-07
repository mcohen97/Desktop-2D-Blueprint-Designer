
using System;

namespace Logic.Domain
{
    public class Column : ISinglePointComponent, IMaterialType, IPriceable
    {
        private Point position;

        public Column(Point position)
        {
            this.position = position;
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
                Column otherColumn = (Column)obj;
                areEqual = position.Equals(otherColumn.position);
            }
            return areEqual;
        }

        public float CalculateCost()
        {
            return Constants.COST_CATALOGUE[GetComponentType()];
        }

        public float CalculatePrice()
        {
            return Constants.PRICE_CATALOGUE[GetComponentType()];
        }

        public ComponentType GetComponentType()
        {
            return ComponentType.COLUMN;
        }

        public override int GetHashCode()
        {
            return position.GetHashCode();
        }
    }
}