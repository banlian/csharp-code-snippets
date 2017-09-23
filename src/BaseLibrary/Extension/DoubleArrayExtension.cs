using System.Collections.Generic;

namespace BaseLibrary.Extension
{
    public static class DoubleArrayExtension
    {
        public static int[] FindPeaks(this double[] data, double disturb = 0)
        {
            var peaks = new List<int>();

            for (var i = 1; i < data.Length - 1; i++)
            {
                if (data[i] - data[i - 1] > disturb && data[i] - data[i + 1] > disturb)
                    peaks.Add(i);
            }

            return peaks.ToArray();
        }
    }
}