using System;
using System.Collections;
using System.IO;

namespace Task_8
{
    /// <summary>
    /// Содержит список строк из файла txt формата
    /// </summary>
    public partial class FileReader : IEnumerable, IDisposable
    {
        /// <summary>
        /// Файл, с которым работаем
        /// </summary>
        private readonly StreamReader reader;

        public FileReader(string path)
        {
            this.reader = new StreamReader(path);
        }

        public IEnumerator GetEnumerator()
        {
            return new FileReaderEnumerator(this.reader);
        }

        public void Dispose()
        {
            this.reader.Dispose();
        }
    }
}