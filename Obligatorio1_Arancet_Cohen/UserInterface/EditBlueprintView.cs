using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic.Domain;
using System.Drawing.Imaging;
using Services;
using DataAccess;
using RepositoryInterface;

namespace UserInterface
{

    public partial class EditBlueprintView : UserControl
    {

        private Blueprint selectedBluePrint;
        private Session CurrentSession { get; set; }
        private NoFlickerPanel drawSurface;
        private LoggedInView parent;
        private Bitmap gridLayer;
        private Bitmap wallsLayer;
        private Bitmap beamsLayer;
        private Bitmap columnsLayer;
        private Bitmap openingLayer;
        private Bitmap currentLineLayer;
        private Bitmap currentPointLayer;
        private System.Drawing.Point start;
        private Pen wallPen;
        private Pen beamPen;
        private Pen doorPen;
        private Pen windowPen;
        private Pen columnPen;
        private BlueprintEditor editor;
        private OpeningFactory openingFactory;


        private int gridCellCountX;
        private int gridCellCountY;
        private int cellSizeInPixels;
        private int windowXBoundryInPixels;
        private int windowYBoundryInPixels;
        private int gridLinesMarginToLayerInPixels;
        private int drawSurfaceMarginToWindowInPixels;

        public EditBlueprintView(Session aSession, LoggedInView aParent, Blueprint aBlueprint)
        {
            InitializeComponent();

            CurrentSession = aSession;
            parent = aParent;
            selectedBluePrint = aBlueprint;

            BlueprintPanel.Cursor = Cursors.Cross;
            editor = new BlueprintEditor(aSession, aBlueprint);
            IRepository<Template> templateRepository = new OpeningTemplateRepository();
            openingFactory = new OpeningFactory(templateRepository);

            wallPen = new Pen(Brushes.Black, 5);
            beamPen = new Pen(Brushes.DarkRed, 8);
            doorPen = new Pen(Brushes.DarkGoldenrod, 1);
            windowPen = new Pen(Brushes.Sienna, 1);
            columnPen = new Pen(Brushes.Purple, 12);

            gridLinesMarginToLayerInPixels = 1;
            drawSurfaceMarginToWindowInPixels = 10;
            gridCellCountX = aBlueprint.Length;
            gridCellCountY = aBlueprint.Width;
            windowXBoundryInPixels = this.BlueprintPanel.Width;
            windowYBoundryInPixels = this.BlueprintPanel.Height;

            ICollection<IGridPaintStrategy> gridPaintStrategies = new List<IGridPaintStrategy>();
            gridPaintStrategies.Add(new CompleteLineGridPaint(gridLayer, gridCellCountX, gridCellCountY, gridLinesMarginToLayerInPixels));
            gridPaintStrategies.Add(new DottedLineGridPaint(gridLayer, gridCellCountX, gridCellCountY, gridLinesMarginToLayerInPixels));
            gridPaintStrategies.Add(new NoPaintedGridLinesStrategy());
            cmbGridLines.DataSource = gridPaintStrategies;
            setUpDrawSurface(40);

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            PaintColumns();
            calulateCostsAndPrices();

            ICollection<Template> templatesInDB = templateRepository.GetAll();
            cmbTemplates.DataSource = templatesInDB;
        }

