using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    public static class ClassePrivadaTeste
    {
        public static string AddSlashes(this string text)
        {
            // List of characters handled:
            // \042 double quote
            // \047 single quote
            // \134 backslash
            // \140 grave accent
            return System.Text.RegularExpressions.Regex.Replace(text, @"[\042\047\140]", "\\$0");
        }
    }
}
