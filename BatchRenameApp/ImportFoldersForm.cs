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
   
        public ImportFoldersWindow()
        {
            InitializeComponent();
        }

        public void clear()
        {
            treeViewFileslist.Nodes.Clear();
        }

        public void AddFiles(string rootdir, Dictionary<string, object> files)
        {
            parentfolder = rootdir;
            treeViewFileslist.BeginUpdate();
            treeViewFileslist.Nodes.Add(GenerateTreenode(rootdir, files));
            treeViewFileslist.EndUpdate();
        }

        private TreeNode GenerateTreenode(string rootDir, Dictionary<string, object> files)
        {
            FileInfo folderName = new FileInfo(rootDir);
            TreeNode node;
            if (folderName.FullName == parentfolder)
            {
                node = new TreeNode(folderName.FullName);
            }
            else
            {
                node = new TreeNode(folderName.Name);
            }

            foreach (KeyValuePair<string, object> temp in files)
            {
                if (temp.Value.GetType() == typeof(FileInfo))
                {
                    node.Nodes.Add(((FileInfo)temp.Value).Name);
                }
                else
                {
                    FileInfo subfoldername = new FileInfo(temp.Key);
                    node.Nodes.Add(GenerateTreenode(subfoldername.FullName, (Dictionary<string, object>)temp.Value));
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
                list.AddRange(GenerateReply(Node, list));
            }

            return list.ToArray();
        }

       public List<string> GenerateReply(TreeNode root, List<string> output)
        {
            output.Add(root.Text);

            foreach (TreeNode childNode in root.Nodes)
            {
                if (childNode.Nodes.Count > 0)
                {                                       
                    GenerateReply(childNode, output);
                } 
                else
                {
                    output.Add(childNode.Text);
                }
            }
            return output;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