        //Auxiliar
        private Logic.Domain.Point DrawablePointIntoLogicPoint(System.Drawing.Point point)
        {
            float pointX = point.X;
            float pointY = point.Y;
            float cellSize = cellSizeInPixels;
            return new Logic.Domain.Point(pointX / cellSize, pointY / cellSize);
        }
        private System.Drawing.Point LogicPointIntoDrawablePoint(Logic.Domain.Point point)
        {
            return new System.Drawing.Point(Convert.ToInt32(point.CoordX * cellSizeInPixels), Convert.ToInt32(point.CoordY * cellSizeInPixels));
        }
        private void calulateCostsAndPrices()
        {
            BlueprintReportGenerator reportGenerator = new BlueprintReportGenerator();
            BlueprintCostReport costReport = reportGenerator.GenerateCostReport(selectedBluePrint);
            BlueprintPriceReport priceReport = reportGenerator.GeneratePriceReport(selectedBluePrint);

            lblWallsTotalCost.Text = costReport.GetTotalCost(ComponentType.WALL) + "";
            lblBeamsTotalCost.Text = costReport.GetTotalCost(ComponentType.BEAM) + "";
            lblDoorsTotalCost.Text = costReport.GetTotalCost(ComponentType.DOOR) + "";
            lblWindowsTotalCost.Text = costReport.GetTotalCost(ComponentType.WINDOW) + "";
            lblColumnsTotalCost.Text = costReport.GetTotalCost(ComponentType.COLUMN) + "";
            lblTotalCostSum.Text = (costReport.GetTotalCost(ComponentType.WALL) + costReport.GetTotalCost(ComponentType.BEAM) + costReport.GetTotalCost(ComponentType.DOOR) + costReport.GetTotalCost(ComponentType.WINDOW)) + costReport.GetTotalCost(ComponentType.COLUMN) + "";

            lblWallsPrice.Text = priceReport.GetTotalPrice(ComponentType.WALL) + "";
            lblBeamsPrice.Text = priceReport.GetTotalPrice(ComponentType.BEAM) + "";
            lblDoorsPrice.Text = priceReport.GetTotalPrice(ComponentType.DOOR) + "";
            lblWindowsPrice.Text = priceReport.GetTotalPrice(ComponentType.WINDOW) + "";
            lblColumnsTotalPrice.Text = priceReport.GetTotalPrice(ComponentType.COLUMN) + "";
            lblTotalPriceSum.Text = (priceReport.GetTotalPrice(ComponentType.WALL) + priceReport.GetTotalPrice(ComponentType.BEAM) + priceReport.GetTotalPrice(ComponentType.DOOR) + priceReport.GetTotalPrice(ComponentType.WINDOW)) + priceReport.GetTotalPrice(ComponentType.COLUMN) + "";
        }


        //Grid and panel config functions
        private void PaintGrid()
        {
            IGridPaintStrategy gridPainter = (IGridPaintStrategy)cmbGridLines.SelectedItem;
            gridPainter.SetCountX(gridCellCountX);
            gridPainter.SetCountY(gridCellCountY);
            gridPainter.SetLayer(gridLayer);
            gridPainter.SetMargin(gridLinesMarginToLayerInPixels);
            gridPainter.PaintGrid();
            /*using (Graphics graphics = Graphics.FromImage(gridLayer))
            {
                for (int i = 0; i < gridCellCountY; i++)
                {
                    DrawGridHorizontalLines(graphics, i);
                }
                for (int i = 0; i < gridCellCountX; i++)
                {
                    DrawGridVerticalLines(graphics, i);
                }
                DrawGridRightAndBottomLines(graphics);
            }*/
            drawSurface.Invalidate();
        }
        private void DrawGridHorizontalLines(Graphics graphics, int axis)
        {
            DrawHorizontalLine(graphics, axis, 0);
        }
        private void DrawGridVerticalLines(Graphics graphics, int axis)
        {
            DrawVerticalLine(graphics, axis, 0);
        }
        private void DrawGridRightAndBottomLines(Graphics graphics)
        {
            DrawHorizontalLine(graphics, gridCellCountY, -gridLinesMarginToLayerInPixels);
            DrawVerticalLine(graphics, gridCellCountX, -gridLinesMarginToLayerInPixels);
        }
        private void DrawHorizontalLine(Graphics graphics, int axis, int offset)
        {
            int gridCellHeight = axis * gridLayer.Height / gridCellCountY + offset;
            graphics.DrawLine(Pens.White, 0, gridCellHeight, gridLayer.Width, gridCellHeight);
        }
        private void DrawVerticalLine(Graphics graphics, int axis, int offset)
        {
            int gridCellWidth = axis * gridLayer.Width / gridCellCountX + offset;
            graphics.DrawLine(Pens.White, gridCellWidth, 0, gridCellWidth, gridLayer.Height);
        }
        private void CreateDrawSurface(int drawSurfaceSizeX, int drawSurfaceSizeY)
        {
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
        private void drawSurface_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Point zeroing = new System.Drawing.Point(0, 0);
            e.Graphics.DrawImage(gridLayer, zeroing);
            e.Graphics.DrawImage(currentLineLayer, zeroing);
            e.Graphics.DrawImage(currentPointLayer, zeroing);
            e.Graphics.DrawImage(wallsLayer, zeroing);
            e.Graphics.DrawImage(beamsLayer, zeroing);
            e.Graphics.DrawImage(openingLayer, zeroing);
            e.Graphics.DrawImage(columnsLayer, zeroing);
        }

