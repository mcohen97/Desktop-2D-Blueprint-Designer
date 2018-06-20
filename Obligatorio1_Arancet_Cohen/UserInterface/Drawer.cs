using Logic.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class Drawer
    {
        private Pen wallPen;
        private Pen beamPen;
        private Pen doorPen;
        private Pen windowPen;
        private Pen columnPen;
        private PointConverter pointConverter;

        public Drawer(float scale)
        {
            wallPen = new Pen(Brushes.Black, 5);
            beamPen = new Pen(Brushes.DarkRed, 8);
            doorPen = new Pen(Brushes.DarkGoldenrod, 6);
            windowPen = new Pen(Brushes.Sienna, 5);
            columnPen = new Pen(Brushes.Purple, 12);
            pointConverter = new PointConverter(scale);
        }

        public void SetScale(float scale)
        {
            pointConverter.CellSize = scale;
        }

        public float GetScale(float scale)
        {
            return pointConverter.CellSize;
        }

        public void PaintLine()
        {
            CreateOrRecreateLayer(ref currentLineLayer);
            using (Graphics graphics = Graphics.FromImage(currentLineLayer))
            {
                graphics.DrawLine(wallPen, start, drawSurface.PointToClient(Cursor.Position));
            }
            drawSurface.Invalidate();
        }
        public void PaintPoint(Brush pointerBrush)
        {
            CreateOrRecreateLayer(ref currentPointLayer);
            using (Graphics graphics = Graphics.FromImage(currentPointLayer))
            {
                System.Drawing.Point actualPoint = AdjustPointToGrid(drawSurface.PointToClient(Cursor.Position));
                graphics.DrawString("♦", DefaultFont, pointerBrush, actualPoint.X - 5, actualPoint.Y - 5);
            }
            drawSurface.Invalidate();
        }
        public void PaintWall(Wall wall)
        {
            using (Graphics graphics = Graphics.FromImage(wallsLayer))
            {
                graphics.DrawLine(wallPen, LogicPointIntoDrawablePoint(wall.Beginning()), LogicPointIntoDrawablePoint(wall.End()));
            }
        }
        public void PaintBeam(Beam beam)
        {
            using (Graphics graphics = Graphics.FromImage(beamsLayer))
            {
                System.Drawing.Point drawPoint = LogicPointIntoDrawablePoint(beam.GetPosition());
                graphics.DrawString("■", DefaultFont, beamPen.Brush, drawPoint.X - 7, drawPoint.Y - 5);
            }
        }
        public void PaintDoor(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(openingLayer))
            {
                System.Drawing.Point center = LogicPointIntoDrawablePoint(opening.GetPosition());
                System.Drawing.Point[] points = {
                        new System.Drawing.Point(center.X+5, center.Y),
                        new System.Drawing.Point(center.X-5, center.Y),
                        new System.Drawing.Point(center.X+5, center.Y+10),
                     };
                graphics.DrawPolygon(doorPen, points);
            }
        }
        public void PaintWindow(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(openingLayer))
            {
                System.Drawing.Point center = LogicPointIntoDrawablePoint(opening.GetPosition());
                System.Drawing.Point[] points = {
                            new System.Drawing.Point(center.X+5, center.Y+5),
                            new System.Drawing.Point(center.X-5, center.Y+5),
                            new System.Drawing.Point(center.X+5, center.Y-5),
                            new System.Drawing.Point(center.X-5, center.Y-5)
                        };
                graphics.DrawPolygon(windowPen, points);
            }
        }
        public void PaintColumn(Column column)
        {
            using (Graphics graphics = Graphics.FromImage(columnsLayer))
            {
                System.Drawing.Point drawPoint = LogicPointIntoDrawablePoint(column.GetPosition());
                graphics.DrawString("■", DefaultFont, columnPen.Brush, drawPoint.X - 7, drawPoint.Y - 5);
            }
        }
    }
}

