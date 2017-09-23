using System;

namespace BaseLibrary.Extension
{
    public static class BitConverterExtension
    {
        public static ulong FromBcdToUInt64(this byte[] data, uint startIndex, uint counts)
        {
            ulong result = 0;

            for (var i = 0; i < counts; i++)
            {
                result *= 100;
                result += (ulong)(10 * (data[startIndex + i] >> 4));
                result += (ulong)(data[startIndex + i] & 0xf);
            }

            return result;
        }
    }


    public class BcdConverter
    {
        public static ulong ToUint64(byte[] data, uint startIndex, uint counts)
        {
            ulong result = 0;

            for (var i = 0; i < counts; i++)
            {
                result *= 100;
                result += (ulong)(10 * (data[startIndex + i] >> 4));
                result += (ulong)(data[startIndex + i] & 0xf);
            }

            return result;
        }

        public static byte[] ToBcd4Bytes(uint value)
        {
            if (value > 99999999)
                throw new ArgumentOutOfRangeException(nameof(ToBcd4Bytes));
            var ret = new byte[4];
            for (var i = 0; i < 4; i++)
            {
                ret[i] = (byte)(value % 10);
                value /= 10;
                ret[i] |= (byte)((value % 10) << 4);
                value /= 10;
            }
            return ret;
        }

        public static byte ToBcdByte(int value)
        {
            if (value > 0xff)
                throw new ArgumentOutOfRangeException(nameof(ToBcdByte));
            byte ret = (byte)(value % 10);
            value /= 10;
            ret |= (byte)((value % 10) << 4);

            return ret;
        }
    }
}