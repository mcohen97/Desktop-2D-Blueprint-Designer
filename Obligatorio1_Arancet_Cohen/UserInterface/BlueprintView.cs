using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Exceptions;
using System.Drawing.Imaging;

namespace UserInterface {

    public partial class BlueprintViewer : UserControl {

        private Blueprint selectedBluePrint;
        private Session CurrentSession { get; set; }
        private NoFlickerPanel drawSurface;
        private LoggedInView parent;
        private Bitmap gridLayer;
        private Bitmap wallsLayer;
        private Bitmap beamsLayer;
        private Bitmap openingLayer;
        private Bitmap currentLineLayer;
        private Bitmap currentPointLayer;
        private System.Drawing.Point start;
        private Pen wallPen;
        private Pen beamPen;
        private Pen doorPen;
        private Pen windowPen;


        private int gridCellCountX;
        private int gridCellCountY;
        private int cellSizeInPixels;
        private int windowXBoundryInPixels;
        private int windowYBoundryInPixels;
        private int gridLinesMarginToLayerInPixels;
        private int drawSurfaceMarginToWindowInPixels;

        public BlueprintViewer(Session aSession, LoggedInView aParent, Blueprint aBlueprint) {
            InitializeComponent();

            CurrentSession = aSession;
            parent = aParent;
            selectedBluePrint = aBlueprint;
            wallPen = new Pen(Brushes.Black, 5);
            beamPen = new Pen(Brushes.DarkRed, 8);
            doorPen = new Pen(Brushes.DarkGoldenrod, 6);
            windowPen = new Pen(Brushes.Sienna, 5);
            BlueprintPanel.Cursor = Cursors.Cross;

            gridLinesMarginToLayerInPixels = 1;
            drawSurfaceMarginToWindowInPixels = 10;
            gridCellCountX = aBlueprint.Length;
            gridCellCountY = aBlueprint.Width;
            windowXBoundryInPixels = this.BlueprintPanel.Width;
            windowYBoundryInPixels = this.BlueprintPanel.Height;
            setUpDrawSurface(40);

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            calulateCostsAndPrices();
        }

        //Auxiliar
        private Domain.Point DrawablePointIntoLogicPoint(System.Drawing.Point point) {
            float pointX = point.X;
            float pointY = point.Y;
            float cellSize = cellSizeInPixels;
            return new Domain.Point(pointX / cellSize, pointY / cellSize);
        }
        private System.Drawing.Point LogicPointIntoDrawablePoint(Domain.Point point) {
            return new System.Drawing.Point(Convert.ToInt32(point.CoordX * cellSizeInPixels), Convert.ToInt32(point.CoordY * cellSizeInPixels));
        }
        private void calulateCostsAndPrices() {
            float wallsCost = 0;
            float beamsCost = 0;
            float doorsCost = 0;
            float windowsCost = 0;
            float wallsPrice = 0;
            float beamsPrice = 0;
            float doorsPrice = 0;
            float windowsPrice = 0;

            foreach (Wall wall in selectedBluePrint.GetWalls()) {
                wallsCost += wall.CalculateCost();
                wallsPrice += wall.CalculatePrice();
            }
            foreach (Beam beam in selectedBluePrint.GetBeams()) {
                beamsCost += beam.CalculateCost();
                beamsPrice += beam.CalculatePrice();
            }
            foreach (Door door in selectedBluePrint.GetOpenings().Where(x => x.GetComponentType() == ComponentType.DOOR)) {
                doorsCost += door.CalculateCost();
                doorsPrice += door.CalculatePrice();
            }
            foreach (Window window in selectedBluePrint.GetOpenings().Where(x => x.GetComponentType() == ComponentType.WINDOW)) {
                windowsCost += window.CalculateCost();
                windowsPrice += window.CalculatePrice();
            }

            lblWallsTotalCost.Text = wallsCost + "";
            lblBeamsTotalCost.Text = beamsCost + "";
            lblDoorsTotalCost.Text = doorsCost + "";
            lblWindowsTotalCost.Text = windowsCost + "";
            lblTotalCostSum.Text = (wallsCost + beamsCost + doorsCost + windowsCost) + "";

            lblWallsPrice.Text = wallsPrice + "";
            lblBeamsPrice.Text = beamsPrice + "";
            lblDoorsPrice.Text = doorsPrice + "";
            lblWindowsPrice.Text = windowsPrice + "";
            lblTotalPriceSum.Text = (wallsPrice + beamsPrice + doorsPrice + windowsPrice) + "";
        }


