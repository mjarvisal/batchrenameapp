using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private SortMode sortMode;


        private Hashtable filetable = new Hashtable();

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

            if (!filetable.ContainsKey(filename))
            {

                switch (sortMode)
                {
                    case SortMode.Asc:
                        files.Add(file);
                        filetable.Add(filename, file);
                        this.SortAsc();
                        break;
                    case SortMode.Desc:
                        files.Add(file);
                        filetable.Add(filename, file);
                        this.SortDesc();
                        break;
                    default:
                        files.Add(file);
                        filetable.Add(filename, file);
                        AddStateToHistory();
                        break;
                }
            }
        }

        public void RemoveFile(string filename)
        {

            if (filetable.ContainsKey(filename))
            {
                files.Remove(filetable[filename]);
                filetable.Remove(filename);
                AddStateToHistory();
            }
        }

        public void SortAsc()
        {
            sortMode = SortMode.Asc;
            IEnumerable sortedfiles = files.Cast<FileInfo>().ToArray().OrderBy(x => x.FullName);
            files.Clear();
            foreach (FileInfo file in sortedfiles)
            {
                files.Add(file);
            }
            AddStateToHistory();

        }

        public void SortDesc()
        {
            sortMode = SortMode.Desc;
            IEnumerable sortedfiles = files.Cast<FileInfo>().ToArray().OrderByDescending(x => x.FullName);
            files.Clear();
            foreach (FileInfo file in sortedfiles)
            {
                files.Add(file);
            }
            AddStateToHistory();
        }


        public void ResetSort()
        {
            sortMode = SortMode.None;
            files.Clear();
            foreach (FileInfo fileinfo in filetable.Values)
            {
                files.Add(fileinfo);
            }
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
                files = (ArrayList)files.Clone(),
                sortMode = sortMode
            };
            history.Push(snapshot);
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

        public string ProcessRegex(int index, string find, string replace, string function, FileInfo file)
        {
            try
            {
                Regex regex = new Regex(find);
                return ProcessPatterns(index, regex.Replace(file.Name, replace), function, file);
            }
            catch (ArgumentException)
            {
                return file.Name;
            }
        }

        public string ProcessPatterns(int index, string text, string function, FileInfo file)
        {

            string output = text.Replace("%file%", file.Name);
            output = output.Replace("%folder%", file.Directory.Name);
            output = output.Replace("%date%", DateTime.Now.ToShortDateString());
            output = output.Replace("%time%", DateTime.Now.ToLongTimeString());
            output = output.Replace("%fnc%", EvaluateFunctionString(function, index));

            return output;
        }
        private string EvaluateFunctionString(string sFunction, int index)
        {
            string expression = "x";
            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl{Language = "VBScript"};
            if (sFunction.Length > 0)
            {
                expression = sFunction.Replace("x", index.ToString());
            }
            else
            {
                expression = expression.Replace("x", index.ToString());
            }

            object result = null;

            try
            {
                result = sc.Eval(expression);
            }
            catch (Exception)
            {
                result = sc.Eval("0");
            }
            return result.ToString();
        }
    }
}
