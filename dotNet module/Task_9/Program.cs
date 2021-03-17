using System;
using System.Collections;
using System.Linq;
using Task_8;

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
            var fileReader = new FileReader(path);
            var dateStr = datetime.Day + "." + datetime.Month + "." + datetime.Year;
            var list = from string line in fileReader
                       where line != string.Empty
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
