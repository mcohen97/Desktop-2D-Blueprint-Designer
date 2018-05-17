namespace UserInterface {
    partial class CreateBlueprint {
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
            this.usersList = new System.Windows.Forms.ListBox();
            this.createButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.widthField = new System.Windows.Forms.MaskedTextBox();
            this.lengthField = new System.Windows.Forms.MaskedTextBox();
            this.widthMsg = new System.Windows.Forms.Label();
            this.lengthMsg = new System.Windows.Forms.Label();
            this.nameMsg = new System.Windows.Forms.Label();
            this.listMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usersList
            // 
            this.usersList.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersList.FormattingEnabled = true;
            this.usersList.ItemHeight = 16;
            this.usersList.Location = new System.Drawing.Point(178, 205);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(525, 164);
            this.usersList.TabIndex = 0;
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(379, 387);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(117, 52);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "Create blueprint";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(333, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Blueprint name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Blueprint width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Blueprint height:";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(431, 72);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(100, 20);
            this.nameText.TabIndex = 5;
            this.nameText.Enter += new System.EventHandler(this.nameText_Enter);
            this.nameText.Leave += new System.EventHandler(this.nameText_Leave);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.titleLabel.Location = new System.Drawing.Point(332, 17);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(199, 23);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Blueprint information";
            // 
            // widthField
            // 
            this.widthField.Location = new System.Drawing.Point(431, 115);
            this.widthField.Mask = "000";
            this.widthField.Name = "widthField";
            this.widthField.Size = new System.Drawing.Size(31, 20);
            this.widthField.TabIndex = 9;
            this.widthField.Enter += new System.EventHandler(this.widthField_Enter);
            this.widthField.Leave += new System.EventHandler(this.widthField_Leave);
            // 
            // lengthField
            // 
            this.lengthField.Location = new System.Drawing.Point(431, 161);
            this.lengthField.Mask = "000";
            this.lengthField.Name = "lengthField";
            this.lengthField.Size = new System.Drawing.Size(31, 20);
            this.lengthField.TabIndex = 10;
            this.lengthField.Enter += new System.EventHandler(this.lengthField_Enter);
            this.lengthField.Leave += new System.EventHandler(this.lengthField_Leave);
            // 
            // widthMsg
            // 
            this.widthMsg.AutoSize = true;
            this.widthMsg.Location = new System.Drawing.Point(496, 118);
            this.widthMsg.Name = "widthMsg";
            this.widthMsg.Size = new System.Drawing.Size(0, 13);
            this.widthMsg.TabIndex = 11;
            // 
            // lengthMsg
            // 
            this.lengthMsg.AutoSize = true;
            this.lengthMsg.Location = new System.Drawing.Point(496, 164);
            this.lengthMsg.Name = "lengthMsg";
            this.lengthMsg.Size = new System.Drawing.Size(0, 13);
            this.lengthMsg.TabIndex = 12;
            // 
            // nameMsg
            // 
            this.nameMsg.AutoSize = true;
            this.nameMsg.Location = new System.Drawing.Point(549, 75);
            this.nameMsg.Name = "nameMsg";
            this.nameMsg.Size = new System.Drawing.Size(0, 13);
            this.nameMsg.TabIndex = 13;
            // 
            // listMsg
            // 
            this.listMsg.AutoSize = true;
            this.listMsg.Location = new System.Drawing.Point(748, 60);
            this.listMsg.Name = "listMsg";
            this.listMsg.Size = new System.Drawing.Size(0, 13);
            this.listMsg.TabIndex = 14;
            // 
            // CreateBlueprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.listMsg);
            this.Controls.Add(this.nameMsg);
            this.Controls.Add(this.lengthMsg);
            this.Controls.Add(this.widthMsg);
            this.Controls.Add(this.lengthField);
            this.Controls.Add(this.widthField);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.usersList);
            this.Name = "CreateBlueprint";
            this.Size = new System.Drawing.Size(884, 461);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox usersList;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.MaskedTextBox widthField;
        private System.Windows.Forms.MaskedTextBox lengthField;
        private System.Windows.Forms.Label widthMsg;
        private System.Windows.Forms.Label lengthMsg;
        private System.Windows.Forms.Label nameMsg;
        private System.Windows.Forms.Label listMsg;
    }
}
