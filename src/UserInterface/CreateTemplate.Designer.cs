namespace UserInterface
{
    partial class CreateTemplate
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameText = new System.Windows.Forms.TextBox();
            this.spinnerLength = new System.Windows.Forms.NumericUpDown();
            this.spinnerHeight = new System.Windows.Forms.NumericUpDown();
            this.spinnerHeightAboveFloor = new System.Windows.Forms.NumericUpDown();
            this.WindowOption = new System.Windows.Forms.RadioButton();
            this.doorOption = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.heightAboveFloorLabel = new System.Windows.Forms.Label();
            this.createButton = new System.Windows.Forms.Button();
            this.msgLabel = new System.Windows.Forms.Label();
            this.msgName = new System.Windows.Forms.Label();
            this.msgLength = new System.Windows.Forms.Label();
            this.msgHeight = new System.Windows.Forms.Label();
            this.msgHightAboveFloor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerHeightAboveFloor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(457, 77);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(173, 20);
            this.nameText.TabIndex = 0;
            this.nameText.Enter += new System.EventHandler(this.nameText_Enter);
            this.nameText.Leave += new System.EventHandler(this.nameText_Leave);
            // 
            // spinnerLength
            // 
            this.spinnerLength.DecimalPlaces = 2;
            this.spinnerLength.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinnerLength.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinnerLength.Location = new System.Drawing.Point(457, 119);
            this.spinnerLength.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spinnerLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinnerLength.Name = "spinnerLength";
            this.spinnerLength.Size = new System.Drawing.Size(120, 26);
            this.spinnerLength.TabIndex = 1;
            this.spinnerLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinnerLength.ValueChanged += new System.EventHandler(this.spinnerLength_ValueChanged);
            this.spinnerLength.Enter += new System.EventHandler(this.spinnerLength_Enter);
            // 
            // spinnerHeight
            // 
            this.spinnerHeight.DecimalPlaces = 2;
            this.spinnerHeight.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinnerHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinnerHeight.Location = new System.Drawing.Point(457, 160);
            this.spinnerHeight.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spinnerHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinnerHeight.Name = "spinnerHeight";
            this.spinnerHeight.Size = new System.Drawing.Size(120, 26);
            this.spinnerHeight.TabIndex = 2;
            this.spinnerHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinnerHeight.ValueChanged += new System.EventHandler(this.spinnerHeight_ValueChanged);
            // 
            // spinnerHeightAboveFloor
            // 
            this.spinnerHeightAboveFloor.DecimalPlaces = 2;
            this.spinnerHeightAboveFloor.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinnerHeightAboveFloor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.spinnerHeightAboveFloor.Location = new System.Drawing.Point(457, 202);
            this.spinnerHeightAboveFloor.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spinnerHeightAboveFloor.Name = "spinnerHeightAboveFloor";
            this.spinnerHeightAboveFloor.Size = new System.Drawing.Size(120, 26);
            this.spinnerHeightAboveFloor.TabIndex = 3;
            this.spinnerHeightAboveFloor.ValueChanged += new System.EventHandler(this.spinnerHeightAboveFloor_ValueChanged);
            // 
            // WindowOption
            // 
            this.WindowOption.AutoSize = true;
            this.WindowOption.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowOption.Location = new System.Drawing.Point(6, 19);
            this.WindowOption.Name = "WindowOption";
            this.WindowOption.Size = new System.Drawing.Size(88, 24);
            this.WindowOption.TabIndex = 4;
            this.WindowOption.TabStop = true;
            this.WindowOption.Text = "Window";
            this.WindowOption.UseVisualStyleBackColor = true;
            this.WindowOption.CheckedChanged += new System.EventHandler(this.WindowOption_CheckedChanged);
            // 
            // doorOption
            // 
            this.doorOption.AutoSize = true;
            this.doorOption.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doorOption.Location = new System.Drawing.Point(6, 42);
            this.doorOption.Name = "doorOption";
            this.doorOption.Size = new System.Drawing.Size(63, 24);
            this.doorOption.TabIndex = 5;
            this.doorOption.TabStop = true;
            this.doorOption.Text = "Door";
            this.doorOption.UseVisualStyleBackColor = true;
            this.doorOption.CheckedChanged += new System.EventHandler(this.doorOption_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.doorOption);
            this.groupBox1.Controls.Add(this.WindowOption);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(282, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 69);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Opening Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Model name:";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lengthLabel.Location = new System.Drawing.Point(278, 121);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(63, 20);
            this.lengthLabel.TabIndex = 8;
            this.lengthLabel.Text = "Length:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heightLabel.Location = new System.Drawing.Point(278, 162);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(60, 20);
            this.heightLabel.TabIndex = 9;
            this.heightLabel.Text = "Height:";
            // 
            // heightAboveFloorLabel
            // 
            this.heightAboveFloorLabel.AutoSize = true;
            this.heightAboveFloorLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heightAboveFloorLabel.Location = new System.Drawing.Point(278, 204);
            this.heightAboveFloorLabel.Name = "heightAboveFloorLabel";
            this.heightAboveFloorLabel.Size = new System.Drawing.Size(151, 20);
            this.heightAboveFloorLabel.TabIndex = 10;
            this.heightAboveFloorLabel.Text = "Height above floor:";
            // 
            // createButton
            // 
            this.createButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(356, 350);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(162, 41);
            this.createButton.TabIndex = 11;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Location = new System.Drawing.Point(328, 365);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(0, 13);
            this.msgLabel.TabIndex = 12;
            // 
            // msgName
            // 
            this.msgName.AutoSize = true;
            this.msgName.Location = new System.Drawing.Point(636, 82);
            this.msgName.Name = "msgName";
            this.msgName.Size = new System.Drawing.Size(0, 13);
            this.msgName.TabIndex = 13;
            // 
            // msgLength
            // 
            this.msgLength.AutoSize = true;
            this.msgLength.Location = new System.Drawing.Point(583, 126);
            this.msgLength.Name = "msgLength";
            this.msgLength.Size = new System.Drawing.Size(0, 13);
            this.msgLength.TabIndex = 14;
            // 
            // msgHeight
            // 
            this.msgHeight.AutoSize = true;
            this.msgHeight.Location = new System.Drawing.Point(583, 167);
            this.msgHeight.Name = "msgHeight";
            this.msgHeight.Size = new System.Drawing.Size(0, 13);
            this.msgHeight.TabIndex = 15;
            // 
            // msgHightAboveFloor
            // 
            this.msgHightAboveFloor.AutoSize = true;
            this.msgHightAboveFloor.Location = new System.Drawing.Point(583, 209);
            this.msgHightAboveFloor.Name = "msgHightAboveFloor";
            this.msgHightAboveFloor.Size = new System.Drawing.Size(0, 13);
            this.msgHightAboveFloor.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(352, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 23);
            this.label2.TabIndex = 34;
            this.label2.Text = "Create Template";
            this.label2.UseMnemonic = false;
            // 
            // CreateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.msgHightAboveFloor);
            this.Controls.Add(this.msgHeight);
            this.Controls.Add(this.msgLength);
            this.Controls.Add(this.msgName);
            this.Controls.Add(this.msgLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.heightAboveFloorLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.spinnerHeightAboveFloor);
            this.Controls.Add(this.spinnerHeight);
            this.Controls.Add(this.spinnerLength);
            this.Controls.Add(this.nameText);
            this.Name = "CreateTemplate";
            this.Size = new System.Drawing.Size(884, 461);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerHeightAboveFloor)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.NumericUpDown spinnerLength;
        private System.Windows.Forms.NumericUpDown spinnerHeight;
        private System.Windows.Forms.NumericUpDown spinnerHeightAboveFloor;
        private System.Windows.Forms.RadioButton WindowOption;
        private System.Windows.Forms.RadioButton doorOption;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label heightAboveFloorLabel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Label msgName;
        private System.Windows.Forms.Label msgLength;
        private System.Windows.Forms.Label msgHeight;
        private System.Windows.Forms.Label msgHightAboveFloor;
        private System.Windows.Forms.Label label2;
    }
}
