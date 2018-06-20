namespace UserInterface
{
    partial class NewEditBlueprintView
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
            this.userList = new System.Windows.Forms.ListBox();
            this.signedList = new System.Windows.Forms.ListBox();
            this.unSignedList = new System.Windows.Forms.ListBox();
            this.signatureLists = new System.Windows.Forms.ListBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(25, 40);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(187, 303);
            this.userList.TabIndex = 0;
            // 
            // signedList
            // 
            this.signedList.FormattingEnabled = true;
            this.signedList.Location = new System.Drawing.Point(244, 40);
            this.signedList.Name = "signedList";
            this.signedList.Size = new System.Drawing.Size(186, 303);
            this.signedList.TabIndex = 1;
            // 
            // unSignedList
            // 
            this.unSignedList.FormattingEnabled = true;
            this.unSignedList.Location = new System.Drawing.Point(459, 40);
            this.unSignedList.Name = "unSignedList";
            this.unSignedList.Size = new System.Drawing.Size(181, 303);
            this.unSignedList.TabIndex = 2;
            // 
            // signatureLists
            // 
            this.signatureLists.FormattingEnabled = true;
            this.signatureLists.Location = new System.Drawing.Point(673, 40);
            this.signatureLists.Name = "signatureLists";
            this.signatureLists.Size = new System.Drawing.Size(181, 303);
            this.signatureLists.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(244, 377);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(165, 46);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(459, 377);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(170, 46);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // NewEditBlueprintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.signatureLists);
            this.Controls.Add(this.unSignedList);
            this.Controls.Add(this.signedList);
            this.Controls.Add(this.userList);
            this.Name = "NewEditBlueprintView";
            this.Size = new System.Drawing.Size(884, 461);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.ListBox signedList;
        private System.Windows.Forms.ListBox unSignedList;
        private System.Windows.Forms.ListBox signatureLists;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
    }
}
