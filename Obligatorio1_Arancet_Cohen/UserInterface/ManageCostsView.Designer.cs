namespace UserInterface {
    partial class ManageCostsView {
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
            this.materialsList = new System.Windows.Forms.ListBox();
            this.costPriceInfo = new System.Windows.Forms.Panel();
            this.costSpinner = new System.Windows.Forms.NumericUpDown();
            this.priceSpinner = new System.Windows.Forms.NumericUpDown();
            this.changePriceButton = new System.Windows.Forms.Button();
            this.priceLabel = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.doneButton = new System.Windows.Forms.Button();
            this.costPriceInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // materialsList
            // 
            this.materialsList.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialsList.FormattingEnabled = true;
            this.materialsList.ItemHeight = 16;
            this.materialsList.Location = new System.Drawing.Point(122, 60);
            this.materialsList.Name = "materialsList";
            this.materialsList.Size = new System.Drawing.Size(636, 180);
            this.materialsList.TabIndex = 0;
            this.materialsList.SelectedIndexChanged += new System.EventHandler(this.materialsList_SelectedIndexChanged);
            // 
            // costPriceInfo
            // 
            this.costPriceInfo.Controls.Add(this.costSpinner);
            this.costPriceInfo.Controls.Add(this.priceSpinner);
            this.costPriceInfo.Controls.Add(this.changePriceButton);
            this.costPriceInfo.Controls.Add(this.priceLabel);
            this.costPriceInfo.Controls.Add(this.costLabel);
            this.costPriceInfo.Location = new System.Drawing.Point(369, 246);
            this.costPriceInfo.Name = "costPriceInfo";
            this.costPriceInfo.Size = new System.Drawing.Size(117, 127);
            this.costPriceInfo.TabIndex = 1;
            // 
            // costSpinner
            // 
            this.costSpinner.Location = new System.Drawing.Point(44, 0);
            this.costSpinner.Name = "costSpinner";
            this.costSpinner.Size = new System.Drawing.Size(58, 20);
            this.costSpinner.TabIndex = 7;
            // 
            // priceSpinner
            // 
            this.priceSpinner.Location = new System.Drawing.Point(44, 44);
            this.priceSpinner.Name = "priceSpinner";
            this.priceSpinner.Size = new System.Drawing.Size(58, 20);
            this.priceSpinner.TabIndex = 6;
            // 
            // changePriceButton
            // 
            this.changePriceButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changePriceButton.Location = new System.Drawing.Point(23, 89);
            this.changePriceButton.Name = "changePriceButton";
            this.changePriceButton.Size = new System.Drawing.Size(75, 23);
            this.changePriceButton.TabIndex = 5;
            this.changePriceButton.Text = "Change";
            this.changePriceButton.UseVisualStyleBackColor = true;
            this.changePriceButton.Click += new System.EventHandler(this.changePriceButton_Click);
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(1, 44);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.priceLabel.Size = new System.Drawing.Size(37, 16);
            this.priceLabel.TabIndex = 1;
            this.priceLabel.Text = "Price:";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costLabel.Location = new System.Drawing.Point(3, 0);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(35, 16);
            this.costLabel.TabIndex = 0;
            this.costLabel.Text = "Cost:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            this.title.Location = new System.Drawing.Point(347, 21);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(149, 23);
            this.title.TabIndex = 2;
            this.title.Text = "Select Material";
            // 
            // doneButton
            // 
            this.doneButton.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.Location = new System.Drawing.Point(348, 405);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(157, 43);
            this.doneButton.TabIndex = 3;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // ManageCostsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.costPriceInfo);
            this.Controls.Add(this.materialsList);
            this.Name = "ManageCostsView";
            this.Size = new System.Drawing.Size(884, 461);
            this.costPriceInfo.ResumeLayout(false);
            this.costPriceInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.costSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox materialsList;
        private System.Windows.Forms.Panel costPriceInfo;
        private System.Windows.Forms.NumericUpDown costSpinner;
        private System.Windows.Forms.NumericUpDown priceSpinner;
        private System.Windows.Forms.Button changePriceButton;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button doneButton;
    }
}
