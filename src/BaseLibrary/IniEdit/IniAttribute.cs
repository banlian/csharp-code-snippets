using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.IniEdit
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class IniAttribute : Attribute
    {
        public IniMode Mode { get; set; } = IniMode.Readonly;
        public int Level { get; set; }

        public Type ValueType { get; set; }


        public bool IsHex { get; set; }
        public bool IsSingle { get; set; }
        public bool IsDouble { get; set; }

        public string StringFormatter { get; set; }

        public IniAttribute()
        {
        }
    }


    public enum IniMode
    {
        Readonly,
        ReadWrite,
    }

}
