namespace UserInterface {
    partial class LoginView {
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
            this.LogInButton = new System.Windows.Forms.Button();
            this.WelcomeMessageLabel = new System.Windows.Forms.Label();
            this.UsernameText = new System.Windows.Forms.TextBox();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.testDataButton = new System.Windows.Forms.Button();
            this.UserNameMsg = new System.Windows.Forms.Label();
            this.PasswordMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LogInButton
            // 
            this.LogInButton.Location = new System.Drawing.Point(333, 328);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(180, 50);
            this.LogInButton.TabIndex = 0;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // WelcomeMessageLabel
            // 
            this.WelcomeMessageLabel.AutoSize = true;
            this.WelcomeMessageLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeMessageLabel.Location = new System.Drawing.Point(312, 115);
            this.WelcomeMessageLabel.Name = "WelcomeMessageLabel";
            this.WelcomeMessageLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WelcomeMessageLabel.Size = new System.Drawing.Size(235, 22);
            this.WelcomeMessageLabel.TabIndex = 1;
            this.WelcomeMessageLabel.Text = "Welcome, please sign up";
            // 
            // UsernameText
            // 
            this.UsernameText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameText.Location = new System.Drawing.Point(310, 199);
            this.UsernameText.Name = "UsernameText";
            this.UsernameText.Size = new System.Drawing.Size(236, 31);
            this.UsernameText.TabIndex = 2;
            this.UsernameText.TextChanged += new System.EventHandler(this.UsernameText_TextChanged);
            // 
            // PasswordText
            // 
            this.PasswordText.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordText.Location = new System.Drawing.Point(310, 273);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(236, 31);
            this.PasswordText.TabIndex = 3;
            this.PasswordText.TextChanged += new System.EventHandler(this.PasswordText_TextChanged);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.Location = new System.Drawing.Point(306, 174);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(106, 22);
            this.UsernameLabel.TabIndex = 4;
            this.UsernameLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(306, 248);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(95, 22);
            this.PasswordLabel.TabIndex = 5;
            this.PasswordLabel.Text = "Password";
            // 
            // testDataButton
            // 
            this.testDataButton.Location = new System.Drawing.Point(41, 480);
            this.testDataButton.Name = "testDataButton";
            this.testDataButton.Size = new System.Drawing.Size(127, 41);
            this.testDataButton.TabIndex = 6;
            this.testDataButton.Text = "Generate data for testing";
            this.testDataButton.UseVisualStyleBackColor = true;
            this.testDataButton.Click += new System.EventHandler(this.testDataButton_Click);
            // 
            // UserNameMsg
            // 
            this.UserNameMsg.AutoSize = true;
            this.UserNameMsg.Location = new System.Drawing.Point(575, 199);
            this.UserNameMsg.Name = "UserNameMsg";
            this.UserNameMsg.Size = new System.Drawing.Size(0, 13);
            this.UserNameMsg.TabIndex = 7;
            // 
            // PasswordMsg
            // 
            this.PasswordMsg.AutoSize = true;
            this.PasswordMsg.Location = new System.Drawing.Point(575, 273);
            this.PasswordMsg.Name = "PasswordMsg";
            this.PasswordMsg.Size = new System.Drawing.Size(0, 13);
            this.PasswordMsg.TabIndex = 8;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PasswordMsg);
            this.Controls.Add(this.UserNameMsg);
            this.Controls.Add(this.testDataButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.UsernameText);
            this.Controls.Add(this.WelcomeMessageLabel);
            this.Controls.Add(this.LogInButton);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(884, 561);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label WelcomeMessageLabel;
        private System.Windows.Forms.TextBox UsernameText;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        internal System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Button testDataButton;
        private System.Windows.Forms.Label UserNameMsg;
        private System.Windows.Forms.Label PasswordMsg;
    }
}
