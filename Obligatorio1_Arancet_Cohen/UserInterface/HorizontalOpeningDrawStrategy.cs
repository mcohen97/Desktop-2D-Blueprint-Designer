using Logic.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UserInterface
{
    public class HorizontalOpeningDrawStrategy : DrawStrategy<Opening>
    {
        private Pen windowsPen;
        private Pen doorPen;
        private PointConverter pointConverter;
        public Pen pen { get { return penUsed; } set { penUsed = value; } }
        
        public HorizontalOpeningDrawStrategy(Pen windowsPen, Pen doorPen)
        {
            penUsed = pen;
            pointConverter = new PointConverter(30);
        }
        public void Draw(Opening drawableObject, Bitmap layer, float scale)
        {
            pointConverter.CellSize = scale;
            using (Graphics graphics = Graphics.FromImage(layer))
            {
                System.Drawing.Point centerPoint = pointConverter.LogicPointIntoDrawablePoint(drawableObject.GetPosition());
                graphics.DrawLine(penUsed, startPoint, endPoint);
            }
        }
    }
}
