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
                } catch (Exception e)
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
            if (file.Attributes == FileAttributes.Directory)
            {
                throw new Exception("item is directory");
            }
                if (!file.Exists)
            {
                throw new Exception("file '"+file.Name+"' doesn't exists!");
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
                    return;
                }
                x += 1;
            }
        }

        private void listBoxFilelist_SelectedIndexChanged(object sender, EventArgs e)
        { 

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

        private void button1_Click(object sender, EventArgs e)
        {
            UpdatePreview();
        }


        private void UpdatePreview()
        {
            listBoxPreview.Items.Clear();

            foreach (FileInfo file in files)
            {
                try
                {
                    Regex regex = new Regex(inputSearch.Text);
                    listBoxPreview.Items.Add(file.Directory + "\\" + regex.Replace(file.Name, inputReplace.Text));
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            if ( listBoxPreview.Items.Count == 0) {
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
    }
}