        //Grid and panel config functions
        private void PaintGrid() {

            using (Graphics graphics = Graphics.FromImage(gridLayer)) {
                for (int i = 0; i < gridCellCountY; i++) {
                    DrawGridHorizontalLines(graphics, i);
                }
                for (int i = 0; i < gridCellCountX; i++) {
                    DrawGridVerticalLines(graphics, i);
                }
                DrawGridRightAndBottomLines(graphics);
            }
            drawSurface.Invalidate();
        }
        private void DrawGridHorizontalLines(Graphics graphics, int axis) {
            DrawHorizontalLine(graphics, axis, 0);
        }
        private void DrawGridVerticalLines(Graphics graphics, int axis) {
            DrawVerticalLine(graphics, axis, 0);
        }
        private void DrawGridRightAndBottomLines(Graphics graphics) {
            DrawHorizontalLine(graphics, gridCellCountY, -gridLinesMarginToLayerInPixels);
            DrawVerticalLine(graphics, gridCellCountX, -gridLinesMarginToLayerInPixels);
        }
        private void DrawHorizontalLine(Graphics graphics, int axis, int offset) {
            int gridCellHeight = axis * gridLayer.Height / gridCellCountY + offset;
            graphics.DrawLine(Pens.White, 0, gridCellHeight, gridLayer.Width, gridCellHeight);
        }
        private void DrawVerticalLine(Graphics graphics, int axis, int offset) {
            int gridCellWidth = axis * gridLayer.Width / gridCellCountX + offset;
            graphics.DrawLine(Pens.White, gridCellWidth, 0, gridCellWidth, gridLayer.Height);
        }
        private void CreateDrawSurface(int drawSurfaceSizeX, int drawSurfaceSizeY) {
            drawSurface = new NoFlickerPanel();
            SuspendLayout();
            drawSurface.Name = "drawSurface";
            drawSurface.Location = new System.Drawing.Point(drawSurfaceMarginToWindowInPixels, drawSurfaceMarginToWindowInPixels);
            drawSurface.Size = new Size(drawSurfaceSizeX, drawSurfaceSizeY);
            drawSurface.TabIndex = 0;
            drawSurface.Paint += new PaintEventHandler(drawSurface_Paint);
            this.BlueprintPanel.Controls.Add(drawSurface);
            ResumeLayout(false);
        }
        private void drawSurface_Paint(object sender, PaintEventArgs e) {
            System.Drawing.Point zeroing = new System.Drawing.Point(0, 0);
            e.Graphics.DrawImage(gridLayer, zeroing);
            e.Graphics.DrawImage(currentLineLayer, zeroing);
            e.Graphics.DrawImage(currentPointLayer, zeroing);
            e.Graphics.DrawImage(wallsLayer, zeroing);
            e.Graphics.DrawImage(beamsLayer, zeroing);
            e.Graphics.DrawImage(openingLayer, zeroing);

        }

