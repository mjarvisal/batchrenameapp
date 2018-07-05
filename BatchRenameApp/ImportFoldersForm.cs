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

namespace BatchRenameApp
{
    public partial class ImportFoldersWindow : Form
    {
        List<string[]> array = new List<string[]>();
        
        public ImportFoldersWindow()
        {
            InitializeComponent();
        }


        public void AddFiles(TreeNode[] files)
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            foreach (TreeNode file in files)
            {
                treeView1.Nodes.Add(file);
            }            
            treeView1.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
