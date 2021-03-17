using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Task_7_WF
{
    public static class Program
    {
        public static string RtfReader(string gzipFile)
        {
            using (var sourceStream = new FileStream(gzipFile, FileMode.OpenOrCreate))
            {
                using (var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                {
                    using (var myFile = new StreamReader(decompressionStream))
                    {
                        return myFile.ReadToEnd();
                    }
                }
            }
        }

        [STAThread]
        public static void Main()
        {
            var gzipFile = "q2.rtf.gz";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form1 = new Form1();
            form1.richTextBox1.Rtf = RtfReader(gzipFile);
            Application.Run(form1);
        }
    }
}