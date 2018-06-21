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
using RepositoryInterface;
using DataAccess;
using DomainRepositoryInterface;

namespace UserInterface
{

    public partial class EditBlueprintView : UserControl
    {

        private Blueprint selectedBluePrint;
        private Session CurrentSession { get; set; }
        private LoggedInView parent;
        private Drawer drawer;
        private BlueprintEditor editor;
        private OpeningFactory openingFactory;

        public EditBlueprintView(Session aSession, LoggedInView aParent, Blueprint aBlueprint)
        {
            InitializeComponent();

            CurrentSession = aSession;
            parent = aParent;
            selectedBluePrint = aBlueprint;
            parent.ParentForm.FormClosing += new FormClosingEventHandler(CheckSignmentEventHandler);

            BlueprintPanel.Cursor = Cursors.Cross;
            IRepository<IBlueprint> bpStorage = new BlueprintRepository();
            IRepository<Template> templatesRepository = new OpeningTemplateRepository();
            editor = new BlueprintEditor(aSession, aBlueprint, bpStorage, templatesRepository);
            IRepository<Template> templates = new OpeningTemplateRepository();
            openingFactory = new OpeningFactory(templates);


            int gridLinesMarginToLayerInPixels = 1;
            int drawSurfaceMarginToWindowInPixels = 10;
            int gridCellCountX = aBlueprint.Length;
            int gridCellCountY = aBlueprint.Width;
            int windowXBoundryInPixels = this.BlueprintPanel.Width;
            int windowYBoundryInPixels = this.BlueprintPanel.Height;
            drawer = new Drawer(gridCellCountX, gridCellCountY, 40, windowXBoundryInPixels, windowYBoundryInPixels, gridLinesMarginToLayerInPixels, drawSurfaceMarginToWindowInPixels);
            LoadGridPaintStrategies();
            setUpDrawSurface(40);

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            PaintColumns();
            calulateCostsAndPrices();
            ShowOrHideSignButton();
            ShowOrHideTools();

            ICollection<Template> templatesInDB = editor.GetTemplates();
            cmbTemplates.DataSource = templatesInDB;

        }

        private void LoadGridPaintStrategies()
        {
            ICollection<IGridPaintStrategy> gridPaintStrategies = new List<IGridPaintStrategy>();
            gridPaintStrategies.Add(new CompleteLineGridPaint(drawer.layers.gridLayer, drawer.GridCellCountX, drawer.GridCellCountY, drawer.GridLinesMarginToLayerInPixels));
            gridPaintStrategies.Add(new DottedLineGridPaint(drawer.layers.gridLayer, drawer.GridCellCountX, drawer.GridCellCountY, drawer.GridLinesMarginToLayerInPixels));
            gridPaintStrategies.Add(new NoPaintedGridLinesStrategy());
            cmbGridLines.DataSource = gridPaintStrategies;
        }
        private void ShowOrHideTools()
        {
            ToolsPanel.Visible = CurrentSession.UserLogged.HasPermission(Permission.EDIT_BLUEPRINT);
        }
        private void ShowOrHideSignButton()
        {
            btnSign.Visible = CurrentSession.UserLogged.HasPermission(Permission.CAN_SIGN_BLUEPRINT);
        }

        //Auxiliar
        private void calulateCostsAndPrices()
        {
            IPriceCostRepository pricesNcosts = new PriceCostRepository();
            BlueprintReportGenerator reportGenerator = new BlueprintReportGenerator(pricesNcosts);
            BlueprintCostReport costReport = reportGenerator.GenerateCostReport(selectedBluePrint);
            BlueprintPriceReport priceReport = reportGenerator.GeneratePriceReport(selectedBluePrint);

            if (CurrentSession.UserLogged.HasPermission(Permission.VIEW_COSTS))
            {
                lblWallsTotalCost.Text = costReport.GetTotalCost(ComponentType.WALL) + "";
                lblBeamsTotalCost.Text = costReport.GetTotalCost(ComponentType.BEAM) + "";
                lblDoorsTotalCost.Text = costReport.GetTotalCost(ComponentType.DOOR) + "";
                lblWindowsTotalCost.Text = costReport.GetTotalCost(ComponentType.WINDOW) + "";
                lblColumnsTotalCost.Text = costReport.GetTotalCost(ComponentType.COLUMN) + "";
                lblTotalCostSum.Text = (costReport.GetTotalCost(ComponentType.WALL) + costReport.GetTotalCost(ComponentType.BEAM) + costReport.GetTotalCost(ComponentType.DOOR) + costReport.GetTotalCost(ComponentType.WINDOW)) + costReport.GetTotalCost(ComponentType.COLUMN) + "";
            }
            
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
            drawer.GridPainter = gridPainter;
            drawer.PaintGrid();
            drawer.drawSurface.Invalidate();
        }
       
