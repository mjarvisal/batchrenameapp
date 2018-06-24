using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BatchRenameApp
{
    public partial class Settings : Form
    {
        public string dateformat = "yyyy-MM-dd";
        public string timeformat = "HH.mm.ss";

        public Settings()
        { 
            InitializeComponent();
        }

        private void textBoxDateFormat_TextChanged(object sender, EventArgs e)
        {
            dateformat = textBoxDateFormat.Text;
        }

        private void textBoxtimeFormat_TextChanged(object sender, EventArgs e)
        {
            timeformat = textBoxDateFormat.Text;
        }
    }
}
