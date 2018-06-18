using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BatchRenameApp
{

    enum SortMode { None, Asc, Desc };

    class UndoObject
    {
        public ArrayList files;
        public SortMode sortMode;
    }

    class FilenameStorage
    {

        /** used for undoing operations */
        private Stack<UndoObject> history = new Stack<UndoObject>(100);
        public SortMode sortMode;

        /**
         * This is used to undo operations.
         * */
        private ArrayList originalOrderedFiles = new ArrayList();

        /**
         * ArrayList files, array of string holding the full filename with path.
         * we use this mainly
         * 
         */
        private ArrayList files = new ArrayList();


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

            if (!originalOrderedFiles.Contains(filename))
            {

                originalOrderedFiles.Add(filename);

                switch (sortMode)
                {
                    case SortMode.Asc:
                        files.Add(filename);
                        this.SortAsc();
                        break;
                    case SortMode.Desc:
                        files.Add(filename);
                        this.SortDesc();
                        break;
                    default:
                        files.Add(filename);
                        AddStateToHistory();
                        break;
                }
            }

        }

        public void RemoveFile(string filename)
        {
            if (originalOrderedFiles.Contains(filename))
            {
                files.Remove(filename);
                originalOrderedFiles.Remove(filename);
                AddStateToHistory();
            }
        }

        public void SortAsc()
        {
            sortMode = SortMode.Asc;
            IEnumerable sortedfiles = files.ToArray().OrderBy(x => x);
            files.Clear();
            foreach (string file in sortedfiles)
            {
                files.Add(file);
            }
            AddStateToHistory();

        }

        public void SortDesc()
        {
            sortMode = SortMode.Desc;
            IEnumerable sortedfiles = files.ToArray().OrderByDescending(x => x);
            files.Clear();
            foreach (string file in sortedfiles)
            {
                files.Add(file);
            }
            AddStateToHistory();
        }


        public void ResetSort()
        {
            sortMode = SortMode.None;
            files = originalOrderedFiles;
            AddStateToHistory();

        }


        public void Swap(int from, int to)
        {
            sortMode = SortMode.None;
            Object tmp = files[from];
            files[from] = files[to];
            files[to] = tmp;
            AddStateToHistory();
        }

        public void Undo()
        {
            if (history.Count > 0)
            {
                UndoObject snapshot = history.Pop();
                files = snapshot.files;
                sortMode = snapshot.sortMode;
            }
        }

        public void AddStateToHistory()
        {
            UndoObject snapshot = new UndoObject
            {
                files = files,
                sortMode = sortMode
            };
            history.Push(snapshot);           
        }
       
        public ArrayList GetFiles()
        {
            return files;
        }

    }
}
