using System;
using System.IO;

namespace BaseLibrary.Util
{
    public static class Logger
    {
        public static string LogFile
        {
            get { return DateTime.Now.ToString("yyyyMMdd") + ".log"; }
        }

        public static string DefaultPath = @".\Log\";

        private static object logObj = new object();

        static Logger()
        {
            if (!Directory.Exists(DefaultPath))
            {
                Directory.CreateDirectory(DefaultPath);
            }
        }

        public static void Line(string log)
        {
            Line(DefaultPath, log);
        }

        public static void Line(string path, string log)
        {
            lock (logObj)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                try
                {
                    using (StreamWriter sw = new StreamWriter(Path.Combine(path, LogFile), true))
                    {
                        sw.WriteLine("{0}-{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), log);
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
    }
}