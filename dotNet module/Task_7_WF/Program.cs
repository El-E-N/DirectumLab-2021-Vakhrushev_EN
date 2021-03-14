using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Task_7_WF
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var gzipFile = "q2.rtf.gz";
            var resultFile = "myFile.txt";
            var infoOfFile = string.Empty;
            using (var sourceStream = new FileStream(gzipFile, FileMode.OpenOrCreate))
            {
                using (var targetStream = File.Create(resultFile))
                {
                    using (var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                    }
                }
                using (var myFile = new StreamReader(resultFile))
                {
                    infoOfFile = myFile.ReadToEnd();
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form1 = new Form1();
            form1.richTextBox1.Rtf = infoOfFile;
            Application.Run(form1);
        }
    }
}