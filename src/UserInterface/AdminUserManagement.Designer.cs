namespace UserInterface {
    partial class AdminUserManagement {
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
            this.userList = new System.Windows.Forms.ListBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.doneButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.createClient = new System.Windows.Forms.Button();
            this.createDesigner = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.createArchitect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userList.FormattingEnabled = true;
            this.userList.ItemHeight = 16;
            this.userList.Location = new System.Drawing.Point(276, 89);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(348, 308);
            this.userList.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(523, 403);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(101, 39);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(795, 414);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(76, 36);
            this.doneButton.TabIndex = 4;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // editButton
            // 
            this.editButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(276, 403);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(107, 39);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(542, 453);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 7;
            // 
            // createClient
            // 
            this.createClient.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createClient.Location = new System.Drawing.Point(276, 43);
            this.createClient.Name = "createClient";
            this.createClient.Size = new System.Drawing.Size(143, 40);
            this.createClient.TabIndex = 8;
            this.createClient.Text = "Create new client";
            this.createClient.UseVisualStyleBackColor = true;
            this.createClient.Click += new System.EventHandler(this.createClient_Click);
            // 
            // createDesigner
            // 
            this.createDesigner.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDesigner.Location = new System.Drawing.Point(425, 43);
            this.createDesigner.Name = "createDesigner";
            this.createDesigner.Size = new System.Drawing.Size(143, 40);
            this.createDesigner.TabIndex = 9;
            this.createDesigner.Text = "Create new designer";
            this.createDesigner.UseVisualStyleBackColor = true;
            this.createDesigner.Click += new System.EventHandler(this.createDesigner_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.label1.Location = new System.Drawing.Point(360, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "User Administration";
            // 
            // createArchitect
            // 
            this.createArchitect.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createArchitect.Location = new System.Drawing.Point(574, 43);
            this.createArchitect.Name = "createArchitect";
            this.createArchitect.Size = new System.Drawing.Size(143, 40);
            this.createArchitect.TabIndex = 11;
            this.createArchitect.Text = "Create new architect";
            this.createArchitect.UseVisualStyleBackColor = true;
            this.createArchitect.Click += new System.EventHandler(this.createArchitect_Click);
            // 
            // AdminUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.createArchitect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createDesigner);
            this.Controls.Add(this.createClient);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.userList);
            this.Name = "AdminUserManagement";
            this.Size = new System.Drawing.Size(884, 461);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button createClient;
        private System.Windows.Forms.Button createDesigner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createArchitect;
    }
}
