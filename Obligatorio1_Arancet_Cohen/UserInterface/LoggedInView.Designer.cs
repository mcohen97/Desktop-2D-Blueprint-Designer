namespace UserInterface {
    partial class LoggedInView {
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.dynamicPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(839, 100);
            this.menuPanel.TabIndex = 0;
            // 
            // dynamicPanel
            // 
            this.dynamicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dynamicPanel.Location = new System.Drawing.Point(0, 100);
            this.dynamicPanel.Name = "dynamicPanel";
            this.dynamicPanel.Size = new System.Drawing.Size(839, 444);
            this.dynamicPanel.TabIndex = 1;
            // 
            // LoggedInView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dynamicPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "LoggedInView";
            this.Size = new System.Drawing.Size(839, 544);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel dynamicPanel;
    }
}
