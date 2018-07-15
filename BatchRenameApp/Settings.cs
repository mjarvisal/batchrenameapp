using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BatchRenameApp
{
    public partial class Settings : Form
    {

        public Settings()
        { 
            InitializeComponent();
            textBoxNumberformat.Text = Properties.Settings.Default.NumberFormat;
            textBoxDateFormat.Text = Properties.Settings.Default.DateFormat;
            textBoxtimeFormat.Text = Properties.Settings.Default.TimeFormat;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.mainWindowForm.UpdatePreview();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
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
                    SaveSettings();
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

        private void SaveSettings()
        {
            Properties.Settings.Default.DateFormat = textBoxDateFormat.Text;
            Properties.Settings.Default.TimeFormat = textBoxtimeFormat.Text;
            Properties.Settings.Default.NumberFormat = textBoxNumberformat.Text;
            Properties.Settings.Default.Save();
        }

    }
}
