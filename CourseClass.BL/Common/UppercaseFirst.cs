using System;
using System.Collections.Generic;
using System.Text;

namespace CourseClass.BL.Common
{
    public static class UppercaseFirst
    {
        public static string ApplyUppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}