namespace UserInterface {
    partial class ClientChooseBlueprintView {
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
            this.title = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.blueprintList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.title.Location = new System.Drawing.Point(217, 13);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(206, 23);
            this.title.TabIndex = 1;
            this.title.Text = "Choose the blueprint:";
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectButton.Location = new System.Drawing.Point(220, 368);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(142, 47);
            this.selectButton.TabIndex = 2;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_ClickView);
            // 
            // blueprintList
            // 
            this.blueprintList.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blueprintList.FormattingEnabled = true;
            this.blueprintList.ItemHeight = 16;
            this.blueprintList.Location = new System.Drawing.Point(220, 42);
            this.blueprintList.Name = "blueprintList";
            this.blueprintList.Size = new System.Drawing.Size(434, 308);
            this.blueprintList.TabIndex = 4;
            // 
            // ClientChooseBlueprintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.blueprintList);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.title);
            this.Name = "ClientChooseBlueprintView";
            this.Size = new System.Drawing.Size(884, 461);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ListBox blueprintList;
    }
}
