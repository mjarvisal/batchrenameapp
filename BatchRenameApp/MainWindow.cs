using System;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Xml;
using System.Globalization;
using System.IO.Compression;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;

namespace BatchRenameApp
{

    public partial class MainWindow : Form
    {
        public Settings settingsForm = new Settings();
        public FilenameStorage filestorage = new FilenameStorage();

        /** For evaluating math functions */
        private BackgroundWorker processPreviews;
        private TagsLegend legend;
        private SortFilterForm sortFilterForm;
        internal string[] exifEnumTypes = Enum.GetNames(typeof(ExifLib.ExifTags));
        public String SortFilter = "";
        public bool SortSelection = false;

        // MAIN WINDOW EVENTS
        #region Main Window events

        public MainWindow()
        {
            InitializeComponent();

            processPreviews = new BackgroundWorker
            {
                WorkerSupportsCancellation = false
            };
            processPreviews.DoWork += new DoWorkEventHandler(DoWorkPreview);
            processPreviews.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ListboxPreviewprocessCompleted);

            int errors = 0;
            Exception outException = null;

            string[] itemsdropped = GetArgs();

            itemsdropped = FolderDropWizard(itemsdropped);

            foreach (string item in itemsdropped)
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
                    labelSelected.Text = "Selected: 0";
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
            labelSelected.Text = String.Format("Selected: {0}", listBoxFilelist.SelectedIndices.Count);
            UpdatePreview();
        }
        #endregion

        // UI ELEMENT CALLBACKS
        #region UI element callbacks

