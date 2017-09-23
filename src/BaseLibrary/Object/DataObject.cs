using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaseLibrary.Object
{
    public class StringDataWriter
    {
        private FileStream fs;
        private StreamWriter sw;

        //private static readonly object lockObj = new object();

        //public static void WriteToFile(string filename, string data)
        //{
        //    lock (lockObj)
        //    {
        //        using (var fws = new FileStream(filename, FileMode.OpenOrCreate))
        //        {
        //            using (var sws = new StreamWriter(fws))
        //            {
        //                sws.WriteLine(data);
        //            }
        //        }
        //    }
        //}

        public void Open(string filename, FileMode mode = FileMode.Append)
        {
            fs = new FileStream(filename, mode);
            sw = new StreamWriter(fs);
        }
        public void Open(string filename, Encoding endcoding, FileMode mode = FileMode.Append)
        {
            fs = new FileStream(filename, mode);
            sw = new StreamWriter(fs, endcoding);
        }

        public void WriteLine(string data)
        {
            lock (this)
            {
                sw.WriteLine(data);
            }
        }

        public void Close()
        {
            if (sw != null)
            {
                sw.Close();
                sw = null;
            }
            if (fs != null)
            {
                fs.Close();
                fs = null;
            }
        }
    }


    public class StringDataReader
    {
        private FileStream fs;
        private StreamReader sr;

        private readonly List<byte> _buffer = new List<byte>();

        public void Open(string filename)
        {
            fs = new FileStream(filename, FileMode.Open);
            sr = new StreamReader(fs);
        }

        public string ReadLine()
        {
            lock (this)
            {
                return sr.ReadLine();
            }
        }

        public void Close()
        {
            if (sr != null) sr.Close();
            if (fs != null) fs.Close();
        }
    }
}