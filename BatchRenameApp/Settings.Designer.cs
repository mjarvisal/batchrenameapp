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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxDateFormat
            // 
            this.textBoxDateFormat.Location = new System.Drawing.Point(12, 29);
            this.textBoxDateFormat.Name = "textBoxDateFormat";
            this.textBoxDateFormat.Size = new System.Drawing.Size(100, 20);
            this.textBoxDateFormat.TabIndex = 0;
            this.textBoxDateFormat.Text = "yyyy-MM-dd";
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
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(116, 226);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(197, 226);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labeltimeFormat);
            this.Controls.Add(this.textBoxtimeFormat);
            this.Controls.Add(this.labeldateFormat);
            this.Controls.Add(this.textBoxDateFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Settings_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDateFormat;
        private System.Windows.Forms.Label labeldateFormat;
        private System.Windows.Forms.Label labeltimeFormat;
        private System.Windows.Forms.TextBox textBoxtimeFormat;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}