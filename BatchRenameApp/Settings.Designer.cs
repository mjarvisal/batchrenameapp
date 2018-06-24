namespace BatchRenameApp
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.textBoxDateFormat = new System.Windows.Forms.TextBox();
            this.labeldateFormat = new System.Windows.Forms.Label();
            this.labeltimeFormat = new System.Windows.Forms.Label();
            this.textBoxtimeFormat = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxDateFormat
            // 
            this.textBoxDateFormat.Location = new System.Drawing.Point(12, 29);
            this.textBoxDateFormat.Name = "textBoxDateFormat";
            this.textBoxDateFormat.Size = new System.Drawing.Size(100, 20);
            this.textBoxDateFormat.TabIndex = 0;
            this.textBoxDateFormat.Text = "yyyy-MM-dd";
            this.textBoxDateFormat.TextChanged += new System.EventHandler(this.textBoxDateFormat_TextChanged);
            // 
            // labeldateFormat
            // 
            this.labeldateFormat.AutoSize = true;
            this.labeldateFormat.Location = new System.Drawing.Point(13, 13);
            this.labeldateFormat.Name = "labeldateFormat";
            this.labeldateFormat.Size = new System.Drawing.Size(62, 13);
            this.labeldateFormat.TabIndex = 1;
            this.labeldateFormat.Text = "Date format";
            // 
            // labeltimeFormat
            // 
            this.labeltimeFormat.AutoSize = true;
            this.labeltimeFormat.Location = new System.Drawing.Point(13, 60);
            this.labeltimeFormat.Name = "labeltimeFormat";
            this.labeltimeFormat.Size = new System.Drawing.Size(62, 13);
            this.labeltimeFormat.TabIndex = 3;
            this.labeltimeFormat.Text = "Time format";
            // 
            // textBoxtimeFormat
            // 
            this.textBoxtimeFormat.Location = new System.Drawing.Point(12, 76);
            this.textBoxtimeFormat.Name = "textBoxtimeFormat";
            this.textBoxtimeFormat.Size = new System.Drawing.Size(100, 20);
            this.textBoxtimeFormat.TabIndex = 2;
            this.textBoxtimeFormat.Text = "HH.mm.ss";
            this.textBoxtimeFormat.TextChanged += new System.EventHandler(this.textBoxtimeFormat_TextChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.labeltimeFormat);
            this.Controls.Add(this.textBoxtimeFormat);
            this.Controls.Add(this.labeldateFormat);
            this.Controls.Add(this.textBoxDateFormat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDateFormat;
        private System.Windows.Forms.Label labeldateFormat;
        private System.Windows.Forms.Label labeltimeFormat;
        private System.Windows.Forms.TextBox textBoxtimeFormat;
    }
}