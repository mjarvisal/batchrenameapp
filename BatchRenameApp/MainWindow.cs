using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace BatchRenameApp
{
    public partial class MainWindow : Form
    {

        string[] args;
        HashSet<FileInfo> files = new HashSet<FileInfo>();
        bool bInputfilesChanged = false;

        public MainWindow()
        {
            InitializeComponent();
            files.Clear();
            int errors = 0;
            Exception outException = null;

            foreach (string item in GetArgs())
            {
                try
                {
                    AddFile(item);
                }
                catch (Exception e)
                {
                    errors += 1;
                    outException = e;
                }
            }

            if (errors > 0)
            {
                MessageBox.Show(outException.Message, errors + " Errors", MessageBoxButtons.OK);
            }


        }

        private string[] GetArgs()
        {
            args = Environment.GetCommandLineArgs();
            args = args.Skip(1).ToArray();
            return args;
        }

        private void AddFile(string filename)
        {
            FileInfo file = new FileInfo(filename);
            if (!file.Exists)
            {
                throw new Exception("file '" + file.Name + "' doesn't exists!");
            }

            else if (file.Attributes.HasFlag(FileAttributes.Directory))
            {
                throw new Exception("item is directory");
            }

            // check for duplicates
            foreach (FileInfo tmpFile in files)
            {
                if (tmpFile.FullName == file.FullName)
                {
                    return;
                }
            }
            // if no duplicates, add file to list

            files.Add(file);
            listBoxFilelist.Items.Add(file);
            bInputfilesChanged = true;
        }

        private void RemoveFile(string filename)
        {
            FileInfo file = new FileInfo(filename);
            int x = 0;
            foreach (FileInfo item in listBoxFilelist.Items)
            {
                if (file.FullName == item.FullName)
                {
                    listBoxFilelist.Items.Remove(item);
                    files.Remove(item);
                    bInputfilesChanged = true;
                    return;
                }
                x += 1;
            }
        }

        private void listBoxFilelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void listBoxFilelist_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            int errors = 0;
            Exception outException = null;
            foreach (string file in files)
            {
                try
                {
                    AddFile(file);
                }
                catch (Exception ex)
                {
                    errors += 1;
                    outException = ex;
                }
            }

            if (errors > 0)
            {
                MessageBox.Show(outException.Message, errors + " Errors", MessageBoxButtons.OK);
            }

            UpdatePreview();
        }

        private void listBoxFilelist_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void listBoxFilelist_DoubleClick(object sender, EventArgs e)
        {
            ListBox listbox = (ListBox)sender;

            if (listbox.SelectedItem != null)
            {
                RemoveFile(listbox.SelectedItem.ToString());
                UpdatePreview();
            }

        }

        private void UpdatePreview()
        {
            listBoxPreview.Items.Clear();

            if (inputSearch.Text.Length > 0)
            {
                foreach (FileInfo file in files)
                {
                    try
                    {
                        Regex regex = new Regex(inputSearch.Text);
                        listBoxPreview.Items.Add(file.DirectoryName + "\\" + regex.Replace(file.Name, inputReplace.Text));
                    }
                    catch (ArgumentException)
                    {
                        listBoxPreview.Items.Add(file.FullName);
                    }
                }
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (listBoxPreview.Items.Count == 0)
            {
                MessageBox.Show("You must preview changes before renaming! ", "Error", MessageBoxButtons.OK);
                return;
            }

            if (listBoxPreview.Items.Count != listBoxFilelist.Items.Count)
            {
                MessageBox.Show("File counts differ, might be regex error", "Error", MessageBoxButtons.OK);
                return;
            }

            // @todo - do actual renaming!

        }

        private void listBoxFilelist_DrawItem(object sender, DrawItemEventArgs e)
        {
            
            e.DrawBackground();

            Brush brush = new SolidBrush(e.ForeColor);

            bool bValidregex = false;

            if (e.Index > -1)
            {
                string itemText = listBoxFilelist.Items[e.Index].ToString();

                if (bInputfilesChanged)
                {
                    if (listBoxFilelist.HorizontalExtent < TextRenderer.MeasureText(itemText, e.Font).Width + 20)
                    {
                        listBoxFilelist.HorizontalExtent = TextRenderer.MeasureText(itemText, e.Font).Width + 20;
                    }
                    if (e.Index >= listBoxFilelist.Items.Count)
                    {
                        bInputfilesChanged = false;
                    }
                }

                if (inputSearch.Text.Length > 0)
                {
                    Regex regex = new Regex("");
                    try
                    {
                        regex = new Regex(inputSearch.Text);
                        bValidregex = true;
                    }
                    catch (ArgumentException)
                    {

                    }
                    if (bValidregex)
                    {
                        MatchCollection collection = regex.Matches(itemText);


                        foreach (Match match in collection)
                        {

                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Near;
                            CharacterRange[] characterRanges = { new CharacterRange(match.Index, match.Length) };
                            stringFormat.SetMeasurableCharacterRanges(characterRanges);

                            Region[] regions = e.Graphics.MeasureCharacterRanges(itemText, e.Font, e.Bounds, stringFormat);

                            RectangleF rect = regions[0].GetBounds(e.Graphics);

                            e.Graphics.FillRectangle(Brushes.BlueViolet, Rectangle.Round(rect));
                        }
                    }
                }
                e.Graphics.DrawString(itemText, e.Font, brush, e.Bounds);
            }
            else
            {
                listBoxFilelist.HorizontalExtent = 0;
            }
            e.DrawFocusRectangle();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Escape):
                    listBoxFilelist.ClearSelected();
                    break;
                case (Keys.Delete):
                     
                    if(listBoxFilelist.ClientRectangle.Contains(listBoxFilelist.PointToClient(MousePosition)))
                    {
                        Object[] SelectedItems = new Object[listBoxFilelist.SelectedItems.Count];
                        listBoxFilelist.SelectedItems.CopyTo(SelectedItems, 0);
                        foreach (object Item in SelectedItems)
                        {
                            RemoveFile(Item.ToString());
                            listBoxFilelist.Items.Remove(Item);
                        }
                        UpdatePreview();
                    }
                    break;
            }
        }

        private void inputSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxFilelist.Refresh();
        }

        private void inputReplace_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }
    }
}
