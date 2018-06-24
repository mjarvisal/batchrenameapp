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
        public Settings settingsForm = new Settings();

        public FilenameStorage filestorage = new FilenameStorage();

        /** For evaluating math functions */
        private static string lastvalidFunction = "x";

        private static string replaceString;

        private static bool bControlPressed = false;

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
                CenteredMessageBox.Show(this, outException.Message, errors + " Errors", MessageBoxButtons.OK);
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
                    History.Push(listBoxFilelist);
                    listBoxFilelist.ClearSelected();
                    break;

                case (Keys.ControlKey):
                    {
                        bControlPressed = true;
                    }
                    break;

                case (Keys.Delete):
                    if (listBoxFilelist.ClientRectangle.Contains(listBoxFilelist.PointToClient(MousePosition)))
                    {
                        History.Push(listBoxFilelist);
                        RemoveSelection();
                        UpdatePreview();
                    }
                    break;
            }
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.ControlKey):
                    {
                        bControlPressed = false;
                    }
                    break;
            }
        }

        #endregion

        // UI ELEMENT CALLBACKS
        #region UI element callbacks

        private void checkBoxUseRegex_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

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
                    Brush brush = Brushes.DeepSkyBlue;
                    int matchindx = 0;
                    foreach (Match match in collection)
                    {

                        StringFormat stringFormat = new StringFormat();
                        stringFormat.Alignment = StringAlignment.Near;
                        CharacterRange[] characterRanges = { new CharacterRange(match.Index, match.Length) };
                        stringFormat.SetMeasurableCharacterRanges(characterRanges);

                        Region[] regions = e.Graphics.MeasureCharacterRanges(itemText, e.Font, e.Bounds, stringFormat);

                        RectangleF rect = regions[0].GetBounds(e.Graphics);
                        switch (matchindx)
                        {
                            case 0:
                                brush = Brushes.DeepSkyBlue;
                                matchindx++;
                                break;
                            case 1:
                                brush = Brushes.DodgerBlue;
                                matchindx = 0;
                                break;
                            default:
                                matchindx = 0;
                                break;
                        }
                        e.Graphics.FillRectangle(brush, Rectangle.Round(rect));
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

        private void listBoxFilelist_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (!bControlPressed)
            {
                int clickedIndex = listBoxFilelist.IndexFromPoint(me.Location);
                if (clickedIndex > -1)
                {
                    if (listBoxFilelist.SelectedIndices.Count > 1)
                    {
                        if (listBoxFilelist.SelectedIndices.Contains(clickedIndex))
                        {
                            listBoxFilelist.SetSelected(clickedIndex, !listBoxFilelist.GetSelected(clickedIndex));
                        }
                    }
                    else if (clickedIndex == listBoxFilelist.SelectedIndex)
                    {

                    }
                }
            }
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            History.Push(listBoxFilelist);
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                int errors = 0;
                Exception outException = null;
                foreach (string filename in files)
                {
                    if (Program.mainWindowForm.filestorage.Contains(filename) == false)
                    {
                        try
                        {
                            filestorage.AddFile(filename);
                            listBoxFilelist.Items.Add(filestorage.GetFileInfo(filename));
                        }
                        catch (Exception ex)
                        {
                            errors += 1;
                            outException = ex;
                        }
                    }
                }

                if (errors > 0)
                {
                    CenteredMessageBox.Show(this, outException.Message, errors + " Errors", MessageBoxButtons.OK);
                }
            }
            UpdatePreview();
        }

        private void Mainwindow_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if (listBoxFilelist.Items.Count == 0)
            {
                CenteredMessageBox.Show(this, "Drag&drop some files first", "Error", MessageBoxButtons.OK);
                return;
            }

            if (listBoxPreview.Items.Count == 0)
            {
                CenteredMessageBox.Show(this, "Search and replace something", "Error", MessageBoxButtons.OK);
                return;
            }

            if (listBoxPreview.Items.Count != listBoxFilelist.Items.Count)
            {
                CenteredMessageBox.Show(this, "File counts differ, might be regex error", "Error", MessageBoxButtons.OK);
                return;
            }

            DialogResult result = CenteredMessageBox.Show(this, "Are you sure?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                int Count = RenameFiles();
                String message = String.Format("Renamed {0} files", Count);
                if (Count > 0)
                {
                    listBoxFilelist.ClearSelected();
                    for (int i = 0; i < listBoxFilelist.Items.Count; i++)
                        listBoxFilelist.SetSelected(i, !listBoxFilelist.GetSelected(i));
                    RemoveSelection();
                    History.Clear();
                }
                UpdatePreview();
                CenteredMessageBox.Show(this, message, "Result", MessageBoxButtons.OK);
            }

            else
                return;

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

        private void collabsibleGroupBoxFiles_Click(object sender, EventArgs e)
        {
            listBoxFilelist.ClearSelected();
        }

        #endregion

        // MENU EVENTS
        #region Menu Events 

        private void ascendingContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist.Items);
            ListBoxSort.SortAsc(listBoxFilelist);
            UpdatePreview();
        }

        private void descendingContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist.Items);
            ListBoxSort.SortDesc(listBoxFilelist);
            UpdatePreview();
        }

        private void undoContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Undo(listBoxFilelist);
            UpdatePreview();
        }

        private void invertSelectionContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist.SelectedItems);
            for (int i = 0; i < listBoxFilelist.Items.Count; i++)
                listBoxFilelist.SetSelected(i, !listBoxFilelist.GetSelected(i));
        }

        private void clearSelectionContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist.SelectedItems);
            listBoxFilelist.ClearSelected();
        }

        private void RemoveSelectionContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist);
            RemoveSelection();
            UpdatePreview();
        }

        private void regularExpressionsContextMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/#sclient=psy-ab&q=regular+expression+cheat+sheet");
        }

        private void redoContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Redo(listBoxFilelist);
            UpdatePreview();
        }

        private void TagsContextMenuItem_Click(object sender, EventArgs e)
        {
            TagsLegend legend = new TagsLegend();
            legend.StartPosition = FormStartPosition.Manual;
            Point startinglocation = Location;
            startinglocation.X = Location.X + Bounds.Width + 3;
            startinglocation.Y = Location.Y + 30;
            legend.Location = startinglocation;
            legend.Show();
        }
        private void settingsContextMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.StartPosition = FormStartPosition.CenterParent;
            settingsForm.ShowDialog(this);
        }

        #endregion

        // HELPERS
        #region Helper Functions

        private void RemoveSelection()
        {
            foreach (object Item in listBoxFilelist.SelectedItems)
            {
                filestorage.RemoveFile(Item.ToString());
            }
            int index = listBoxFilelist.SelectedIndex;
            listBoxFilelist.RemoveSelectedItems(ref index);
            if(index > (listBoxFilelist.Items.Count -1))
            {
                index--;
            }
            if(listBoxFilelist.Items.Count == 0)
            {
                index = -1;
            }
            listBoxFilelist.SelectedIndex = index;
        }

        public void UpdatePreview()
        {
            listBoxPreview.Items.Clear();
            string Search = inputSearch.Text;
            if (Search.Length == 0)
            {
                Search = "^";
            }
            String[] inputs = { Search, inputReplace.Text, inputFunction.Text };
            bool bmode = checkBoxUseRegex.Checked;
            int x = 0;
            foreach (FileInfo file in listBoxFilelist.Items)
            {
                string fileName = ProcessRegex(x, bmode, inputs, file);
                if (fileName != null)
                {
                    listBoxPreview.Items.Add(fileName);
                }
                x++;
            }
        }

        #endregion

        // PROCESS STRINGS
        #region

        private static string Replacement
        {
            get
            {
                return replaceString;
            }
            set
            {
                replaceString = value;
            }
        }

        private static Regex r = new Regex(":");
        private static FileInfo notImage;

        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                try
                {
                    using (Image myImage = Image.FromStream(fs, false, false))
                    {
                        System.Drawing.Imaging.PropertyItem propItem = myImage.GetPropertyItem(36867);
                        string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                        return DateTime.Parse(dateTaken);
                    }
                }
                catch (Exception)
                {
                    return DateTime.MaxValue;
                }
        }

        private string ProcessPatterns(int number, string replacetext, string function, FileInfo file)
        {
            string dateformat = settingsForm.dateformat;
            string timeformat = settingsForm.timeformat;
            string date = file.CreationTime.ToString(dateformat);
            string time = file.CreationTime.ToString(timeformat);
            String[] imagedatetime = { "%datetaken", "%timetaken" };

            string output = replacetext.Replace("%file%", file.Name);
            output = output.Replace("%folder%", file.Directory.Name);
            output = output.Replace("%datecreated%", date);
            output = output.Replace("%timecreated%", time);
            output = output.Replace("%datenow%", DateTime.Now.ToString(dateformat));
            output = output.Replace("%timenow%", DateTime.Now.ToString(timeformat));
            output = output.Replace("%fnc%", EvaluateFunctionString(function, number));

            if (imagedatetime.Any(replacetext.Contains))
            {
                DateTime dateTime = GetDateTakenFromImage(file.FullName);
                if (dateTime == DateTime.MaxValue)
                {
                    output = output.Replace("%datetaken%", "%datetaken%");
                    output = output.Replace("%timetaken%", "%timetaken%");
                }
                else
                {
                    output = output.Replace("%datetaken%", dateTime.ToString(dateformat));
                    output = output.Replace("%timetaken%", dateTime.ToString(timeformat));
                }
                
            }
            else
            {
                output = output.Replace("%datetaken%", "%datetaken%");
                output = output.Replace("%timetaken%", "%timetaken%");
            }

            return output;
        }

        private string ConvertToRegex(string normalsearch)
        {
            Regex test = new Regex(".*");
            return "test";
        }

        private string ProcessRegex(int number, bool mode, String[] inputs, FileInfo file)
        {
            string find = inputs[0];
            string replace = inputs[1];
            string function = inputs[2];
            string result = "";
            Replacement = replace;
            if (!mode)
            {
                find = ConvertToRegex(find);
            }

            try
            {
                Regex regex = new Regex(find);
                MatchEvaluator myEvaluator = new MatchEvaluator(EvaluateMatch);
                if(regex.IsMatch(file.Name))
                {
                    string renamed = regex.Replace(file.Name, myEvaluator);
                    result = ProcessPatterns(number, renamed, function, file);
                }
                if (result == file.Name)
                    return "";
                else
                    return result;

            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public string EvaluateMatch(Match match)
        {
            string replace = Replacement;
            return replace;
            /*
            if (match.Length > 0)
                return replace;
            else
                return "";
                */
        }

        private string EvaluateFunctionString(string sFunction, int number)
        {
            string expression = "x";
            string lastvalidexpression = "x";
            Regex allowedRegex = new Regex(@"[^x0-9()*/+-\^]");

            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl { Language = "VBScript" };
            if (sFunction.Length > 0)
            {
                if (allowedRegex.IsMatch(sFunction))
                {
                    lastvalidexpression = lastvalidFunction.Replace("x", number.ToString());
                }
                else
                {
                    expression = sFunction.Replace("x", number.ToString());
                    lastvalidexpression = lastvalidFunction.Replace("x", number.ToString());
                }
            }
            else
            {
                sFunction = "x";
                expression = sFunction.Replace("x", number.ToString());
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

        // RENAME FILES
        #region
        private int RenameFiles()
        {
            int renamed = 0;
            int index = 0;
            foreach(string renameditem in listBoxPreview.Items)
            {
                if (renameditem != "")
                {
                    FileInfo originalfileInfo = (FileInfo)listBoxFilelist.Items[index];
                    string directory = originalfileInfo.DirectoryName;
                    string renamedFullname = directory + @"\" + renameditem;
                    originalfileInfo.MoveTo(renamedFullname);
                    renamed++;
                }
                index++;
            }
            return renamed;
        }


        #endregion

        private void MainWindow_Load(object sender, EventArgs e)
        {
            listBoxFilelist.Items.Clear();
            History.Push(listBoxFilelist);
            int x = 0;
            foreach (FileInfo file in filestorage.GetFileInfos())
            {
                listBoxFilelist.Items.Add(file);
                listBoxFilelist.SetSelected(x, true);
                x++;
            }

            UpdatePreview();
        }
    }
}