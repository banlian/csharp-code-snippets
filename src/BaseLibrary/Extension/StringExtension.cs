using System.Linq;
using System.Text;

namespace BaseLibrary.Extension
{
    public static class StringExtension
    {
        public static string Duplicate(this string s, int i)
        {
            var sb = new StringBuilder();
            for (int j = 0; j < i; j++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null) return true;

            return value.All(char.IsWhiteSpace);
        }
    }
}