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
            this.telNumberMsg = new System.Windows.Forms.Label();
            this.telNumberText = new System.Windows.Forms.MaskedTextBox();
            this.idMsg = new System.Windows.Forms.Label();
            this.IDTitle = new System.Windows.Forms.Label();
            this.idText = new System.Windows.Forms.MaskedTextBox();
            this.addressText = new System.Windows.Forms.TextBox();
            this.addressMsg = new System.Windows.Forms.Label();
            this.addressTitle = new System.Windows.Forms.Label();
            this.telNumberTitle = new System.Windows.Forms.Label();
            this.UsernameTitle = new System.Windows.Forms.Label();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameMsg = new System.Windows.Forms.Label();
            this.passwordMsg = new System.Windows.Forms.Label();
            this.surnameMsg = new System.Windows.Forms.Label();
            this.nameMsg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.onlyClientFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // surnameText
            // 
            this.surnameText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameText.Location = new System.Drawing.Point(460, 149);
            this.surnameText.Name = "surnameText";
            this.surnameText.Size = new System.Drawing.Size(187, 31);
            this.surnameText.TabIndex = 2;
            this.surnameText.Enter += new System.EventHandler(this.surnameText_Enter);
            this.surnameText.Leave += new System.EventHandler(this.surnameText_Leave);
            // 
            // surnameTitle
            // 
            this.surnameTitle.AutoSize = true;
            this.surnameTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameTitle.Location = new System.Drawing.Point(226, 152);
            this.surnameTitle.Name = "surnameTitle";
            this.surnameTitle.Size = new System.Drawing.Size(96, 22);
            this.surnameTitle.TabIndex = 9;
            this.surnameTitle.Text = "Surname:";
            // 
            // nameTitle
            // 
            this.nameTitle.AutoSize = true;
            this.nameTitle.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTitle.Location = new System.Drawing.Point(226, 195);
            this.nameTitle.Name = "nameTitle";
            this.nameTitle.Size = new System.Drawing.Size(71, 22);
            this.nameTitle.TabIndex = 8;
            this.nameTitle.Text = "Name:";
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(460, 192);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(187, 31);
            this.nameTxt.TabIndex = 13;
            this.nameTxt.Enter += new System.EventHandler(this.nameTxt_Enter);
            this.nameTxt.Leave += new System.EventHandler(this.nameTxt_Leave);
            // 
            // onlyClientFields
            // 
            this.onlyClientFields.Controls.Add(this.telNumberMsg);
            this.onlyClientFields.Controls.Add(this.telNumberText);
            this.onlyClientFields.Controls.Add(this.idMsg);
            this.onlyClientFields.Controls.Add(this.IDTitle);
            this.onlyClientFields.Controls.Add(this.idText);
            this.onlyClientFields.Controls.Add(this.addressText);
            this.onlyClientFields.Controls.Add(this.addressMsg);
            this.onlyClientFields.Controls.Add(this.addressTitle);
            this.onlyClientFields.Controls.Add(this.telNumberTitle);
            this.onlyClientFields.Location = new System.Drawing.Point(193, 229);
            this.onlyClientFields.Name = "onlyClientFields";
            this.onlyClientFields.Size = new System.Drawing.Size(619, 142);
            this.onlyClientFields.TabIndex = 22;
            // 
            // telNumberMsg
            // 
            this.telNumberMsg.AutoSize = true;
            this.telNumberMsg.Location = new System.Drawing.Point(355, 68);
            this.telNumberMsg.Name = "telNumberMsg";
            this.telNumberMsg.Size = new System.Drawing.Size(0, 13);
            this.telNumberMsg.TabIndex = 34;
            // 
            // telNumberText
            // 
            this.telNumberText.Location = new System.Drawing.Point(267, 63);
            this.telNumberText.Mask = "0000-00-00";
            this.telNumberText.Name = "telNumberText";
            this.telNumberText.Size = new System.Drawing.Size(68, 20);
            this.telNumberText.TabIndex = 37;
            this.telNumberText.Enter += new System.EventHandler(this.telNumberText_Enter);
            this.telNumberText.Leave += new System.EventHandler(this.telNumberText_Leave);
            // 
            // idMsg
            // 
            this.idMsg.AutoSize = true;
            this.idMsg.Location = new System.Drawing.Point(355, 26);
            this.idMsg.Name = "idMsg";
            this.idMsg.Size = new System.Drawing.Size(0, 13);
            this.idMsg.TabIndex = 33;
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
            // idText
            // 
            this.idText.ImeMode = System.Windows.Forms.ImeMode.On;
            this.idText.Location = new System.Drawing.Point(267, 21);
            this.idText.Mask = "0.000.000-0";
            this.idText.Name = "idText";
            this.idText.Size = new System.Drawing.Size(68, 20);
            this.idText.TabIndex = 36;
            this.idText.Enter += new System.EventHandler(this.idText_Enter);
            this.idText.Leave += new System.EventHandler(this.idText_Leave);
            // 
            // addressText
            // 
            this.addressText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressText.Location = new System.Drawing.Point(267, 99);
            this.addressText.Name = "addressText";
            this.addressText.Size = new System.Drawing.Size(187, 31);
            this.addressText.TabIndex = 5;
            this.addressText.Enter += new System.EventHandler(this.addressText_Enter);
            this.addressText.Leave += new System.EventHandler(this.addressText_Leave);
            // 
            // addressMsg
            // 
            this.addressMsg.AutoSize = true;
            this.addressMsg.Location = new System.Drawing.Point(469, 127);
            this.addressMsg.Name = "addressMsg";
            this.addressMsg.Size = new System.Drawing.Size(0, 13);
            this.addressMsg.TabIndex = 35;
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
            this.UsernameTitle.Location = new System.Drawing.Point(226, 63);
            this.UsernameTitle.Name = "UsernameTitle";
            this.UsernameTitle.Size = new System.Drawing.Size(111, 22);
            this.UsernameTitle.TabIndex = 20;
            this.UsernameTitle.Text = "User name:";
            this.UsernameTitle.UseMnemonic = false;
            // 
            // userNameText
            // 
            this.userNameText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameText.Location = new System.Drawing.Point(460, 60);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(187, 31);
            this.userNameText.TabIndex = 25;
            this.userNameText.Enter += new System.EventHandler(this.userNameText_Enter);
            this.userNameText.Leave += new System.EventHandler(this.userNameText_Leave);
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(366, 390);
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
            this.passwordText.Location = new System.Drawing.Point(460, 106);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(187, 31);
            this.passwordText.TabIndex = 28;
            this.passwordText.Enter += new System.EventHandler(this.passwordText_Enter);
            this.passwordText.Leave += new System.EventHandler(this.passwordText_Leave);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(226, 109);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(100, 22);
            this.passwordLabel.TabIndex = 27;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.UseMnemonic = false;
            // 
            // userNameMsg
            // 
            this.userNameMsg.AutoSize = true;
            this.userNameMsg.Location = new System.Drawing.Point(743, 74);
            this.userNameMsg.Name = "userNameMsg";
            this.userNameMsg.Size = new System.Drawing.Size(0, 13);
            this.userNameMsg.TabIndex = 29;
            // 
            // passwordMsg
            // 
            this.passwordMsg.AutoSize = true;
            this.passwordMsg.Location = new System.Drawing.Point(743, 116);
            this.passwordMsg.Name = "passwordMsg";
            this.passwordMsg.Size = new System.Drawing.Size(0, 13);
            this.passwordMsg.TabIndex = 30;
            // 
            // surnameMsg
            // 
            this.surnameMsg.AutoSize = true;
            this.surnameMsg.Location = new System.Drawing.Point(743, 159);
            this.surnameMsg.Name = "surnameMsg";
            this.surnameMsg.Size = new System.Drawing.Size(0, 13);
            this.surnameMsg.TabIndex = 31;
            // 
            // nameMsg
            // 
            this.nameMsg.AutoSize = true;
            this.nameMsg.Location = new System.Drawing.Point(743, 202);
            this.nameMsg.Name = "nameMsg";
            this.nameMsg.Size = new System.Drawing.Size(0, 13);
            this.nameMsg.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.label1.Location = new System.Drawing.Point(380, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 33;
            this.label1.Text = "Create User";
            this.label1.UseMnemonic = false;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameMsg);
            this.Controls.Add(this.surnameMsg);
            this.Controls.Add(this.passwordMsg);
            this.Controls.Add(this.userNameMsg);
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
        private System.Windows.Forms.Label IDTitle;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label addressTitle;
        private System.Windows.Forms.Label telNumberTitle;
        private System.Windows.Forms.Label UsernameTitle;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label userNameMsg;
        private System.Windows.Forms.Label passwordMsg;
        private System.Windows.Forms.Label surnameMsg;
        private System.Windows.Forms.Label nameMsg;
        private System.Windows.Forms.Label idMsg;
        private System.Windows.Forms.Label telNumberMsg;
        private System.Windows.Forms.Label addressMsg;
        private System.Windows.Forms.MaskedTextBox telNumberText;
        private System.Windows.Forms.MaskedTextBox idText;
        private System.Windows.Forms.Label label1;
    }
}
