using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BaseLibrary.Object;

namespace BaseLibrary.Version
{
    public class VersionQuery : LogEventStaticObject
    {
        public static void ClearDir(string savePath)
        {
            if (!Directory.Exists(savePath))
            {
                return;
            }

            foreach (var file in Directory.GetFiles(savePath))
            {
                if (file.EndsWith(".version"))
                {
                    File.Delete(file);
                }
            }
        }

        public static void QueryDir(string dir, string savePath = null)
        {
            if (savePath == null)
            {
                savePath = dir;
            }

            foreach (var d in Directory.GetDirectories(dir))
            {
                Info($"QueryDir {d}");
                QueryDir(d, savePath);
            }


            foreach (var file in Directory.GetFiles(dir))
            {
                var fn = Path.GetFileName(file);

                if (fn != null && (fn.EndsWith(".exe") && fn.Contains("Tool") && !fn.Contains("vshost")))
                {
                    var versInfo = FileVersionInfo.GetVersionInfo(file);
                    String fileVersion = versInfo.FileVersion;

                    string f = Path.Combine(savePath, $"{fn.Remove(fn.Length - 4)}_{fileVersion}.version");

                    if (File.Exists(f))
                    {
                        File.Delete(f);
                    }

                    using (File.Create(f))
                    {
                    }

                    Info($"QueryFileVersion {Path.GetFileName(f)}");
                }
            }


        }
    }
}
