namespace UserInterface {
    partial class ChooseUserView {
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
            this.createButton = new System.Windows.Forms.Button();
            this.usersList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(710, 381);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(136, 58);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Start";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // usersList
            // 
            this.usersList.FormattingEnabled = true;
            this.usersList.Location = new System.Drawing.Point(235, 34);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(405, 355);
            this.usersList.TabIndex = 2;
            // 
            // ChooseUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.createButton);
            this.Name = "ChooseUserView";
            this.Size = new System.Drawing.Size(884, 461);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button createButton;
        protected System.Windows.Forms.ListBox usersList;
    }
}
