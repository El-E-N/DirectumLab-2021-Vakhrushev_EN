using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_8
{
    /// <summary>
    /// Содержит список строк из файла txt формата
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Содержит список из строк файла
        /// </summary>
        public List<string> ContentList { get; }

        public FileReader(string path)
        {
            using (var txtFile = new StreamReader(path))
            {
                this.ContentList = new List<string>(txtFile.ReadToEnd().Split("\n"));
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new FileReaderEnumerator(this.ContentList);
        }
    }
}