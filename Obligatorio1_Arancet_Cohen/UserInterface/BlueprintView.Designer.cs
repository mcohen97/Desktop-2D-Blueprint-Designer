namespace UserInterface {
    partial class BlueprintViewer {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.BlueprintPanel = new System.Windows.Forms.Panel();
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.btnExportBlueprint = new System.Windows.Forms.Button();
            this.lblTotalPriceSum = new System.Windows.Forms.Label();
            this.lblWindowsPrice = new System.Windows.Forms.Label();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.lblDoorsPrice = new System.Windows.Forms.Label();
            this.lblWallsPrice = new System.Windows.Forms.Label();
            this.lblBeamsPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalCostSum = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWindowsTotalCost = new System.Windows.Forms.Label();
            this.lblWalls = new System.Windows.Forms.Label();
            this.lblDoorsTotalCost = new System.Windows.Forms.Label();
            this.lblWallsTotalCost = new System.Windows.Forms.Label();
            this.lblBeamsTotalCost = new System.Windows.Forms.Label();
            this.lblBeams = new System.Windows.Forms.Label();
            this.lblWindows = new System.Windows.Forms.Label();
            this.lblDoors = new System.Windows.Forms.Label();
            this.InventoryPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BlueprintPanel
            // 
            this.BlueprintPanel.AutoScroll = true;
            this.BlueprintPanel.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.BlueprintPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.BlueprintPanel.Location = new System.Drawing.Point(3, 3);
            this.BlueprintPanel.Name = "BlueprintPanel";
            this.BlueprintPanel.Size = new System.Drawing.Size(450, 450);
            this.BlueprintPanel.TabIndex = 2;
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.Controls.Add(this.btnExportBlueprint);
            this.InventoryPanel.Controls.Add(this.lblTotalPriceSum);
            this.InventoryPanel.Controls.Add(this.lblWindowsPrice);
            this.InventoryPanel.Controls.Add(this.btnZoomOut);
            this.InventoryPanel.Controls.Add(this.btnZoomIn);
            this.InventoryPanel.Controls.Add(this.lblDoorsPrice);
            this.InventoryPanel.Controls.Add(this.lblWallsPrice);
            this.InventoryPanel.Controls.Add(this.lblBeamsPrice);
            this.InventoryPanel.Controls.Add(this.label3);
            this.InventoryPanel.Controls.Add(this.label5);
            this.InventoryPanel.Controls.Add(this.lblTotalCostSum);
            this.InventoryPanel.Controls.Add(this.lblTotal);
            this.InventoryPanel.Controls.Add(this.label1);
            this.InventoryPanel.Controls.Add(this.lblWindowsTotalCost);
            this.InventoryPanel.Controls.Add(this.lblWalls);
            this.InventoryPanel.Controls.Add(this.lblDoorsTotalCost);
            this.InventoryPanel.Controls.Add(this.lblWallsTotalCost);
            this.InventoryPanel.Controls.Add(this.lblBeamsTotalCost);
            this.InventoryPanel.Controls.Add(this.lblBeams);
            this.InventoryPanel.Controls.Add(this.lblWindows);
            this.InventoryPanel.Controls.Add(this.lblDoors);
            this.InventoryPanel.Location = new System.Drawing.Point(459, 3);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(205, 450);
            this.InventoryPanel.TabIndex = 1;
            // 
            // btnExportBlueprint
            // 
            this.btnExportBlueprint.Location = new System.Drawing.Point(42, 406);
            this.btnExportBlueprint.Name = "btnExportBlueprint";
            this.btnExportBlueprint.Size = new System.Drawing.Size(123, 31);
            this.btnExportBlueprint.TabIndex = 17;
            this.btnExportBlueprint.Text = "Export Blueprint";
            this.btnExportBlueprint.UseVisualStyleBackColor = true;
            this.btnExportBlueprint.Click += new System.EventHandler(this.btnExportBlueprint_Click);
            // 
            // lblTotalPriceSum
            // 
            this.lblTotalPriceSum.AutoSize = true;
            this.lblTotalPriceSum.Location = new System.Drawing.Point(140, 164);
            this.lblTotalPriceSum.Name = "lblTotalPriceSum";
            this.lblTotalPriceSum.Size = new System.Drawing.Size(10, 13);
            this.lblTotalPriceSum.TabIndex = 24;
            this.lblTotalPriceSum.Text = "-";
            // 
            // lblWindowsPrice
            // 
            this.lblWindowsPrice.AutoSize = true;
            this.lblWindowsPrice.Location = new System.Drawing.Point(140, 130);
            this.lblWindowsPrice.Name = "lblWindowsPrice";
            this.lblWindowsPrice.Size = new System.Drawing.Size(10, 13);
            this.lblWindowsPrice.TabIndex = 23;
            this.lblWindowsPrice.Text = "-";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Location = new System.Drawing.Point(120, 211);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(70, 26);
            this.btnZoomOut.TabIndex = 3;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Location = new System.Drawing.Point(7, 211);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(70, 26);
            this.btnZoomIn.TabIndex = 2;
            this.btnZoomIn.Text = "Zoom In";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // lblDoorsPrice
            // 
            this.lblDoorsPrice.AutoSize = true;
            this.lblDoorsPrice.Location = new System.Drawing.Point(140, 107);
            this.lblDoorsPrice.Name = "lblDoorsPrice";
            this.lblDoorsPrice.Size = new System.Drawing.Size(10, 13);
            this.lblDoorsPrice.TabIndex = 22;
            this.lblDoorsPrice.Text = "-";
            // 
            // lblWallsPrice
            // 
            this.lblWallsPrice.AutoSize = true;
            this.lblWallsPrice.Location = new System.Drawing.Point(140, 62);
            this.lblWallsPrice.Name = "lblWallsPrice";
            this.lblWallsPrice.Size = new System.Drawing.Size(10, 13);
            this.lblWallsPrice.TabIndex = 20;
            this.lblWallsPrice.Text = "-";
            // 
            // lblBeamsPrice
            // 
            this.lblBeamsPrice.AutoSize = true;
            this.lblBeamsPrice.Location = new System.Drawing.Point(140, 84);
            this.lblBeamsPrice.Name = "lblBeamsPrice";
            this.lblBeamsPrice.Size = new System.Drawing.Size(10, 13);
            this.lblBeamsPrice.TabIndex = 21;
            this.lblBeamsPrice.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Blueprint Info";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Price";
            // 
            // lblTotalCostSum
            // 
            this.lblTotalCostSum.AutoSize = true;
            this.lblTotalCostSum.Location = new System.Drawing.Point(67, 164);
            this.lblTotalCostSum.Name = "lblTotalCostSum";
            this.lblTotalCostSum.Size = new System.Drawing.Size(10, 13);
            this.lblTotalCostSum.TabIndex = 16;
            this.lblTotalCostSum.Text = "-";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(3, 164);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "Total:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Costs";
            // 
            // lblWindowsTotalCost
            // 
            this.lblWindowsTotalCost.AutoSize = true;
            this.lblWindowsTotalCost.Location = new System.Drawing.Point(67, 130);
            this.lblWindowsTotalCost.Name = "lblWindowsTotalCost";
            this.lblWindowsTotalCost.Size = new System.Drawing.Size(10, 13);
            this.lblWindowsTotalCost.TabIndex = 14;
            this.lblWindowsTotalCost.Text = "-";
            // 
            // lblWalls
            // 
            this.lblWalls.AutoSize = true;
            this.lblWalls.Location = new System.Drawing.Point(3, 62);
            this.lblWalls.Name = "lblWalls";
            this.lblWalls.Size = new System.Drawing.Size(36, 13);
            this.lblWalls.TabIndex = 6;
            this.lblWalls.Text = "Walls:";
            // 
            // lblDoorsTotalCost
            // 
            this.lblDoorsTotalCost.AutoSize = true;
            this.lblDoorsTotalCost.Location = new System.Drawing.Point(67, 107);
            this.lblDoorsTotalCost.Name = "lblDoorsTotalCost";
            this.lblDoorsTotalCost.Size = new System.Drawing.Size(10, 13);
            this.lblDoorsTotalCost.TabIndex = 13;
            this.lblDoorsTotalCost.Text = "-";
            // 
            // lblWallsTotalCost
            // 
            this.lblWallsTotalCost.AutoSize = true;
            this.lblWallsTotalCost.Location = new System.Drawing.Point(67, 62);
            this.lblWallsTotalCost.Name = "lblWallsTotalCost";
            this.lblWallsTotalCost.Size = new System.Drawing.Size(10, 13);
            this.lblWallsTotalCost.TabIndex = 8;
            this.lblWallsTotalCost.Text = "-";
            // 
            // lblBeamsTotalCost
            // 
            this.lblBeamsTotalCost.AutoSize = true;
            this.lblBeamsTotalCost.Location = new System.Drawing.Point(67, 84);
            this.lblBeamsTotalCost.Name = "lblBeamsTotalCost";
            this.lblBeamsTotalCost.Size = new System.Drawing.Size(10, 13);
            this.lblBeamsTotalCost.TabIndex = 12;
            this.lblBeamsTotalCost.Text = "-";
            // 
            // lblBeams
            // 
            this.lblBeams.AutoSize = true;
            this.lblBeams.Location = new System.Drawing.Point(3, 84);
            this.lblBeams.Name = "lblBeams";
            this.lblBeams.Size = new System.Drawing.Size(42, 13);
            this.lblBeams.TabIndex = 9;
            this.lblBeams.Text = "Beams:";
            // 
            // lblWindows
            // 
            this.lblWindows.AutoSize = true;
            this.lblWindows.Location = new System.Drawing.Point(3, 130);
            this.lblWindows.Name = "lblWindows";
            this.lblWindows.Size = new System.Drawing.Size(54, 13);
            this.lblWindows.TabIndex = 11;
            this.lblWindows.Text = "Windows:";
            // 
            // lblDoors
            // 
            this.lblDoors.AutoSize = true;
            this.lblDoors.Location = new System.Drawing.Point(3, 107);
            this.lblDoors.Name = "lblDoors";
            this.lblDoors.Size = new System.Drawing.Size(38, 13);
            this.lblDoors.TabIndex = 10;
            this.lblDoors.Text = "Doors:";
            // 
            // BlueprintViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BlueprintPanel);
            this.Controls.Add(this.InventoryPanel);
            this.Name = "BlueprintViewer";
            this.Size = new System.Drawing.Size(669, 461);
            this.Load += new System.EventHandler(this.EditBlueprintView_Load);
            this.InventoryPanel.ResumeLayout(false);
            this.InventoryPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.Panel BlueprintPanel;
        private System.Windows.Forms.Label lblWallsTotalCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWalls;
        private System.Windows.Forms.Label lblWindows;
        private System.Windows.Forms.Label lblDoors;
        private System.Windows.Forms.Label lblBeams;
        private System.Windows.Forms.Label lblWindowsTotalCost;
        private System.Windows.Forms.Label lblDoorsTotalCost;
        private System.Windows.Forms.Label lblBeamsTotalCost;
        private System.Windows.Forms.Label lblTotalCostSum;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnExportBlueprint;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalPriceSum;
        private System.Windows.Forms.Label lblWindowsPrice;
        private System.Windows.Forms.Label lblDoorsPrice;
        private System.Windows.Forms.Label lblWallsPrice;
        private System.Windows.Forms.Label lblBeamsPrice;
        private System.Windows.Forms.Label label3;
    }
}
