namespace UserInterface {
    partial class BlueprintCommandsView {
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
            this.wallRadio = new System.Windows.Forms.RadioButton();
            this.doorRadio = new System.Windows.Forms.RadioButton();
            this.windowRadio = new System.Windows.Forms.RadioButton();
            this.radioButtonGroup = new System.Windows.Forms.GroupBox();
            this.radioButtonGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // wallRadio
            // 
            this.wallRadio.AutoSize = true;
            this.wallRadio.Location = new System.Drawing.Point(16, 22);
            this.wallRadio.Name = "wallRadio";
            this.wallRadio.Size = new System.Drawing.Size(46, 17);
            this.wallRadio.TabIndex = 0;
            this.wallRadio.TabStop = true;
            this.wallRadio.Text = "Wall";
            this.wallRadio.UseVisualStyleBackColor = true;
            // 
            // doorRadio
            // 
            this.doorRadio.AutoSize = true;
            this.doorRadio.Location = new System.Drawing.Point(16, 64);
            this.doorRadio.Name = "doorRadio";
            this.doorRadio.Size = new System.Drawing.Size(48, 17);
            this.doorRadio.TabIndex = 1;
            this.doorRadio.TabStop = true;
            this.doorRadio.Text = "Door";
            this.doorRadio.UseVisualStyleBackColor = true;
            // 
            // windowRadio
            // 
            this.windowRadio.AutoSize = true;
            this.windowRadio.Location = new System.Drawing.Point(16, 105);
            this.windowRadio.Name = "windowRadio";
            this.windowRadio.Size = new System.Drawing.Size(64, 17);
            this.windowRadio.TabIndex = 2;
            this.windowRadio.TabStop = true;
            this.windowRadio.Text = "Window";
            this.windowRadio.UseVisualStyleBackColor = true;
            // 
            // radioButtonGroup
            // 
            this.radioButtonGroup.Controls.Add(this.windowRadio);
            this.radioButtonGroup.Controls.Add(this.doorRadio);
            this.radioButtonGroup.Controls.Add(this.wallRadio);
            this.radioButtonGroup.Location = new System.Drawing.Point(35, 30);
            this.radioButtonGroup.Name = "radioButtonGroup";
            this.radioButtonGroup.Size = new System.Drawing.Size(151, 182);
            this.radioButtonGroup.TabIndex = 3;
            this.radioButtonGroup.TabStop = false;
            this.radioButtonGroup.Text = "Current component:";
            // 
            // BlueprintCommandsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButtonGroup);
            this.Name = "BlueprintCommandsView";
            this.Size = new System.Drawing.Size(376, 461);
            this.radioButtonGroup.ResumeLayout(false);
            this.radioButtonGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton wallRadio;
        private System.Windows.Forms.RadioButton doorRadio;
        private System.Windows.Forms.RadioButton windowRadio;
        private System.Windows.Forms.GroupBox radioButtonGroup;
    }
}
