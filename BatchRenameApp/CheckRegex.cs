using System.Text.RegularExpressions;

namespace BatchRenameApp
{
    public class CheckRegex
    {
        private Regex regex;
        public bool bIsValidRegex = false;

        public CheckRegex(string Filter)
        {
            try
            {
                regex = new Regex(Filter);
                bIsValidRegex = true;
            }
            catch
            {
                regex = new Regex("^");
                bIsValidRegex = false;
            }
        }

        public Regex Eval()
        {
            return regex;
        }
    }
}
