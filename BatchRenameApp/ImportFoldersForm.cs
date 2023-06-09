﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BatchRenameApp
{
    public partial class ImportFoldersWindow : Form
    {

        private static string parentfolder = "";
        private int folderTreeDepthMax = 0;
        private int tempFolderTreeDepth = 0;
        Dictionary<string, object> originalFiles = new Dictionary<string, object>();

        public ImportFoldersWindow()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            folderTreeDepthMax = 0;
            treeViewFileslist.Nodes.Clear();
        }

        public void AddFiles(Dictionary<string, object> files)
        {
            originalFiles = files;
            tempFolderTreeDepth = 0;
            treeViewFileslist.BeginUpdate();
            foreach (KeyValuePair<string, object> values in files)
            {
                parentfolder = values.Key;
                treeViewFileslist.Nodes.Add(GenerateTreenode(values.Key, (Dictionary<string, object>)values.Value));
            }
            treeViewFileslist.EndUpdate();
            trackBarFolderDepth.Maximum = folderTreeDepthMax;
            trackBarFolderDepth.Value = folderTreeDepthMax;
        }

        public void UpdateFoldersWithDepth(int maxDepth)
        {
            tempFolderTreeDepth = 0;
            foreach (KeyValuePair<string, object> values in originalFiles)
            {
                parentfolder = values.Key;
                treeViewFileslist.Nodes.Add(GenerateTreenode(values.Key, (Dictionary<string, object>)values.Value, maxDepth));
            }
        }


        private TreeNode GenerateTreenode(string rootDir, Dictionary<string, object> files)
        {
            return GenerateTreenode(rootDir, files, 20);
        }

        private TreeNode GenerateTreenode(string rootDir, Dictionary<string, object> itemsdict, int maxDepth)
        {

            FileInfo folderName = new FileInfo(rootDir);
            TreeNode node;
            // check for first recursion
            if (folderName.FullName == parentfolder)
            {
                node = new TreeNode(folderName.FullName); // add full folder name
                node.Expand();
            }
            else
            {
                node = new TreeNode(folderName.Name); // add only subfolder name
                node.Expand();
            }

            foreach (KeyValuePair<string, object> keyvalpair in itemsdict)
            {
                // check if the value type is file
                if (keyvalpair.Value.GetType() == typeof(FileInfo))
                {
                    DirectoryInfo testdirectory = new DirectoryInfo(((FileInfo)keyvalpair.Value).FullName);
                    if ((testdirectory.Attributes & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        node.Nodes.Add(((FileInfo)keyvalpair.Value).Name);   // add plain filename
                    }
                }
                else
                {
                    // check if the value is a subfolder
                    if (keyvalpair.Value.GetType() == typeof(Dictionary<string, object>))
                    {
                        // cast 
                        var subfolderObject = (Dictionary<string, object>)keyvalpair.Value;
                        if (tempFolderTreeDepth < maxDepth)
                        { 
                            tempFolderTreeDepth += 1;
                            if (tempFolderTreeDepth > folderTreeDepthMax)
                            {
                                folderTreeDepthMax = tempFolderTreeDepth;
                                textBoxFolderDepth.Text = "" + folderTreeDepthMax;
                            }
                            node.Nodes.Add(GenerateTreenode(keyvalpair.Key, subfolderObject, maxDepth)); // temp.key has full folder name.
                            tempFolderTreeDepth -= 1;
                        }
                    }
                }
            }
            return node;
        }

        private TreeNode GenerateTreenode(Dictionary<string, object> files)
        {
            return GenerateTreenode("", files);
        }

        public string[] GetFiles()
        {

            List<string> list = new List<string>();
            foreach (TreeNode Node in treeViewFileslist.Nodes)
            {
                // hold temporarily root folder
                parentfolder = Node.Text;
                list.AddRange(GenerateReply(Node));
            }

            return list.ToArray();
        }

        // generate back the original file names from the treenode structure.
        public List<string> GenerateReply(TreeNode root)
        {
            List<string> output = new List<string>();
            foreach (TreeNode childNode in root.Nodes)
            {
                if (childNode.Nodes.Count > 0)
                {
                    GenerateReply(childNode, output);
                }
                else
                {
                    DirectoryInfo isdirectory = new DirectoryInfo(childNode.FullPath);
                    if ((isdirectory.Attributes & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        output.Add(childNode.FullPath);
                    }
                }
            }
            return output;
        }

        public List<string> GenerateReply(TreeNode root, List<string> output)
        {
            foreach (TreeNode childNode in root.Nodes)
            {
                if (childNode.Nodes.Count > 0)
                {
                    GenerateReply(childNode, output);
                }
                else
                {
                    DirectoryInfo isdirectory = new DirectoryInfo(childNode.FullPath);
                    if ((isdirectory.Attributes & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        output.Add(childNode.FullPath);
                    }
                }
            }

            return output;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TreeViewFileslist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                treeViewFileslist.SelectedNode.Remove();
            }
        }

        private void TrackBarFolderDepth_ValueChanged(object sender, EventArgs e)
        {

            treeViewFileslist.BeginUpdate();
            Clear();
            int value = trackBarFolderDepth.Value;
            textBoxFolderDepth.Text = "" + value;
            UpdateFoldersWithDepth(value);
            treeViewFileslist.EndUpdate();
        }
    }
}
