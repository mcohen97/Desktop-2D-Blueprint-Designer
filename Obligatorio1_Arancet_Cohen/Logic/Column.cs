
using System;

namespace Logic.Domain
{
    public class Column : ISinglePointComponent, IMaterialType, IComponent3D
    {
        private Point position;
        private float width;
        private float length;
        private float height;

        public Column(Point position)
        {
            this.width = 0.5f;
            this.length = 0.5f;
            this.height = 3;
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
        public ComponentType GetComponentType()
        {
            return ComponentType.COLUMN;
        }

        public override int GetHashCode()
        {
            return position.GetHashCode();
        }

        public float Width()
        {
            return width;
        }

        public float Length()
        {
            return length;
        }

        public float Height()
        {
            return height;
        }
    }
}