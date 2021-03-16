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
                try
                {
                    try
                    {
                        using (var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                        {
                            using (var myFile = new StreamReader(decompressionStream))
                            {
                                return myFile.ReadToEnd();
                            }
                        }
                    }
                    catch (FileNotFoundException ex)
                    {
                        throw new LoadFileException($"Файл {gzipFile} не найден", ex);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw new LoadFileException($"Недостаточно прав доступа к файлу {gzipFile}", ex);
                }
                catch (LoadFileException ex)
                {
                    Console.WriteLine(ex.Message);
                    return string.Empty;
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