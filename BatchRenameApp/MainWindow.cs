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

        // @todo: check if this is needed, it evaluates as false always atm.
        bool bInputfilesChanged = false;

        FilenameStorage filestorage = new FilenameStorage();

        // MAIN WINDOW EVENTS
        #region Main Window events

        public MainWindow()
        {
            InitializeComponent();

            int errors = 0;
            Exception outException = null;

            foreach (string item in GetArgs())
            {
                try
                {
                    filestorage.AddFile(item);
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
            string[] args;
            args = Environment.GetCommandLineArgs();
            args = args.Skip(1).ToArray();
            return args;
        }


        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Escape):
                    listBoxFilelist.ClearSelected();
                    break;

                case (Keys.Delete):
                    if (listBoxFilelist.ClientRectangle.Contains(listBoxFilelist.PointToClient(MousePosition)))
                    {
                        Object[] SelectedItems = new Object[listBoxFilelist.SelectedItems.Count];
                        listBoxFilelist.SelectedItems.CopyTo(SelectedItems, 0);
                        foreach (object Item in SelectedItems)
                        {
                            filestorage.RemoveFile(Item.ToString());
                        }
                        UpdateFilelist();
                    }
                    break;
            }
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            UpdateFilelist();
        }

        #endregion

        // UI ELEMENT CALLBACKS
        #region UI element callbacks

        private void listBoxFilelist_DrawItem(object sender, DrawItemEventArgs e)
        {

            bool bValidregex = false;

            e.DrawBackground();
            if (e.Index > -1)
            {
                FileInfo item = (FileInfo)listBoxFilelist.Items[e.Index];
                string itemText = item.Name;

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
                e.Graphics.DrawString(itemText, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
            else
            {
                listBoxFilelist.HorizontalExtent = 0;
            }
            e.DrawFocusRectangle();
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
                    filestorage.AddFile(file);
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

            UpdateFilelist();
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
                filestorage.RemoveFile(listbox.SelectedItem.ToString());
                UpdateFilelist();
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

        private void inputSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxFilelist.Refresh();
            UpdatePreview();
        }

        private void inputReplace_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        #endregion

        // MENU EVENTS
        #region Menu Events 

        private void ascendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filestorage.SortAsc();
            UpdateFilelist();
        }

        private void descendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filestorage.SortDesc();
            UpdateFilelist();
        }

        private void noSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filestorage.ResetSort();
            UpdateFilelist();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filestorage.Undo();
            UpdateFilelist();
        }

        #endregion

        // HELPERS
        #region Helper Functions
        public void UpdateFilelist()
        {
            listBoxFilelist.Items.Clear();

            foreach(FileInfo file in filestorage.GetFileInfos())
            {
                listBoxFilelist.Items.Add(file);
            }

            UpdatePreview();
        }

        private void UpdatePreview()
        {
            listBoxPreview.Items.Clear();

            if (inputSearch.Text.Length > 0)
            {
                int x = 0;
                foreach (FileInfo file in filestorage.GetFileInfos())
                {

                    string filename = filestorage.ProcessRegex(x, inputSearch.Text, inputReplace.Text, file);
                    listBoxPreview.Items.Add(filename);

                    /*try
                    {                        
                        Regex regex = new Regex(inputSearch.Text);
                        listBoxPreview.Items.Add(file.DirectoryName + "\\" + regex.Replace(file.Name, inputReplace.Text));
                    }
                    catch (ArgumentException)
                    {
                        listBoxPreview.Items.Add(file.ToString());
                    } */

                    x++;
                }
            }
        }

        #endregion

    }
}
