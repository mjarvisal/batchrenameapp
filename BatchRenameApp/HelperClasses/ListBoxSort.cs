using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace BatchRenameApp
{

    public enum SortMode { None, Asc, Desc };
    public enum Copying { from, to };

    public class ListBoxSort
    {
        private static String SortFilter = "^";

        private class MyDescSortClass : IComparer
        {

            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(Object x, Object y)
            {
                FileInfo File1 = (FileInfo)x;
                FileInfo File2 = (FileInfo)y;

                return ((new CaseInsensitiveComparer()).Compare(RegexFilter(SortFilter, File2.Name), RegexFilter(SortFilter, File1.Name)));
            }
        }
        private class MyAscSortClass : IComparer
        {

            // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(Object x, Object y)
            {
                FileInfo File1 = (FileInfo)x;
                FileInfo File2 = (FileInfo)y;
                return ((new CaseInsensitiveComparer()).Compare(RegexFilter(SortFilter, File1.Name), RegexFilter(SortFilter, File2.Name)));
            }
        }

        public static void FilterSelection(ListBox listBox, String filter)
        {
            listBox.ClearSelected();
            listBox.BeginUpdate();
            for (int x = 0; x < listBox.Items.Count; x++)
            {
                if (IsMatch(filter, ((FileInfo)listBox.Items[x]).Name) )
                {
                    listBox.SetSelected(x, true);
                }
            }
            listBox.EndUpdate();
        }

        public static void SortList(SortMode mode, ListBox itemsListBox, String Filter, bool isSelection)
        {

            IComparer comparer = new MyAscSortClass();

            switch (mode)
            {
                case SortMode.Desc:
                    comparer = new MyDescSortClass();
                    break;
            }

            ArrayList sortedList = new ArrayList();
            ArrayList notSortedList = new ArrayList();
            int x = 0;
            foreach (object item in itemsListBox.Items)
            {
                if (isSelection)
                {
                    if (itemsListBox.GetSelected(x))
                    {
                        sortedList.Add(item);
                    }
                    else
                    {
                        notSortedList.Add(item);
                    }
                }
                else
                {
                    sortedList.Add(item);
                }
                x++;
            }
            SortFilter = Filter;
            sortedList.Sort(comparer);
            itemsListBox.Items.Clear();

            itemsListBox.BeginUpdate();
            int i = 0;
            foreach (object item in sortedList)
            {
                itemsListBox.Items.Add(item);
                if (isSelection)
                {
                    itemsListBox.SetSelected(i++, true);
                }
            }

            foreach (object item in notSortedList)
            {
                itemsListBox.Items.Add(item);
            }

            itemsListBox.EndUpdate();
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
            if (Filter == "")
                Filter = "^.+";

            RegexHelper regex = new RegexHelper(Filter);
            if (regex.bIsValidRegex)
            {
                MatchCollection collection = regex.GetMatches(Text);
                if (collection.Count > 0)
                    return collection[collection.Count - 1].Value;
            }
            return Text;
        }


        public static CharacterRange GetFilterRange(String Filter, String Text)
        {

            RegexHelper regex = new RegexHelper(Filter);
            if (regex.bIsValidRegex)
            {
                MatchCollection collection = regex.GetMatches(Text);
                if (collection.Count > 0)
                {
                    int i = collection.Count - 1;
                    return new CharacterRange(collection[i].Index, collection[i].Length);
                }
            }
            return new CharacterRange(0, 0);
        }

        private static bool IsMatch(String Filter, String Text)
        {
            RegexHelper checkRegex = new RegexHelper(Filter);
            Regex regex = checkRegex.GetRegex();

            if (checkRegex.bIsValidRegex)
            {
                if (regex.IsMatch(Text))
                {
                    return true;
                }
            }
            return false;
        }

    }

}