        private void CreateDrawSurface(int drawSurfaceSizeX, int drawSurfaceSizeY)
        {
            drawer.drawSurface = new NoFlickerPanel();
            SuspendLayout();
            drawer.drawSurface.Name = "drawSurface";
            drawer.drawSurface.Location = new System.Drawing.Point(drawer.DrawSurfaceMarginToWindowInPixels, drawer.DrawSurfaceMarginToWindowInPixels);
            drawer.drawSurface.Size = new Size(drawSurfaceSizeX, drawSurfaceSizeY);
            drawer.drawSurface.TabIndex = 0;
            drawer.drawSurface.Paint += new PaintEventHandler(drawSurface_Paint);
            this.BlueprintPanel.Controls.Add(drawer.drawSurface);
            ResumeLayout(false);
        }
        private void drawSurface_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Point zeroing = new System.Drawing.Point(0, 0);
            e.Graphics.DrawImage(drawer.layers.gridLayer, zeroing);
            e.Graphics.DrawImage(drawer.layers.currentLineLayer, zeroing);
            e.Graphics.DrawImage(drawer.layers.currentPointLayer, zeroing);
            e.Graphics.DrawImage(drawer.layers.wallsLayer, zeroing);
            e.Graphics.DrawImage(drawer.layers.beamsLayer, zeroing);
            e.Graphics.DrawImage(drawer.layers.openingLayer, zeroing);
            e.Graphics.DrawImage(drawer.layers.columnsLayer, zeroing);
        }

