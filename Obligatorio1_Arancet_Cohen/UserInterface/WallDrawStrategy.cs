using Logic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UserInterface
{
    public class WallDrawStrategy : DrawStrategy<Wall>
    {
        private Pen penUsed;
        private PointConverter pointConverter;
        public Pen pen { get { return penUsed; } set { penUsed = value; } }

        public WallDrawStrategy(Pen pen)
        {
            penUsed = pen;
            pointConverter = new PointConverter(30);
        }

        public void Draw(Wall drawableObject, Bitmap layer, float scale)
        {
            pointConverter.CellSize = scale;
            using (Graphics graphics = Graphics.FromImage(layer))
            {
                System.Drawing.Point startPoint = pointConverter.LogicPointIntoDrawablePoint(drawableObject.Beginning());
                System.Drawing.Point endPoint = pointConverter.LogicPointIntoDrawablePoint(drawableObject.End());
                graphics.DrawLine(penUsed, startPoint, endPoint);
            }
        }

    }
}
