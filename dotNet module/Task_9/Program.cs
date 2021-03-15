using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Task_9
{
    public class Program
    {
        /// <summary>
        /// Получение сортированного массива из файла логов с определенной датой
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <param name="datetime">определенная дата</param>
        /// <returns>сортированный и отфильтрованный массив</returns>
        public static IEnumerable GetSortedDateLines(string path, DateTime datetime)
        {
            ContentOfFile content;
            var dateStr = datetime.Day + "." + datetime.Month + "." + datetime.Year;
            using (var file = new StreamReader(path))
            {
                content = new ContentOfFile(file.ReadToEnd());
            }
            content.ContentList.RemoveAt(0); // убираем шапку
            content.ContentList.Remove(string.Empty); // убираем пустые строки
            var list = from string line in content
                       let date = line.Split("\t")[0] // дата
                       let time = line.Split("\t")[1] // время
                       where date == dateStr
                       orderby time
                       select line;
            return list;
        }

        public static void Main(string[] args)
        {
            var path = "ClientConnectionLog.log";
            var ourList = GetSortedDateLines(path, new DateTime(2007, 12, 11));
            foreach (var line in ourList)
                Console.WriteLine(line);
        }
    } 
}
