using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace FunctionalTests.Utils
{
    public static class TableExtensions
    {
        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static bool ToBoolean(this string value)
        {
            return value == "Yes" ? true : false;
        }
    }
}
