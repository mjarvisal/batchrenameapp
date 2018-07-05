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
        public static TreeNode DirSearch(string dir)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(dir);
                TreeNode output = new TreeNode(fileinfo.Name);
                foreach (string d in Directory.GetDirectories(dir))
                {
                    output.Nodes.Add(DirSearch(d));
                }
                foreach (string f in Directory.GetFiles(dir))
                {
                    FileInfo fileinfo2 = new FileInfo(f);                         
                   var node = new TreeNode(fileinfo2.Name);
                   output.Nodes.Add(node);
                }                
                return output;
            }
            catch (Exception)
            {
                return new TreeNode();
            }
        }


    }
}