        //Wall events
        private void drawSurface_MouseClickStartWall(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = drawer.AdjustPointToGridIntersection(drawer.drawSurface.PointToClient(Cursor.Position));
            drawer.auxiliar = point;

            drawer.drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMovePaintWall);
            drawer.drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawer.drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickEndWall);
        }
        private void drawSurface_MouseClickEndWall(object sender, MouseEventArgs e)
        {

            System.Drawing.Point gridAjustedPoint = drawer.AdjustPointToGridIntersection(drawer.drawSurface.PointToClient(Cursor.Position));
            System.Drawing.Point end = drawer.AdjustPointToHorizontalOrVerticalLine(gridAjustedPoint);

            try
            {
                editor.InsertWall(drawer.pointConverter.DrawablePointIntoLogicPoint(drawer.auxiliar), drawer.pointConverter.DrawablePointIntoLogicPoint(end));
            }
            catch (Exception)
            {

            }

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            calulateCostsAndPrices();

            drawer.CreateOrRecreateLayer(ref drawer.layers.currentLineLayer);
            drawer.CreateOrRecreateLayer(ref drawer.layers.currentPointLayer);


            drawer.drawSurface.MouseMove -= new MouseEventHandler(drawSurface_MouseMovePaintWall);
            drawer.drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawer.drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickEndWall);
        }
        private void drawSurface_MouseMovePaintWall(object sender, MouseEventArgs e)
        {
            drawer.PaintCurrentLine(drawer.drawSurface.PointToClient(Cursor.Position));
        }

        //Opening events
        private void drawSurface_MouseClickInsertOpening(object sender, MouseEventArgs e)
        {
            System.Drawing.Point point = drawer.AdjustPointToGridIntersection(drawer.drawSurface.PointToClient(Cursor.Position));
            Logic.Domain.Point openingPoint = drawer.pointConverter.DrawablePointIntoLogicPoint(point);
            Template selectedTemplate = (Template)cmbTemplates.SelectedItem;
            if (selectedTemplate != null)
            {
                Opening newOpening = openingFactory.CreateFromTemplate(openingPoint, selectedTemplate.Name);
                InsertAndDrawOpening(newOpening);
            }
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
            System.Drawing.Point point = drawer.AdjustPointToGrid(drawer.drawSurface.PointToClient(Cursor.Position));
            Logic.Domain.Point deletionPointPrecise = drawer.pointConverter.DrawablePointIntoLogicPoint(point);
            Logic.Domain.Point closestDeletionPointToGridIntersection = drawer.pointConverter.DrawablePointIntoLogicPoint(drawer.AdjustPointToGridIntersection(point));

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
            System.Drawing.Point columnPoint = drawer.AdjustPointToGridIntersection(drawer.drawSurface.PointToClient(Cursor.Position));
            InsertAndDrawColumn(columnPoint);
        }
        private void InsertAndDrawColumn(System.Drawing.Point newColumnPoint)
        {
            Logic.Domain.Point logicColumnPoint = drawer.pointConverter.DrawablePointIntoLogicPoint(newColumnPoint);
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

        //Selection point mouse move
        private void drawSurface_MouseMoveShowSelectedPoint(object sender, MouseEventArgs e)
        {
            drawer.PaintPoint(drawer.drawSurface.PointToClient(Cursor.Position), Brushes.FloralWhite, DefaultFont);
        }
        private void drawSurface_MouseMoveDeleteSelectedPoint(object sender, MouseEventArgs e)
        {
            drawer.PaintPoint(drawer.drawSurface.PointToClient(Cursor.Position), Brushes.Red, DefaultFont);
        }
        private void drawSurface_MouseClickShowTemplateInfo(object sender, MouseEventArgs e)
        {
            System.Drawing.Point selectedPoint = drawer.AdjustPointToGridIntersection(drawer.drawSurface.PointToClient(Cursor.Position));
            Logic.Domain.Point domainSeleectedPoint = drawer.pointConverter.DrawablePointIntoLogicPoint(selectedPoint);
            if (selectedBluePrint.GetOpenings().Any(x => x.GetPosition().Equals(domainSeleectedPoint)))
            {
                Opening selectedOpening = selectedBluePrint.GetOpenings().First(x => x.GetPosition().Equals(domainSeleectedPoint));
                ShowTemplateInfo(selectedOpening.getTemplate());
            }
        }

        //Paint functions
        private void PaintWalls()
        {
            drawer.CreateOrRecreateLayer(ref drawer.layers.wallsLayer);
            ICollection<Wall> walls = selectedBluePrint.GetWalls();
            foreach (Wall wall in walls)
            {
                drawer.PaintWall(wall);
            }
            drawer.drawSurface.Invalidate();
        }
        private void PaintBeams()
        {
            drawer.CreateOrRecreateLayer(ref drawer.layers.beamsLayer);
            using (Graphics graphics = Graphics.FromImage(drawer.layers.beamsLayer))
            {
                ICollection<Beam> beams = selectedBluePrint.GetBeams();
                foreach (Beam beam in beams)
                {
                   drawer.PaintBeam(beam, DefaultFont);
                }
            }
            drawer.drawSurface.Invalidate();
        }
        private void PaintOpenings()
        {
            drawer.CreateOrRecreateLayer(ref drawer.layers.openingLayer);
            ICollection<Opening> openings = selectedBluePrint.GetOpenings();

            foreach (Opening opening in openings.Where(x => x.GetComponentType() == ComponentType.DOOR))
            {
                Wall wall = selectedBluePrint.GetWalls().First(x => x.DoesContainPoint(opening.GetPosition()));
                if (wall.Beginning().CoordX == wall.End().CoordX)
                {
                    drawer.PaintVerticalDoor(opening);
                }
                else
                {
                    drawer.PaintHorizontalDoor(opening);
                }
            }
            foreach (Opening opening in openings.Where(x => x.GetComponentType() == ComponentType.WINDOW))
            {
                Wall wall = selectedBluePrint.GetWalls().First(x => x.DoesContainPoint(opening.GetPosition()));
                if (wall.Beginning().CoordX == wall.End().CoordX)
                {
                    drawer.PaintVerticalWindow(opening);
                }
                else
                {
                    drawer.PaintHorizontalWindow(opening);
                }
            }
            drawer.drawSurface.Invalidate();
        }
        private void PaintColumns()
        {
            drawer.CreateOrRecreateLayer(ref drawer.layers.columnsLayer);
            ICollection<ISinglePointComponent> columns = selectedBluePrint.GetColumns();
            foreach (Column column in columns)
            {
                drawer.PaintColumn(column);
            }

            drawer.drawSurface.Invalidate();
        }
        
        private void EditBlueprintView_Load(object sender, EventArgs e)
        {
            drawer.drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveShowSelectedPoint);
        }

        //Tool selected buttons click
        private void btnPointerTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            btnPointerTool.Enabled = false;
            drawer.drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickShowTemplateInfo);
        }
        private void btnWallTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawer.drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickStartWall);
            btnWallTool.Enabled = false;
        }
        private void btnEraserTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawer.drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickErase);
            drawer.drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveDeleteSelectedPoint);
            btnEraserTool.Enabled = false;
        }
        private void btnColumnTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawer.drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickInsertColumn);
            btnColumnTool.Enabled = false;
        }
        private void btnOpeningTool_Click(object sender, EventArgs e)
        {
            RemoveEveryHandler();
            EnableEveryTool();
            drawer.drawSurface.MouseClick += new MouseEventHandler(drawSurface_MouseClickInsertOpening);
            btnOpeningTool.Enabled = false;
        }
        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            setUpDrawSurface(drawer.CellSizeInPixels + 10);
        }
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            setUpDrawSurface(drawer.CellSizeInPixels - 10);
        }
        private void RemoveEveryHandler()
        {
            drawer.drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickStartWall);
            drawer.drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickErase);
            drawer.drawSurface.MouseMove -= new MouseEventHandler(drawSurface_MouseMoveDeleteSelectedPoint);
            drawer.drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickInsertColumn);
            drawer.drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickInsertOpening);
            drawer.drawSurface.MouseClick -= new MouseEventHandler(drawSurface_MouseClickShowTemplateInfo);
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
            int width = drawer.drawSurface.Size.Width;
            int height = drawer.drawSurface.Size.Height;

            Bitmap bitmapToExport = new Bitmap(width, height);
            drawer.CreateOrRecreateLayer(ref drawer.layers.currentPointLayer);
            drawer.drawSurface.DrawToBitmap(bitmapToExport, new Rectangle(0, 0, width, height));

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


        private void setUpDrawSurface(int cellSize)
        {
            if (BlueprintPanel.Controls.Contains(drawer.drawSurface))
            {
                BlueprintPanel.Controls.Remove(drawer.drawSurface);
            }

            drawer.CellSizeInPixels = ValidateCellSize(cellSize);

            int cellSizeInPixelsX = (drawer.WindowXBoundryInPixels - 2 * drawer.DrawSurfaceMarginToWindowInPixels) / drawer.GridCellCountX;
            int cellSizeInPixelsY = (drawer.WindowXBoundryInPixels - 2 * drawer.DrawSurfaceMarginToWindowInPixels) / drawer.GridCellCountY;
            int drawSurfaceSizeX = drawer.CellSizeInPixels * drawer.GridCellCountX;
            int drawSurfaceSizeY = drawer.CellSizeInPixels * drawer.GridCellCountY;
            CreateOrRecreateLayers(drawSurfaceSizeX, drawSurfaceSizeY);
            BlueprintPanel.Refresh();

            PaintWalls();
            PaintBeams();
            PaintOpenings();
            PaintColumns();
            drawer.drawSurface.Refresh();
            drawer.drawSurface.MouseMove += new MouseEventHandler(drawSurface_MouseMoveShowSelectedPoint);
            EnableEveryTool();
        }
        private void CreateOrRecreateLayers(int drawSurfaceSizeX, int drawSurfaceSizeY)
        {
            CreateDrawSurface(drawSurfaceSizeX, drawSurfaceSizeY);
            drawer.CreateOrRecreateLayer(ref drawer.layers.gridLayer);
            PaintGrid();
            drawer.CreateOrRecreateLayer(ref drawer.layers.wallsLayer);
            drawer.CreateOrRecreateLayer(ref drawer.layers.beamsLayer);
            drawer.CreateOrRecreateLayer(ref drawer.layers.openingLayer);
            drawer.CreateOrRecreateLayer(ref drawer.layers.columnsLayer);
            drawer.CreateOrRecreateLayer(ref drawer.layers.currentLineLayer);
            drawer.CreateOrRecreateLayer(ref drawer.layers.currentPointLayer);
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
            setUpDrawSurface(drawer.CellSizeInPixels);

        }

        //Signment
        private void btnSign_Click(object sender, EventArgs e)
        {
            editor.Sign();
            parent.RestartMenu();
        }
        private void EditBlueprintView_Leave(object sender, EventArgs e)
        {
            CheckSignment();
        }
        public void CheckSignment()
        {

            if (CurrentSession.UserLogged.HasPermission(Permission.CAN_SIGN_BLUEPRINT) && selectedBluePrint.IsSigned() && editor.HasBeenModify)
            {
                editor.Sign();
            }
        }
        public void CheckSignmentEventHandler(object sender, EventArgs e)
        {
            CheckSignment();

        }


    }
}