        //Point adjustment functions
        private System.Drawing.Point AdjustPointToHorizontalOrVerticalLine(System.Drawing.Point point) {
            int xDifference = Math.Abs(point.X - start.X);
            int yDifference = Math.Abs(point.Y - start.Y);
            System.Drawing.Point returnedEndpoint;

            if (xDifference < yDifference) {
                returnedEndpoint = new System.Drawing.Point(start.X, point.Y);
            } else {
                returnedEndpoint = new System.Drawing.Point(point.X, start.Y);
            }

            return returnedEndpoint;
        }
        private System.Drawing.Point AdjustPointToGridIntersection(System.Drawing.Point point) {
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
        private System.Drawing.Point AdjustPointToGrid(System.Drawing.Point point) {
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

            if (differenceX > differenceY) {
                adjustedPoint = new System.Drawing.Point(point.X, adjustedCoordY);
            } else {
                adjustedPoint = new System.Drawing.Point(adjustedCoordX, point.Y);
            }

            return adjustedPoint;
        }

        //Selection point mouse move
        private void drawSurface_MouseMoveShowSelectedPoint(object sender, MouseEventArgs e) {
            PaintPoint(Brushes.FloralWhite);
        }

        //Paint functions
        private void PaintWalls() {
            CreateOrRecreateLayer(ref wallsLayer);
            ICollection<Wall> walls = selectedBluePrint.GetWalls();
            foreach (Wall wall in walls) {
                PaintWall(wall);
            }
            drawSurface.Invalidate();
        }
        private void PaintBeams() {
            CreateOrRecreateLayer(ref beamsLayer);
            using (Graphics graphics = Graphics.FromImage(beamsLayer)) {
                ICollection<Beam> beams = selectedBluePrint.GetBeams();
                foreach (Beam beam in beams) {
                    PaintBeam(beam);
                }
            }
            drawSurface.Invalidate();
        }
        private void PaintOpenings() {
            CreateOrRecreateLayer(ref openingLayer);
            ICollection<Opening> openings = selectedBluePrint.GetOpenings();
            foreach (Opening opening in openings.Where(x => x.GetComponentType() == ComponentType.DOOR)) {
                PaintDoor(opening);
            }
            foreach (Opening opening in openings.Where(x => x.GetComponentType() == ComponentType.WINDOW)) {
                PaintWindow(opening);
            }
            drawSurface.Invalidate();
        }
        private void PaintCurrentLine() {
            CreateOrRecreateLayer(ref currentLineLayer);
            using (Graphics graphics = Graphics.FromImage(currentLineLayer)) {
                graphics.DrawLine(wallPen, start, drawSurface.PointToClient(Cursor.Position));
            }
            drawSurface.Invalidate();
        }
        private void PaintPoint(Brush pointerBrush) {
            CreateOrRecreateLayer(ref currentPointLayer);
            using (Graphics graphics = Graphics.FromImage(currentPointLayer)) {
                System.Drawing.Point actualPoint = AdjustPointToGrid(drawSurface.PointToClient(Cursor.Position));
                graphics.DrawString("♦", DefaultFont, pointerBrush, actualPoint.X - 5, actualPoint.Y - 5);
            }
            drawSurface.Invalidate();
        }
        private void PaintWall(Wall wall) {
            using (Graphics graphics = Graphics.FromImage(wallsLayer)) {
                graphics.DrawLine(wallPen, LogicPointIntoDrawablePoint(wall.Beginning()), LogicPointIntoDrawablePoint(wall.End()));
            }
        }
        private void PaintBeam(Beam beam) {
            using (Graphics graphics = Graphics.FromImage(beamsLayer)) {
                System.Drawing.Point drawPoint = LogicPointIntoDrawablePoint(beam.GetPosition());
                graphics.DrawString("■", DefaultFont, beamPen.Brush, drawPoint.X - 7, drawPoint.Y - 5);
            }
        }
        private void PaintDoor(Opening opening) {
            using (Graphics graphics = Graphics.FromImage(openingLayer)) {
                System.Drawing.Point center = LogicPointIntoDrawablePoint(opening.GetPosition());
                System.Drawing.Point[] points = {
                        new System.Drawing.Point(center.X+5, center.Y),
                        new System.Drawing.Point(center.X-5, center.Y),
                        new System.Drawing.Point(center.X+5, center.Y+10),
                     };
                graphics.DrawPolygon(doorPen, points);
            }
        }
        private void PaintWindow(Opening opening) {
            using (Graphics graphics = Graphics.FromImage(openingLayer)) {
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

        private void CreateOrRecreateLayer(ref Bitmap layer) {
            try {
                layer.Dispose();
            } catch (Exception) {
            } finally {
                layer = new Bitmap(drawSurface.Width, drawSurface.Height);
            }
        }
        private void EditBlueprintView_Load(object sender, EventArgs e) {
            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveShowSelectedPoint);
        }


        private void btnExportBlueprint_Click(object sender, EventArgs e) {
            int width = drawSurface.Size.Width;
            int height = drawSurface.Size.Height;

            Bitmap bitmapToExport = new Bitmap(width, height);
            CreateOrRecreateLayer(ref currentPointLayer);
            drawSurface.DrawToBitmap(bitmapToExport, new Rectangle(0, 0, width, height));


            try {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                saveFile.ShowDialog();
                var path = saveFile.FileName;

                ImageFormat imageFormatSelected = ImageFormat.Png;
                if (saveFile.Filter == ".jpeg") {
                    imageFormatSelected = ImageFormat.Jpeg;
                } else if (saveFile.Filter == ".png") {
                    imageFormatSelected = ImageFormat.Png;
                }
                bitmapToExport.Save(path, imageFormatSelected);
            } catch (ArgumentException) {

            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e) {
            setUpDrawSurface(cellSizeInPixels + 10);
        }
        private void btnZoomOut_Click(object sender, EventArgs e) {
            setUpDrawSurface(cellSizeInPixels - 10);
        }

        private void setUpDrawSurface(int cellSize) {
            if (BlueprintPanel.Controls.Contains(drawSurface)) {
                BlueprintPanel.Controls.Remove(drawSurface);
            }

            if (cellSize < 10) {
                cellSizeInPixels = 10;
            }else {
                cellSizeInPixels = cellSize;
            }

            int cellSizeInPixelsX = (windowXBoundryInPixels - 2 * drawSurfaceMarginToWindowInPixels) / gridCellCountX;
            int cellSizeInPixelsY = (windowXBoundryInPixels - 2 * drawSurfaceMarginToWindowInPixels) / gridCellCountY;
            int drawSurfaceSizeX = cellSizeInPixels * gridCellCountX;
            int drawSurfaceSizeY = cellSizeInPixels * gridCellCountY;

            CreateDrawSurface(drawSurfaceSizeX, drawSurfaceSizeY);
            CreateOrRecreateLayer(ref gridLayer);
            PaintGrid();
            CreateOrRecreateLayer(ref wallsLayer);
            CreateOrRecreateLayer(ref beamsLayer);
            CreateOrRecreateLayer(ref openingLayer);
            CreateOrRecreateLayer(ref currentLineLayer);
            CreateOrRecreateLayer(ref currentPointLayer);

            BlueprintPanel.Refresh();

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            drawSurface.Refresh();
            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveShowSelectedPoint);
        }
    }
}