namespace UserInterface {
    partial class EditBlueprintView {
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
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.lblWindows = new System.Windows.Forms.Label();
            this.lblDoors = new System.Windows.Forms.Label();
            this.lblBeams = new System.Windows.Forms.Label();
            this.lblWallsTotalCost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWalls = new System.Windows.Forms.Label();
            this.btnEraserTool = new System.Windows.Forms.Button();
            this.btnWindowTool = new System.Windows.Forms.Button();
            this.btnDoorTool = new System.Windows.Forms.Button();
            this.btnWallTool = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPointerTool = new System.Windows.Forms.Button();
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.BlueprintPanel = new System.Windows.Forms.Panel();
            this.lblBeamsTotalCost = new System.Windows.Forms.Label();
            this.lblDoorsTotalCost = new System.Windows.Forms.Label();
            this.lblWindowsTotalCost = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalCostSum = new System.Windows.Forms.Label();
            this.btnExportBlueprint = new System.Windows.Forms.Button();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.btnExportBlueprint);
            this.ButtonsPanel.Controls.Add(this.lblTotalCostSum);
            this.ButtonsPanel.Controls.Add(this.lblTotal);
            this.ButtonsPanel.Controls.Add(this.lblWindowsTotalCost);
            this.ButtonsPanel.Controls.Add(this.lblDoorsTotalCost);
            this.ButtonsPanel.Controls.Add(this.lblBeamsTotalCost);
            this.ButtonsPanel.Controls.Add(this.lblWindows);
            this.ButtonsPanel.Controls.Add(this.lblDoors);
            this.ButtonsPanel.Controls.Add(this.lblBeams);
            this.ButtonsPanel.Controls.Add(this.lblWallsTotalCost);
            this.ButtonsPanel.Controls.Add(this.label1);
            this.ButtonsPanel.Controls.Add(this.lblWalls);
            this.ButtonsPanel.Controls.Add(this.btnEraserTool);
            this.ButtonsPanel.Controls.Add(this.btnWindowTool);
            this.ButtonsPanel.Controls.Add(this.btnDoorTool);
            this.ButtonsPanel.Controls.Add(this.btnWallTool);
            this.ButtonsPanel.Controls.Add(this.label2);
            this.ButtonsPanel.Controls.Add(this.btnPointerTool);
            this.ButtonsPanel.Location = new System.Drawing.Point(3, 3);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(211, 555);
            this.ButtonsPanel.TabIndex = 0;
            this.ButtonsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonsPanel_Paint);
            // 
            // lblWindows
            // 
            this.lblWindows.AutoSize = true;
            this.lblWindows.Location = new System.Drawing.Point(51, 331);
            this.lblWindows.Name = "lblWindows";
            this.lblWindows.Size = new System.Drawing.Size(54, 13);
            this.lblWindows.TabIndex = 11;
            this.lblWindows.Text = "Windows:";
            // 
            // lblDoors
            // 
            this.lblDoors.AutoSize = true;
            this.lblDoors.Location = new System.Drawing.Point(51, 308);
            this.lblDoors.Name = "lblDoors";
            this.lblDoors.Size = new System.Drawing.Size(38, 13);
            this.lblDoors.TabIndex = 10;
            this.lblDoors.Text = "Doors:";
            // 
            // lblBeams
            // 
            this.lblBeams.AutoSize = true;
            this.lblBeams.Location = new System.Drawing.Point(51, 285);
            this.lblBeams.Name = "lblBeams";
            this.lblBeams.Size = new System.Drawing.Size(42, 13);
            this.lblBeams.TabIndex = 9;
            this.lblBeams.Text = "Beams:";
            // 
            // lblWallsTotalCost
            // 
            this.lblWallsTotalCost.AutoSize = true;
            this.lblWallsTotalCost.Location = new System.Drawing.Point(128, 263);
            this.lblWallsTotalCost.Name = "lblWallsTotalCost";
            this.lblWallsTotalCost.Size = new System.Drawing.Size(10, 13);
            this.lblWallsTotalCost.TabIndex = 8;
            this.lblWallsTotalCost.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Costs";
            // 
            // lblWalls
            // 
            this.lblWalls.AutoSize = true;
            this.lblWalls.Location = new System.Drawing.Point(51, 263);
            this.lblWalls.Name = "lblWalls";
            this.lblWalls.Size = new System.Drawing.Size(36, 13);
            this.lblWalls.TabIndex = 6;
            this.lblWalls.Text = "Walls:";
            this.lblWalls.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnEraserTool
            // 
            this.btnEraserTool.Location = new System.Drawing.Point(45, 66);
            this.btnEraserTool.Name = "btnEraserTool";
            this.btnEraserTool.Size = new System.Drawing.Size(123, 26);
            this.btnEraserTool.TabIndex = 4;
            this.btnEraserTool.Text = "Eraser";
            this.btnEraserTool.UseVisualStyleBackColor = true;
            this.btnEraserTool.Click += new System.EventHandler(this.btnEraserTool_Click);
            // 
            // btnWindowTool
            // 
            this.btnWindowTool.Location = new System.Drawing.Point(45, 178);
            this.btnWindowTool.Name = "btnWindowTool";
            this.btnWindowTool.Size = new System.Drawing.Size(123, 26);
            this.btnWindowTool.TabIndex = 3;
            this.btnWindowTool.Text = "Window";
            this.btnWindowTool.UseVisualStyleBackColor = true;
            this.btnWindowTool.Click += new System.EventHandler(this.btnWindowTool_Click);
            // 
            // btnDoorTool
            // 
            this.btnDoorTool.Location = new System.Drawing.Point(45, 146);
            this.btnDoorTool.Name = "btnDoorTool";
            this.btnDoorTool.Size = new System.Drawing.Size(123, 26);
            this.btnDoorTool.TabIndex = 2;
            this.btnDoorTool.Text = "Door";
            this.btnDoorTool.UseVisualStyleBackColor = true;
            this.btnDoorTool.Click += new System.EventHandler(this.btnDoorTool_Click);
            // 
            // btnWallTool
            // 
            this.btnWallTool.Location = new System.Drawing.Point(45, 114);
            this.btnWallTool.Name = "btnWallTool";
            this.btnWallTool.Size = new System.Drawing.Size(123, 26);
            this.btnWallTool.TabIndex = 1;
            this.btnWallTool.Text = "Wall";
            this.btnWallTool.UseVisualStyleBackColor = true;
            this.btnWallTool.Click += new System.EventHandler(this.btnWallTool_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tools";
            // 
            // btnPointerTool
            // 
            this.btnPointerTool.Location = new System.Drawing.Point(45, 34);
            this.btnPointerTool.Name = "btnPointerTool";
            this.btnPointerTool.Size = new System.Drawing.Size(123, 26);
            this.btnPointerTool.TabIndex = 0;
            this.btnPointerTool.Text = "Pointer";
            this.btnPointerTool.UseVisualStyleBackColor = true;
            this.btnPointerTool.Click += new System.EventHandler(this.btnPointerTool_Click);
            // 
            // InventoryPanel
            // 
            this.InventoryPanel.Location = new System.Drawing.Point(684, 3);
            this.InventoryPanel.Name = "InventoryPanel";
            this.InventoryPanel.Size = new System.Drawing.Size(197, 555);
            this.InventoryPanel.TabIndex = 1;
            // 
            // BlueprintPanel
            // 
            this.BlueprintPanel.AutoScroll = true;
            this.BlueprintPanel.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.BlueprintPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.BlueprintPanel.Location = new System.Drawing.Point(220, 3);
            this.BlueprintPanel.Name = "BlueprintPanel";
            this.BlueprintPanel.Size = new System.Drawing.Size(450, 450);
            this.BlueprintPanel.TabIndex = 2;
            // 
            // lblBeamsTotalCost
            // 
            this.lblBeamsTotalCost.AutoSize = true;
            this.lblBeamsTotalCost.Location = new System.Drawing.Point(128, 285);
            this.lblBeamsTotalCost.Name = "lblBeamsTotalCost";
            this.lblBeamsTotalCost.Size = new System.Drawing.Size(10, 13);
            this.lblBeamsTotalCost.TabIndex = 12;
            this.lblBeamsTotalCost.Text = "-";
            // 
            // lblDoorsTotalCost
            // 
            this.lblDoorsTotalCost.AutoSize = true;
            this.lblDoorsTotalCost.Location = new System.Drawing.Point(128, 308);
            this.lblDoorsTotalCost.Name = "lblDoorsTotalCost";
            this.lblDoorsTotalCost.Size = new System.Drawing.Size(10, 13);
            this.lblDoorsTotalCost.TabIndex = 13;
            this.lblDoorsTotalCost.Text = "-";
            // 
            // lblWindowsTotalCost
            // 
            this.lblWindowsTotalCost.AutoSize = true;
            this.lblWindowsTotalCost.Location = new System.Drawing.Point(128, 331);
            this.lblWindowsTotalCost.Name = "lblWindowsTotalCost";
            this.lblWindowsTotalCost.Size = new System.Drawing.Size(10, 13);
            this.lblWindowsTotalCost.TabIndex = 14;
            this.lblWindowsTotalCost.Text = "-";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(51, 365);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(57, 13);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "Total cost:";
            // 
            // lblTotalCostSum
            // 
            this.lblTotalCostSum.AutoSize = true;
            this.lblTotalCostSum.Location = new System.Drawing.Point(128, 365);
            this.lblTotalCostSum.Name = "lblTotalCostSum";
            this.lblTotalCostSum.Size = new System.Drawing.Size(10, 13);
            this.lblTotalCostSum.TabIndex = 16;
            this.lblTotalCostSum.Text = "-";
            // 
            // btnExportBlueprint
            // 
            this.btnExportBlueprint.Location = new System.Drawing.Point(45, 419);
            this.btnExportBlueprint.Name = "btnExportBlueprint";
            this.btnExportBlueprint.Size = new System.Drawing.Size(123, 31);
            this.btnExportBlueprint.TabIndex = 17;
            this.btnExportBlueprint.Text = "Export Blueprint";
            this.btnExportBlueprint.UseVisualStyleBackColor = true;
            this.btnExportBlueprint.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditBlueprintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BlueprintPanel);
            this.Controls.Add(this.InventoryPanel);
            this.Controls.Add(this.ButtonsPanel);
            this.Name = "EditBlueprintView";
            this.Size = new System.Drawing.Size(884, 561);
            this.Load += new System.EventHandler(this.EditBlueprintView_Load);
            this.ButtonsPanel.ResumeLayout(false);
            this.ButtonsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.Panel BlueprintPanel;
        private System.Windows.Forms.Button btnWindowTool;
        private System.Windows.Forms.Button btnDoorTool;
        private System.Windows.Forms.Button btnWallTool;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPointerTool;
        private System.Windows.Forms.Button btnEraserTool;
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
    }
}
