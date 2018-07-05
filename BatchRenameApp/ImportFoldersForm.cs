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

   
        public ImportFoldersWindow()
        {
            InitializeComponent();
        }

        public void clear()
        {
            treeView1.Nodes.Clear();
        }

        public void AddFiles(string dir, Dictionary<string, object> files)
        {
            treeView1.BeginUpdate();                       
            treeView1.Nodes.Add(GenerateTreenode(dir, files));
            treeView1.EndUpdate();
        }

        private TreeNode GenerateTreenode(string rootDir, Dictionary<string, object> files)
        {
            var node = new TreeNode(rootDir);

            foreach (KeyValuePair<string, object> temp in files)
            {
                if (temp.Value.GetType() == typeof(FileInfo))
                {
                    node.Nodes.Add(((FileInfo)temp.Value).FullName);
                }
                else
                {
                    node.Nodes.Add(GenerateTreenode(temp.Key, (Dictionary<string, object>)temp.Value));
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
            foreach (TreeNode Node in treeView1.Nodes)
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


        private void CancelButton_Click(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }
    }
}
