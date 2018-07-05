using System;
using System.Collections;
using System.IO;

namespace BatchRenameApp
{

    public class FilenameStorage
    {

        private static Hashtable filetable = new Hashtable();

        /**
         * ArrayList files, array of string holding the full filename with path.
         * we use this mainly
         * 
         */
        private static ArrayList files = new ArrayList();

        public void AddFile(string[] filename)
        {
            foreach (string file in filename)
            {
                try
                {
                    AddFile(file);
                } catch (Exception)
                {

                }
            }
        }

        public void AddFile(string filename)
        {
            FileInfo file = new FileInfo(filename);

            if (!file.Exists)
            {
                throw new Exception("file '" + file.Name + "' doesn't exists!");
            }

            else if (file.Attributes.HasFlag(FileAttributes.Directory))
            {
                throw new Exception("item is directory");
            }

            if (!filetable.ContainsKey(filename))
            {
                files.Add(file);
                filetable.Add(filename, file);
            }
        }

        public void RemoveFile(string filename)
        {

            if (filetable.ContainsKey(filename))
            {
                files.Remove(filetable[filename]);
                filetable.Remove(filename);
            }
        }

        public void Clear()
        {
            files.Clear();
            filetable.Clear();
        }

        public ArrayList GetFiles()
        {
            ArrayList outList = new ArrayList();
            foreach (FileInfo file in files)
            {
                outList.Add(file.FullName);
            }

            return outList;
        }

        public ArrayList GetFileInfos()
        {
            return files;
        }

        public FileInfo GetFileInfo(string file)
        {
            try
            {
                return (FileInfo)filetable[file];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Contains(string filename)
        {
            if (filetable.ContainsKey(filename))
            {
                return true;
            }
            return false;
        }
    }
}
