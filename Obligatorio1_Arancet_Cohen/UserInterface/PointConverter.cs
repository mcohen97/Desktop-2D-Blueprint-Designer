using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class PointConverter
    {
        private float cellSize;
        public float CellSize { get { return cellSize; } set { cellSize = value; } }

        public PointConverter(float scale)
        {
            cellSize = scale;
        }

        public Logic.Domain.Point DrawablePointIntoLogicPoint(System.Drawing.Point point)
        {
            float pointX = point.X;
            float pointY = point.Y;
            return new Logic.Domain.Point(pointX / cellSize, pointY / cellSize);
        }

        public System.Drawing.Point LogicPointIntoDrawablePoint(Logic.Domain.Point point)
        {
            return new System.Drawing.Point(Convert.ToInt32(point.CoordX * cellSize), Convert.ToInt32(point.CoordY * cellSize));
        }
    }
}
