using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Extension
{
    public static class DictonaryExtension
    {

        public static void Reset<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            foreach (var key in dict.Keys.ToArray())
            {
                dict[key] = default(TValue);
            }
        }
    }
}
