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
            this.toolStripSeparatorMainSort = new System.Windows.Forms.ToolStripSeparator();
            this.sortContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMainSelection = new System.Windows.Forms.ToolStripSeparator();
            this.filterSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSelectionContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectionContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorMainSettings = new System.Windows.Forms.ToolStripSeparator();
            this.settingsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorTags = new System.Windows.Forms.ToolStripSeparator();
            this.panelSearchandReplace = new System.Windows.Forms.Panel();
            this.labelFunction = new System.Windows.Forms.Label();
            this.inputFunction = new System.Windows.Forms.TextBox();
            this.linkLabelTags = new System.Windows.Forms.LinkLabel();
            this.linkLabelRegex = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelected = new System.Windows.Forms.Label();
            this.labelMatched = new System.Windows.Forms.Label();
            this.tableLayoutPanelListBoxes = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxPreview = new System.Windows.Forms.ListBox();
            this.labelFileList = new System.Windows.Forms.Label();
            this.labelChanged = new System.Windows.Forms.Label();
            this.listBoxFilelist = new Oli.Controls.DragDropListBox();
            this.contextMenu.SuspendLayout();
            this.panelSearchandReplace.SuspendLayout();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.tableLayoutPanelListBoxes.SuspendLayout();
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
            this.toolStripSeparatorMainSort,
            this.sortContextMenuItem,
            this.toolStripSeparatorMainSelection,
            this.filterSelectionToolStripMenuItem,
            this.invertSelectionContextMenuItem,
            this.clearSelectionContextMenuItem,
            this.removeSelectionContextMenuItem,
            this.toolStripSeparatorMainSettings,
            this.settingsContextMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(171, 198);
            this.contextMenu.Text = "^";
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
            // toolStripSeparatorMainSort
            // 
            this.toolStripSeparatorMainSort.Name = "toolStripSeparatorMainSort";
            this.toolStripSeparatorMainSort.Size = new System.Drawing.Size(167, 6);
            // 
            // sortContextMenuItem
            // 
            this.sortContextMenuItem.Name = "sortContextMenuItem";
            this.sortContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.sortContextMenuItem.Text = "Sort";
            this.sortContextMenuItem.Click += new System.EventHandler(this.SortContextMenuItem_Click);
            // 
            // toolStripSeparatorMainSelection
            // 
            this.toolStripSeparatorMainSelection.Name = "toolStripSeparatorMainSelection";
            this.toolStripSeparatorMainSelection.Size = new System.Drawing.Size(167, 6);
            // 
            // filterSelectionToolStripMenuItem
            // 
            this.filterSelectionToolStripMenuItem.Name = "filterSelectionToolStripMenuItem";
            this.filterSelectionToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.filterSelectionToolStripMenuItem.Text = "Select matched";
            this.filterSelectionToolStripMenuItem.Click += new System.EventHandler(this.FilterSelectionToolStripMenuItem_Click);
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
            // toolStripSeparatorMainSettings
            // 
            this.toolStripSeparatorMainSettings.Name = "toolStripSeparatorMainSettings";
            this.toolStripSeparatorMainSettings.Size = new System.Drawing.Size(167, 6);
            // 
            // settingsContextMenuItem
            // 
            this.settingsContextMenuItem.Name = "settingsContextMenuItem";
            this.settingsContextMenuItem.Size = new System.Drawing.Size(170, 22);
            this.settingsContextMenuItem.Text = "Settings";
            this.settingsContextMenuItem.Click += new System.EventHandler(this.SettingsContextMenuItem_Click);
            // 
            // toolStripSeparatorTags
            // 
            this.toolStripSeparatorTags.Name = "toolStripSeparatorTags";
            this.toolStripSeparatorTags.Size = new System.Drawing.Size(167, 6);
            // 
            // panelSearchandReplace
            // 
            this.panelSearchandReplace.Controls.Add(this.labelFunction);
            this.panelSearchandReplace.Controls.Add(this.inputFunction);
            this.panelSearchandReplace.Controls.Add(this.linkLabelTags);
            this.panelSearchandReplace.Controls.Add(this.linkLabelRegex);
            this.panelSearchandReplace.Controls.Add(this.inputSearch);
            this.panelSearchandReplace.Controls.Add(this.labelRegExp);
            this.panelSearchandReplace.Controls.Add(this.buttonRename);
            this.panelSearchandReplace.Controls.Add(this.labelReplace);
            this.panelSearchandReplace.Controls.Add(this.inputReplace);
            this.panelSearchandReplace.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchandReplace.Location = new System.Drawing.Point(0, 0);
            this.panelSearchandReplace.Name = "panelSearchandReplace";
            this.panelSearchandReplace.Size = new System.Drawing.Size(467, 151);
            this.panelSearchandReplace.TabIndex = 10;
            // 
            // labelFunction
            // 
            this.labelFunction.AutoSize = true;
            this.labelFunction.Location = new System.Drawing.Point(12, 94);
            this.labelFunction.Name = "labelFunction";
            this.labelFunction.Size = new System.Drawing.Size(48, 13);
            this.labelFunction.TabIndex = 13;
            this.labelFunction.Text = "Function";
            // 
            // inputFunction
            // 
            this.inputFunction.Location = new System.Drawing.Point(12, 110);
            this.inputFunction.Name = "inputFunction";
            this.inputFunction.Size = new System.Drawing.Size(338, 20);
            this.inputFunction.TabIndex = 10;
            this.inputFunction.TextChanged += new System.EventHandler(this.TextBoxFunction_TextChanged);
            // 
            // linkLabelTags
            // 
            this.linkLabelTags.AutoSize = true;
            this.linkLabelTags.Location = new System.Drawing.Point(319, 55);
            this.linkLabelTags.Name = "linkLabelTags";
            this.linkLabelTags.Size = new System.Drawing.Size(31, 13);
            this.linkLabelTags.TabIndex = 11;
            this.linkLabelTags.TabStop = true;
            this.linkLabelTags.Text = "Tags";
            this.linkLabelTags.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelTags.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelTags_LinkClicked);
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
            this.linkLabelRegex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelRegex_LinkClicked);
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.ColumnCount = 4;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.09091F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.90909F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanelBottom.Controls.Add(this.labelSelected, 0, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.labelMatched, 0, 0);
            this.tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(0, 468);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(467, 23);
            this.tableLayoutPanelBottom.TabIndex = 14;
            // 
            // labelSelected
            // 
            this.labelSelected.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSelected.AutoSize = true;
            this.labelSelected.Location = new System.Drawing.Point(100, 6);
            this.labelSelected.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelSelected.Name = "labelSelected";
            this.labelSelected.Size = new System.Drawing.Size(52, 13);
            this.labelSelected.TabIndex = 17;
            this.labelSelected.Text = "Selected:";
            // 
            // labelMatched
            // 
            this.labelMatched.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelMatched.AutoSize = true;
            this.labelMatched.Location = new System.Drawing.Point(3, 6);
            this.labelMatched.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.labelMatched.Name = "labelMatched";
            this.labelMatched.Size = new System.Drawing.Size(52, 13);
            this.labelMatched.TabIndex = 16;
            this.labelMatched.Text = "Matched:";
            // 
            // tableLayoutPanelListBoxes
            // 
            this.tableLayoutPanelListBoxes.AutoSize = true;
            this.tableLayoutPanelListBoxes.ColumnCount = 2;
            this.tableLayoutPanelListBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelListBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelListBoxes.Controls.Add(this.listBoxPreview, 1, 1);
            this.tableLayoutPanelListBoxes.Controls.Add(this.listBoxFilelist, 0, 1);
            this.tableLayoutPanelListBoxes.Controls.Add(this.labelFileList, 0, 0);
            this.tableLayoutPanelListBoxes.Controls.Add(this.labelChanged, 1, 0);
            this.tableLayoutPanelListBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelListBoxes.Location = new System.Drawing.Point(0, 151);
            this.tableLayoutPanelListBoxes.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.tableLayoutPanelListBoxes.Name = "tableLayoutPanelListBoxes";
            this.tableLayoutPanelListBoxes.RowCount = 2;
            this.tableLayoutPanelListBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.362776F));
            this.tableLayoutPanelListBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.63722F));
            this.tableLayoutPanelListBoxes.Size = new System.Drawing.Size(467, 317);
            this.tableLayoutPanelListBoxes.TabIndex = 15;
            // 
            // listBoxPreview
            // 
            this.listBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPreview.HorizontalScrollbar = true;
            this.listBoxPreview.Items.AddRange(new object[] {
            ""});
            this.listBoxPreview.Location = new System.Drawing.Point(236, 19);
            this.listBoxPreview.Name = "listBoxPreview";
            this.listBoxPreview.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPreview.Size = new System.Drawing.Size(228, 295);
            this.listBoxPreview.TabIndex = 7;
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
            this.labelChanged.Location = new System.Drawing.Point(236, 0);
            this.labelChanged.Name = "labelChanged";
            this.labelChanged.Size = new System.Drawing.Size(97, 13);
            this.labelChanged.TabIndex = 8;
            this.labelChanged.Text = "Changed filenames";
            // 
            // listBoxFilelist
            // 
            this.listBoxFilelist.AllowDrop = true;
            this.listBoxFilelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFilelist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxFilelist.FormattingEnabled = true;
            this.listBoxFilelist.HorizontalScrollbar = true;
            this.listBoxFilelist.Location = new System.Drawing.Point(3, 19);
            this.listBoxFilelist.Name = "listBoxFilelist";
            this.listBoxFilelist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxFilelist.Size = new System.Drawing.Size(227, 295);
            this.listBoxFilelist.TabIndex = 0;
            this.listBoxFilelist.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxFilelist_DrawItem);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(467, 491);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.tableLayoutPanelListBoxes);
            this.Controls.Add(this.tableLayoutPanelBottom);
            this.Controls.Add(this.panelSearchandReplace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(483, 530);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "BatchRenameApp";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Mainwindow_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.contextMenu.ResumeLayout(false);
            this.panelSearchandReplace.ResumeLayout(false);
            this.panelSearchandReplace.PerformLayout();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            this.tableLayoutPanelListBoxes.ResumeLayout(false);
            this.tableLayoutPanelListBoxes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox inputSearch;
        private System.Windows.Forms.Label labelRegExp;
        private System.Windows.Forms.Label labelReplace;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem sortContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMainSettings;
        private System.Windows.Forms.ToolStripMenuItem undoContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSelectionContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMainSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorMainSelection;
        private System.Windows.Forms.ToolStripMenuItem removeSelectionContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoContextMenuItem;
        private System.Windows.Forms.TextBox inputFunction;
        private System.Windows.Forms.Panel panelSearchandReplace;
        private System.Windows.Forms.ToolStripMenuItem settingsContextMenuItem;
        public System.Windows.Forms.TextBox inputReplace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorTags;
        private System.Windows.Forms.LinkLabel linkLabelRegex;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.Label labelSelected;
        private System.Windows.Forms.Label labelMatched;
        private System.Windows.Forms.LinkLabel linkLabelTags;
        private System.Windows.Forms.Label labelFunction;
        private System.Windows.Forms.ToolStripMenuItem filterSelectionToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelListBoxes;
        public System.Windows.Forms.ListBox listBoxPreview;
        public Oli.Controls.DragDropListBox listBoxFilelist;
        private System.Windows.Forms.Label labelFileList;
        private System.Windows.Forms.Label labelChanged;
    }
}

