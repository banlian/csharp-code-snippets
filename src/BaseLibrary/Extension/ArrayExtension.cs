using System.Linq;

namespace BaseLibrary.Extension
{
    public static class ArrayExtension
    {
        public static string HexString(this byte[] buffer, string seprator = " ")
        {
            if (buffer == null)
            {
                return string.Empty;
            }

            return string.Join(seprator, buffer.Select(b => b.ToString("X2")));
        }


        public static int ToInt32(this ushort[] ushorts)
        {
            if (ushorts.Length == 2)
            {
                return ((int) ushorts[1] << 16) + ushorts[0];
            }

            return 0;
        }

        public static ushort[] GetUshorts(this int val)
        {
            return new[] { (ushort)val, (ushort)(val >> 16), };
        }
    }
}