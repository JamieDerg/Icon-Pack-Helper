namespace Icon_Pack_Helper.GUI.Forms
{
    partial class EditCategory
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.nameText = new System.Windows.Forms.TextBox();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.button = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(175, 227);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(193, 12);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(75, 67);
            this.MoveUpButton.TabIndex = 1;
            this.MoveUpButton.Text = "🡩";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(13, 257);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(174, 20);
            this.nameText.TabIndex = 3;
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(194, 172);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(75, 67);
            this.MoveDownButton.TabIndex = 2;
            this.MoveDownButton.Text = "🡫";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(194, 257);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 20);
            this.button.TabIndex = 4;
            this.button.Text = "add";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 171;
            // 
            // EditCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 304);
            this.Controls.Add(this.button);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.listView1);
            this.Name = "EditCategory";
            this.Text = "EditCategory";
            this.Load += new System.EventHandler(this.EditCategory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}