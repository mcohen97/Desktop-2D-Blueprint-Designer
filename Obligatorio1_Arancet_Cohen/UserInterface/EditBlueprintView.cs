using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace UserInterface {

    public partial class EditBlueprintView : UserControl {

        private Blueprint selectedBluePrint;
        private Session CurrentSession { get; set; }
        private NoFlickerPanel drawSurface;
        private LoggedInView parent;
        private Bitmap gridLayer;
        private Bitmap linesLayer;
        private Bitmap currentLineLayer;
        private System.Drawing.Point start;
        private List<System.Drawing.Point> points;
        private Pen wallPen;

        private const int gridCellCountX = 11;
        private const int gridCellCountY = 11;
        private const int cellSizeInPixels = 40;
        private const int windowXBoundryInPixels = 20;
        private const int windowYBoundryInPixels = 40;
        private const int gridLinesMarginToLayerInPixels = 1;
        private const int drawSurfaceMarginToWindowInPixels = 10;

        public EditBlueprintView(Session aSession, LoggedInView aParent, Blueprint aBlueprint) {
            InitializeComponent();
            CurrentSession = aSession;
            parent = aParent;
            selectedBluePrint = aBlueprint;
            points = new List<System.Drawing.Point>();

            wallPen = new Pen(Brushes.Black, 5);

            int drawSurfaceSizeX = cellSizeInPixels * gridCellCountX;
            int drawSurfaceSizeY = cellSizeInPixels * gridCellCountY;
            CreateDrawSurface(drawSurfaceSizeX, drawSurfaceSizeY);
            CreateOrRecreateLayer(ref gridLayer);
            PaintGrid();
            CreateOrRecreateLayer(ref linesLayer);
            CreateOrRecreateLayer(ref currentLineLayer);
        }

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
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickStart);
            this.BlueprintPanel.Controls.Add(drawSurface);
            ResumeLayout(false);
        }

        private void drawSurface_Paint(object sender, PaintEventArgs e) {
            System.Drawing.Point zeroing = new System.Drawing.Point(0, 0);
            e.Graphics.DrawImage(gridLayer, zeroing);
            e.Graphics.DrawImage(currentLineLayer, zeroing);
            e.Graphics.DrawImage(linesLayer, zeroing);
        }

        private void drawSurface_MouseClickStart(object sender, MouseEventArgs e) {

            System.Drawing.Point point = AdjustPointToGrid(drawSurface.PointToClient(Cursor.Position));
            points.Add(point);
            start = point;

            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMove);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickStart);
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickEnd);
        }

        private void drawSurface_MouseClickEnd(object sender, MouseEventArgs e) {

            System.Drawing.Point gridAjustedPoint = AdjustPointToGrid(drawSurface.PointToClient(Cursor.Position));
            System.Drawing.Point endPoint = adjustPointToHorizontalOrVerticalLine(gridAjustedPoint);

            try {
                selectedBluePrint.InsertWall(new Logic.Point(start.X, start.Y), new Logic.Point(endPoint.X, endPoint.Y));

            } catch (Exception) {

            }

            PaintLines();

            CreateOrRecreateLayer(ref currentLineLayer);

            drawSurface.MouseMove -= new MouseEventHandler(drawSurface_MouseMove);
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickStart);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickEnd);
        }

        private System.Drawing.Point adjustPointToHorizontalOrVerticalLine(System.Drawing.Point point) {
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

        private System.Drawing.Point AdjustPointToGrid(System.Drawing.Point point) {
            int gridCellWidth = gridLayer.Width / gridCellCountX;
            int gridCellHeight = gridLayer.Height / gridCellCountY;
            int x = point.X * (gridCellCountX + 1) / gridLayer.Width;
            int y = point.Y * (gridCellCountY + 1) / gridLayer.Height;
            point = new System.Drawing.Point(x * gridCellWidth, y * gridCellHeight);
            return point;
        }

        private void PaintLines() {
            CreateOrRecreateLayer(ref linesLayer);
            using (Graphics graphics = Graphics.FromImage(linesLayer)) {
                ICollection<Wall> walls = selectedBluePrint.GetWalls();
                foreach (Wall wall in walls) {
                    int startX = Convert.ToInt32(wall.Beginning().CoordX);
                    int startY = Convert.ToInt32(wall.Beginning().CoordY);
                    int endX = Convert.ToInt32(wall.End().CoordX);
                    int endY = Convert.ToInt32(wall.End().CoordY);
                    graphics.DrawLine(wallPen, new System.Drawing.Point(startX, startY), new System.Drawing.Point(endX, endY));
                }
            }
            drawSurface.Invalidate();
        }

        private void drawSurface_MouseMove(object sender, MouseEventArgs e) {
            PaintCurrentLine();
        }

        private void PaintCurrentLine() {
            CreateOrRecreateLayer(ref currentLineLayer);
            using (Graphics graphics = Graphics.FromImage(currentLineLayer)) {
                graphics.DrawLine(wallPen, start, drawSurface.PointToClient(Cursor.Position));
            }
            drawSurface.Invalidate();
        }

        private void CreateOrRecreateLayer(ref Bitmap layer) {
            try {
                layer.Dispose();
            } catch (Exception) {
            } finally {
                layer = new Bitmap(drawSurface.Width, drawSurface.Height);
            }
        }

        private void BlueprintPanel_Paint(object sender, PaintEventArgs e) {

        }
    }
}
