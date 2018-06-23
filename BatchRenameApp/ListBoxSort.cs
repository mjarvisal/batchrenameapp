using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace BatchRenameApp
{

    enum SortMode { None, Asc, Desc };
    enum Copying { from, to };

    public class ListBoxSort
    {

        private class myDescSortClass : IComparer
        {

            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(Object x, Object y)
            {
                FileInfo filex = (FileInfo)x;
                FileInfo filey = (FileInfo)y;
                return ((new CaseInsensitiveComparer()).Compare(filey.Name, filex.Name));
            }
        }
        private class myAscSortClass : IComparer
        {

            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(Object x, Object y)
            {
                FileInfo filex = (FileInfo)x;
                FileInfo filey = (FileInfo)y;
                return ((new CaseInsensitiveComparer()).Compare(filex.Name, filey.Name));
            }
        }
        public static void SortAsc(ListBox itemsListBox)
        {
            IComparer Asc = new myAscSortClass();
            ArrayList sortedList = new ArrayList();
            foreach (object item in itemsListBox.Items)
            {
                sortedList.Add(item);
            }

            sortedList.Sort(Asc);
            itemsListBox.Items.Clear();
            foreach (object item in sortedList)
            {
                itemsListBox.Items.Add(item);
            }

        }

        public static void SortDesc(ListBox itemsListBox)
        {
            IComparer Desc = new myDescSortClass();
            ArrayList sortedList = new ArrayList();
            foreach (FileInfo item in itemsListBox.Items)
            {
                sortedList.Add(item);
            }

            sortedList.Sort(Desc);
            itemsListBox.Items.Clear();
            foreach (object item in sortedList)
            {
                itemsListBox.Items.Add(item);
            }
        }

        public static void Swap(ListBox itemsListBox, int from, int to)
        {
            String[] itemstorage = new String[2];
            itemstorage[(int)Copying.from] = itemsListBox.Items[from].ToString();
            itemstorage[(int)Copying.to] = itemsListBox.Items[to].ToString();
            itemsListBox.Items[(int)Copying.to] = Program.mainWindowForm.filestorage.GetFileInfo(itemstorage[from]);
            itemsListBox.Items[(int)Copying.from] = Program.mainWindowForm.filestorage.GetFileInfo(itemstorage[to]);
        }
    }
}
