using System;
using System.Text;

namespace BaseLibrary.Extension
{
    public static class StringBuilderExtension
    {
        public static StringBuilder AppendSuffix(this StringBuilder sb, string str, string splitter = ",")
        {
            sb.Append(str);
            return sb.Append(splitter);
        }

        public static StringBuilder RemoveSuffix(this StringBuilder sb, string splitter = ",")
        {
            if (sb.Length >= splitter.Length)
            {
                return sb.Remove(sb.Length - splitter.Length, splitter.Length);
            }

            return sb;
        }

        public static StringBuilder RemoveLine(this StringBuilder sb)
        {
            if (sb.Length >= Environment.NewLine.Length)
            {
                return sb.Remove(sb.Length - Environment.NewLine.Length, Environment.NewLine.Length);
            }

            return sb;
        }
    }
}