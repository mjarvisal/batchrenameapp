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
        private static string lastvalidFunction = "x";
        private static string replaceString;
        private static bool bControlPressed = false;
        private BackgroundWorker processPreviews;
        private LocationServices savedLocations = new LocationServices();

        // MAIN WINDOW EVENTS
        #region Main Window events

        public MainWindow()
        {
            InitializeComponent();

            processPreviews = new BackgroundWorker();
            processPreviews.WorkerSupportsCancellation = false;
            processPreviews.DoWork += new DoWorkEventHandler(DoWorkPreview);
            processPreviews.RunWorkerCompleted += new RunWorkerCompletedEventHandler(listboxPreviewprocessCompleted);

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

        private void CheckBoxUseRegex_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void ListBoxFilelist_DrawItem(object sender, DrawItemEventArgs e)
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
                e.Graphics.DrawString(itemText, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
                ItemsCountPrev = listBoxFilelist.Items.Count;
            }
            else
            {
                listBoxFilelist.HorizontalExtent = 0;
            }
            e.DrawFocusRectangle();
        }

        private void ListBoxFilelist_Click(object sender, EventArgs e)
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
                string[] itemsdropped = (string[])e.Data.GetData(DataFormats.FileDrop);
                Dictionary<string, object> lDirectories = new Dictionary<string, object>();

                var x = 0;
                foreach (string filename in itemsdropped)
                {
                    DirectoryInfo file = new DirectoryInfo(filename);
                    if (file.Attributes == FileAttributes.Directory)
                    {
                        lDirectories.Add(filename, CustomDirectoryIterator.DirSearch(filename));
                        x++;
                    }
                }

                if (lDirectories.Count > 0)
                {
                    ImportFoldersWindow foldersWindow = new ImportFoldersWindow();

                    foldersWindow.clear();
                    foldersWindow.AddFiles(lDirectories);
                    DialogResult result = foldersWindow.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        itemsdropped = foldersWindow.getFiles();
                    }
                    else
                    {
                        return;
                    }
                }

                int errors = 0;
                Exception outException = null;
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
                            errors += 1;
                            outException = ex;
                        }
                    }
                }
                listBoxFilelist.EndUpdate();
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

        #endregion

        // MENU EVENTS
        #region Menu Events 

        private void AscendingContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist.Items);
            ListBoxSort.SortAsc(listBoxFilelist);
            UpdatePreview();
        }

        private void DescendingContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Push(listBoxFilelist.Items);
            ListBoxSort.SortDesc(listBoxFilelist);
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
            for (int i = 0; i < listBoxFilelist.Items.Count; i++)
                listBoxFilelist.SetSelected(i, !listBoxFilelist.GetSelected(i));
        }

        private void ClearSelectionContextMenuItem_Click(object sender, EventArgs e)
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

        private void RegularExpressionsContextMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/#sclient=psy-ab&q=regular+expression+cheat+sheet");
        }

        private void RedoContextMenuItem_Click(object sender, EventArgs e)
        {
            History.Redo(listBoxFilelist);
            UpdatePreview();
        }

        private void TagsContextMenuItem_Click(object sender, EventArgs e)
        {
            TagsLegend legend = new TagsLegend
            {
                StartPosition = FormStartPosition.Manual
            };

            Point startinglocation = Location;
            startinglocation.X = Location.X + Bounds.Width + 3;
            startinglocation.Y = Location.Y + 30;
            legend.Location = startinglocation;
            legend.Show();
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
            listBoxFilelist.SelectedIndex = index;
            listBoxFilelist.EndUpdate();
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

        private void DoWorkPreview(object sender, DoWorkEventArgs e)
        {
            object[] Filelist = (object[])e.Argument;
            object[] Previewlist = new object[Filelist.Length];
            string Search = inputSearch.Text;
            string Replace = inputReplace.Text;
            if (Search == "")
            {
                Search = "^";
            }
            bool bmode = checkBoxUseRegex.Checked;
            int x = 0;
            foreach (FileInfo item in Filelist)
            {
                string fileName = item.ToString();
                if (fileName != null)
                {
                    string renamed = processfile(x, item, Search, Replace);
                    if (renamed == "\r\n")
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        Previewlist.SetValue(renamed, x);
                    }
                }
                x++;
            }
            e.Result = Previewlist;
        }

        private string processfile(int x, FileInfo file, string startSearch, string startReplace)
        {
            string Search = inputSearch.Text;
            string Replace = inputReplace.Text;
            if (Search == "")
            {
                Search = "^";
            }
            string result = string.Empty;
            if (!startSearch.Equals(Search) || !startReplace.Equals(Replace))
            {
                return "\r\n";
            }
            else
            {
                bool bmode = checkBoxUseRegex.Checked;
                String[] inputs = { Search, inputReplace.Text, inputFunction.Text };
                result = ProcessRegex(x, bmode, inputs, file);
            }
            return result;
        }


        private void listboxPreviewprocessCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                UpdatePreview();
                listBoxPreview.EndUpdate();
            }
            else
            {
                listBoxPreview.Items.Clear();
                try
                {
                    listBoxPreview.Items.AddRange((object[])e.Result);
                }
                catch (Exception)
                {
                }
                listBoxPreview.EndUpdate();
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


        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                try
                {
                    using (Image myImage = Image.FromStream(fs, false, false))
                    {
                        PropertyItem propItem = myImage.GetPropertyItem(36867);
                        string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                        return DateTime.Parse(dateTaken);
                    }
                }
                catch (Exception)
                {
                    return DateTime.MaxValue;
                }
        }

        public Double[] GetGPSLocationFromImage(string path)
        {
            Double[] output = new Double[2] { -360.0d, -360.0d };
            double[] lat = null;
            double[] lon = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    ExifLib.ExifReader exifReader = new ExifLib.ExifReader(fs);
                    exifReader.GetTagValue<double[]>(ExifLib.ExifTags.GPSLatitude, out lat);
                    exifReader.GetTagValue<double[]>(ExifLib.ExifTags.GPSLongitude, out lon);
                }
                catch
                {

                }
            }
            if (!(lat == null) || !(lon == null))
            {
                output[0] = lat[0] + lat[1] / 60 + lat[2] / 3600;
                output[1] = lon[0] + lon[1] / 60 + lon[2] / 3600;
            }
            return output;
        }

        private double ExifGpsToDouble(PropertyItem propItemRef, PropertyItem propItem)
        {
            double degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            double degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            double degrees = degreesNumerator / (double)degreesDenominator;

            double minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            double minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            double minutes = minutesNumerator / (double)minutesDenominator;

            double secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            double secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            double seconds = secondsNumerator / (double)secondsDenominator;


            double coorditate = degrees + (minutes / 60d) + (seconds / 3600d);
            string gpsRef = Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
            if (gpsRef == "S" || gpsRef == "W")
                coorditate = coorditate * -1;
            return coorditate;
        }

        private string ProcessPatterns(int number, string replacetext, string function, FileInfo file)
        {
            string filense = string.Empty;
            string fileext = string.Empty;
            string output = replacetext;

            string dateformat = settingsForm.dateformat;
            string timeformat = settingsForm.timeformat;
            string date = file.CreationTime.ToString(dateformat);
            string time = file.CreationTime.ToString(timeformat);
            String[] imagedatetime = { "%datetaken", "%timetaken" };
            String[] fileparts = { "%file%", "%ext%" };

            if (fileparts.Any(output.Contains))
            {
                Regex extension = new Regex("[.](.){3,4}$");
                try
                {
                    Match fileextregex = extension.Match(file.Name);
                    int index = fileextregex.Index;
                    int lenght = fileextregex.Length;
                    filense = file.Name.Remove(index, lenght);
                    fileext = fileextregex.Value;
                }
                catch { }
                output = output.Replace("%ext%", fileext);
                output = output.Replace("%file%", filense);
            }

            output = output.Replace("%folder%", file.Directory.Name);
            output = output.Replace("%datecreated%", date);
            output = output.Replace("%timecreated%", time);
            output = output.Replace("%datenow%", DateTime.Now.ToString(dateformat));
            output = output.Replace("%timenow%", DateTime.Now.ToString(timeformat));

            if (output.Contains("%fnc%"))
            {
                output = output.Replace("%fnc%", EvaluateFunctionString(function, number));
            }

            if (output.Contains("%loc%"))
            {
                double[] location = GetGPSLocationFromImage(file.FullName);

                if (location[0] > -360.0 && location[1] > -360.0)
                {
                    string[] LocationNames = new string[] { "", "" };
                    int savedLocationindex = savedLocations.GetSavedLocationIndex(location);
                    if (savedLocationindex == int.MaxValue)
                    {
                        savedLocations.SearchforLocation(location, 14);
                        savedLocationindex = savedLocations.GetSavedLocationIndex(location);
                        if (savedLocationindex == int.MaxValue)
                        {
                            savedLocations.SearchforLocation(location, 10);
                            savedLocationindex = savedLocations.GetSavedLocationIndex(location);
                        }
                        LocationNames = savedLocations.GetLocationNames(savedLocationindex);
                    }
                    else
                    {
                        LocationNames = savedLocations.GetLocationNames(savedLocationindex);
                    }
                    string geoLocationCountry = LocationNames[0];
                    string geoLocationCity = LocationNames[1];
                    string geoLocation = string.Format("{0},{1}", geoLocationCity, geoLocationCountry);
                    output = output.Replace("%loc%", geoLocation);
                }
                else
                {
                    output = output.Replace("%loc%", "");
                }
            }

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
            // @todo implement this feature
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
                if (regex.IsMatch(file.Name))
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
            string numberformat = settingsForm.numberformat.ToLower();

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
            {
                double doubleresult = Convert.ToDouble(result);
                // @TODO
                // Evaluate that the string format is valid
                if (numberformat.Contains("d") || numberformat.Contains("x"))
                {
                    int numberresult = Convert.ToInt32(doubleresult);
                    return numberresult.ToString(numberformat);
                }
                else
                    return doubleresult.ToString(numberformat);
            }
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
            foreach (string renameditem in listBoxPreview.Items)
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