        private void ListBoxFilelist_DrawItem(object sender, DrawItemEventArgs e)
        {

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

                RegexHelper checkRegex = new RegexHelper(inputSearch.Text);
                Regex regex = checkRegex.GetRegex();

                if (checkRegex.bIsValidRegex)
                {
                    if (regex.IsMatch(itemText))
                    {
                        MatchCollection collection = regex.Matches(itemText);
                        Brush brush = Brushes.DeepSkyBlue;
                        int matchindx = 0;
                        foreach (Match match in collection)
                        {
                            StringFormat stringFormat = new StringFormat
                            {
                                Alignment = StringAlignment.Near
                            };
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

                }

                // if sortfilter form is shown.
                if (sortFilterForm != null && !sortFilterForm.IsDisposed)
                {
                    StringFormat stringFormat2 = new StringFormat
                    {
                        Alignment = StringAlignment.Near
                    };
                    CharacterRange[] characterRanges2 = { ListBoxSort.GetFilterRange(SortFilter, itemText) };
                    stringFormat2.SetMeasurableCharacterRanges(characterRanges2);
                    Region[] regions2 = e.Graphics.MeasureCharacterRanges(itemText, e.Font, e.Bounds, stringFormat2);
                    RectangleF rect2 = regions2[0].GetBounds(e.Graphics);
                    e.Graphics.DrawRectangle(Pens.DarkOrange, Rectangle.Round(rect2));
                }

                e.Graphics.DrawString(itemText, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                ItemsCountPrev = listBoxFilelist.Items.Count;
            }
            else
            {
                listBoxFilelist.HorizontalExtent = 0;
            }
            e.DrawFocusRectangle();
            labelSelected.Text = String.Format("Selected: {0}", listBoxFilelist.SelectedIndices.Count);
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            History.Push(listBoxFilelist);
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                string[] itemsdropped = (string[])e.Data.GetData(DataFormats.FileDrop);

                itemsdropped = FolderDropWizard(itemsdropped);

                int errors = 0;
                List<string> erronousFiles = new List<string>();
                listBoxFilelist.BeginUpdate();
                foreach (string filename in itemsdropped)
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
                            erronousFiles.Add(ex.Message);
                            erronousFiles.Add(filename);
                            errors += 1;
                        }
                    }
                }
                listBoxFilelist.EndUpdate();
                if (errors > 0)
                {
                    String ErrorText = "";
                    foreach (string ErrorItem in erronousFiles)
                    {
                        ErrorText += String.Format("{0} \r\n", ErrorItem);
                    }
                    CenteredMessageBox.Show(this, ErrorText, errors + " Errors", MessageBoxButtons.OK);
                }
            }

            UpdatePreview();
        }

        public string[] FolderDropWizard(string[] itemsdropped)
        {
            Dictionary<string, object> lDirectories = new Dictionary<string, object>();
            Array itemsArray = itemsdropped.ToArray();

            try
            {
                var x = 0;
                foreach (string filename in itemsArray)
                {
                    DirectoryInfo file = new DirectoryInfo(filename);
                    if ((file.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        lDirectories.Add(filename, CustomDirectoryIterator.DirSearch(filename));
                        x++;
                    }
                }

                if (lDirectories.Count > 0)
                {
                    ImportFoldersWindow foldersWindow = new ImportFoldersWindow();

                    foldersWindow.Clear();
                    foldersWindow.AddFiles(lDirectories);
                    DialogResult result = foldersWindow.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        itemsdropped = foldersWindow.GetFiles();
                    }
                    else
                    {
                        return itemsdropped;
                    }
                }
            }
            catch
            {
                return new string[0];
            }
            return itemsdropped;
        }

        private void Mainwindow_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void ButtonRename_Click(object sender, EventArgs e)
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

        private void InputSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxFilelist.Refresh();
            UpdatePreview();
        }

        private void InputReplace_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void TextBoxFunction_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void CollabsibleGroupBoxFiles_Click(object sender, EventArgs e)
        {
            listBoxFilelist.ClearSelected();
        }

        private void LinkLabelRegex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference");
        }

        private void LinkLabelTags_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (legend == null || legend.IsDisposed)
            {
                legend = new TagsLegend
                {
                    StartPosition = FormStartPosition.Manual
                };
            }

            Point newLocation = new Point(Location.X + Bounds.Width + 3, Location.Y + 30);

            if ((newLocation.X + legend.Width) > Screen.GetWorkingArea(this).Right)
            {
                newLocation.X = Bounds.Left - legend.Width + 3;
            }

            legend.Location = newLocation;
            legend.Show();
            legend.Focus();
        }

        private void InputSortFilter_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void SortContextMenuItem_Click(object sender, EventArgs e)
        {
            if (sortFilterForm == null || sortFilterForm.IsDisposed)
            {
                sortFilterForm = new SortFilterForm();
            }

            sortFilterForm.Show();
            sortFilterForm.Focus();
        }

        #endregion

        // MENU EVENTS
        #region Menu Events 

        public void SortFilesAsc()
        {
            History.Push(listBoxFilelist.Items);
            ListBoxSort.SortList(SortMode.Asc, listBoxFilelist, SortFilter, SortSelection);
            UpdatePreview();
        }


        public void SortFilesDesc()
        {
            History.Push(listBoxFilelist.Items);
            ListBoxSort.SortList(SortMode.Desc, listBoxFilelist, SortFilter, SortSelection);
            UpdatePreview();
        }

        private void UndoContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Undo(listBoxFilelist);
            UpdatePreview();
        }

        private void InvertSelectionContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist.SelectedItems);
            listBoxFilelist.BeginUpdate();
            for (int i = 0; i < listBoxFilelist.Items.Count; i++)
                listBoxFilelist.SetSelected(i, !listBoxFilelist.GetSelected(i));
            labelSelected.Text = String.Format("Selected: {0}", listBoxFilelist.SelectedIndices.Count);
            listBoxFilelist.EndUpdate();
        }

        private void ClearSelectionContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist.SelectedItems);
            listBoxFilelist.ClearSelected();
            labelSelected.Text = String.Format("Selected: {0}", listBoxFilelist.SelectedIndices.Count);
        }

        private void RemoveSelectionContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist);
            RemoveSelection();
            UpdatePreview();
        }

        private void RegularExpressionsContextMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/#sclient=psy-ab&q=regular+expression+cheat+sheet");
        }

        private void RedoContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Redo(listBoxFilelist);
            UpdatePreview();
        }

        private void SettingsContextMenuItem_Click(object sender, EventArgs e)
        {
            settingsForm.StartPosition = FormStartPosition.CenterParent;
            settingsForm.ShowDialog(this);
        }

        #endregion

        // HELPERS
        #region Helper Functions

        private void RemoveSelection()
        {
            listBoxFilelist.BeginUpdate();
            foreach (object Item in listBoxFilelist.SelectedItems)
            {
                filestorage.RemoveFile(Item.ToString());
            }
            int index = listBoxFilelist.SelectedIndex;
            listBoxFilelist.RemoveSelectedItems(ref index);
            if (index > (listBoxFilelist.Items.Count - 1))
            {
                index--;
            }
            if (listBoxFilelist.Items.Count == 0)
            {
                index = -1;
            }
            labelSelected.Text = String.Format("Selected: {0}", listBoxFilelist.SelectedIndices.Count);
            listBoxFilelist.SelectedIndex = index;
            listBoxFilelist.EndUpdate();
        }

        public void SelectFiltered()
        {
            ListBoxSort.FilterSelection(listBoxFilelist, SortFilter);
        }


        public void UpdatePreview()
        {
            object[] listofitems = new object[listBoxFilelist.Items.Count];
            int x = 0;
            foreach (object item in listBoxFilelist.Items)
            {
                listofitems[x] = item;
                x++;
            }
            if (processPreviews.IsBusy != true)
            {
                listBoxPreview.BeginUpdate();
                // Start the asynchronous operation.
                processPreviews.RunWorkerAsync(listofitems);
            }
        }

        public class PreviewResult
        {
            public object[] Filelist;
            public object[] PreviewList;
            public int MatchedCount;

            public PreviewResult(object[] inputFilelist)
            {
                MatchedCount = 0;
                Filelist = inputFilelist;
                PreviewList = new object[Filelist.Length];
            }

            public PreviewResult()
            {
                MatchedCount = 0;
                Filelist = new object[0];
                PreviewList = new object[Filelist.Length];
            }

        }

        private void DoWorkPreview(object sender, DoWorkEventArgs e)
        {
            PreviewResult previewResult = new PreviewResult((object[])e.Argument);

            string Search = inputSearch.Text;
            string Replace = inputReplace.Text;
            if (Search == "")
            {
                bSearchStringEmpty = true;
                Search = "^";
            }
            else
                bSearchStringEmpty = false;

            int x = 0;
            foreach (FileInfo item in previewResult.Filelist)
            {
                string fileName = item.ToString();
                if (fileName != null)
                {
                    string renamed = Processfile(x, item, Search, Replace);
                    if (renamed != "")
                    {
                        previewResult.MatchedCount += 1;
                    }
                    if (renamed == "\r\n")
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        previewResult.PreviewList.SetValue(renamed, x);
                    }
                }
                x++;
            }
            if (bSearchStringEmpty)
            {

            }
            e.Result = previewResult;
        }

        private string Processfile(int x, FileInfo file, string startSearch, string startReplace)
        {
            string Search = inputSearch.Text;
            string Replace = inputReplace.Text;
            if (Search == "")
            {
                bSearchStringEmpty = true;
                Search = "^";
            }
            else
                bSearchStringEmpty = false;

            string result = string.Empty;
            if (!startSearch.Equals(Search) || !startReplace.Equals(Replace))
            {
                return "\r\n";
            }
            else
            {
                String[] inputs = { Search, inputReplace.Text, inputFunction.Text };
                result = ProcessRegex(x, inputs, file);
            }
            return result;
        }


        private void ListboxPreviewprocessCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                UpdatePreview();
                listBoxPreview.EndUpdate();
            }
            else
            {
                PreviewResult result = new PreviewResult();
                try
                {
                    result = (PreviewResult)e.Result;
                }
                catch
                {
                }

                listBoxPreview.Items.Clear();
                try
                {
                    listBoxPreview.Items.AddRange(result.PreviewList);
                }
                catch (Exception)
                {
                }
                listBoxPreview.EndUpdate();
                labelMatched.Text = String.Format("Matched: {0}", result.MatchedCount);
            }
        }
        #endregion

        // PROCESS REGEX
        #region

        private static Regex r = new Regex(":");
        private bool bSearchStringEmpty;
        internal ProcessStrings ProcessString = new ProcessStrings();

        private string ProcessRegex(int number, String[] inputs, FileInfo file)
        {
            string find = inputs[0];
            string replace = inputs[1];
            string function = inputs[2];
            string result = "";
            try
            {
                Regex regex = new Regex(find);
                if (regex.IsMatch(file.Name))
                {
                    Dictionary<int, string> groupreplacedict = new Dictionary<int, string> { };                   
                    Regex groupregex = new Regex(@"(?<single>\{[0-9][0-9]{0,1}\})|(?<indexes>\{[0-9]+,[0-9]+\})|(?<range>\{[0-9]+-[0-9]+\})");
                    MatchCollection matchcollection = groupregex.Matches(replace);
                    if (matchcollection.Count > 0)
                    {
                        foreach (Match groupmatch in matchcollection)
                        {
                            Regex numberRegex = new Regex("[0-9]");
                            Match nextMatch = groupmatch.NextMatch();
                            GroupCollection groupcollection = groupmatch.Groups;
                            try
                            {
                                string groupreplace = string.Empty;
                                if (groupcollection["single"].Success)
                                {
                                    int replacestartIndex = groupmatch.Index + groupmatch.Length;
                                    int replaceLength = (replace.Length - replacestartIndex);
                                    if (nextMatch.Success)
                                    {
                                        replaceLength = (nextMatch.Index - replacestartIndex);
                                    }
                                    Match groupnumberMatch = numberRegex.Match(groupmatch.Value);
                                    groupreplacedict.Add(Convert.ToInt32(groupnumberMatch.Value), replace.Substring(replacestartIndex, replaceLength));
                                }
                                if (groupcollection["indexes"].Success)
                                {
                                    int replacestartIndex = groupmatch.Index + groupmatch.Length;
                                    int replaceLength = (replace.Length - replacestartIndex);
                                    if (nextMatch.Success)
                                    {
                                        replaceLength = (nextMatch.Index - replacestartIndex);
                                    }
                                    MatchCollection indexescollection = numberRegex.Matches(groupmatch.Value);
                                    foreach (Match indexMatch in indexescollection)
                                    {
                                        groupreplacedict.Add(Convert.ToInt32(indexMatch.Value), replace.Substring(replacestartIndex, replaceLength));
                                    }
                                }
                                if (groupcollection["range"].Success)
                                {
                                    int replacestartIndex = groupmatch.Index + groupmatch.Length;
                                    int replaceLength = (replace.Length - replacestartIndex);
                                    if (nextMatch.Success)
                                    {
                                        replaceLength = (nextMatch.Index - replacestartIndex);
                                    }
                                    Match firstgroupnumberMatch = numberRegex.Match(groupmatch.Value);
                                    Match lastgroupnumberMatch = firstgroupnumberMatch.NextMatch();
                                    for (int i = Convert.ToInt32(firstgroupnumberMatch.Value); i <= Convert.ToInt32(lastgroupnumberMatch.Value); i++)
                                    {
                                        groupreplacedict.Add(i, replace.Substring(replacestartIndex, replaceLength));
                                    }
                                }
                            }
                            catch { }
                        }
                    }

                    MatchCollection collection = regex.Matches(file.Name);
                    int substringstartIndex = 0;
                    int collectionIndex = 0;
                    foreach (Match match in collection)
                    {
                        string groupreplace = replace;
                        if(groupreplacedict.Count > 0 )
                        {
                            try
                            {
                                groupreplace = groupreplacedict[collectionIndex];
                            }
                            catch
                            {
                                groupreplace = "";
                            }
                        }
                        string subresult = string.Empty;
                        string substring = file.Name.Substring(substringstartIndex, match.Index - substringstartIndex + match.Length);
                        string renamed = regex.Replace(substring, groupreplace);
                        substringstartIndex += match.Index - substringstartIndex + match.Length;
                        ProcessString.ProcessPatterns(number, renamed, function, file);
                        subresult = ProcessString.output;
                        result += subresult;
                        collectionIndex++;
                    }
                    if (substringstartIndex < file.Name.Length)
                    {
                        result += file.Name.Substring(substringstartIndex);
                    }
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

        #endregion

        // RENAME FILES
        #region
        private int RenameFiles()
        {
            int renamed = 0;
            int index = 0;
            foreach (string renameditem in listBoxPreview.Items)
            {
                if (renameditem != "")
                {
                    FileInfo originalfileInfo = (FileInfo)listBoxFilelist.Items[index];
                    string directory = originalfileInfo.DirectoryName;
                    string renamedFullname = directory + @"\" + renameditem;
                    if (!File.Exists(renamedFullname))
                    {
                        originalfileInfo.MoveTo(renamedFullname);
                        renamed++;
                    }                    
                }
                index++;
            }
            return renamed;
        }


        #endregion

        private void FilterSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBoxSort.FilterSelection(listBoxFilelist, inputSearch.Text);
        }
    }
}