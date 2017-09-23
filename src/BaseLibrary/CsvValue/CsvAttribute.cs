using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.CsvValue
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class CsvAttribute : Attribute
    {
        public string HeadPrefix { get; set; }
        public string HeadSuffix { get; set; }


        public bool IsDouble { get; set; }
        public bool IsSingle { get; set; }
        public bool IsHex { get; set; }
        public string StringFormatter { get; set; }


        public bool IsExpandable { get; set; }

        public CsvAttribute()
        {
        }
    }
}
