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
            this.InventoryPanel = new System.Windows.Forms.Panel();
            this.BlueprintPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Location = new System.Drawing.Point(3, 3);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(205, 555);
            this.ButtonsPanel.TabIndex = 0;
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
            this.BlueprintPanel.BackColor = System.Drawing.Color.MidnightBlue;
            this.BlueprintPanel.Location = new System.Drawing.Point(220, 3);
            this.BlueprintPanel.Name = "BlueprintPanel";
            this.BlueprintPanel.Size = new System.Drawing.Size(450, 450);
            this.BlueprintPanel.TabIndex = 2;
            this.BlueprintPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BlueprintPanel_Paint);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Panel InventoryPanel;
        private System.Windows.Forms.Panel BlueprintPanel;
    }
}
