namespace BatchRenameApp
{
    partial class SortFilterForm
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
            this.buttonSortAsc = new System.Windows.Forms.Button();
            this.buttonSortDesc = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonSelectFiltered = new System.Windows.Forms.Button();
            this.DropdownSelect = new System.Windows.Forms.ComboBox();
            this.buttonClearSelection = new System.Windows.Forms.Button();
            this.labelSort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSortAsc
            // 
            this.buttonSortAsc.Location = new System.Drawing.Point(182, 99);
            this.buttonSortAsc.Name = "buttonSortAsc";
            this.buttonSortAsc.Size = new System.Drawing.Size(99, 23);
            this.buttonSortAsc.TabIndex = 0;
            this.buttonSortAsc.Text = "Sort Asc";
            this.buttonSortAsc.UseVisualStyleBackColor = true;
            this.buttonSortAsc.Click += new System.EventHandler(this.ButtonSortAsc_Click);
            // 
            // buttonSortDesc
            // 
            this.buttonSortDesc.Location = new System.Drawing.Point(182, 128);
            this.buttonSortDesc.Name = "buttonSortDesc";
            this.buttonSortDesc.Size = new System.Drawing.Size(99, 23);
            this.buttonSortDesc.TabIndex = 1;
            this.buttonSortDesc.Text = "Sort Desc";
            this.buttonSortDesc.UseVisualStyleBackColor = true;
            this.buttonSortDesc.Click += new System.EventHandler(this.ButtonSortDesc_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(12, 39);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(161, 20);
            this.textBoxFilter.TabIndex = 2;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.TextBoxFilter_TextChanged);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(12, 20);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(29, 13);
            this.labelFilter.TabIndex = 3;
            this.labelFilter.Text = "Filter";
            // 
            // buttonSelectFiltered
            // 
            this.buttonSelectFiltered.Location = new System.Drawing.Point(182, 36);
            this.buttonSelectFiltered.Name = "buttonSelectFiltered";
            this.buttonSelectFiltered.Size = new System.Drawing.Size(99, 23);
            this.buttonSelectFiltered.TabIndex = 5;
            this.buttonSelectFiltered.Text = "Select Filtered";
            this.buttonSelectFiltered.UseVisualStyleBackColor = true;
            this.buttonSelectFiltered.Click += new System.EventHandler(this.ButtonSelectFiltered_Click);
            // 
            // DropdownSelect
            // 
            this.DropdownSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropdownSelect.Items.AddRange(new object[] {
            "All",
            "Selection"});
            this.DropdownSelect.Location = new System.Drawing.Point(15, 128);
            this.DropdownSelect.Name = "DropdownSelect";
            this.DropdownSelect.Size = new System.Drawing.Size(161, 21);
            this.DropdownSelect.TabIndex = 6;
            this.DropdownSelect.SelectedIndexChanged += new System.EventHandler(this.DropdownBox_SelectedIndexChanged);
            // 
            // buttonClearSelection
            // 
            this.buttonClearSelection.Location = new System.Drawing.Point(182, 7);
            this.buttonClearSelection.Name = "buttonClearSelection";
            this.buttonClearSelection.Size = new System.Drawing.Size(99, 23);
            this.buttonClearSelection.TabIndex = 7;
            this.buttonClearSelection.Text = "Clear Selection";
            this.buttonClearSelection.UseVisualStyleBackColor = true;
            this.buttonClearSelection.Click += new System.EventHandler(this.ButtonClearSelection_Click);
            // 
            // labelSort
            // 
            this.labelSort.AutoSize = true;
            this.labelSort.Location = new System.Drawing.Point(12, 112);
            this.labelSort.Name = "labelSort";
            this.labelSort.Size = new System.Drawing.Size(88, 13);
            this.labelSort.TabIndex = 8;
            this.labelSort.Text = "Do sort based on";
            // 
            // SortFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 163);
            this.Controls.Add(this.labelSort);
            this.Controls.Add(this.buttonClearSelection);
            this.Controls.Add(this.DropdownSelect);
            this.Controls.Add(this.buttonSelectFiltered);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.buttonSortDesc);
            this.Controls.Add(this.buttonSortAsc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SortFilterForm";
            this.Text = "Sort helper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SortFilterForm_FormClosed);
            this.Load += new System.EventHandler(this.FormSortFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSortAsc;
        private System.Windows.Forms.Button buttonSortDesc;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Button buttonSelectFiltered;
        private System.Windows.Forms.ComboBox DropdownSelect;
        private System.Windows.Forms.Button buttonClearSelection;
        private System.Windows.Forms.Label labelSort;
    }
}