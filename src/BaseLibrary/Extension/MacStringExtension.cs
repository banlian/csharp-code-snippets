using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BaseLibrary.Extension
{
    /// <summary>
    /// convert mac between ulong and hex string
    /// </summary>
    public static class MacStringExtension
    {
        static Regex r = new Regex("^[0-9A-F]{12}$");

        public static bool IsMacString(this string mac)
        {
            if (r.IsMatch(mac))
            {
                return true;
            }
            return false;
        }


        public static ulong MacStringToUlong(this string mac)
        {
            return Convert.ToUInt64(mac, 16);
        }

        public static byte[] UlongToMacBytes(this ulong mac)
        {
            return BitConverter.GetBytes(mac).Reverse().Skip(2).Take(6).ToArray();
        }

        public static string UlongToMacString(this ulong mac)
        {
            return mac.UlongToMacBytes().HexString(string.Empty);
        }
    }
}