using System;

namespace BaseLibrary.Extension
{
    public static class DateTimeStringExtension
    {
        /// <summary>
        ///     yyyyMMdd-HHmmss
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s)
        {
            if (s.Length != 9)
            {
                return DateTime.MinValue;
            }


            var data = s.Split('-');

            var year = int.Parse(data[0].Substring(0, 4));
            var month = int.Parse(data[0].Substring(4, 2));
            var day = int.Parse(data[0].Substring(6, 2));

            var hour = int.Parse(data[1].Substring(0, 2));
            var min = int.Parse(data[1].Substring(2, 2));
            var sec = int.Parse(data[1].Substring(4, 2));


            return new DateTime(year, month, day, hour, min, sec);
        }
    }
}