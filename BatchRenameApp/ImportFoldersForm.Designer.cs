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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFoldersWindow));
            this.trackBarFolderDepth = new System.Windows.Forms.TrackBar();
            this.textBoxFolderDepth = new System.Windows.Forms.TextBox();
            this.treeViewFileslist = new System.Windows.Forms.TreeView();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFolderDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarFolderDepth
            // 
            this.trackBarFolderDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarFolderDepth.Location = new System.Drawing.Point(311, 12);
            this.trackBarFolderDepth.Name = "trackBarFolderDepth";
            this.trackBarFolderDepth.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarFolderDepth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarFolderDepth.RightToLeftLayout = true;
            this.trackBarFolderDepth.Size = new System.Drawing.Size(45, 104);
            this.trackBarFolderDepth.TabIndex = 1;
            this.trackBarFolderDepth.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarFolderDepth.Value = 10;
            this.trackBarFolderDepth.ValueChanged += new System.EventHandler(this.TrackBarFolderDepth_ValueChanged);
            // 
            // textBoxFolderDepth
            // 
            this.textBoxFolderDepth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFolderDepth.Enabled = false;
            this.textBoxFolderDepth.Location = new System.Drawing.Point(311, 122);
            this.textBoxFolderDepth.Name = "textBoxFolderDepth";
            this.textBoxFolderDepth.Size = new System.Drawing.Size(45, 20);
            this.textBoxFolderDepth.TabIndex = 2;
            this.textBoxFolderDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // treeViewFileslist
            // 
            this.treeViewFileslist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewFileslist.Location = new System.Drawing.Point(12, 12);
            this.treeViewFileslist.Name = "treeViewFileslist";
            this.treeViewFileslist.Size = new System.Drawing.Size(276, 426);
            this.treeViewFileslist.TabIndex = 3;
            this.treeViewFileslist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TreeViewFileslist_KeyUp);
            // 
            // ButtonOk
            // 
            this.ButtonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonOk.Location = new System.Drawing.Point(294, 382);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 4;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(294, 411);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ImportFoldersWindow
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(377, 450);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.treeViewFileslist);
            this.Controls.Add(this.textBoxFolderDepth);
            this.Controls.Add(this.trackBarFolderDepth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ImportFoldersWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Import Folders";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFolderDepth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackBarFolderDepth;
        private System.Windows.Forms.TextBox textBoxFolderDepth;
        private System.Windows.Forms.TreeView treeViewFileslist;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
    }
}