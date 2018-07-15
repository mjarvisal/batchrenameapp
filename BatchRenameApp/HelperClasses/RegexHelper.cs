using System.Collections;
using System.Text.RegularExpressions;

namespace BatchRenameApp
{
    public class RegexHelper
    {
        private Regex regex;
        public bool bIsValidRegex = false;

        public RegexHelper(string Filter)
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

        public Regex GetRegex()
        {
            return regex;
        }


        public MatchCollection getMatches(string Text)
        {
            return regex.Matches(Text);
        }

    }
}
