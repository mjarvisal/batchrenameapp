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
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TagsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMain1 = new System.Windows.Forms.ToolStripSeparator();
            this.sortContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMain2 = new System.Windows.Forms.ToolStripSeparator();
            this.invertSelectionContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSelectionContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectionContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMain3 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularExpressionsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSearchandReplace = new System.Windows.Forms.Panel();
            this.linkLabelRegex = new System.Windows.Forms.LinkLabel();
            this.collabsibleGroupBoxFiles = new Indigo.CollapsibleGroupBox();
            this.statusStripProgress = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelProcessing = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxPreview = new System.Windows.Forms.ListBox();
            this.listBoxFilelist = new Oli.Controls.DragDropListBox();
            this.labelFileList = new System.Windows.Forms.Label();
            this.labelChanged = new System.Windows.Forms.Label();
            this.collapsibleGroupBoxFunction = new Indigo.CollapsibleGroupBox();
            this.inputFunction = new System.Windows.Forms.TextBox();
            this.contextMenu.SuspendLayout();
            this.panelSearchandReplace.SuspendLayout();
            this.collabsibleGroupBoxFiles.SuspendLayout();
            this.statusStripProgress.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.collapsibleGroupBoxFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputSearch
            // 
            this.inputSearch.Location = new System.Drawing.Point(13, 29);
            this.inputSearch.Multiline = true;
            this.inputSearch.Name = "inputSearch";
            this.inputSearch.Size = new System.Drawing.Size(337, 20);
            this.inputSearch.TabIndex = 1;
            this.inputSearch.Text = "^";
            this.inputSearch.TextChanged += new System.EventHandler(this.InputSearch_TextChanged);
            // 
            // labelRegExp
            // 
            this.labelRegExp.AutoSize = true;
            this.labelRegExp.Location = new System.Drawing.Point(12, 13);
            this.labelRegExp.Name = "labelRegExp";
            this.labelRegExp.Size = new System.Drawing.Size(41, 13);
            this.labelRegExp.TabIndex = 2;
            this.labelRegExp.Text = "Search";
            // 
            // labelReplace
            // 
            this.labelReplace.AutoSize = true;
            this.labelReplace.Location = new System.Drawing.Point(12, 55);
            this.labelReplace.Name = "labelReplace";
            this.labelReplace.Size = new System.Drawing.Size(47, 13);
            this.labelReplace.TabIndex = 5;
            this.labelReplace.Text = "Replace";
            // 
            // inputReplace
            // 
            this.inputReplace.Location = new System.Drawing.Point(13, 71);
            this.inputReplace.Name = "inputReplace";
            this.inputReplace.Size = new System.Drawing.Size(337, 20);
            this.inputReplace.TabIndex = 2;
            this.inputReplace.TextChanged += new System.EventHandler(this.InputReplace_TextChanged);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(378, 71);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 23);
            this.buttonRename.TabIndex = 9;
            this.buttonRename.Text = "Rename!";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoContextMenuItem,
            this.redoContextMenuItem,
            this.toolStripSeparator1,
            this.TagsContextMenuItem,
            this.toolStripSeparatorMain1,
            this.sortContextMenuItem,
            this.toolStripSeparatorMain2,
            this.invertSelectionContextMenuItem,
            this.clearSelectionContextMenuItem,
            this.removeSelectionContextMenuItem,
            this.toolStripSeparatorMain3,
            this.settingsContextMenuItem,
            this.helpContextMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(171, 248);
            // 
            // undoContextMenuItem
            // 
            this.undoContextMenuItem.Name = "undoContextMenuItem";
            this.undoContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.undoContextMenuItem.Text = "Undo";
            this.undoContextMenuItem.Click += new System.EventHandler(this.UndoContextMenuItem_Click);
            // 
            // redoContextMenuItem
            // 
            this.redoContextMenuItem.Name = "redoContextMenuItem";
            this.redoContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.redoContextMenuItem.Text = "Redo";
            this.redoContextMenuItem.Click += new System.EventHandler(this.RedoContextMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // TagsContextMenuItem
            // 
            this.TagsContextMenuItem.Name = "TagsContextMenuItem";
            this.TagsContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.TagsContextMenuItem.Text = "Tags";
            this.TagsContextMenuItem.Click += new System.EventHandler(this.TagsContextMenuItem_Click);
            // 
            // toolStripSeparatorMain1
            // 
            this.toolStripSeparatorMain1.Name = "toolStripSeparatorMain1";
            this.toolStripSeparatorMain1.Size = new System.Drawing.Size(167, 6);
            // 
            // sortContextMenuItem
            // 
            this.sortContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascendingContextMenuItem,
            this.descendingContextMenuItem});
            this.sortContextMenuItem.Name = "sortContextMenuItem";
            this.sortContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.sortContextMenuItem.Text = "Sort";
            // 
            // ascendingContextMenuItem
            // 
            this.ascendingContextMenuItem.Name = "ascendingContextMenuItem";
            this.ascendingContextMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ascendingContextMenuItem.Text = "Ascending";
            this.ascendingContextMenuItem.Click += new System.EventHandler(this.AscendingContextMenuItem_Click);
            // 
            // descendingContextMenuItem
            // 
            this.descendingContextMenuItem.Name = "descendingContextMenuItem";
            this.descendingContextMenuItem.Size = new System.Drawing.Size(136, 22);
            this.descendingContextMenuItem.Text = "Descending";
            this.descendingContextMenuItem.Click += new System.EventHandler(this.DescendingContextMenuItem_Click);
            // 
            // toolStripSeparatorMain2
            // 
            this.toolStripSeparatorMain2.Name = "toolStripSeparatorMain2";
            this.toolStripSeparatorMain2.Size = new System.Drawing.Size(167, 6);
            // 
            // invertSelectionContextMenuItem
            // 
            this.invertSelectionContextMenuItem.Name = "invertSelectionContextMenuItem";
            this.invertSelectionContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.invertSelectionContextMenuItem.Text = "Invert selection";
            this.invertSelectionContextMenuItem.Click += new System.EventHandler(this.InvertSelectionContextMenuItem_Click);
            // 
            // clearSelectionContextMenuItem
            // 
            this.clearSelectionContextMenuItem.Name = "clearSelectionContextMenuItem";
            this.clearSelectionContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.clearSelectionContextMenuItem.Text = "Clear selection";
            this.clearSelectionContextMenuItem.Click += new System.EventHandler(this.ClearSelectionContextMenuItem_Click);
            // 
            // removeSelectionContextMenuItem
            // 
            this.removeSelectionContextMenuItem.Name = "removeSelectionContextMenuItem";
            this.removeSelectionContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.removeSelectionContextMenuItem.Text = "Remove selected items";
            this.removeSelectionContextMenuItem.Click += new System.EventHandler(this.RemoveSelectionContextMenuItem_Click);
            // 
            // toolStripSeparatorMain3
            // 
            this.toolStripSeparatorMain3.Name = "toolStripSeparatorMain3";
            this.toolStripSeparatorMain3.Size = new System.Drawing.Size(167, 6);
            // 
            // settingsContextMenuItem
            // 
            this.settingsContextMenuItem.Name = "settingsContextMenuItem";
            this.settingsContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.settingsContextMenuItem.Text = "Settings";
            this.settingsContextMenuItem.Click += new System.EventHandler(this.SettingsContextMenuItem_Click);
            // 
            // helpContextMenuItem
            // 
            this.helpContextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.regularExpressionsContextMenuItem});
            this.helpContextMenuItem.Name = "helpContextMenuItem";
            this.helpContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.helpContextMenuItem.Text = "Help";
            // 
            // regularExpressionsContextMenuItem
            // 
            this.regularExpressionsContextMenuItem.Name = "regularExpressionsContextMenuItem";
            this.regularExpressionsContextMenuItem.Size = new System.Drawing.Size(177, 22);
            this.regularExpressionsContextMenuItem.Text = "Regular expressions";
            this.regularExpressionsContextMenuItem.Click += new System.EventHandler(this.RegularExpressionsContextMenuItem_Click);
            // 
            // panelSearchandReplace
            // 
            this.panelSearchandReplace.Controls.Add(this.linkLabelRegex);
            this.panelSearchandReplace.Controls.Add(this.inputSearch);
            this.panelSearchandReplace.Controls.Add(this.labelRegExp);
            this.panelSearchandReplace.Controls.Add(this.buttonRename);
            this.panelSearchandReplace.Controls.Add(this.labelReplace);
            this.panelSearchandReplace.Controls.Add(this.inputReplace);
            this.panelSearchandReplace.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchandReplace.Location = new System.Drawing.Point(0, 0);
            this.panelSearchandReplace.Name = "panelSearchandReplace";
            this.panelSearchandReplace.Size = new System.Drawing.Size(467, 103);
            this.panelSearchandReplace.TabIndex = 10;
            // 
            // linkLabelRegex
            // 
            this.linkLabelRegex.AutoSize = true;
            this.linkLabelRegex.Location = new System.Drawing.Point(190, 13);
            this.linkLabelRegex.Name = "linkLabelRegex";
            this.linkLabelRegex.Size = new System.Drawing.Size(160, 13);
            this.linkLabelRegex.TabIndex = 10;
            this.linkLabelRegex.TabStop = true;
            this.linkLabelRegex.Text = "How to use Regular Expressions";
            this.linkLabelRegex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegex_LinkClicked);
            // 
            // collabsibleGroupBoxFiles
            // 
            this.collabsibleGroupBoxFiles.Controls.Add(this.statusStripProgress);
            this.collabsibleGroupBoxFiles.Controls.Add(this.tableLayoutPanel1);
            this.collabsibleGroupBoxFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.collabsibleGroupBoxFiles.Location = new System.Drawing.Point(0, 156);
            this.collabsibleGroupBoxFiles.Name = "collabsibleGroupBoxFiles";
            this.collabsibleGroupBoxFiles.Size = new System.Drawing.Size(467, 329);
            this.collabsibleGroupBoxFiles.TabIndex = 12;
            this.collabsibleGroupBoxFiles.TabStop = false;
            this.collabsibleGroupBoxFiles.Text = "Files";
            // 
            // statusStripProgress
            // 
            this.statusStripProgress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statusStripProgress.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.statusStripProgress.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabelProcessing});
            this.statusStripProgress.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStripProgress.Location = new System.Drawing.Point(3, 304);
            this.statusStripProgress.Name = "statusStripProgress";
            this.statusStripProgress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripProgress.Size = new System.Drawing.Size(461, 22);
            this.statusStripProgress.SizingGrip = false;
            this.statusStripProgress.TabIndex = 9;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Margin = new System.Windows.Forms.Padding(1, 3, 13, 3);
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripProgressBar.RightToLeftLayout = true;
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabelProcessing
            // 
            this.toolStripStatusLabelProcessing.Name = "toolStripStatusLabelProcessing";
            this.toolStripStatusLabelProcessing.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabelProcessing.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelProcessing.Text = "Ready";
            this.toolStripStatusLabelProcessing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxPreview, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBoxFilelist, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelFileList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelChanged, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.782313F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.21769F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 293);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // listBoxPreview
            // 
            this.listBoxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPreview.FormattingEnabled = true;
            this.listBoxPreview.HorizontalScrollbar = true;
            this.listBoxPreview.Location = new System.Drawing.Point(223, 19);
            this.listBoxPreview.Name = "listBoxPreview";
            this.listBoxPreview.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPreview.Size = new System.Drawing.Size(215, 264);
            this.listBoxPreview.TabIndex = 7;
            // 
            // listBoxFilelist
            // 
            this.listBoxFilelist.AllowDrop = true;
            this.listBoxFilelist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxFilelist.FormattingEnabled = true;
            this.listBoxFilelist.HorizontalScrollbar = true;
            this.listBoxFilelist.Location = new System.Drawing.Point(3, 19);
            this.listBoxFilelist.Name = "listBoxFilelist";
            this.listBoxFilelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFilelist.Size = new System.Drawing.Size(214, 264);
            this.listBoxFilelist.TabIndex = 0;
            this.listBoxFilelist.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxFilelist_DrawItem);
            // 
            // labelFileList
            // 
            this.labelFileList.AutoSize = true;
            this.labelFileList.Location = new System.Drawing.Point(3, 0);
            this.labelFileList.Name = "labelFileList";
            this.labelFileList.Size = new System.Drawing.Size(89, 13);
            this.labelFileList.TabIndex = 3;
            this.labelFileList.Text = "Original filenames";
            // 
            // labelChanged
            // 
            this.labelChanged.AutoSize = true;
            this.labelChanged.Location = new System.Drawing.Point(223, 0);
            this.labelChanged.Name = "labelChanged";
            this.labelChanged.Size = new System.Drawing.Size(97, 13);
            this.labelChanged.TabIndex = 8;
            this.labelChanged.Text = "Changed filenames";
            // 
            // collapsibleGroupBoxFunction
            // 
            this.collapsibleGroupBoxFunction.Controls.Add(this.inputFunction);
            this.collapsibleGroupBoxFunction.Dock = System.Windows.Forms.DockStyle.Top;
            this.collapsibleGroupBoxFunction.Location = new System.Drawing.Point(0, 103);
            this.collapsibleGroupBoxFunction.Name = "collapsibleGroupBoxFunction";
            this.collapsibleGroupBoxFunction.Size = new System.Drawing.Size(467, 53);
            this.collapsibleGroupBoxFunction.TabIndex = 13;
            this.collapsibleGroupBoxFunction.TabStop = false;
            this.collapsibleGroupBoxFunction.Text = "Function";
            // 
            // inputFunction
            // 
            this.inputFunction.Location = new System.Drawing.Point(13, 19);
            this.inputFunction.Name = "inputFunction";
            this.inputFunction.Size = new System.Drawing.Size(337, 20);
            this.inputFunction.TabIndex = 10;
            this.inputFunction.TextChanged += new System.EventHandler(this.TextBoxFunction_TextChanged);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(467, 651);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.collabsibleGroupBoxFiles);
            this.Controls.Add(this.collapsibleGroupBoxFunction);
            this.Controls.Add(this.panelSearchandReplace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(483, 140);
            this.Name = "MainWindow";
            this.Text = "BatchRenameApp";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Mainwindow_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.contextMenu.ResumeLayout(false);
            this.panelSearchandReplace.ResumeLayout(false);
            this.panelSearchandReplace.PerformLayout();
            this.collabsibleGroupBoxFiles.ResumeLayout(false);
            this.collabsibleGroupBoxFiles.PerformLayout();
            this.statusStripProgress.ResumeLayout(false);
            this.statusStripProgress.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.collapsibleGroupBoxFunction.ResumeLayout(false);
            this.collapsibleGroupBoxFunction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox inputSearch;
        private System.Windows.Forms.Label labelRegExp;
        private System.Windows.Forms.Label labelReplace;
        public System.Windows.Forms.ListBox listBoxPreview;
        private System.Windows.Forms.Label labelFileList;
        private System.Windows.Forms.Label labelChanged;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem sortContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ascendingContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendingContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMain3;
        private System.Windows.Forms.ToolStripMenuItem helpContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularExpressionsContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSelectionContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMain1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMain2;
        private System.Windows.Forms.ToolStripMenuItem removeSelectionContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoContextMenuItem;
        private System.Windows.Forms.TextBox inputFunction;
        private Indigo.CollapsibleGroupBox collabsibleGroupBoxFiles;
        private Indigo.CollapsibleGroupBox collapsibleGroupBoxFunction;
        private System.Windows.Forms.Panel panelSearchandReplace;
        public Oli.Controls.DragDropListBox listBoxFilelist;
        private System.Windows.Forms.ToolStripMenuItem settingsContextMenuItem;
        public System.Windows.Forms.TextBox inputReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TagsContextMenuItem;
        private System.Windows.Forms.LinkLabel linkLabelRegex;
        private System.Windows.Forms.StatusStrip statusStripProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelProcessing;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