        //Wall events
        private void drawSurface_MouseClickStartWall(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            start = point;

            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMovePaintWall);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickEndWall);
        }
        private void drawSurface_MouseClickEndWall(object sender, MouseEventArgs e)
        {

            System.Drawing.Point gridAjustedPoint = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            System.Drawing.Point endPoint = AdjustPointToHorizontalOrVerticalLine(gridAjustedPoint);

            try
            {
                editor.InsertWall(DrawablePointIntoLogicPoint(start), DrawablePointIntoLogicPoint(endPoint));
            }
            catch (Exception)
            {

            }

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            calulateCostsAndPrices();

            CreateOrRecreateLayer(ref currentLineLayer);
            CreateOrRecreateLayer(ref currentPointLayer);


            drawSurface.MouseMove -= new MouseEventHandler(drawSurface_MouseMovePaintWall);
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickEndWall);
        }
        private void drawSurface_MouseMovePaintWall(object sender, MouseEventArgs e)
        {
            PaintCurrentLine();
        }

        //Opening events
        private void drawSurface_MouseClickInsertDoor(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            Logic.Domain.Point doorPoint = DrawablePointIntoLogicPoint(point);
            Opening newDoor = new Door(doorPoint);
            InsertAndDrawOpening(newDoor);

        }
        private void drawSurface_MouseClickInsertWindow(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            Logic.Domain.Point doorPoint = DrawablePointIntoLogicPoint(point);
            Opening newWindow = new Window(doorPoint);
            InsertAndDrawOpening(newWindow);
        }
        private void InsertAndDrawOpening(Opening newOpening)
        {
            try
            {
                editor.InsertOpening(newOpening);
            }
            catch (Exception)
            {
                //error message
            }

            PaintOpenings();
            calulateCostsAndPrices();
        }

        //Erase events
        private void drawSurface_MouseClickErase(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = AdjustPointToGrid(drawSurface.PointToClient(Cursor.Position));
            Logic.Domain.Point deletionPointPrecise = DrawablePointIntoLogicPoint(point);
            Logic.Domain.Point closestDeletionPointToGridIntersection = DrawablePointIntoLogicPoint(AdjustPointToGridIntersection(point));

            try
            {
                bool existOpeningInPoint = selectedBluePrint.GetOpenings().Any(x => x.GetPosition().Equals(closestDeletionPointToGridIntersection));
                bool existWallInPoint = selectedBluePrint.GetWalls().Any(x => x.DoesContainPoint(deletionPointPrecise));
                bool existColumnInPoint = selectedBluePrint.GetColumns().Any(x => x.GetPosition().Equals(closestDeletionPointToGridIntersection));
                if (existOpeningInPoint)
                {
                    Opening openingToRemove = selectedBluePrint.GetOpenings().FirstOrDefault(x => x.GetPosition().Equals(closestDeletionPointToGridIntersection));
                    editor.RemoveOpening(openingToRemove);
                }
                else if (existWallInPoint && !existOpeningInPoint)
                {
                    Wall wallToDelete = selectedBluePrint.GetWalls().First(x => x.DoesContainPoint(deletionPointPrecise));
                    editor.RemoveWall(wallToDelete.Beginning(), wallToDelete.End());
                }
                else if (existColumnInPoint)
                {
                    editor.RemoveColumn(closestDeletionPointToGridIntersection);
                }
            }
            catch (Exception)
            {
                //error message
            }

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            PaintColumns();
            calulateCostsAndPrices();
        }

        //Column events
        private void drawSurface_MouseClickInsertColumn(object sender, MouseEventArgs e)
        {
            System.Drawing.Point columnPoint = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            InsertAndDrawColumn(columnPoint);
        }
        private void InsertAndDrawColumn(System.Drawing.Point newColumnPoint)
        {
            Logic.Domain.Point logicColumnPoint = DrawablePointIntoLogicPoint(newColumnPoint);
            try
            {
                editor.InsertColumn(logicColumnPoint);
            }
            catch (Exception)
            {
                //error message
            }

            PaintColumns();
            calulateCostsAndPrices();
        }

        //Point adjustment functions
        private System.Drawing.Point AdjustPointToHorizontalOrVerticalLine(System.Drawing.Point point)
        {
            int xDifference = Math.Abs(point.X - start.X);
            int yDifference = Math.Abs(point.Y - start.Y);
            System.Drawing.Point returnedEndpoint;

            if (xDifference < yDifference)
            {
                returnedEndpoint = new System.Drawing.Point(start.X, point.Y);
            }
            else
            {
                returnedEndpoint = new System.Drawing.Point(point.X, start.Y);
            }

            return returnedEndpoint;
        }
        private System.Drawing.Point AdjustPointToGridIntersection(System.Drawing.Point point)
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

            /*decimal gridCellWidth = gridLayer.Width / gridCellCountX;
            decimal gridCellHeight = gridLayer.Height / gridCellCountY;
            decimal x = point.X * (gridCellCountX + 1) / gridLayer.Width;
            decimal y = point.Y * (gridCellCountY + 1) / gridLayer.Height;
            point = new System.Drawing.Point(Convert.ToInt32(Math.Round(x * gridCellWidth)), Convert.ToInt32(Math.Round(y * gridCellHeight)));
            return point;*/
        }
        private System.Drawing.Point AdjustPointToGrid(System.Drawing.Point point)
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

        //Selection point mouse move
        private void drawSurface_MouseMoveShowSelectedPoint(object sender, MouseEventArgs e)
        {
            PaintPoint(Brushes.FloralWhite);
        }
        private void drawSurface_MouseMoveDeleteSelectedPoint(object sender, MouseEventArgs e)
        {
            PaintPoint(Brushes.Red);
        }
        private void drawSurface_MouseClickShowTemplateInfo(object sender, MouseEventArgs e)
        {
            System.Drawing.Point selectedPoint = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            Logic.Domain.Point domainSeleectedPoint = DrawablePointIntoLogicPoint(selectedPoint);
            if (selectedBluePrint.GetOpenings().Any(x => x.GetPosition().Equals(domainSeleectedPoint)))
            {
                Opening selectedOpening = selectedBluePrint.GetOpenings().First(x => x.GetPosition().Equals(domainSeleectedPoint));
                ShowTemplateInfo(selectedOpening.getTemplate());
            }
        }

        //Paint functions
        private void PaintWalls()
        {
            CreateOrRecreateLayer(ref wallsLayer);
            ICollection<Wall> walls = selectedBluePrint.GetWalls();
            foreach (Wall wall in walls)
            {
                PaintWall(wall);
            }
            drawSurface.Invalidate();
        }
        private void PaintBeams()
        {
            CreateOrRecreateLayer(ref beamsLayer);
            using (Graphics graphics = Graphics.FromImage(beamsLayer))
            {
                ICollection<Beam> beams = selectedBluePrint.GetBeams();
                foreach (Beam beam in beams)
                {
                    PaintBeam(beam);
                }
            }
            drawSurface.Invalidate();
        }
        private void PaintOpenings()
        {
            CreateOrRecreateLayer(ref openingLayer);
            ICollection<Opening> openings = selectedBluePrint.GetOpenings();

            foreach (Opening opening in openings.Where(x => x.GetComponentType() == ComponentType.DOOR))
            {
                Wall wall = selectedBluePrint.GetWalls().First(x => x.DoesContainPoint(opening.GetPosition()));
                if (wall.Beginning().CoordX == wall.End().CoordX)
                {
                    PaintVerticalDoor(opening);
                }
                else
                {
                    PaintHorizontalDoor(opening);
                }
            }
            foreach (Opening opening in openings.Where(x => x.GetComponentType() == ComponentType.WINDOW))
            {
                Wall wall = selectedBluePrint.GetWalls().First(x => x.DoesContainPoint(opening.GetPosition()));
                if (wall.Beginning().CoordX == wall.End().CoordX)
                {
                    PaintVerticalWindow(opening);
                }
                else
                {
                    PaintHorizontalWindow(opening);
                }
            }
            drawSurface.Invalidate();
        }
        private void PaintColumns()
        {
            CreateOrRecreateLayer(ref columnsLayer);
            ICollection<ISinglePointComponent> columns = selectedBluePrint.GetColumns();
            foreach (Column column in columns)
            {
                PaintColumn(column);
            }

            drawSurface.Invalidate();
        }
        private void PaintCurrentLine()
        {
            CreateOrRecreateLayer(ref currentLineLayer);
            using (Graphics graphics = Graphics.FromImage(currentLineLayer))
            {
                graphics.DrawLine(wallPen, start, drawSurface.PointToClient(Cursor.Position));
            }
            drawSurface.Invalidate();
        }
        private void PaintPoint(Brush pointerBrush)
        {
            CreateOrRecreateLayer(ref currentPointLayer);
            using (Graphics graphics = Graphics.FromImage(currentPointLayer))
            {
                System.Drawing.Point actualPoint = AdjustPointToGrid(drawSurface.PointToClient(Cursor.Position));
                graphics.DrawString("♦", DefaultFont, pointerBrush, actualPoint.X - 5, actualPoint.Y - 5);
            }
            drawSurface.Invalidate();
        }
        private void PaintWall(Wall wall)
        {
            using (Graphics graphics = Graphics.FromImage(wallsLayer))
            {
                graphics.DrawLine(wallPen, LogicPointIntoDrawablePoint(wall.Beginning()), LogicPointIntoDrawablePoint(wall.End()));
            }
        }
        private void PaintBeam(Beam beam)
        {
            using (Graphics graphics = Graphics.FromImage(beamsLayer))
            {
                System.Drawing.Point drawPoint = LogicPointIntoDrawablePoint(beam.GetPosition());
                graphics.DrawString("■", DefaultFont, beamPen.Brush, drawPoint.X - 7, drawPoint.Y - 5);
            }
        }
        private void PaintHorizontalDoor(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(openingLayer))
            {
                System.Drawing.Point center = LogicPointIntoDrawablePoint(opening.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((opening.Length() * cellSizeInPixels) / 2);
                System.Drawing.Point[] points = {
                        new System.Drawing.Point(center.X+halfLengthInPixels, center.Y),
                        new System.Drawing.Point(center.X-halfLengthInPixels, center.Y),
                        new System.Drawing.Point(center.X+halfLengthInPixels, center.Y+halfLengthInPixels/2),
                     };
                graphics.DrawPolygon(doorPen, points);
                graphics.FillPolygon(doorPen.Brush, points);

            }
        }
        private void PaintVerticalDoor(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(openingLayer))
            {
                System.Drawing.Point center = LogicPointIntoDrawablePoint(opening.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((opening.Length() * cellSizeInPixels) / 2);
                System.Drawing.Point[] points = {
                        new System.Drawing.Point(center.X, center.Y+halfLengthInPixels),
                        new System.Drawing.Point(center.X, center.Y-halfLengthInPixels),
                        new System.Drawing.Point(center.X+halfLengthInPixels/2, center.Y+halfLengthInPixels),
                     };
                graphics.DrawPolygon(doorPen, points);
                graphics.FillPolygon(doorPen.Brush, points);

            }
        }
        private void PaintHorizontalWindow(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(openingLayer))
            {
                System.Drawing.Point center = LogicPointIntoDrawablePoint(opening.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((opening.Length() * cellSizeInPixels)/2);
                System.Drawing.Point[] points = {
                            new System.Drawing.Point(center.X+halfLengthInPixels, center.Y+5),
                            new System.Drawing.Point(center.X-halfLengthInPixels, center.Y+5),
                            new System.Drawing.Point(center.X+halfLengthInPixels, center.Y-5),
                            new System.Drawing.Point(center.X-halfLengthInPixels, center.Y-5)
                        };
                graphics.DrawPolygon(windowPen, points);
                graphics.FillPolygon(windowPen.Brush, points);

            }
        }
        private void PaintVerticalWindow(Opening opening)
        {
            using (Graphics graphics = Graphics.FromImage(openingLayer))
            {
                System.Drawing.Point center = LogicPointIntoDrawablePoint(opening.GetPosition());
                int halfLengthInPixels = Convert.ToInt32((opening.Length() * cellSizeInPixels) / 2);
                System.Drawing.Point[] points = {
                            new System.Drawing.Point(center.X+5, center.Y+halfLengthInPixels),
                            new System.Drawing.Point(center.X+5, center.Y-halfLengthInPixels),
                            new System.Drawing.Point(center.X-5, center.Y+halfLengthInPixels),
                            new System.Drawing.Point(center.X-5, center.Y-halfLengthInPixels)
                        };
                graphics.DrawPolygon(windowPen, points);
                graphics.FillPolygon(windowPen.Brush, points);
            }
        }
        private void PaintColumn(Column column)
        {
            using (Graphics graphics = Graphics.FromImage(columnsLayer))
            {
                System.Drawing.Point drawPoint = LogicPointIntoDrawablePoint(column.GetPosition());
                graphics.DrawString("■", DefaultFont, columnPen.Brush, drawPoint.X - 7, drawPoint.Y - 5);
            }
        }


        private void CreateOrRecreateLayer(ref Bitmap layer)
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
        private void EditBlueprintView_Load(object sender, EventArgs e)
        {
            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveShowSelectedPoint);
        }

        //Tool selected buttons click
        private void btnPointerTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            btnPointerTool.Enabled = false;
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickShowTemplateInfo);
        }
        private void btnWallTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickStartWall);
            btnWallTool.Enabled = false;
        }
        private void btnWindowTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickInsertWindow);
        }
        private void btnDoorTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickInsertDoor);
        }
        private void btnEraserTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickErase);
            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveDeleteSelectedPoint);
            btnEraserTool.Enabled = false;
        }
        private void btnColumnTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickInsertColumn);
            btnColumnTool.Enabled = false;
        }
        private void btnOpeningTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickInsertOpening);
            btnOpeningTool.Enabled = false;
        }

        private void drawSurface_MouseClickInsertOpening(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = AdjustPointToGridIntersection(drawSurface.PointToClient(Cursor.Position));
            Logic.Domain.Point openingPoint = DrawablePointIntoLogicPoint(point);
            Template selectedTemplate = (Template)cmbTemplates.SelectedItem;
            Opening newOpening = openingFactory.CreateFromTemplate(openingPoint, selectedTemplate.Name);
            InsertAndDrawOpening(newOpening);
        }

        private void RemoveEveryHandler()
        {
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickInsertDoor);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickInsertWindow);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickErase);
            drawSurface.MouseMove -= new MouseEventHandler(drawSurface_MouseMoveDeleteSelectedPoint);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickInsertColumn);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickInsertOpening);
            drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickShowTemplateInfo);
        }
        private void EnableEveryTool()
        {
            btnPointerTool.Enabled = true;
            btnWallTool.Enabled = true;
            btnEraserTool.Enabled = true;
            btnColumnTool.Enabled = true;
            btnOpeningTool.Enabled = true;
        }

        private void btnExportBlueprint_Click(object sender, EventArgs e)
        {
            int width = drawSurface.Size.Width;
            int height = drawSurface.Size.Height;

            Bitmap bitmapToExport = new Bitmap(width, height);
            CreateOrRecreateLayer(ref currentPointLayer);
            drawSurface.DrawToBitmap(bitmapToExport, new Rectangle(0, 0, width, height));


            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
                saveFile.ShowDialog();
                var path = saveFile.FileName;

                ImageFormat imageFormatSelected = ImageFormat.Png;
                if (saveFile.Filter == ".jpeg")
                {
                    imageFormatSelected = ImageFormat.Jpeg;
                }
                else if (saveFile.Filter == ".png")
                {
                    imageFormatSelected = ImageFormat.Png;
                }
                bitmapToExport.Save(path, imageFormatSelected);
            }
            catch (ArgumentException)
            {

            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            setUpDrawSurface(cellSizeInPixels + 10);
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            setUpDrawSurface(cellSizeInPixels - 10);
        }

        private void setUpDrawSurface(int cellSize)
        {
            if (BlueprintPanel.Controls.Contains(drawSurface))
            {
                BlueprintPanel.Controls.Remove(drawSurface);
            }

            cellSizeInPixels = ValidateCellSize(cellSize);

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
            CreateOrRecreateLayer(ref columnsLayer);
            CreateOrRecreateLayer(ref currentLineLayer);
            CreateOrRecreateLayer(ref currentPointLayer);

            BlueprintPanel.Refresh();

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            PaintColumns();
            drawSurface.Refresh();
            drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveShowSelectedPoint);
            EnableEveryTool();
        }

        private int ValidateCellSize(int cellSize)
        {
            int returnedCellSize = cellSize;
            if (returnedCellSize < 10)
            {
                returnedCellSize = 10;
            }
            else if (returnedCellSize > 60)
            {
                returnedCellSize = 60;
            }
            return returnedCellSize;
        }

        private void ShowTemplateInfo(Template template)
        {
            lblOpeningLength.Text = template.Length.ToString();
            cmbTemplates.SelectedItem = template;
        }

        private void cmbTemplates_SelectedValueChanged(object sender, EventArgs e)
        {
            lblOpeningLength.Text = ((Template)cmbTemplates.SelectedValue).Length.ToString();
        }

        private void cmbGridLines_SelectedValueChanged(object sender, EventArgs e)
        {
            setUpDrawSurface(cellSizeInPixels);

        }
    }
}