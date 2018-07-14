using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BatchRenameApp
{
    public partial class Settings : Form
    {
        public string dateformat = "yyyy-MM-dd";
        public string timeformat = "HH.mm.ss";
        public string numberformat = "D2";

        public Settings()
        { 
            InitializeComponent();
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainWindowForm.UpdatePreview();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            dateformat = textBoxDateFormat.Text;
            timeformat = textBoxtimeFormat.Text;
            numberformat = textBoxNumberformat.Text;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
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
                    numberformat = textBoxNumberformat.Text;
                    this.Close();
                    break;
                case (Keys.Escape):
                    this.Close();
                    break;
            }
        }

        private void LabelNumberHelp_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings");
        }

        private void LabelNumberHelp_MouseEnter(object sender, EventArgs e)
        {
            labelNumberHelp.Font = new Font(labelNumberHelp.Font, FontStyle.Underline);
        }

        private void LabelNumberHelp_MouseLeave(object sender, EventArgs e)
        {
            labelNumberHelp.Font = new Font(labelNumberHelp.Font, FontStyle.Regular);
        }
    }
}
