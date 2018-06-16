namespace BatchRenameApp
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.listBoxFilelist = new System.Windows.Forms.ListBox();
            this.textBoxRegExp = new System.Windows.Forms.TextBox();
            this.labelRegExp = new System.Windows.Forms.Label();
            this.labelFileList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxFilelist
            // 
            this.listBoxFilelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFilelist.FormattingEnabled = true;
            this.listBoxFilelist.HorizontalScrollbar = true;
            this.listBoxFilelist.Location = new System.Drawing.Point(270, 38);
            this.listBoxFilelist.Name = "listBoxFilelist";
            this.listBoxFilelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFilelist.Size = new System.Drawing.Size(197, 459);
            this.listBoxFilelist.TabIndex = 0;
            // 
            // textBoxRegExp
            // 
            this.textBoxRegExp.Location = new System.Drawing.Point(12, 78);
            this.textBoxRegExp.Name = "textBoxRegExp";
            this.textBoxRegExp.Size = new System.Drawing.Size(252, 20);
            this.textBoxRegExp.TabIndex = 1;
            // 
            // labelRegExp
            // 
            this.labelRegExp.AutoSize = true;
            this.labelRegExp.Location = new System.Drawing.Point(13, 59);
            this.labelRegExp.Name = "labelRegExp";
            this.labelRegExp.Size = new System.Drawing.Size(92, 13);
            this.labelRegExp.TabIndex = 2;
            this.labelRegExp.Text = "regular expression";
            // 
            // labelFileList
            // 
            this.labelFileList.AutoSize = true;
            this.labelFileList.Location = new System.Drawing.Point(267, 22);
            this.labelFileList.Name = "labelFileList";
            this.labelFileList.Size = new System.Drawing.Size(35, 13);
            this.labelFileList.TabIndex = 3;
            this.labelFileList.Text = "Filelist";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 511);
            this.Controls.Add(this.labelFileList);
            this.Controls.Add(this.labelRegExp);
            this.Controls.Add(this.textBoxRegExp);
            this.Controls.Add(this.listBoxFilelist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(495, 550);
            this.Name = "MainWindow";
            this.Text = "BatchRenameApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBoxFilelist;
        private System.Windows.Forms.TextBox textBoxRegExp;
        private System.Windows.Forms.Label labelRegExp;
        private System.Windows.Forms.Label labelFileList;
    }
}

