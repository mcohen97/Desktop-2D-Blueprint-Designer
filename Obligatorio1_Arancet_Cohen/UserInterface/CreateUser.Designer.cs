namespace UserInterface {
    partial class CreateUser {
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
            this.surnameText = new System.Windows.Forms.TextBox();
            this.surnameTitle = new System.Windows.Forms.Label();
            this.nameTitle = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.onlyClientFields = new System.Windows.Forms.Panel();
            this.idText = new System.Windows.Forms.TextBox();
            this.IDTitle = new System.Windows.Forms.Label();
            this.telNumberText = new System.Windows.Forms.TextBox();
            this.addressText = new System.Windows.Forms.TextBox();
            this.addressTitle = new System.Windows.Forms.Label();
            this.telNumberTitle = new System.Windows.Forms.Label();
            this.UsernameTitle = new System.Windows.Forms.Label();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.onlyClientFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // surnameText
            // 
            this.surnameText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameText.Location = new System.Drawing.Point(392, 154);
            this.surnameText.Name = "surnameText";
            this.surnameText.Size = new System.Drawing.Size(187, 31);
            this.surnameText.TabIndex = 2;
            // 
            // surnameTitle
            // 
            this.surnameTitle.AutoSize = true;
            this.surnameTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameTitle.Location = new System.Drawing.Point(158, 157);
            this.surnameTitle.Name = "surnameTitle";
            this.surnameTitle.Size = new System.Drawing.Size(96, 22);
            this.surnameTitle.TabIndex = 9;
            this.surnameTitle.Text = "Surname:";
            // 
            // nameTitle
            // 
            this.nameTitle.AutoSize = true;
            this.nameTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTitle.Location = new System.Drawing.Point(158, 200);
            this.nameTitle.Name = "nameTitle";
            this.nameTitle.Size = new System.Drawing.Size(71, 22);
            this.nameTitle.TabIndex = 8;
            this.nameTitle.Text = "Name:";
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(392, 197);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(187, 31);
            this.nameTxt.TabIndex = 13;
            // 
            // onlyClientFields
            // 
            this.onlyClientFields.Controls.Add(this.idText);
            this.onlyClientFields.Controls.Add(this.IDTitle);
            this.onlyClientFields.Controls.Add(this.telNumberText);
            this.onlyClientFields.Controls.Add(this.addressText);
            this.onlyClientFields.Controls.Add(this.addressTitle);
            this.onlyClientFields.Controls.Add(this.telNumberTitle);
            this.onlyClientFields.Location = new System.Drawing.Point(125, 240);
            this.onlyClientFields.Name = "onlyClientFields";
            this.onlyClientFields.Size = new System.Drawing.Size(474, 154);
            this.onlyClientFields.TabIndex = 22;
            // 
            // idText
            // 
            this.idText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idText.Location = new System.Drawing.Point(267, 14);
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(187, 31);
            this.idText.TabIndex = 3;
            // 
            // IDTitle
            // 
            this.IDTitle.AutoSize = true;
            this.IDTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDTitle.Location = new System.Drawing.Point(33, 17);
            this.IDTitle.Name = "IDTitle";
            this.IDTitle.Size = new System.Drawing.Size(29, 22);
            this.IDTitle.TabIndex = 10;
            this.IDTitle.Text = "ID";
            // 
            // telNumberText
            // 
            this.telNumberText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telNumberText.Location = new System.Drawing.Point(267, 62);
            this.telNumberText.Name = "telNumberText";
            this.telNumberText.Size = new System.Drawing.Size(187, 31);
            this.telNumberText.TabIndex = 4;
            // 
            // addressText
            // 
            this.addressText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressText.Location = new System.Drawing.Point(267, 117);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(187, 31);
            this.addressText.TabIndex = 5;
            // 
            // addressTitle
            // 
            this.addressTitle.AutoSize = true;
            this.addressTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressTitle.Location = new System.Drawing.Point(33, 102);
            this.addressTitle.Name = "addressTitle";
            this.addressTitle.Size = new System.Drawing.Size(88, 22);
            this.addressTitle.TabIndex = 12;
            this.addressTitle.Text = "Address:";
            // 
            // telNumberTitle
            // 
            this.telNumberTitle.AutoSize = true;
            this.telNumberTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telNumberTitle.Location = new System.Drawing.Point(33, 59);
            this.telNumberTitle.Name = "telNumberTitle";
            this.telNumberTitle.Size = new System.Drawing.Size(188, 22);
            this.telNumberTitle.TabIndex = 11;
            this.telNumberTitle.Text = "Telephone number:";
            // 
            // UsernameTitle
            // 
            this.UsernameTitle.AutoSize = true;
            this.UsernameTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTitle.Location = new System.Drawing.Point(158, 68);
            this.UsernameTitle.Name = "UsernameTitle";
            this.UsernameTitle.Size = new System.Drawing.Size(111, 22);
            this.UsernameTitle.TabIndex = 20;
            this.UsernameTitle.Text = "User name:";
            this.UsernameTitle.UseMnemonic = false;
            // 
            // userNameText
            // 
            this.userNameText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameText.Location = new System.Drawing.Point(392, 65);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(187, 31);
            this.userNameText.TabIndex = 25;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(719, 388);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(141, 53);
            this.createButton.TabIndex = 26;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.Location = new System.Drawing.Point(392, 111);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(187, 31);
            this.passwordText.TabIndex = 28;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(158, 114);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(100, 22);
            this.passwordLabel.TabIndex = 27;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.UseMnemonic = false;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.userNameText);
            this.Controls.Add(this.surnameText);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.surnameTitle);
            this.Controls.Add(this.nameTitle);
            this.Controls.Add(this.onlyClientFields);
            this.Controls.Add(this.UsernameTitle);
            this.Name = "CreateUser";
            this.Size = new System.Drawing.Size(884, 461);
            this.onlyClientFields.ResumeLayout(false);
            this.onlyClientFields.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox surnameText;
        private System.Windows.Forms.Label surnameTitle;
        private System.Windows.Forms.Label nameTitle;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Panel onlyClientFields;
        private System.Windows.Forms.TextBox idText;
        private System.Windows.Forms.Label IDTitle;
        private System.Windows.Forms.TextBox telNumberText;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label addressTitle;
        private System.Windows.Forms.Label telNumberTitle;
        private System.Windows.Forms.Label UsernameTitle;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label passwordLabel;
    }
}
