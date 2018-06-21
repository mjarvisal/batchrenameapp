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
            this.inputSearch = new System.Windows.Forms.TextBox();
            this.labelRegExp = new System.Windows.Forms.Label();
            this.labelReplace = new System.Windows.Forms.Label();
            this.inputReplace = new System.Windows.Forms.TextBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.checkBoxUseRegex = new System.Windows.Forms.CheckBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMain1 = new System.Windows.Forms.ToolStripSeparator();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorSort = new System.Windows.Forms.ToolStripSeparator();
            this.noSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMain2 = new System.Windows.Forms.ToolStripSeparator();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSelectiontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMain3 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularExpressionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usableTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSearchandReplace = new System.Windows.Forms.Panel();
            this.collapsibleGroupBoxFunction = new Indigo.CollapsibleGroupBox();
            this.labelFunction = new System.Windows.Forms.Label();
            this.inputFunction = new System.Windows.Forms.TextBox();
            this.collabsibleGroupBoxFiles = new Indigo.CollapsibleGroupBox();
            this.labelFileList = new System.Windows.Forms.Label();
            this.listBoxFilelist = new System.Windows.Forms.ListBox();
            this.listBoxPreview = new System.Windows.Forms.ListBox();
            this.labelChanged = new System.Windows.Forms.Label();
            this.contextMenu.SuspendLayout();
            this.panelSearchandReplace.SuspendLayout();
            this.collapsibleGroupBoxFunction.SuspendLayout();
            this.collabsibleGroupBoxFiles.SuspendLayout();
            this.SuspendLayout();
            // 

            // listBoxFilelist
            // 
            this.listBoxFilelist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxFilelist.FormattingEnabled = true;
            this.listBoxFilelist.HorizontalScrollbar = true;
            this.listBoxFilelist.Location = new System.Drawing.Point(13, 36);
            this.listBoxFilelist.Name = "listBoxFilelist";
            this.listBoxFilelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFilelist.Size = new System.Drawing.Size(198, 264);
            this.listBoxFilelist.TabIndex = 0;
            this.listBoxFilelist.Click += new System.EventHandler(this.listBoxFilelist_Click);
            this.listBoxFilelist.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxFilelist_DrawItem);
            this.listBoxFilelist.SelectedIndexChanged += new System.EventHandler(this.listBoxFilelist_SelectedIndexChanged);
            // 
            // inputSearch
            // 
            this.inputSearch.Location = new System.Drawing.Point(19, 26);
            this.inputSearch.Multiline = true;
            this.inputSearch.Name = "inputSearch";
            this.inputSearch.Size = new System.Drawing.Size(252, 20);
            this.inputSearch.TabIndex = 1;
            this.inputSearch.TextChanged += new System.EventHandler(this.inputSearch_TextChanged);
            // 
            // labelRegExp
            // 
            this.labelRegExp.AutoSize = true;
            this.labelRegExp.Location = new System.Drawing.Point(19, 10);
            this.labelRegExp.Name = "labelRegExp";
            this.labelRegExp.Size = new System.Drawing.Size(41, 13);
            this.labelRegExp.TabIndex = 2;
            this.labelRegExp.Text = "Search";
            // 
            // labelReplace
            // 
            this.labelReplace.AutoSize = true;
            this.labelReplace.Location = new System.Drawing.Point(19, 55);
            this.labelReplace.Name = "labelReplace";
            this.labelReplace.Size = new System.Drawing.Size(47, 13);
            this.labelReplace.TabIndex = 5;
            this.labelReplace.Text = "Replace";
            // 
            // inputReplace
            // 
            this.inputReplace.Location = new System.Drawing.Point(19, 71);
            this.inputReplace.Name = "inputReplace";
            this.inputReplace.Size = new System.Drawing.Size(252, 20);
            this.inputReplace.TabIndex = 2;
            this.inputReplace.TextChanged += new System.EventHandler(this.inputReplace_TextChanged);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(310, 67);
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
            this.checkBoxUseRegex.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxUseRegex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBoxUseRegex.Checked = true;
            this.checkBoxUseRegex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseRegex.Location = new System.Drawing.Point(310, 28);
            this.checkBoxUseRegex.Name = "checkBoxUseRegex";
            this.checkBoxUseRegex.Size = new System.Drawing.Size(143, 17);
            this.checkBoxUseRegex.TabIndex = 3;
            this.checkBoxUseRegex.Text = "Use Regular expressions";
            this.checkBoxUseRegex.UseVisualStyleBackColor = false;
            this.checkBoxUseRegex.CheckedChanged += new System.EventHandler(this.checkBoxUseRegex_CheckedChanged);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparatorMain1,
            this.sortToolStripMenuItem,
            this.toolStripSeparatorMain2,
            this.invertSelectionToolStripMenuItem,
            this.clearSelectionToolStripMenuItem,
            this.RemoveSelectiontoolStripMenuItem,
            this.toolStripSeparatorMain3,
            this.helpToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(168, 154);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparatorMain1
            // 
            this.toolStripSeparatorMain1.Name = "toolStripSeparatorMain1";
            this.toolStripSeparatorMain1.Size = new System.Drawing.Size(164, 6);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem,
            this.toolStripSeparatorSort,
            this.noSortToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // ascendingToolStripMenuItem
            // 
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ascendingToolStripMenuItem.Text = "Ascending";
            this.ascendingToolStripMenuItem.Click += new System.EventHandler(this.ascendingToolStripMenuItem_Click);
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.descendingToolStripMenuItem.Text = "Descending";
            this.descendingToolStripMenuItem.Click += new System.EventHandler(this.descendingToolStripMenuItem_Click);
            // 
            // toolStripSeparatorSort
            // 
            this.toolStripSeparatorSort.Name = "toolStripSeparatorSort";
            this.toolStripSeparatorSort.Size = new System.Drawing.Size(133, 6);
            // 
            // noSortToolStripMenuItem
            // 
            this.noSortToolStripMenuItem.Name = "noSortToolStripMenuItem";
            this.noSortToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.noSortToolStripMenuItem.Text = "Reset";
            this.noSortToolStripMenuItem.Click += new System.EventHandler(this.noSortToolStripMenuItem_Click);
            // 
            // toolStripSeparatorMain2
            // 
            this.toolStripSeparatorMain2.Name = "toolStripSeparatorMain2";
            this.toolStripSeparatorMain2.Size = new System.Drawing.Size(164, 6);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            this.invertSelectionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.invertSelectionToolStripMenuItem.Text = "Invert selection";
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // clearSelectionToolStripMenuItem
            // 
            this.clearSelectionToolStripMenuItem.Name = "clearSelectionToolStripMenuItem";
            this.clearSelectionToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.clearSelectionToolStripMenuItem.Text = "Clear selection";
            this.clearSelectionToolStripMenuItem.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem_Click);
            // 
            // RemoveSelectiontoolStripMenuItem
            // 
            this.RemoveSelectiontoolStripMenuItem.Name = "RemoveSelectiontoolStripMenuItem";
            this.RemoveSelectiontoolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.RemoveSelectiontoolStripMenuItem.Text = "Remove selection";
            this.RemoveSelectiontoolStripMenuItem.Click += new System.EventHandler(this.RemoveSelectiontoolStripMenuItem_Click);
            // 
            // toolStripSeparatorMain3
            // 
            this.toolStripSeparatorMain3.Name = "toolStripSeparatorMain3";
            this.toolStripSeparatorMain3.Size = new System.Drawing.Size(164, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularExpressionsToolStripMenuItem,
            this.usableTagsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // regularExpressionsToolStripMenuItem
            // 
            this.regularExpressionsToolStripMenuItem.Name = "regularExpressionsToolStripMenuItem";
            this.regularExpressionsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.regularExpressionsToolStripMenuItem.Text = "Regular expressions";
            this.regularExpressionsToolStripMenuItem.Click += new System.EventHandler(this.regularExpressionsToolStripMenuItem_Click);
            // 
            // usableTagsToolStripMenuItem
            // 
            this.usableTagsToolStripMenuItem.Name = "usableTagsToolStripMenuItem";
            this.usableTagsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.usableTagsToolStripMenuItem.Text = "Usable tags";
            this.usableTagsToolStripMenuItem.Click += new System.EventHandler(this.usableTagsToolStripMenuItem_Click);
            // 
            // panelSearchandReplace
            // 
            this.panelSearchandReplace.Controls.Add(this.checkBoxUseRegex);
            this.panelSearchandReplace.Controls.Add(this.inputSearch);
            this.panelSearchandReplace.Controls.Add(this.labelRegExp);
            this.panelSearchandReplace.Controls.Add(this.buttonRename);
            this.panelSearchandReplace.Controls.Add(this.labelReplace);
            this.panelSearchandReplace.Controls.Add(this.inputReplace);
            this.panelSearchandReplace.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchandReplace.Location = new System.Drawing.Point(0, 0);
            this.panelSearchandReplace.Name = "panelSearchandReplace";
            this.panelSearchandReplace.Size = new System.Drawing.Size(487, 100);
            this.panelSearchandReplace.TabIndex = 10;
            // 
            // collapsibleGroupBoxFunction
            // 
            this.collapsibleGroupBoxFunction.Controls.Add(this.labelFunction);
            this.collapsibleGroupBoxFunction.Controls.Add(this.inputFunction);
            this.collapsibleGroupBoxFunction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsibleGroupBoxFunction.Location = new System.Drawing.Point(0, 108);
            this.collapsibleGroupBoxFunction.Name = "collapsibleGroupBoxFunction";
            this.collapsibleGroupBoxFunction.Size = new System.Drawing.Size(487, 65);
            this.collapsibleGroupBoxFunction.TabIndex = 13;
            this.collapsibleGroupBoxFunction.TabStop = false;
            this.collapsibleGroupBoxFunction.Text = "Function";
            // 
            // labelFunction
            // 
            this.labelFunction.AutoSize = true;
            this.labelFunction.Location = new System.Drawing.Point(16, 16);
            this.labelFunction.Name = "labelFunction";
            this.labelFunction.Size = new System.Drawing.Size(48, 13);
            this.labelFunction.TabIndex = 11;
            this.labelFunction.Text = "Function";
            // 
            // inputFunction
            // 
            this.inputFunction.Location = new System.Drawing.Point(16, 32);
            this.inputFunction.Name = "inputFunction";
            this.inputFunction.Size = new System.Drawing.Size(252, 20);
            this.inputFunction.TabIndex = 10;
            this.inputFunction.TextChanged += new System.EventHandler(this.textBoxFunction_TextChanged);
            // 
            // collabsibleGroupBoxFiles
            // 
            this.collabsibleGroupBoxFiles.Controls.Add(this.labelFileList);
            this.collabsibleGroupBoxFiles.Controls.Add(this.listBoxFilelist);
            this.collabsibleGroupBoxFiles.Controls.Add(this.listBoxPreview);
            this.collabsibleGroupBoxFiles.Controls.Add(this.labelChanged);
            this.collabsibleGroupBoxFiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collabsibleGroupBoxFiles.Location = new System.Drawing.Point(0, 173);
            this.collabsibleGroupBoxFiles.Name = "collabsibleGroupBoxFiles";
            this.collabsibleGroupBoxFiles.Size = new System.Drawing.Size(487, 313);
            this.collabsibleGroupBoxFiles.TabIndex = 12;
            this.collabsibleGroupBoxFiles.TabStop = false;
            this.collabsibleGroupBoxFiles.Text = "Files";
            // 
            // labelFileList
            // 
            this.labelFileList.AutoSize = true;
            this.labelFileList.Location = new System.Drawing.Point(10, 16);
            this.labelFileList.Name = "labelFileList";
            this.labelFileList.Size = new System.Drawing.Size(89, 13);
            this.labelFileList.TabIndex = 3;
            this.labelFileList.Text = "Original filenames";
            // 
            // listBoxFilelist
            // 
            this.listBoxFilelist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxFilelist.FormattingEnabled = true;
            this.listBoxFilelist.HorizontalScrollbar = true;
            this.listBoxFilelist.Location = new System.Drawing.Point(13, 36);
            this.listBoxFilelist.Name = "listBoxFilelist";
            this.listBoxFilelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFilelist.Size = new System.Drawing.Size(198, 264);
            this.listBoxFilelist.TabIndex = 0;
            this.listBoxFilelist.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxFilelist_DrawItem);
            // 
            // listBoxPreview
            // 
            this.listBoxPreview.FormattingEnabled = true;
            this.listBoxPreview.HorizontalScrollbar = true;
            this.listBoxPreview.Location = new System.Drawing.Point(256, 36);
            this.listBoxPreview.Name = "listBoxPreview";
            this.listBoxPreview.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPreview.Size = new System.Drawing.Size(197, 264);
            this.listBoxPreview.TabIndex = 7;
            // 
            // labelChanged
            // 
            this.labelChanged.AutoSize = true;
            this.labelChanged.Location = new System.Drawing.Point(253, 16);
            this.labelChanged.Name = "labelChanged";
            this.labelChanged.Size = new System.Drawing.Size(97, 13);
            this.labelChanged.TabIndex = 8;
            this.labelChanged.Text = "Changed filenames";
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(487, 486);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.panelSearchandReplace);
            this.Controls.Add(this.collapsibleGroupBoxFunction);
            this.Controls.Add(this.collabsibleGroupBoxFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(503, 525);
            this.MinimumSize = new System.Drawing.Size(503, 140);
            this.Name = "MainWindow";
            this.Text = "BatchRenameApp";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxFilelist_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxFilelist_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.contextMenu.ResumeLayout(false);
            this.panelSearchandReplace.ResumeLayout(false);
            this.panelSearchandReplace.PerformLayout();
            this.collapsibleGroupBoxFunction.ResumeLayout(false);
            this.collapsibleGroupBoxFunction.PerformLayout();
            this.collabsibleGroupBoxFiles.ResumeLayout(false);
            this.collabsibleGroupBoxFiles.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorSort;
        private System.Windows.Forms.ToolStripMenuItem ascendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMain3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularExpressionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usableTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMain1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMain2;
        private System.Windows.Forms.ToolStripMenuItem RemoveSelectiontoolStripMenuItem;
        private System.Windows.Forms.Label labelFunction;
        private System.Windows.Forms.TextBox inputFunction;
        private Indigo.CollapsibleGroupBox collabsibleGroupBoxFiles;
        private Indigo.CollapsibleGroupBox collapsibleGroupBoxFunction;
        private System.Windows.Forms.Panel panelSearchandReplace;
    }
}

