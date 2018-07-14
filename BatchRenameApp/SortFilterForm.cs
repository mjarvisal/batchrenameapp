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
    public partial class SortFilterForm : Form
    {
        public SortFilterForm()
        {
            InitializeComponent();
            textBox1.Text = Program.mainWindowForm.SortFilter;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Program.mainWindowForm.SortFilter = textBox1.Text;
            Program.mainWindowForm.UpdatePreview();
            Program.mainWindowForm.listBoxFilelist.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.mainWindowForm.SortFilesAsc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.mainWindowForm.SortFilesDesc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
