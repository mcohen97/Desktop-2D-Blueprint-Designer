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

        private int gridCellCountX;
        private int gridCellCountY;
        private int cellSizeInPixels;
        private int windowXBoundryInPixels;
        private int windowYBoundryInPixels;
        private int gridLinesMarginToLayerInPixels;
        private int drawSurfaceMarginToWindowInPixels;
        private IGridPaintStrategy gridPainter;
        public LayersStructure layers;
        public Pencilcase pencilcase;
        public PointConverter pointConverter;
        public System.Drawing.Point auxiliar;
        public NoFlickerPanel drawSurface;

        public Drawer(int gridCellCountX, int gridCellCountY, int cellSizeInPixels, int windowXBoundryInPixels, int windowYBoundryInPixels, int gridLinesMarginToLayerInPixels, int drawSurfaceMarginToWindowInPixels)
        {
            this.gridCellCountX = gridCellCountX;
            this.gridCellCountY = gridCellCountY;
            this.cellSizeInPixels = cellSizeInPixels;
            this.windowXBoundryInPixels = windowXBoundryInPixels;
            this.windowYBoundryInPixels = windowYBoundryInPixels;
            this.gridLinesMarginToLayerInPixels = gridLinesMarginToLayerInPixels;
            this.drawSurfaceMarginToWindowInPixels = drawSurfaceMarginToWindowInPixels;

            layers = new LayersStructure(20, 20);
            gridPainter = new CompleteLineGridPaint(layers.gridLayer, gridCellCountX, gridCellCountY, gridLinesMarginToLayerInPixels);
            pencilcase = new Pencilcase(new Pen(Brushes.Black, 5), new Pen(Brushes.DarkRed, 8), new Pen(Brushes.DarkGoldenrod, 1), new Pen(Brushes.Sienna, 1), new Pen(Brushes.Purple, 12));
            pointConverter = new PointConverter(cellSizeInPixels);
        }

        public int GridCellCountX {
            get {
                return gridCellCountX;
            }

            set {
                gridCellCountX = value;
            }
        }
        public int GridCellCountY {
            get {
                return gridCellCountY;
            }

            set {
                gridCellCountY = value;
            }
        }
        public int CellSizeInPixels {
            get {
                return cellSizeInPixels;
            }

            set {
                cellSizeInPixels = value;
                this.pointConverter.CellSize = value;
            }
        }
        public int WindowXBoundryInPixels {
            get {
                return windowXBoundryInPixels;
            }

            set {
                windowXBoundryInPixels = value;
            }
        }
        public int WindowYBoundryInPixels {
            get {
                return windowYBoundryInPixels;
            }

            set {
                windowYBoundryInPixels = value;
            }
        }
        public int GridLinesMarginToLayerInPixels {
            get {
                return gridLinesMarginToLayerInPixels;
            }

            set {
                gridLinesMarginToLayerInPixels = value;
            }
        }
        public int DrawSurfaceMarginToWindowInPixels {
            get {
                return drawSurfaceMarginToWindowInPixels;
            }

            set {
                drawSurfaceMarginToWindowInPixels = value;
            }
        }

        public IGridPaintStrategy GridPainter {
            get {
                return gridPainter;
            }

            set {
                gridPainter = value;
            }
        }

        public void PaintGrid()
        {
            GridPainter.SetCountX(gridCellCountX);
            GridPainter.SetCountY(gridCellCountY);
            GridPainter.SetLayer(layers.gridLayer);
            GridPainter.SetMargin(gridLinesMarginToLayerInPixels);
            GridPainter.PaintGrid();
        }
        public void PaintWall(Wall wall)
        {
            using (Graphics graphics = Graphics.FromImage(layers.wallsLayer))
            {
                graphics.DrawLine(pencilcase.WallPen, pointConverter.LogicPointIntoDrawablePoint(wall.Beginning()), pointConverter.LogicPointIntoDrawablePoint(wall.End()));
            }
        }
        public void PaintBeam(Beam beam, Font stringFont)
        {
            using (Graphics graphics = Graphics.FromImage(layers.beamsLayer))
            {
                System.Drawing.Point drawPoint = pointConverter.LogicPointIntoDrawablePoint(beam.GetPosition());
                graphics.DrawString("■", stringFont, pencilcase.BeamPen.Brush, drawPoint.X - 7, drawPoint.Y - 5);
            }
        }
        public void PaintHorizontalDoor(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(layers.openingLayer))
            {
                System.Drawing.Point center = pointConverter.LogicPointIntoDrawablePoint(opening.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((opening.Length() * cellSizeInPixels) / 2);
                System.Drawing.Point[] points = {
                        new System.Drawing.Point(center.X+halfLengthInPixels, center.Y),
                        new System.Drawing.Point(center.X-halfLengthInPixels, center.Y),
                        new System.Drawing.Point(center.X+halfLengthInPixels, center.Y+halfLengthInPixels/2),
                     };
                graphics.DrawPolygon(pencilcase.DoorPen, points);
                graphics.FillPolygon(pencilcase.DoorPen.Brush, points);

            }
        }
        public void PaintVerticalDoor(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(layers.openingLayer))
            {
                System.Drawing.Point center = pointConverter.LogicPointIntoDrawablePoint(opening.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((opening.Length() * cellSizeInPixels) / 2);
                System.Drawing.Point[] points = {
                        new System.Drawing.Point(center.X, center.Y+halfLengthInPixels),
                        new System.Drawing.Point(center.X, center.Y-halfLengthInPixels),
                        new System.Drawing.Point(center.X+halfLengthInPixels/2, center.Y+halfLengthInPixels),
                     };
                graphics.DrawPolygon(pencilcase.DoorPen, points);
                graphics.FillPolygon(pencilcase.DoorPen.Brush, points);

            }
        }
        public void PaintHorizontalWindow(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(layers.openingLayer))
            {
                System.Drawing.Point center = pointConverter.LogicPointIntoDrawablePoint(opening.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((opening.Length() * cellSizeInPixels) / 2);
                System.Drawing.Point[] points = {
                            new System.Drawing.Point(center.X+halfLengthInPixels, center.Y+5),
                            new System.Drawing.Point(center.X-halfLengthInPixels, center.Y+5),
                            new System.Drawing.Point(center.X+halfLengthInPixels, center.Y-5),
                            new System.Drawing.Point(center.X-halfLengthInPixels, center.Y-5)
                        };
                graphics.DrawPolygon(pencilcase.WindowPen, points);
                graphics.FillPolygon(pencilcase.WindowPen.Brush, points);

            }
        }
        public void PaintVerticalWindow(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(layers.openingLayer))
            {
                System.Drawing.Point center = pointConverter.LogicPointIntoDrawablePoint(opening.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((opening.Length() * cellSizeInPixels) / 2);
                System.Drawing.Point[] points = {
                            new System.Drawing.Point(center.X+5, center.Y+halfLengthInPixels),
                            new System.Drawing.Point(center.X+5, center.Y-halfLengthInPixels),
                            new System.Drawing.Point(center.X-5, center.Y+halfLengthInPixels),
                            new System.Drawing.Point(center.X-5, center.Y-halfLengthInPixels)
                        };
                graphics.DrawPolygon(pencilcase.WindowPen, points);
                graphics.FillPolygon(pencilcase.WindowPen.Brush, points);
            }
        }
        public void PaintColumn(Column column)
        {
            using (Graphics graphics = Graphics.FromImage(layers.columnsLayer))
            {
                System.Drawing.Point center = pointConverter.LogicPointIntoDrawablePoint(column.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((column.Length() * cellSizeInPixels) / 2);
                System.Drawing.Point[] points = {
                            new System.Drawing.Point(center.X+halfLengthInPixels, center.Y+halfLengthInPixels),
                            new System.Drawing.Point(center.X-halfLengthInPixels, center.Y+halfLengthInPixels),
                            new System.Drawing.Point(center.X-halfLengthInPixels, center.Y-halfLengthInPixels),
                            new System.Drawing.Point(center.X+halfLengthInPixels, center.Y-halfLengthInPixels)

                        };
                graphics.DrawPolygon(pencilcase.ColumnPen, points);
                graphics.FillPolygon(pencilcase.ColumnPen.Brush, points);
            }
        }
        public void CreateOrRecreateLayer(ref Bitmap layer)
        {
            try
            {
                layer.Dispose();
            }
            catch (Exception)
            {
            }
            finally
            {
                layer = new Bitmap(drawSurface.Width, drawSurface.Height);
            }
        }
        public void PaintCurrentLine(System.Drawing.Point end)
        {
            CreateOrRecreateLayer(ref layers.currentLineLayer);
            using (Graphics graphics = Graphics.FromImage(layers.currentLineLayer))
            {
                graphics.DrawLine(pencilcase.WallPen, auxiliar, end);
            }
            drawSurface.Invalidate();
        }
        public void PaintPoint(System.Drawing.Point point, Brush pointerBrush, Font font)
        {
            CreateOrRecreateLayer(ref layers.currentPointLayer);
            using (Graphics graphics = Graphics.FromImage(layers.currentPointLayer))
            {
                System.Drawing.Point actualPoint = AdjustPointToGrid(point);
                graphics.DrawString("♦", font, pointerBrush, actualPoint.X - 5, actualPoint.Y - 5);
            }
            drawSurface.Invalidate();
        }

        public System.Drawing.Point AdjustPointToHorizontalOrVerticalLine(System.Drawing.Point point)
        {
            int xDifference = Math.Abs(point.X - auxiliar.X);
            int yDifference = Math.Abs(point.Y - auxiliar.Y);
            System.Drawing.Point returnedEndpoint;

            if (xDifference < yDifference)
            {
                returnedEndpoint = new System.Drawing.Point(auxiliar.X, point.Y);
            }
            else
            {
                returnedEndpoint = new System.Drawing.Point(point.X, auxiliar.Y);
            }

            return returnedEndpoint;
        }
        public System.Drawing.Point AdjustPointToGridIntersection(System.Drawing.Point point)
        {
            System.Drawing.Point adjustedPoint;
            decimal xCoord = point.X;
            decimal yCoord = point.Y;
            decimal cellSize = cellSizeInPixels;
            decimal gridCoordX = xCoord / cellSize;
            decimal gridCoordY = yCoord / cellSize;
            int adjustedCoordX = Convert.ToInt32(Math.Round(gridCoordX));
            int adjustedCoordY = Convert.ToInt32(Math.Round(gridCoordY));

            adjustedPoint = new System.Drawing.Point(adjustedCoordX * cellSizeInPixels, adjustedCoordY * cellSizeInPixels);
            return adjustedPoint;
        }
        public System.Drawing.Point AdjustPointToGrid(System.Drawing.Point point)
        {
            System.Drawing.Point adjustedPoint;
            decimal xCoord = point.X;
            decimal yCoord = point.Y;
            decimal cellSize = cellSizeInPixels;
            decimal gridCoordX = xCoord / cellSize;
            decimal gridCoordY = yCoord / cellSize;
            int adjustedCoordX = Convert.ToInt32(Math.Round(gridCoordX)) * cellSizeInPixels;
            int adjustedCoordY = Convert.ToInt32(Math.Round(gridCoordY)) * cellSizeInPixels;

            int differenceX = Math.Abs(adjustedCoordX - point.X);
            int differenceY = Math.Abs(adjustedCoordY - point.Y);

            if (differenceX > differenceY)
            {
                adjustedPoint = new System.Drawing.Point(point.X, adjustedCoordY);
            }
            else
            {
                adjustedPoint = new System.Drawing.Point(adjustedCoordX, point.Y);
            }

            return adjustedPoint;
        }
    }
}
