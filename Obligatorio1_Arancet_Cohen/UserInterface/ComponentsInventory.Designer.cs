namespace UserInterface {
    partial class ComponentsInventory {
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
            this.componentsList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // componentsList
            // 
            this.componentsList.FormattingEnabled = true;
            this.componentsList.Location = new System.Drawing.Point(122, 62);
            this.componentsList.Name = "componentsList";
            this.componentsList.Size = new System.Drawing.Size(211, 277);
            this.componentsList.TabIndex = 0;
            // 
            // ComponentsInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.componentsList);
            this.Name = "ComponentsInventory";
            this.Size = new System.Drawing.Size(473, 559);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox componentsList;
    }
}
