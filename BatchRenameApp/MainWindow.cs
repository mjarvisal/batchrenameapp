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

        FilenameStorage filestorage = new FilenameStorage();

        /** For evaluating math functions */
        private static string lastvalidFunction = "x";

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
                        RemoveSelection();
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
                int ItemsCount = listBoxFilelist.Items.Count;
                int ItemsCountPrev = 0;

                if (ItemsCount != ItemsCountPrev)
                {
                    if (listBoxFilelist.HorizontalExtent < TextRenderer.MeasureText(itemText, e.Font).Width + 20)
                    {
                        listBoxFilelist.HorizontalExtent = TextRenderer.MeasureText(itemText, e.Font).Width + 20;
                    }
                }

                string SearchText = "^";
                Regex regex = new Regex(SearchText);

                if (inputSearch.Text.Length > 0)
                {
                    SearchText = inputSearch.Text;
                }
                try
                {
                    regex = new Regex(SearchText);
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
                e.Graphics.DrawString(itemText, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                ItemsCountPrev = listBoxFilelist.Items.Count;
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

        private void textBoxFunction_TextChanged(object sender, EventArgs e)
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

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxFilelist.Items.Count; i++)
                listBoxFilelist.SetSelected(i, !listBoxFilelist.GetSelected(i));
        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBoxFilelist.ClearSelected();
        }

        private void RemoveSelectiontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelection();
        }

        private void regularExpressionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/#sclient=psy-ab&q=regular+expression+cheat+sheet");
        }

        private void usableTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Search Tags\n" +
                 "------------\n" +
                 "%end% -Concat replace string to end of filename(excl.extension)\n\n" +
                 "Replace Tags\n" +
                 "------------\n" +
                 "%date% - Replace match with current date\n" +
                 "%time% - Replace match with current time\n" +
                 "%folder% - Replace match with file directory name\n" +
                 "%file% - Replace match with file name\n" +
                 "%fnc% - Replace match with math function result\n";
            string caption = "Tags Legend";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

        }

        #endregion

        // HELPERS
        #region Helper Functions

        private void RemoveSelection()
        {
            Object[] SelectedItems = new Object[listBoxFilelist.SelectedItems.Count];
            listBoxFilelist.SelectedItems.CopyTo(SelectedItems, 0);
            foreach (object Item in SelectedItems)
            {
                filestorage.RemoveFile(Item.ToString());

            }
            UpdateFilelist();
        }
        public void UpdateFilelist()
        {
            listBoxFilelist.Items.Clear();

            foreach (FileInfo file in filestorage.GetFileInfos())
            {
                listBoxFilelist.Items.Add(file);
            }

            UpdatePreview();
        }

        private void UpdatePreview()
        {
            listBoxPreview.Items.Clear();

            string SearchText = "^";

            if (inputSearch.Text.Length > 0)
            {
                SearchText = inputSearch.Text;
            }
            int x = 0;
            foreach (FileInfo file in filestorage.GetFileInfos())
            {

                string filename = ProcessRegex(x, SearchText, inputReplace.Text, textBoxFunction.Text, file);
                listBoxPreview.Items.Add(filename);

                x++;
            }
        }

        #endregion

        // Process strings
        #region
        private string ProcessPatterns(int index, string text, string function, FileInfo file)
        {

            string output = text.Replace("%file%", file.Name);
            output = output.Replace("%folder%", file.Directory.Name);
            output = output.Replace("%date%", DateTime.Now.ToShortDateString());
            output = output.Replace("%time%", DateTime.Now.ToLongTimeString());
            output = output.Replace("%fnc%", EvaluateFunctionString(function, index));

            return output;
        }

        private string ProcessRegex(int index, string find, string replace, string function, FileInfo file)
        {
            try
            {
                Regex regex = new Regex(find);
                return ProcessPatterns(index, regex.Replace(file.Name, replace), function, file);
            }
            catch (ArgumentException)
            {
                return file.Name;
            }
        }

        private string EvaluateFunctionString(string sFunction, int index)
        {
            string expression = "x";
            string lastvalidexpression = "x";
            Regex allowedRegex = new Regex("[^x0-9()*/+-\\^]");

            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl { Language = "VBScript" };
            if (sFunction.Length > 0)
            {
                if (allowedRegex.IsMatch(sFunction))
                {
                    lastvalidexpression = lastvalidFunction.Replace("x", index.ToString());
                }
                else
                {
                    expression = sFunction.Replace("x", index.ToString());
                    lastvalidexpression = lastvalidFunction.Replace("x", index.ToString());
                }
            }
            else
            {
                sFunction = "x";
                expression = sFunction.Replace("x", index.ToString());
            }

            object result = null;

            try
            {
                if (allowedRegex.IsMatch(sFunction))
                {
                    result = sc.Eval(lastvalidexpression);

                }
                else
                {
                    result = sc.Eval(expression);
                    lastvalidFunction = sFunction;
                }
            }
            catch (Exception)
            {
                result = sc.Eval(lastvalidexpression);
            }
            if (result != null)
                return result.ToString();
            else
                return "0";
        }

        #endregion

    }
}
