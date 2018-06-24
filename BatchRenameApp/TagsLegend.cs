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
    public partial class TagsLegend : Form
    {
        private TextBox inputReplace = Program.mainWindowForm.inputReplace;
        public TagsLegend()
        {
            InitializeComponent();
        }

        private void Taglabeldatenow_Click(object sender, EventArgs e)
        {
            string insertText = "%datenow%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void Taglabeltimenow_Click(object sender, EventArgs e)
        {
            string insertText = "%timenow%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void Taglabeldatecreated_Click(object sender, EventArgs e)
        {
            string insertText = "%datecreated%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void Taglabeltimecreated_Click(object sender, EventArgs e)
        {
            string insertText = "%timecreated%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void Taglabeldatetaken_Click(object sender, EventArgs e)
        {
            string insertText = "%datetaken%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void Taglabeltimetaken_Click(object sender, EventArgs e)
        {
            string insertText = "%timetaken%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void Taglabelfolder_Click(object sender, EventArgs e)
        {
            string insertText = "%folder%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void Taglabelfile_Click(object sender, EventArgs e)
        {
            string insertText = "%file%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void Taglabelfunction_Click(object sender, EventArgs e)
        {
            string insertText = "%fnc%";
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, insertText);
            inputReplace.SelectionStart = Cursorlocation + insertText.Length;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
