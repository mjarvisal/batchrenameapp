﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchRenameApp
{

    public partial class TagsLegend : Form
    {
        private TextBox inputReplace = Program.mainWindowForm.inputReplace;

        public TagsLegend()
        {
            InitializeComponent();
          
            List<Tag> GenericTags = new List<Tag>
            {
              new Tag("%timenow%","Current Time"),
              new Tag("%datenow%","Current Date"),
              new Tag("%fnc%","Function result"),
            };

            List<Tag> fileAttributeTags = new List<Tag>
            {
              new Tag("%file%","File name without extension"),
              new Tag("%ext%","File extension"),
              new Tag("%folder%","Folder name"),
              new Tag("%datecreated%","Date when file was created"),
              new Tag("%timecreated%","Time when file was created"),
            };

            List<Tag> exifTags = new List<Tag>
            {
              new Tag("%exifdate%","Date when picture was taken"),
              new Tag("%exiftime%","Time when picture was taken"),
              new Tag("%loc%","Finds city and country"),
            };

            GenerateTagLines(flowLayoutPanelGeneric, GenericTags);
            GenerateTagLines(flowLayoutPanelFileAttributes, fileAttributeTags);
            GenerateTagLines(flowLayoutPanelExif, exifTags);

        }


        private void GenerateTagLines(FlowLayoutPanel panel, List<Tag> tags)
        {
            int ControllerHeight = 0;
            float FirstColumnSize = 0.33f; 
            foreach (Tag tag in tags)
            {
                LinkLabel link = new LinkLabel();
                link.Text = tag.TagName;
                link.Size = new Size((int)(FirstColumnSize * panel.Size.Width), link.Size.Height);
                link.Click += onClick;

                Label description = new Label();
                //description.Size = TextRenderer.MeasureText(tag.TagDescription, description.Font);
                description.Size = new Size(panel.Size.Width - link.Size.Width - 20, description.Size.Height);
                description.Text = tag.TagDescription;

                panel.Controls.Add(link);
                panel.Controls.Add(description);
                ControllerHeight += link.Height;
            }
            panel.Parent.Size = new Size(panel.Size.Width, ControllerHeight+20);

        }

        public void onClick(object sender, EventArgs e)
        {
            InsertText(((LinkLabel)sender).Text);
        }

        private void InsertText(string text)
        {
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, text);
            inputReplace.SelectionStart = Cursorlocation + text.Length;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

    public class Tag
    {
        public String TagName;
        public String TagDescription;

        public Tag(string Name, string Desc)
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            TagName = Name;
            TagDescription = Desc;
        }
    }
}
