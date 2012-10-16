using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UDL.Model
{
    public static class TypeParser
    {
        private static Regex __parsingRegex = new Regex(@";\s*codecs=""(?:[^\\""]+|\\.)*""",RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static String[] Parse(String aTexte)
        {
            String newText = __parsingRegex.Replace(aTexte, "");

            //String newText = __parsingRegex.Replace(aTexte, "");
            //MatchCollection matches = __parsingRegex.Matches(aTexte);

            return newText.Split(new Char[] {','});
        }
    }

    public static class QualityParser
    {
        private static Regex __parsingRegex = new Regex("itag=[0-9]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static String[] Parse(String aTexte)
        {
            String newText = __parsingRegex.Replace(aTexte, "");



            return newText.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }

}
