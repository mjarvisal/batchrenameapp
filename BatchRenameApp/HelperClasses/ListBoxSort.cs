using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace BatchRenameApp
{

    enum SortMode { None, Asc, Desc };
    enum Copying { from, to };

    public class ListBoxSort
    {
        private static String SortFilter = "^";

        private class myDescSortClass : IComparer
        {

            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(Object x, Object y)
            {
                FileInfo File1 = (FileInfo)x;
                FileInfo File2 = (FileInfo)y;

                return ((new CaseInsensitiveComparer()).Compare(RegexFilter(SortFilter, File2.Name), RegexFilter(SortFilter, File1.Name)));
            }
        }
        private class myAscSortClass : IComparer
        {

            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(Object x, Object y)
            {
                FileInfo File1 = (FileInfo)x;
                FileInfo File2 = (FileInfo)y;
                return ((new CaseInsensitiveComparer()).Compare(RegexFilter(SortFilter, File1.Name), RegexFilter(SortFilter, File2.Name)));
            }
        }

        public static void SortAsc(ListBox itemsListBox, String Text)
        {
            IComparer Asc = new myAscSortClass();
            ArrayList sortedList = new ArrayList();
            foreach (object item in itemsListBox.Items)
            {
                sortedList.Add(item);
            }
            SortFilter = Text;
            sortedList.Sort(Asc);
            itemsListBox.Items.Clear();

            foreach (object item in sortedList)
            {
                itemsListBox.Items.Add(item);
            }

        }

        public static void SortDesc(ListBox itemsListBox, String Text)
        {
            IComparer Desc = new myDescSortClass();
            ArrayList sortedList = new ArrayList();
            foreach (FileInfo item in itemsListBox.Items)
            {
                sortedList.Add(item);
            }
            SortFilter = Text;
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


        private static String RegexFilter(String Filter, String Text)
        {
            bool bValidregex = false;

            Regex regex = new Regex("^");

            if (Filter.Length > 0)
            {
                try
                {
                    regex = new Regex(Filter);
                    bValidregex = true;
                }
                catch (ArgumentException)
                {

                }
            }

            if (bValidregex)
            {
                if (regex.IsMatch(Text))
                {
                    MatchCollection collection = regex.Matches(Text);
                    int i = collection.Count-1;
                    if (collection.Count > 0)
                        return collection[i].Value;
                }
                return Text;
            }
            return Text;
        }


        public static CharacterRange GetFilterRange(String Filter, String Text)
        {
            bool bValidregex = false;

            Regex regex = new Regex("^");

            if (Filter.Length > 0)
            {
                try
                {
                    regex = new Regex(Filter);
                    bValidregex = true;
                }
                catch (ArgumentException)
                {

                }
            }

            if (bValidregex)
            {
                if (regex.IsMatch(Text))
                {
                    MatchCollection collection = regex.Matches(Text);
                    int i = collection.Count - 1;
                    if (collection.Count > 0)
                        return new CharacterRange(collection[i].Index, collection[i].Length);
                }
                return new CharacterRange(0, 0);
            }
            return new CharacterRange(0, 0);
        }

    }
}
