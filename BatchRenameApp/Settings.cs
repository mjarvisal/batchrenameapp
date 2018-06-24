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

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainWindowForm.UpdatePreview();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            dateformat = textBoxDateFormat.Text;
            timeformat = textBoxtimeFormat.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Enter):
                    dateformat = textBoxDateFormat.Text;
                    timeformat = textBoxtimeFormat.Text;
                    this.Close();
                    break;
                case (Keys.Escape):
                    this.Close();
                    break;
            }
        }
    }
}
