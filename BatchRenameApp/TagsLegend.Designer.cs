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
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelHelp = new System.Windows.Forms.Label();
            this.groupBoxGenerig = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelGeneric = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxExif = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelExif = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelFileAttributes = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxFileAttributes = new System.Windows.Forms.GroupBox();
            this.panelTop.SuspendLayout();
            this.groupBoxGenerig.SuspendLayout();
            this.groupBoxExif.SuspendLayout();
            this.groupBoxFileAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelHelp);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(468, 37);
            this.panelTop.TabIndex = 1;
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
            // groupBoxGenerig
            // 
            this.groupBoxGenerig.Controls.Add(this.flowLayoutPanelGeneric);
            this.groupBoxGenerig.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxGenerig.Location = new System.Drawing.Point(0, 37);
            this.groupBoxGenerig.Name = "groupBoxGenerig";
            this.groupBoxGenerig.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBoxGenerig.Size = new System.Drawing.Size(468, 109);
            this.groupBoxGenerig.TabIndex = 14;
            this.groupBoxGenerig.TabStop = false;
            this.groupBoxGenerig.Text = "Generic Tags";
            // 
            // flowLayoutPanelGeneric
            // 
            this.flowLayoutPanelGeneric.AutoSize = true;
            this.flowLayoutPanelGeneric.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelGeneric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelGeneric.Location = new System.Drawing.Point(10, 16);
            this.flowLayoutPanelGeneric.Name = "flowLayoutPanelGeneric";
            this.flowLayoutPanelGeneric.Size = new System.Drawing.Size(455, 90);
            this.flowLayoutPanelGeneric.TabIndex = 12;
            // 
            // groupBoxExif
            // 
            this.groupBoxExif.Controls.Add(this.flowLayoutPanelExif);
            this.groupBoxExif.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxExif.Location = new System.Drawing.Point(0, 255);
            this.groupBoxExif.Name = "groupBoxExif";
            this.groupBoxExif.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBoxExif.Size = new System.Drawing.Size(468, 419);
            this.groupBoxExif.TabIndex = 15;
            this.groupBoxExif.TabStop = false;
            this.groupBoxExif.Text = "Exif Tags";
            // 
            // flowLayoutPanelExif
            // 
            this.flowLayoutPanelExif.AutoScroll = true;
            this.flowLayoutPanelExif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelExif.Location = new System.Drawing.Point(10, 16);
            this.flowLayoutPanelExif.Name = "flowLayoutPanelExif";
            this.flowLayoutPanelExif.Size = new System.Drawing.Size(455, 400);
            this.flowLayoutPanelExif.TabIndex = 12;
            // 
            // flowLayoutPanelFileAttributes
            // 
            this.flowLayoutPanelFileAttributes.AutoSize = true;
            this.flowLayoutPanelFileAttributes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelFileAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFileAttributes.Location = new System.Drawing.Point(10, 16);
            this.flowLayoutPanelFileAttributes.Name = "flowLayoutPanelFileAttributes";
            this.flowLayoutPanelFileAttributes.Size = new System.Drawing.Size(455, 90);
            this.flowLayoutPanelFileAttributes.TabIndex = 12;
            // 
            // groupBoxFileAttributes
            // 
            this.groupBoxFileAttributes.Controls.Add(this.flowLayoutPanelFileAttributes);
            this.groupBoxFileAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxFileAttributes.Location = new System.Drawing.Point(0, 146);
            this.groupBoxFileAttributes.Name = "groupBoxFileAttributes";
            this.groupBoxFileAttributes.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.groupBoxFileAttributes.Size = new System.Drawing.Size(468, 109);
            this.groupBoxFileAttributes.TabIndex = 13;
            this.groupBoxFileAttributes.TabStop = false;
            this.groupBoxFileAttributes.Text = "File Attribute Tags";
            // 
            // TagsLegend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(468, 674);
            this.Controls.Add(this.groupBoxExif);
            this.Controls.Add(this.groupBoxFileAttributes);
            this.Controls.Add(this.groupBoxGenerig);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(317, 403);
            this.Name = "TagsLegend";
            this.ShowInTaskbar = false;
            this.Text = "Tags legend";
            this.Load += new System.EventHandler(this.TagsLegend_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.groupBoxGenerig.ResumeLayout(false);
            this.groupBoxGenerig.PerformLayout();
            this.groupBoxExif.ResumeLayout(false);
            this.groupBoxFileAttributes.ResumeLayout(false);
            this.groupBoxFileAttributes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.GroupBox groupBoxGenerig;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelGeneric;
        private System.Windows.Forms.GroupBox groupBoxExif;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelExif;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFileAttributes;
        private System.Windows.Forms.GroupBox groupBoxFileAttributes;
    }
}