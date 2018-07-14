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

        private void InsertText(string text)
        {
            int Cursorlocation = inputReplace.SelectionStart;
            inputReplace.Text = inputReplace.Text.Insert(Cursorlocation, text);
            inputReplace.SelectionStart = Cursorlocation + text.Length;
        }

        private void Taglabeldatenow_Click(object sender, EventArgs e)
        {
            InsertText("%datenow%");
        }

        private void Taglabeltimenow_Click(object sender, EventArgs e)
        {
            InsertText("%timenow%");
        }

        private void Taglabeldatecreated_Click(object sender, EventArgs e)
        {
            InsertText("%datecreated%");
        }

        private void Taglabeltimecreated_Click(object sender, EventArgs e)
        {
            InsertText("%timecreated%");
        }

        private void Taglabeldatetaken_Click(object sender, EventArgs e)
        {
            InsertText("%datetaken%");
        }

        private void Taglabeltimetaken_Click(object sender, EventArgs e)
        {
            InsertText("%timetaken%");
        }

        private void Taglabelfolder_Click(object sender, EventArgs e)
        {
            InsertText("%folder%");
        }

        private void Taglabelfile_Click(object sender, EventArgs e)
        {
            InsertText("%file%");
        }

        private void Taglabelfunction_Click(object sender, EventArgs e)
        {
            InsertText("%fnc%");
        }

        private void Tagelabelext_Click(object sender, EventArgs e)
        {
            InsertText("%ext%");
        }

        private void Taglabelloc_Click(object sender, EventArgs e)
        {
            InsertText("%loc%");
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
