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
            this.title = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // blueprintsList
            // 
            this.blueprintsList.Location = new System.Drawing.Point(87, 58);
            this.blueprintsList.Name = "blueprintsList";
            this.blueprintsList.Size = new System.Drawing.Size(453, 340);
            this.blueprintsList.TabIndex = 0;
            this.blueprintsList.UseCompatibleStateImageBehavior = false;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(84, 33);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(107, 13);
            this.title.TabIndex = 1;
            this.title.Text = "Choose the blueprint:";
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(726, 401);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(142, 47);
            this.selectButton.TabIndex = 2;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(578, 401);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(142, 47);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // ChooseBlueprintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.blueprintsList);
            this.Name = "ChooseBlueprintView";
            this.Size = new System.Drawing.Size(884, 461);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView blueprintsList;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button deleteButton;
    }
}
