using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BaseLibrary.Extension
{
    public class BinaryFileControl
    {
        public static byte[] ReadBytes(string file)
        {
            try
            {
                using (var fs = new FileStream(file, FileMode.Open))
                {
                    using (var sr = new BinaryReader(fs))
                    {
                        return sr.ReadBytes((int)fs.Length);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }


    public static class BinaryFileExtension
    {
        public static void SaveBinaryFile(this byte[] buffer, string file)
        {
            try
            {
                using (var fs = new FileStream(file, FileMode.Create))
                {
                    using (var bw = new BinaryWriter(fs))
                    {
                        bw.Write(buffer);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }





    public static class BinaryStreamExtension
    {
        public static string ReadDoubleMatrix(this BinaryReader br, int width, int height)
        {
            var sb = new StringBuilder();

            sb.Append("[");
            for (int i = 0; i < height; i++)
            {
                sb.Append("{");
                for (int j = 0; j < width; j++)
                {
                    sb.Append($"{BitConverter.ToDouble(br.ReadBytes(8).ToArray(), 0).ToString("F3")} ");
                }
                sb.Append("}\r\n");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]\r\n");

            return sb.ToString();
        }
    }



}