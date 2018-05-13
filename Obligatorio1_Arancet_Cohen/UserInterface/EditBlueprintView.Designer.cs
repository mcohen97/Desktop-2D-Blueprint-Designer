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
            this.btnEraserTool = new System.Windows.Forms.Button();
            this.btnWindowTool = new System.Windows.Forms.Button();
            this.btnDoorTool = new System.Windows.Forms.Button();
            this.btnWallTool = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPointerTool = new System.Windows.Forms.Button();
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.BlueprintPanel = new System.Windows.Forms.Panel();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
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
            // 
            // btnEraserTool
            // 
            this.btnEraserTool.Location = new System.Drawing.Point(32, 102);
            this.btnEraserTool.Name = "btnEraserTool";
            this.btnEraserTool.Size = new System.Drawing.Size(155, 51);
            this.btnEraserTool.TabIndex = 4;
            this.btnEraserTool.Text = "Eraser";
            this.btnEraserTool.UseVisualStyleBackColor = true;
            this.btnEraserTool.Click += new System.EventHandler(this.btnEraserTool_Click);
            // 
            // btnWindowTool
            // 
            this.btnWindowTool.Location = new System.Drawing.Point(32, 273);
            this.btnWindowTool.Name = "btnWindowTool";
            this.btnWindowTool.Size = new System.Drawing.Size(155, 51);
            this.btnWindowTool.TabIndex = 3;
            this.btnWindowTool.Text = "Window";
            this.btnWindowTool.UseVisualStyleBackColor = true;
            this.btnWindowTool.Click += new System.EventHandler(this.btnWindowTool_Click);
            // 
            // btnDoorTool
            // 
            this.btnDoorTool.Location = new System.Drawing.Point(32, 216);
            this.btnDoorTool.Name = "btnDoorTool";
            this.btnDoorTool.Size = new System.Drawing.Size(155, 51);
            this.btnDoorTool.TabIndex = 2;
            this.btnDoorTool.Text = "Door";
            this.btnDoorTool.UseVisualStyleBackColor = true;
            this.btnDoorTool.Click += new System.EventHandler(this.btnDoorTool_Click);
            // 
            // btnWallTool
            // 
            this.btnWallTool.Location = new System.Drawing.Point(32, 159);
            this.btnWallTool.Name = "btnWallTool";
            this.btnWallTool.Size = new System.Drawing.Size(155, 51);
            this.btnWallTool.TabIndex = 1;
            this.btnWallTool.Text = "Wall";
            this.btnWallTool.UseVisualStyleBackColor = true;
            this.btnWallTool.Click += new System.EventHandler(this.btnWallTool_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tools";
            // 
            // btnPointerTool
            // 
            this.btnPointerTool.Location = new System.Drawing.Point(32, 45);
            this.btnPointerTool.Name = "btnPointerTool";
            this.btnPointerTool.Size = new System.Drawing.Size(155, 51);
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
    }
}
