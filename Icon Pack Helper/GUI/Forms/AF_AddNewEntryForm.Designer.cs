namespace Icon_Pack_Helper.GUI.Forms
{
    partial class AddNewEntryForm
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
            this.label9 = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ComponentInfoText = new System.Windows.Forms.TextBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Drawable = new System.Windows.Forms.Label();
            this.DrawableText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label9.Location = new System.Drawing.Point(12, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 24);
            this.label9.TabIndex = 15;
            this.label9.Text = "Name";
            // 
            // NameText
            // 
            this.NameText.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.NameText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NameText.Location = new System.Drawing.Point(14, 52);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(512, 22);
            this.NameText.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(343, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "Component Info (das aus der email)";
            // 
            // ComponentInfoText
            // 
            this.ComponentInfoText.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ComponentInfoText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ComponentInfoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComponentInfoText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ComponentInfoText.Location = new System.Drawing.Point(12, 130);
            this.ComponentInfoText.Name = "ComponentInfoText";
            this.ComponentInfoText.Size = new System.Drawing.Size(512, 22);
            this.ComponentInfoText.TabIndex = 18;
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.DoneButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoneButton.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.DoneButton.FlatAppearance.BorderSize = 2;
            this.DoneButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DoneButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DoneButton.Location = new System.Drawing.Point(141, 326);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(120, 40);
            this.DoneButton.TabIndex = 22;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton.FlatAppearance.BorderSize = 2;
            this.CancelButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButton.Location = new System.Drawing.Point(289, 326);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(120, 40);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Drawable
            // 
            this.Drawable.AutoSize = true;
            this.Drawable.BackColor = System.Drawing.Color.Transparent;
            this.Drawable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drawable.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Drawable.Location = new System.Drawing.Point(10, 174);
            this.Drawable.Name = "Drawable";
            this.Drawable.Size = new System.Drawing.Size(97, 24);
            this.Drawable.TabIndex = 25;
            this.Drawable.Text = "Drawable";
            // 
            // DrawableText
            // 
            this.DrawableText.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DrawableText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DrawableText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrawableText.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.DrawableText.Location = new System.Drawing.Point(12, 208);
            this.DrawableText.Name = "DrawableText";
            this.DrawableText.Size = new System.Drawing.Size(512, 22);
            this.DrawableText.TabIndex = 26;
            // 
            // AddNewEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 413);
            this.Controls.Add(this.Drawable);
            this.Controls.Add(this.DrawableText);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComponentInfoText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NameText);
            this.Name = "AddNewEntryForm";
            this.Text = "AddNewEntryForm";
            this.Load += new System.EventHandler(this.AddNewEntryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ComponentInfoText;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label Drawable;
        private System.Windows.Forms.TextBox DrawableText;
    }
}