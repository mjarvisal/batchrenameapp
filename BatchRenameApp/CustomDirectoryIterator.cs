using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace BatchRenameApp
{
    class CustomDirectoryIterator
    {
        public static Dictionary<string, object> DirSearch(string dir)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(dir);
                Dictionary<string, object> output = new Dictionary<string, object>();
                foreach (string d in Directory.GetDirectories(dir))
                {
                    output.Add(d, DirSearch(d));
                }
                foreach (string f in Directory.GetFiles(dir))
                {
                   FileInfo fileinfo2 = new FileInfo(f);                                      
                   output.Add(f, fileinfo2);
                }                
                return output;
            }
            catch (Exception)
            {
                return new Dictionary<string, object>();
            }
        }


    }
}
