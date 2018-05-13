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

        public EditBlueprintView(Session aSession, LoggedInView aParent, Blueprint aBlueprint) {
            InitializeComponent();

            gridLinesMarginToLayerInPixels = 1;
            drawSurfaceMarginToWindowInPixels = 10;
            gridCellCountX = aBlueprint.Length;
            gridCellCountY = aBlueprint.Width;
            windowXBoundryInPixels = this.BlueprintPanel.Width;
            windowYBoundryInPixels = this.BlueprintPanel.Height;
            int cellSizeInPixelsX = (windowXBoundryInPixels - 2 * drawSurfaceMarginToWindowInPixels) / gridCellCountX;
            int cellSizeInPixelsY = (windowXBoundryInPixels - 2 * drawSurfaceMarginToWindowInPixels) / gridCellCountY;
            //cellSizeInPixels = Math.Min(cellSizeInPixelsX, cellSizeInPixelsY);
            cellSizeInPixels = 40;

            int drawSurfaceSizeX = cellSizeInPixels * gridCellCountX;
            int drawSurfaceSizeY = cellSizeInPixels * gridCellCountY;
            CreateDrawSurface(drawSurfaceSizeX, drawSurfaceSizeY);

            CurrentSession = aSession;
            parent = aParent;
            selectedBluePrint = aBlueprint;
            wallPen = new Pen(Brushes.Black, 5);
            beamPen = new Pen(Brushes.DarkRed, 8);
            doorPen = new Pen(Brushes.DarkGoldenrod, 6);
            windowPen = new Pen(Brushes.Sienna, 5);

            CreateOrRecreateLayer(ref gridLayer);
            PaintGrid();
            CreateOrRecreateLayer(ref wallsLayer);
            CreateOrRecreateLayer(ref beamsLayer);
            CreateOrRecreateLayer(ref openingLayer);
            CreateOrRecreateLayer(ref currentLineLayer);
            CreateOrRecreateLayer(ref currentPointLayer);

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

        //Wall events
        private void drawSurface_MouseClickStartWall(object sender, MouseEventArgs e) {
            System.Drawing.Point point = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            start = point;

            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMovePaintWall);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickEndWall);
        }
        private void drawSurface_MouseClickEndWall(object sender, MouseEventArgs e) {

            System.Drawing.Point gridAjustedPoint = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            System.Drawing.Point endPoint = AdjustPointToHorizontalOrVerticalLine(gridAjustedPoint);

            try {
                selectedBluePrint.InsertWall(new Logic.Point(start.X / cellSizeInPixels, start.Y / cellSizeInPixels), new Logic.Point(endPoint.X / cellSizeInPixels, endPoint.Y / cellSizeInPixels));

            } catch (Exception) {

            }

            PaintWalls();
            PaintBeams();
            PaintOpenings();

            CreateOrRecreateLayer(ref currentLineLayer);
            CreateOrRecreateLayer(ref currentPointLayer);


            drawSurface.MouseMove -= new MouseEventHandler(drawSurface_MouseMovePaintWall);
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickEndWall);
        }
        private void drawSurface_MouseMovePaintWall(object sender, MouseEventArgs e) {
            PaintCurrentLine();
        }

        //Opening events
        private void drawSurface_MouseClickInsertDoor(object sender, MouseEventArgs e) {
            System.Drawing.Point point = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            Logic.Point doorPoint = new Logic.Point(point.X / cellSizeInPixels, point.Y / cellSizeInPixels);
            Opening newDoor = new Door(doorPoint);

            try {
                selectedBluePrint.InsertOpening(newDoor);
            } catch (Exception) {
                //error message
            }

            PaintOpenings();
        }
        private void drawSurface_MouseClickInsertWindow(object sender, MouseEventArgs e) {
            System.Drawing.Point point = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            Logic.Point doorPoint = new Logic.Point(point.X / cellSizeInPixels, point.Y / cellSizeInPixels);
            Opening newDoor = new Window(doorPoint);

            try {
                selectedBluePrint.InsertOpening(newDoor);
            } catch (Exception) {
                //error message
            }

            PaintOpenings();
        }

        //Erase events
        private void drawSurface_MouseClickErase(object sender, MouseEventArgs e) {
            System.Drawing.Point point = AdjustPointToGrid(drawSurface.PointToClient(Cursor.Position));
            Logic.Point deletionPoint = new Logic.Point(point.X / cellSizeInPixels, point.Y / cellSizeInPixels);

            try {
                bool existOpeningInPoint = selectedBluePrint.GetOpenings().Any(x => x.GetPosition().Equals(deletionPoint));
                bool existWallInPoint = selectedBluePrint.GetWalls().Any(x => x.DoesContainPoint(deletionPoint));
                if (existOpeningInPoint) {
                    selectedBluePrint.RemoveOpeningIfExists(deletionPoint);
                }else if(existWallInPoint){
                    Wall wallToDelete = selectedBluePrint.GetWalls().First(x => x.DoesContainPoint(deletionPoint));
                    selectedBluePrint.RemoveWall(wallToDelete.Beginning(), wallToDelete.End());
                }
            } catch (Exception) {
                //error message
            }

            PaintWalls();
            PaintBeams();
            PaintOpenings();
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
              
            /*decimal gridCellWidth = gridLayer.Width / gridCellCountX;
            decimal gridCellHeight = gridLayer.Height / gridCellCountY;
            decimal x = point.X * (gridCellCountX + 1) / gridLayer.Width;
            decimal y = point.Y * (gridCellCountY + 1) / gridLayer.Height;
            point = new System.Drawing.Point(Convert.ToInt32(Math.Round(x * gridCellWidth)), Convert.ToInt32(Math.Round(y * gridCellHeight)));
            return point;*/
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
            
            if(differenceX > differenceY) {
                adjustedPoint = new System.Drawing.Point(point.X, adjustedCoordY);
            }else {
                adjustedPoint = new System.Drawing.Point(adjustedCoordX, point.Y);
            }

            return adjustedPoint;
        }

        //Selection point mouse move
        private void drawSurface_MouseMoveShowSelectedPoint(object sender, MouseEventArgs e) {
            PaintSelectedPoint(Brushes.FloralWhite);
        }
        private void drawSurface_MouseMoveDeleteSelectedPoint(object sender, MouseEventArgs e) {
            PaintSelectedPoint(Brushes.Red);
        }



        //Paint functions
        private void PaintWalls() {
            CreateOrRecreateLayer(ref wallsLayer);
            using (Graphics graphics = Graphics.FromImage(wallsLayer)) {
                ICollection<Wall> walls = selectedBluePrint.GetWalls();
                foreach (Wall wall in walls) {
                    int startX = Convert.ToInt32(wall.Beginning().CoordX) * cellSizeInPixels;
                    int startY = Convert.ToInt32(wall.Beginning().CoordY) * cellSizeInPixels;
                    int endX = Convert.ToInt32(wall.End().CoordX) * cellSizeInPixels;
                    int endY = Convert.ToInt32(wall.End().CoordY) * cellSizeInPixels;
                    graphics.DrawLine(wallPen, new System.Drawing.Point(startX, startY), new System.Drawing.Point(endX, endY));
                }
            }
            drawSurface.Invalidate();
        }
        private void PaintBeams() {
            CreateOrRecreateLayer(ref beamsLayer);
            using (Graphics graphics = Graphics.FromImage(beamsLayer)) {
                ICollection<Beam> beams = selectedBluePrint.GetBeams();
                foreach (Beam beam in beams) {
                    int pointX = Convert.ToInt32(beam.GetPosition().CoordX) * cellSizeInPixels;
                    int pointY = Convert.ToInt32(beam.GetPosition().CoordY) * cellSizeInPixels;
                    graphics.DrawString("■", DefaultFont, beamPen.Brush, pointX - 7, pointY - 5);

                    //graphics.DrawLine(beamPen, point, point);
                    //graphics.DrawString("■", DefaultFont, Brushes.DarkRed, new System.Drawing.Point(pointX, pointY));
                }
            }
            drawSurface.Invalidate();
        }
        /* private void PaintDoors() {
             CreateOrRecreateLayer(ref openingLayer);
             using (Graphics graphics = Graphics.FromImage(openingLayer)) {
                 ICollection<Opening> openings = selectedBluePrint.GetOpenings();
                 foreach (Opening opening in openings) {
                     if (opening is Door) {
                         int pointX = Convert.ToInt32(opening.GetPosition().CoordX) * cellSizeInPixels;
                         int pointY = Convert.ToInt32(opening.GetPosition().CoordY) * cellSizeInPixels;
                         System.Drawing.Point[] points = {
                         new System.Drawing.Point(pointX+5, pointY),
                         new System.Drawing.Point(pointX-5, pointY),
                         new System.Drawing.Point(pointX+5, pointY+10),
                     };
                         graphics.DrawPolygon(doorPen, points);
                     }
                 }
             }
             drawSurface.Invalidate();
         }
         private void PaintWindows() {
             CreateOrRecreateLayer(ref openingLayer);
             using (Graphics graphics = Graphics.FromImage(openingLayer)) {
                 ICollection<Opening> openings = selectedBluePrint.GetOpenings();
                 foreach (Opening opening in openings) {
                     if (opening is Window) {
                         int pointX = Convert.ToInt32(opening.GetPosition().CoordX) * cellSizeInPixels;
                         int pointY = Convert.ToInt32(opening.GetPosition().CoordY) * cellSizeInPixels;
                         System.Drawing.Point[] points = {
                             new System.Drawing.Point(pointX+5, pointY+5),
                             new System.Drawing.Point(pointX-5, pointY+5),
                             new System.Drawing.Point(pointX+5, pointY-5),
                             new System.Drawing.Point(pointX-5, pointY-5)
                         };
                         graphics.DrawPolygon(windowPen, points);
                     }
                 }
             }
             drawSurface.Invalidate();
         }
         */
        private void PaintOpenings() {
            CreateOrRecreateLayer(ref openingLayer);
            using (Graphics graphics = Graphics.FromImage(openingLayer)) {
                ICollection<Opening> openings = selectedBluePrint.GetOpenings();
                foreach (Opening opening in openings) {
                    if (opening is Window) {
                        int pointX = Convert.ToInt32(opening.GetPosition().CoordX) * cellSizeInPixels;
                        int pointY = Convert.ToInt32(opening.GetPosition().CoordY) * cellSizeInPixels;
                        System.Drawing.Point[] points = {
                            new System.Drawing.Point(pointX+5, pointY+5),
                            new System.Drawing.Point(pointX-5, pointY+5),
                            new System.Drawing.Point(pointX+5, pointY-5),
                            new System.Drawing.Point(pointX-5, pointY-5)
                        };
                        graphics.DrawPolygon(windowPen, points);
                    }

                    if (opening is Door) {
                        int pointX = Convert.ToInt32(opening.GetPosition().CoordX) * cellSizeInPixels;
                        int pointY = Convert.ToInt32(opening.GetPosition().CoordY) * cellSizeInPixels;
                        System.Drawing.Point[] points = {
                        new System.Drawing.Point(pointX+5, pointY),
                        new System.Drawing.Point(pointX-5, pointY),
                        new System.Drawing.Point(pointX+5, pointY+10),
                    };
                        graphics.DrawPolygon(doorPen, points);
                    }
                }
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
        private void PaintSelectedPoint(Brush pointerBrush) {
            CreateOrRecreateLayer(ref currentLineLayer);
            using (Graphics graphics = Graphics.FromImage(currentLineLayer)) {
                System.Drawing.Point actualPoint =AdjustPointToGrid(drawSurface.PointToClient(Cursor.Position));
                graphics.DrawString("♦", DefaultFont, pointerBrush, actualPoint.X - 5, actualPoint.Y - 5);
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

        private void EditBlueprintView_Load(object sender, EventArgs e) {
            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveShowSelectedPoint);
        }

        //Tool selected buttons click
        private void btnPointerTool_Click(object sender, EventArgs e) {
            RemoveEveryHandler();
            EnableEveryButton();
            btnPointerTool.Enabled = false;

        }
        private void btnWallTool_Click(object sender, EventArgs e) {
            RemoveEveryHandler();
            EnableEveryButton();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickStartWall);
            btnWallTool.Enabled = false;
        }
        private void btnWindowTool_Click(object sender, EventArgs e) {
            RemoveEveryHandler();
            EnableEveryButton();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickInsertWindow);
            btnWindowTool.Enabled = false;

        }
        private void btnDoorTool_Click(object sender, EventArgs e) {
            RemoveEveryHandler();
            EnableEveryButton();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickInsertDoor);
            btnDoorTool.Enabled = false;

        }
        private void btnEraserTool_Click(object sender, EventArgs e) {
            RemoveEveryHandler();
            EnableEveryButton();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickErase);
            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveDeleteSelectedPoint);
            btnEraserTool.Enabled = false;
        }

        private void RemoveEveryHandler() {
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickInsertDoor);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickInsertWindow);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickErase);
            drawSurface.MouseMove -= new MouseEventHandler(drawSurface_MouseMoveDeleteSelectedPoint);
        }

        private void EnableEveryButton() {
            btnPointerTool.Enabled = true;
            btnWallTool.Enabled = true;
            btnWindowTool.Enabled = true;
            btnDoorTool.Enabled = true;
            btnEraserTool.Enabled = true;

        }
    }
}
