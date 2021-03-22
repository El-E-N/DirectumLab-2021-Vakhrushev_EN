using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_8
{
    /// <summary>
    /// Содержит список строк из файла txt формата
    /// </summary>
    public partial class FileReader : IEnumerable<string>, IDisposable
    {
        /// <summary>
        /// Файл, с которым работаем
        /// </summary>
        private readonly StreamReader reader;

        public FileReader(string path)
        {
            this.reader = new StreamReader(path);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new FileReaderEnumerator(this.reader);
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator1();
        }

        public void Dispose()
        {
            this.reader.Dispose();
        }
    }
}