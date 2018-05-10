namespace UserInterface {
    partial class ChooseBlueprintView {
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
            this.blueprintsList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // blueprintsList
            // 
            this.blueprintsList.Location = new System.Drawing.Point(167, 60);
            this.blueprintsList.Name = "blueprintsList";
            this.blueprintsList.Size = new System.Drawing.Size(543, 434);
            this.blueprintsList.TabIndex = 0;
            this.blueprintsList.UseCompatibleStateImageBehavior = false;
            // 
            // ChooseBlueprintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.blueprintsList);
            this.Name = "ChooseBlueprintView";
            this.Size = new System.Drawing.Size(884, 561);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView blueprintsList;
    }
}
