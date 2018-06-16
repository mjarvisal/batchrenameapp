using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchRenameApp
{
    static class Program
    {
        static MainWindow mainWindowForm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mainWindowForm = new MainWindow();
            Application.Run(mainWindowForm);
        }
    }
}
