using System;
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

        public void clear()
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
            treeViewFileslist.BeginUpdate();
            tempFolderTreeDepth = 0;
            foreach (KeyValuePair<string, object> values in originalFiles)
            {
                parentfolder = values.Key;
                treeViewFileslist.Nodes.Add(GenerateTreenode(values.Key, (Dictionary<string, object>)values.Value, maxDepth));
            }           
            treeViewFileslist.EndUpdate();
            
        }


        private TreeNode GenerateTreenode(string rootDir, Dictionary<string, object> files)
        {
            return GenerateTreenode(rootDir, files, 20);
        }

        private TreeNode GenerateTreenode(string rootDir, Dictionary<string, object> files, int maxDepth)
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

            foreach (KeyValuePair<string, object> temp in files)
            {
                // check if the value type is file
                if (temp.Value.GetType() == typeof(FileInfo))
                {
                    node.Nodes.Add(((FileInfo)temp.Value).Name);   // add plain filename
                }
                else
                {
                    // check if the value is a subfolder
                    if (temp.Value.GetType() == typeof(Dictionary<string, object>))
                    {
                        // cast 
                        var subfolderObject = (Dictionary<string, object>)temp.Value;
                        // if subfolder has files, add them, othervice do nothing
                        if (subfolderObject.Count > 0)
                        {
                            if (tempFolderTreeDepth < maxDepth)
                            {
                                tempFolderTreeDepth += 1;
                                if (tempFolderTreeDepth > folderTreeDepthMax)
                                {
                                    folderTreeDepthMax = tempFolderTreeDepth;
                                    textBoxFolderDepth.Text = "" + folderTreeDepthMax;
                                }
                                node.Nodes.Add(GenerateTreenode(temp.Key, subfolderObject, maxDepth)); // temp.key has full folder name.
                                tempFolderTreeDepth -= 1;
                            }
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public string[] getFiles()
        {

            List<string> list = new List<string>();
            foreach (TreeNode Node in treeViewFileslist.Nodes)
            {
                // hold temporarily root folder
                parentfolder = Node.Text;
                list.AddRange(GenerateReply(Node, list));
            }

            return list.ToArray();
        }

        // generate back the original file names from the treenode structure.
        public List<string> GenerateReply(TreeNode root, List<string> output)
        {
            string folder = "";
            if (root.Text == parentfolder)
            {
                folder = parentfolder;
            }
            else
            {
                folder = parentfolder + "\\" + root.Text;
            }

            foreach (TreeNode childNode in root.Nodes)
            {
                if (childNode.Nodes.Count > 0)
                {
                    GenerateReply(childNode, output);
                }
                else
                {
                    output.Add(folder + "\\" + childNode.Text);
                }
            }

            return output;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void treeViewFileslist_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                treeViewFileslist.SelectedNode.Remove();
            }
        }

        private void trackBarFolderDepth_ValueChanged(object sender, EventArgs e)
        {
            clear();
            int value = trackBarFolderDepth.Value;
            textBoxFolderDepth.Text = ""+ value;
            UpdateFoldersWithDepth(value);
        }
    }
}
