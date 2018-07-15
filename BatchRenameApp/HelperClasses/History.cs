using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace BatchRenameApp
{
    enum UndoType { List, Selection};


    class UndoObject
    {
        public ArrayList items;
        public ArrayList selecteditems;
    }

    class History
    {
        /** For undoing operations */
        private static Stack<UndoObject> history = new Stack<UndoObject>(100);
        private static Stack<UndoObject> redo = new Stack<UndoObject>(100);

        public static void Clear()
        {
            history.Clear();
            redo.Clear();
        }

        public static void Redo(ListBox itemsListBox)
        {
            if (redo.Count > 0)
            {
                ArrayList listofitems = new ArrayList();
                ArrayList listofselecteditems = new ArrayList();
                foreach (object item in itemsListBox.Items)
                {
                    listofitems.Add(item);
                }
                foreach (object item in itemsListBox.SelectedItems)
                {
                    listofselecteditems.Add(item);
                }
                UndoObject undosnapshot = new UndoObject
                {
                    items = listofitems,
                    selecteditems = listofselecteditems
                };
                history.Push(undosnapshot);

                UndoObject snapshot = redo.Pop();
                if (snapshot.items != null)
                {
                    itemsListBox.Items.Clear();
                    Program.mainWindowForm.filestorage.Clear();
                    foreach (object item in snapshot.items)
                    {
                        itemsListBox.Items.Add(item);
                        FileInfo file = (FileInfo)item;
                        Program.mainWindowForm.filestorage.AddFile(file.FullName);
                    }
                }

                if (snapshot.selecteditems != null)
                {
                    itemsListBox.SelectedItems.Clear();
                    foreach (object item in snapshot.selecteditems)
                    {
                        itemsListBox.SelectedItems.Add(item);
                    }
                }
            }
        }

        public static void Undo(ListBox itemsListBox)
        {
            if (history.Count > 0)
            {
                ArrayList listofitems = new ArrayList();
                ArrayList listofselecteditems = new ArrayList();
                foreach (object item in itemsListBox.Items)
                {
                    listofitems.Add(item);
                }
                foreach (object item in itemsListBox.SelectedItems)
                {
                    listofselecteditems.Add(item);
                }
                UndoObject redosnapshot = new UndoObject
                {
                    items = listofitems,
                    selecteditems = listofselecteditems
                };
                redo.Push(redosnapshot);

                UndoObject snapshot = history.Pop();
                if (snapshot.items != null)
                {
                    itemsListBox.Items.Clear();
                    Program.mainWindowForm.filestorage.Clear();
                    foreach (object item in snapshot.items)
                    {
                        itemsListBox.Items.Add(item);
                        FileInfo file = (FileInfo)item;
                        Program.mainWindowForm.filestorage.AddFile(file.FullName);
                    }
                }

                if (snapshot.selecteditems != null)
                {
                    itemsListBox.SelectedItems.Clear();
                    foreach (object item in snapshot.selecteditems)
                    {
                        itemsListBox.SelectedItems.Add(item);
                    }
                }
            }
        }

        #region Push
        public static void Push(ListBox itemsListBox)
        {
            ArrayList listofitems = new ArrayList();
            ArrayList listofselecteditems = new ArrayList();
            foreach (object item in itemsListBox.Items)
            {
                listofitems.Add(item);
            }
            foreach (object item in itemsListBox.SelectedItems)
            {
                listofselecteditems.Add(item);
            }
            UndoObject snapshot = new UndoObject
            {
                items = listofitems,
                selecteditems = listofselecteditems
            };
            redo.Clear();
            history.Push(snapshot);
        }

        public static void Push(ListBox.ObjectCollection inputfiles, ListBox.SelectedObjectCollection selectedinputfiles)
        {
            ArrayList listofitems = new ArrayList();
            ArrayList listofselecteditems = new ArrayList();
            foreach (object item in inputfiles)
            {
                listofitems.Add(item);
            }
            foreach (object item in selectedinputfiles)
            {
                listofselecteditems.Add(item);
            }
            UndoObject snapshot = new UndoObject
            {
                items = listofitems,
                selecteditems = listofselecteditems
            };
            redo.Clear();
            history.Push(snapshot);
        }

        public static void Push(ListBox.ObjectCollection inputfiles)
        {
            if (inputfiles.Count >= 0)
            {
                ArrayList listofitems = new ArrayList();
                foreach (object item in inputfiles)
                {
                    listofitems.Add(item);
                }
                UndoObject snapshot = new UndoObject
                {
                    items = listofitems,
                    selecteditems = null
                };
                redo.Clear();
                history.Push(snapshot);
            }
        }

        public static void Push(ListBox.SelectedObjectCollection inputfiles)
        {
            if (inputfiles.Count >= 0)
            {
                ArrayList listofitems = new ArrayList();
                foreach (object item in inputfiles)
                {
                    listofitems.Add(item);
                }
                UndoObject snapshot = new UndoObject
                {
                    items = null,
                    selecteditems = listofitems
                };
                redo.Clear();
                history.Push(snapshot);
            }
        }

        public static void Push(UndoObject snapshot)
        {
            if (snapshot != null)
            {
                if (snapshot.items.Count > 0)
                {
                    redo.Clear();
                    history.Push(snapshot);
                }
            }
        }
        #endregion

    }
}
