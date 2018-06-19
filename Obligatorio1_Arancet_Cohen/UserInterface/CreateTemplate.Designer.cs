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
            ((System.ComponentModel.ISupportInitialize)(this.spinnerLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerHeightAboveFloor)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(207, 117);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(173, 20);
            this.nameText.TabIndex = 0;
            // 
            // spinnerLength
            // 
            this.spinnerLength.Location = new System.Drawing.Point(207, 159);
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
            this.spinnerLength.Size = new System.Drawing.Size(120, 20);
            this.spinnerLength.TabIndex = 1;
            this.spinnerLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // spinnerHeight
            // 
            this.spinnerHeight.Location = new System.Drawing.Point(207, 200);
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
            this.spinnerHeight.Size = new System.Drawing.Size(120, 20);
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
            this.spinnerHeightAboveFloor.Location = new System.Drawing.Point(207, 242);
            this.spinnerHeightAboveFloor.Name = "spinnerHeightAboveFloor";
            this.spinnerHeightAboveFloor.Size = new System.Drawing.Size(120, 20);
            this.spinnerHeightAboveFloor.TabIndex = 3;
            this.spinnerHeightAboveFloor.ValueChanged += new System.EventHandler(this.spinnerHeightAboveFloor_ValueChanged);
            // 
            // WindowOption
            // 
            this.WindowOption.AutoSize = true;
            this.WindowOption.Location = new System.Drawing.Point(6, 19);
            this.WindowOption.Name = "WindowOption";
            this.WindowOption.Size = new System.Drawing.Size(64, 17);
            this.WindowOption.TabIndex = 4;
            this.WindowOption.TabStop = true;
            this.WindowOption.Text = "Window";
            this.WindowOption.UseVisualStyleBackColor = true;
            this.WindowOption.CheckedChanged += new System.EventHandler(this.WindowOption_CheckedChanged);
            // 
            // doorOption
            // 
            this.doorOption.AutoSize = true;
            this.doorOption.Location = new System.Drawing.Point(6, 42);
            this.doorOption.Name = "doorOption";
            this.doorOption.Size = new System.Drawing.Size(48, 17);
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
            this.groupBox1.Location = new System.Drawing.Point(207, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 69);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Opening Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Model name:";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(80, 159);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(43, 13);
            this.lengthLabel.TabIndex = 8;
            this.lengthLabel.Text = "Length:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(80, 200);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(41, 13);
            this.heightLabel.TabIndex = 9;
            this.heightLabel.Text = "Height:";
            // 
            // heightAboveFloorLabel
            // 
            this.heightAboveFloorLabel.AutoSize = true;
            this.heightAboveFloorLabel.Location = new System.Drawing.Point(80, 242);
            this.heightAboveFloorLabel.Name = "heightAboveFloorLabel";
            this.heightAboveFloorLabel.Size = new System.Drawing.Size(97, 13);
            this.heightAboveFloorLabel.TabIndex = 10;
            this.heightAboveFloorLabel.Text = "Height above floor:";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(419, 400);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(162, 23);
            this.createButton.TabIndex = 11;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // CreateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
