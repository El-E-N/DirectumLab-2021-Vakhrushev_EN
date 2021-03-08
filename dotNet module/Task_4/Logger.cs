using System;
using System.IO;

namespace Task_4
{
    /// <summary>
    /// Логгер - класс для ведения логов.
    /// </summary>
    public class Logger : IDisposable
    {
        /// <summary>
        /// Освобождение памяти для последующего использования файлов логов в другой программе
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.logWriter != null)
                    this.logWriter.Close();
                if (this.logFile != null)
                    this.logFile.Close();
            }
        }

        /// <summary>
        /// Файл логов.
        /// </summary>
        private FileStream logFile;

        /// <summary>
        /// Писатель в лог.
        /// </summary>
        private StreamWriter logWriter;

        /// <summary>
        /// Создать объект.
        /// </summary>
        /// <param name="fileName">Имя файла логов.</param>
        public Logger(string fileName)
        {
            this.logFile = new FileStream(fileName, FileMode.Append);
            this.logWriter = new StreamWriter(this.logFile);
        }

        public void WriteString(string data)
        {
            this.logWriter.WriteLine(data);
        }
    }
}