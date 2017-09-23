using System;
using System.Linq;
using System.Text;
using BaseLibrary.Extension;

namespace BaseLibrary.CsvValue
{
    public static class CsvControl
    {
        public static string AttrHeaders(this object csv, string prefix = null, string suffix = null)
        {
            var sb = new StringBuilder();

            var fields = csv.GetType().GetFields();
            foreach (var f in fields)
            {
                var attr = Attribute.GetCustomAttribute(f, typeof(CsvAttribute)) as CsvAttribute;
                if (attr != null)
                {
                    if (attr.IsExpandable)
                    {
                        sb.AppendSuffix(f.GetValue(csv).AttrHeaders(attr.HeadPrefix, attr.HeadSuffix));
                        continue;
                    }

                    if (attr.HeadPrefix.IsNotNullOrEmpty() || attr.HeadSuffix.IsNotNullOrEmpty())
                    {
                        prefix = attr.HeadPrefix;
                        suffix = attr.HeadSuffix;
                    }

                    sb.AppendSuffix($"{prefix}{f.Name}{suffix}");
                }
            }
            sb.RemoveSuffix();

            return sb.ToString();
        }


        public static string AttrValues(this object csv)
        {
            var sb = new StringBuilder();

            var fields = csv.GetType().GetFields();
            foreach (var f in fields)
            {
                var attr = Attribute.GetCustomAttribute(f, typeof(CsvAttribute)) as CsvAttribute;
                if (attr != null)
                {
                    if (attr.IsExpandable)
                    {
                        sb.AppendSuffix(f.GetValue(csv).AttrValues());
                        continue;
                    }


                    if (attr.IsDouble)
                    {
                        sb.AppendSuffix(((double)f.GetValue(csv)).ToString(attr.StringFormatter));
                    }
                    else if (attr.IsSingle)
                    {
                        sb.AppendSuffix(((float)f.GetValue(csv)).ToString(attr.StringFormatter));
                    }
                    else if (attr.IsHex)
                    {
                        sb.AppendSuffix(((ulong)f.GetValue(csv)).ToString(attr.StringFormatter));
                    }
                    else
                    {
                        sb.AppendSuffix(f.GetValue(csv).ToString());
                    }
                }
            }
            sb.RemoveSuffix();

            return sb.ToString();
        }

        public static string AttrString(this object csv, string prefix = null, string suffix = null)
        {
            var sb = new StringBuilder();

            var fields = csv.GetType().GetFields();
            foreach (var f in fields)
            {
                var attr = Attribute.GetCustomAttribute(f, typeof(CsvAttribute)) as CsvAttribute;
                if (attr != null)
                {
                    if (attr.IsExpandable)
                    {
                        sb.AppendLine(f.GetValue(csv).AttrString(attr.HeadPrefix, attr.HeadSuffix));
                        continue;
                    }

                    if (attr.HeadPrefix.IsNotNullOrEmpty() || attr.HeadSuffix.IsNotNullOrEmpty())
                    {
                        prefix = attr.HeadPrefix;
                        suffix = attr.HeadSuffix;
                    }

                    if (attr.IsDouble)
                    {
                        sb.AppendLine(
                            $"{prefix}{f.Name}{suffix}:{((double)f.GetValue(csv)).ToString(attr.StringFormatter)}");
                    }
                    else if (attr.IsSingle)
                    {
                        sb.AppendLine(
                            $"{prefix}{f.Name}{suffix}:{((float)f.GetValue(csv)).ToString(attr.StringFormatter)}");
                    }
                    else if (attr.IsHex)
                    {
                        sb.AppendLine(
                            $"{prefix}{f.Name}{suffix}:{((ulong)f.GetValue(csv)).ToString(attr.StringFormatter)}");
                    }
                    else
                    {
                        sb.AppendLine($"{prefix}{f.Name}{suffix}:{f.GetValue(csv)}");
                    }
                }
            }
            sb.RemoveLine();

            return sb.ToString();
        }
    }
}