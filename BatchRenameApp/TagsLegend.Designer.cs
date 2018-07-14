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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelHelp = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelGeneric = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelExif = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelFileAttributes = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelHelp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 37);
            this.panel1.TabIndex = 1;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(197, 251);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Location = new System.Drawing.Point(51, 12);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(225, 13);
            this.labelHelp.TabIndex = 2;
            this.labelHelp.Text = "Click the tag to insert it to the Replace textBox";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanelGeneric);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(301, 109);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generic Tags";
            // 
            // flowLayoutPanelGeneric
            // 
            this.flowLayoutPanelGeneric.AutoSize = true;
            this.flowLayoutPanelGeneric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelGeneric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelGeneric.Location = new System.Drawing.Point(10, 16);
            this.flowLayoutPanelGeneric.Name = "flowLayoutPanelGeneric";
            this.flowLayoutPanelGeneric.Size = new System.Drawing.Size(288, 90);
            this.flowLayoutPanelGeneric.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanelExif);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 255);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(301, 109);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Exif Tags";
            // 
            // flowLayoutPanelExif
            // 
            this.flowLayoutPanelExif.AutoSize = true;
            this.flowLayoutPanelExif.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelExif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelExif.Location = new System.Drawing.Point(10, 16);
            this.flowLayoutPanelExif.Name = "flowLayoutPanelExif";
            this.flowLayoutPanelExif.Size = new System.Drawing.Size(288, 90);
            this.flowLayoutPanelExif.TabIndex = 12;
            // 
            // flowLayoutPanelFileAttributes
            // 
            this.flowLayoutPanelFileAttributes.AutoSize = true;
            this.flowLayoutPanelFileAttributes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelFileAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFileAttributes.Location = new System.Drawing.Point(10, 16);
            this.flowLayoutPanelFileAttributes.Name = "flowLayoutPanelFileAttributes";
            this.flowLayoutPanelFileAttributes.Size = new System.Drawing.Size(288, 90);
            this.flowLayoutPanelFileAttributes.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanelFileAttributes);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(301, 109);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Attribute Tags";
            // 
            // TagsLegend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(301, 364);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(317, 403);
            this.Name = "TagsLegend";
            this.ShowInTaskbar = false;
            this.Text = "Tags legend";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGeneric;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelExif;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFileAttributes;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}