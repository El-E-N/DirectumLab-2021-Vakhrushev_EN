using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_8
{
    public partial class FileReader
    {
        /// <summary>
        /// Реализация Enumerator для содержимого файла txt
        /// </summary>
        private class FileReaderEnumerator : IEnumerator<string>
        {
            private readonly StreamReader reader;
            private string current;

            public FileReaderEnumerator(StreamReader reader)
            {
                this.reader = reader;
            }

            public string Current { get => this.current; }

            object IEnumerator.Current { get => this.Current; }

            public bool MoveNext()
            {
                if (this.reader.EndOfStream)
                    return false;
                this.current = this.reader.ReadLine();
                return true;
            }

            public void Reset()
            {
                this.reader.BaseStream.Position = 0;
            }

            public void Dispose()
            {
                this.reader.Dispose();
            }
        }
    }
}