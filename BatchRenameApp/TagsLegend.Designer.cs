namespace BatchRenameApp
{
    partial class TagsLegend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagsLegend));
            this.Taglabeldatenow = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelHelp = new System.Windows.Forms.Label();
            this.Taglabeltimenow = new System.Windows.Forms.Label();
            this.Taglabeldatecreated = new System.Windows.Forms.Label();
            this.Taglabeltimecreated = new System.Windows.Forms.Label();
            this.Taglabeldatetaken = new System.Windows.Forms.Label();
            this.Taglabeltimetaken = new System.Windows.Forms.Label();
            this.Taglabelfolder = new System.Windows.Forms.Label();
            this.Taglabelfile = new System.Windows.Forms.Label();
            this.Taglabelfunction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Taglabeldatenow
            // 
            this.Taglabeldatenow.AutoSize = true;
            this.Taglabeldatenow.Location = new System.Drawing.Point(44, 35);
            this.Taglabeldatenow.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabeldatenow.Name = "Taglabeldatenow";
            this.Taglabeldatenow.Size = new System.Drawing.Size(134, 13);
            this.Taglabeldatenow.TabIndex = 0;
            this.Taglabeldatenow.Text = "%datenow% -- Current date";
            this.Taglabeldatenow.Click += new System.EventHandler(this.Taglabeldatenow_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(197, 225);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(44, 9);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(225, 13);
            this.labelHelp.TabIndex = 2;
            this.labelHelp.Text = "Click the tag to insert it to the Replace textBox";
            // 
            // Taglabeltimenow
            // 
            this.Taglabeltimenow.AutoSize = true;
            this.Taglabeltimenow.Location = new System.Drawing.Point(44, 53);
            this.Taglabeltimenow.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabeltimenow.Name = "Taglabeltimenow";
            this.Taglabeltimenow.Size = new System.Drawing.Size(127, 13);
            this.Taglabeltimenow.TabIndex = 3;
            this.Taglabeltimenow.Text = "%timenow% - Current time";
            this.Taglabeltimenow.Click += new System.EventHandler(this.Taglabeltimenow_Click);
            // 
            // Taglabeldatecreated
            // 
            this.Taglabeldatecreated.AutoSize = true;
            this.Taglabeldatecreated.Location = new System.Drawing.Point(44, 71);
            this.Taglabeldatecreated.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabeldatecreated.Name = "Taglabeldatecreated";
            this.Taglabeldatecreated.Size = new System.Drawing.Size(205, 13);
            this.Taglabeldatecreated.TabIndex = 4;
            this.Taglabeldatecreated.Text = "%datecreated% - date the file was created";
            this.Taglabeldatecreated.Click += new System.EventHandler(this.Taglabeldatecreated_Click);
            // 
            // Taglabeltimecreated
            // 
            this.Taglabeltimecreated.AutoSize = true;
            this.Taglabeltimecreated.Location = new System.Drawing.Point(44, 90);
            this.Taglabeltimecreated.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabeltimecreated.Name = "Taglabeltimecreated";
            this.Taglabeltimecreated.Size = new System.Drawing.Size(201, 13);
            this.Taglabeltimecreated.TabIndex = 6;
            this.Taglabeltimecreated.Text = "%timecreated% - time the file was created";
            this.Taglabeltimecreated.Click += new System.EventHandler(this.Taglabeltimecreated_Click);
            // 
            // Taglabeldatetaken
            // 
            this.Taglabeldatetaken.AutoSize = true;
            this.Taglabeldatetaken.Location = new System.Drawing.Point(44, 108);
            this.Taglabeldatetaken.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabeldatetaken.Name = "Taglabeldatetaken";
            this.Taglabeldatetaken.Size = new System.Drawing.Size(206, 13);
            this.Taglabeldatetaken.TabIndex = 5;
            this.Taglabeldatetaken.Text = "%datetaken% - date the picture was taken";
            this.Taglabeldatetaken.Click += new System.EventHandler(this.Taglabeldatetaken_Click);
            // 
            // Taglabeltimetaken
            // 
            this.Taglabeltimetaken.AutoSize = true;
            this.Taglabeltimetaken.Location = new System.Drawing.Point(44, 126);
            this.Taglabeltimetaken.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabeltimetaken.Name = "Taglabeltimetaken";
            this.Taglabeltimetaken.Size = new System.Drawing.Size(202, 13);
            this.Taglabeltimetaken.TabIndex = 10;
            this.Taglabeltimetaken.Text = "%timetaken% - time the picture was taken";
            this.Taglabeltimetaken.Click += new System.EventHandler(this.Taglabeltimetaken_Click);
            // 
            // Taglabelfolder
            // 
            this.Taglabelfolder.AutoSize = true;
            this.Taglabelfolder.Location = new System.Drawing.Point(44, 162);
            this.Taglabelfolder.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabelfolder.Name = "Taglabelfolder";
            this.Taglabelfolder.Size = new System.Drawing.Size(116, 13);
            this.Taglabelfolder.TabIndex = 9;
            this.Taglabelfolder.Text = "%folder% - Folder name";
            this.Taglabelfolder.Click += new System.EventHandler(this.Taglabelfolder_Click);
            // 
            // Taglabelfile
            // 
            this.Taglabelfile.AutoSize = true;
            this.Taglabelfile.Location = new System.Drawing.Point(44, 144);
            this.Taglabelfile.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabelfile.Name = "Taglabelfile";
            this.Taglabelfile.Size = new System.Drawing.Size(90, 13);
            this.Taglabelfile.TabIndex = 8;
            this.Taglabelfile.Text = "%file% - File name";
            this.Taglabelfile.Click += new System.EventHandler(this.Taglabelfile_Click);
            // 
            // Taglabelfunction
            // 
            this.Taglabelfunction.AutoSize = true;
            this.Taglabelfunction.Location = new System.Drawing.Point(44, 180);
            this.Taglabelfunction.Margin = new System.Windows.Forms.Padding(20, 5, 3, 0);
            this.Taglabelfunction.Name = "Taglabelfunction";
            this.Taglabelfunction.Size = new System.Drawing.Size(116, 13);
            this.Taglabelfunction.TabIndex = 7;
            this.Taglabelfunction.Text = "%fnc% - Function result";
            this.Taglabelfunction.Click += new System.EventHandler(this.Taglabelfunction_Click);
            // 
            // TagsLegend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 260);
            this.Controls.Add(this.Taglabeltimetaken);
            this.Controls.Add(this.Taglabelfolder);
            this.Controls.Add(this.Taglabelfile);
            this.Controls.Add(this.Taglabelfunction);
            this.Controls.Add(this.Taglabeltimecreated);
            this.Controls.Add(this.Taglabeldatetaken);
            this.Controls.Add(this.Taglabeldatecreated);
            this.Controls.Add(this.Taglabeltimenow);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.Taglabeldatenow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TagsLegend";
            this.Text = "Tags legend";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Taglabeldatenow;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Label Taglabeltimenow;
        private System.Windows.Forms.Label Taglabeldatecreated;
        private System.Windows.Forms.Label Taglabeltimecreated;
        private System.Windows.Forms.Label Taglabeldatetaken;
        private System.Windows.Forms.Label Taglabeltimetaken;
        private System.Windows.Forms.Label Taglabelfolder;
        private System.Windows.Forms.Label Taglabelfile;
        private System.Windows.Forms.Label Taglabelfunction;
    }
}