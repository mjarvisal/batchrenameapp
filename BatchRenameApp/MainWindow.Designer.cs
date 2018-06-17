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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.listBoxFilelist = new System.Windows.Forms.ListBox();
            this.inputSearch = new System.Windows.Forms.TextBox();
            this.labelRegExp = new System.Windows.Forms.Label();
            this.labelFileList = new System.Windows.Forms.Label();
            this.labelReplace = new System.Windows.Forms.Label();
            this.inputReplace = new System.Windows.Forms.TextBox();
            this.listBoxPreview = new System.Windows.Forms.ListBox();
            this.labelChanged = new System.Windows.Forms.Label();
            this.buttonRename = new System.Windows.Forms.Button();
            this.checkBoxUseRegex = new System.Windows.Forms.CheckBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.noSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularExpressionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxFilelist
            // 
            this.listBoxFilelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFilelist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxFilelist.FormattingEnabled = true;
            this.listBoxFilelist.HorizontalScrollbar = true;
            this.listBoxFilelist.Location = new System.Drawing.Point(12, 202);
            this.listBoxFilelist.Name = "listBoxFilelist";
            this.listBoxFilelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFilelist.Size = new System.Drawing.Size(197, 238);
            this.listBoxFilelist.TabIndex = 0;
            this.listBoxFilelist.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxFilelist_DrawItem);
            this.listBoxFilelist.SelectedIndexChanged += new System.EventHandler(this.listBoxFilelist_SelectedIndexChanged);
            this.listBoxFilelist.DoubleClick += new System.EventHandler(this.listBoxFilelist_DoubleClick);
            // 
            // inputSearch
            // 
            this.inputSearch.Location = new System.Drawing.Point(12, 38);
            this.inputSearch.Multiline = true;
            this.inputSearch.Name = "inputSearch";
            this.inputSearch.Size = new System.Drawing.Size(252, 20);
            this.inputSearch.TabIndex = 1;
            this.inputSearch.TextChanged += new System.EventHandler(this.inputSearch_TextChanged);
            // 
            // labelRegExp
            // 
            this.labelRegExp.AutoSize = true;
            this.labelRegExp.Location = new System.Drawing.Point(12, 22);
            this.labelRegExp.Name = "labelRegExp";
            this.labelRegExp.Size = new System.Drawing.Size(41, 13);
            this.labelRegExp.TabIndex = 2;
            this.labelRegExp.Text = "Search";
            // 
            // labelFileList
            // 
            this.labelFileList.AutoSize = true;
            this.labelFileList.Location = new System.Drawing.Point(12, 182);
            this.labelFileList.Name = "labelFileList";
            this.labelFileList.Size = new System.Drawing.Size(89, 13);
            this.labelFileList.TabIndex = 3;
            this.labelFileList.Text = "Original filenames";
            // 
            // labelReplace
            // 
            this.labelReplace.AutoSize = true;
            this.labelReplace.Location = new System.Drawing.Point(12, 67);
            this.labelReplace.Name = "labelReplace";
            this.labelReplace.Size = new System.Drawing.Size(47, 13);
            this.labelReplace.TabIndex = 5;
            this.labelReplace.Text = "Replace";
            // 
            // inputReplace
            // 
            this.inputReplace.Location = new System.Drawing.Point(12, 83);
            this.inputReplace.Name = "inputReplace";
            this.inputReplace.Size = new System.Drawing.Size(252, 20);
            this.inputReplace.TabIndex = 2;
            this.inputReplace.TextChanged += new System.EventHandler(this.inputReplace_TextChanged);
            // 
            // listBoxPreview
            // 
            this.listBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPreview.FormattingEnabled = true;
            this.listBoxPreview.HorizontalScrollbar = true;
            this.listBoxPreview.Location = new System.Drawing.Point(267, 202);
            this.listBoxPreview.Name = "listBoxPreview";
            this.listBoxPreview.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPreview.Size = new System.Drawing.Size(197, 238);
            this.listBoxPreview.TabIndex = 7;
            // 
            // labelChanged
            // 
            this.labelChanged.AutoSize = true;
            this.labelChanged.Location = new System.Drawing.Point(264, 182);
            this.labelChanged.Name = "labelChanged";
            this.labelChanged.Size = new System.Drawing.Size(97, 13);
            this.labelChanged.TabIndex = 8;
            this.labelChanged.Text = "Changed filenames";
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(389, 457);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 23);
            this.buttonRename.TabIndex = 9;
            this.buttonRename.Text = "Rename!";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.buttonRename_Click);
            // 
            // checkBoxUseRegex
            // 
            this.checkBoxUseRegex.AutoSize = true;
            this.checkBoxUseRegex.Location = new System.Drawing.Point(286, 41);
            this.checkBoxUseRegex.Name = "checkBoxUseRegex";
            this.checkBoxUseRegex.Size = new System.Drawing.Size(143, 17);
            this.checkBoxUseRegex.TabIndex = 3;
            this.checkBoxUseRegex.Text = "Use Regular expressions";
            this.checkBoxUseRegex.UseVisualStyleBackColor = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.sortToolStripMenuItem,
            this.toolStripSeparator2,
            this.helpToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(104, 76);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem,
            this.toolStripSeparator1,
            this.noSortToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // ascendingToolStripMenuItem
            // 
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ascendingToolStripMenuItem.Text = "Ascending";
            this.ascendingToolStripMenuItem.Click += new System.EventHandler(this.ascendingToolStripMenuItem_Click);
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.descendingToolStripMenuItem.Text = "Descending";
            this.descendingToolStripMenuItem.Click += new System.EventHandler(this.descendingToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // noSortToolStripMenuItem
            // 
            this.noSortToolStripMenuItem.Name = "noSortToolStripMenuItem";
            this.noSortToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noSortToolStripMenuItem.Text = "Reset";
            this.noSortToolStripMenuItem.Click += new System.EventHandler(this.noSortToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(100, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularExpressionsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // regularExpressionsToolStripMenuItem
            // 
            this.regularExpressionsToolStripMenuItem.Name = "regularExpressionsToolStripMenuItem";
            this.regularExpressionsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.regularExpressionsToolStripMenuItem.Text = "Regular expressions";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 516);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.checkBoxUseRegex);
            this.Controls.Add(this.buttonRename);
            this.Controls.Add(this.labelChanged);
            this.Controls.Add(this.listBoxPreview);
            this.Controls.Add(this.labelReplace);
            this.Controls.Add(this.inputReplace);
            this.Controls.Add(this.labelFileList);
            this.Controls.Add(this.labelRegExp);
            this.Controls.Add(this.inputSearch);
            this.Controls.Add(this.listBoxFilelist);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(495, 550);
            this.Name = "MainWindow";
            this.Text = "BatchRenameApp";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxFilelist_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxFilelist_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox listBoxFilelist;
        private System.Windows.Forms.TextBox inputSearch;
        private System.Windows.Forms.Label labelRegExp;
        private System.Windows.Forms.Label labelReplace;
        private System.Windows.Forms.TextBox inputReplace;
        public System.Windows.Forms.ListBox listBoxPreview;
        private System.Windows.Forms.Label labelFileList;
        private System.Windows.Forms.Label labelChanged;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.CheckBox checkBoxUseRegex;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ascendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularExpressionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
    }
}

