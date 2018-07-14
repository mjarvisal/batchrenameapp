using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

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

            string SearchText = "^";
            Regex regex = new Regex(Filter);

            if (Text.Length > 0)
            {
                SearchText = Text;
            }

            try
            {
                regex = new Regex(SearchText);
                bValidregex = true;
            }
            catch (ArgumentException)
            {

            }

            if (bValidregex)
            {
                if (regex.IsMatch(Text))
                {
                    MatchCollection collection = regex.Matches(Text);
                    if (collection.Count > 0)
                        return collection[0].Value;
                }
                return Text;
            }
            return Text;
        }

    }
}
