namespace BatchRenameApp
{
    partial class ImportFoldersWindow
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(283, 12);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 104);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(283, 122);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(239, 426);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // OkButton
            // 
            this.ButtonOk.Location = new System.Drawing.Point(257, 382);
            this.ButtonOk.Name = "OkButton";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(257, 411);
            this.ButtonCancel.Name = "CancelButton";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ImportFoldersWindow
            // 
            this.AcceptButton = this.ButtonOk;
            this.CancelButton = this.ButtonCancel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;    
            this.ClientSize = new System.Drawing.Size(340, 450);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ImportFoldersWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Import Folders";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
    }
}