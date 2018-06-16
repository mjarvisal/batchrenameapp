using System;
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
    public partial class MainWindow : Form
    {
        string[] args;
        public MainWindow()
        {
            InitializeComponent();
            listBoxFilelist.Items.AddRange(GetArgs());
        }
        private string[] GetArgs()
        {
            args = Environment.GetCommandLineArgs();
            args = args.Skip(1).ToArray();
            return args;
        }
    }
}
