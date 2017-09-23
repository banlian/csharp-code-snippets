using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Version
{
    public class VersionFile
    {
        public static void SaveVersionFile(string version)
        {
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                if (file.EndsWith(".version"))
                {
                    File.Delete(file);
                }
            }

            using (var fs = File.Create($"{version}.version"))
            {
            }
        }
    }
}
