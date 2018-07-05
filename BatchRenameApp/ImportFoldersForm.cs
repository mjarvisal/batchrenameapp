using System;
using System.Collections;
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
        ArrayList array = new ArrayList();
        
        public ImportFoldersWindow()
        {
            InitializeComponent();
        }


        public void addFiles(string[] files)
        {
            array.AddRange(files);
            foreach (string file in files)
            {
                treeView1.Nodes.Add(file);
            }

        }

    }
}
