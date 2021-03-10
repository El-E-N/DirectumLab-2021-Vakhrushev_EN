using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace Task_4
{
    public partial class Program
    {
        /// <summary>
        /// Проверка методов классов MeetingWithTypes и MeetingWithBlankEndTime
        /// </summary>
        public static void Task1()
        {
            var meetingWithTypes = new MeetingWithTypes();
            meetingWithTypes.StartTime = new DateTime(2021, 3, 7);
            meetingWithTypes.EndTime = new DateTime(2021, 3, 8);
            meetingWithTypes.Type = "совещание";
            Console.WriteLine(meetingWithTypes.Type);
            meetingWithTypes.Type = "некоторое событие";

            var meetingWithIndefiniteTime = new MeetingWithIndefiniteTime();
            meetingWithIndefiniteTime.StartTime = new DateTime(2021, 3, 7);
            meetingWithIndefiniteTime.EndTime = new DateTime(2021, 3, 8);
            Console.WriteLine(meetingWithIndefiniteTime.EndTime);
            Console.WriteLine(meetingWithIndefiniteTime.DurationTime);
            Console.WriteLine(meetingWithIndefiniteTime.StartTime);
            Console.WriteLine(meetingWithIndefiniteTime.EndTime);
            Console.WriteLine(meetingWithIndefiniteTime.DurationTime);
        }

        /// <summary>
        /// Создается DataSet для просмотра возможностей функции SeparationOfDataSet
        /// </summary>
        public static void Task2()
        {
            var bookStore = new DataSet("BookStore");
            var booksTable = new DataTable("Books");
            // добавляем таблицу в dataset
            bookStore.Tables.Add(booksTable);

            // создаем столбцы для таблицы Books
            var idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

            var nameColumn = new DataColumn("Name", Type.GetType("System.String"));
            var priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
            priceColumn.DefaultValue = 100; // значение по умолчанию
            var discountColumn = new DataColumn("Discount", Type.GetType("System.Decimal"));
            discountColumn.Expression = "Price * 0.2";

            booksTable.Columns.Add(idColumn);
            booksTable.Columns.Add(nameColumn);
            booksTable.Columns.Add(priceColumn);
            booksTable.Columns.Add(discountColumn);
            // определяем первичный ключ таблицы books
            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

            var row = booksTable.NewRow();
            row.ItemArray = new object[] { null, "Война и мир", 200 };
            booksTable.Rows.Add(row); // добавляем первую строку
            booksTable.Rows.Add(new object[] { null, "Отцы и дети", 170 }); // добавляем вторую строку
            var booksTable1 = booksTable.Copy();
            booksTable1.TableName = "newName";
            bookStore.Tables.Add(booksTable1);
            booksTable.Rows.Add(new object[] { null, "Отцы и эти", 228 });
            Console.WriteLine(Separator.SeparationOfDataSet(bookStore, "---", "|||", "///"));
        }

        /// <summary>
        /// Пример использования вывода перечня прав
        /// </summary>
        public static void Task3()
        {
            for (int val = 1; val <= 70; val++)
            {
                Console.Write(val + ": ");
                ProcedureForTask3((AccessRights)val);
            }
        }

        /// <summary>
        /// получение доступных прав
        /// </summary>
        /// <param name="accessRights">Число, по которому выводится перечень прав</param>
        public static void ProcedureForTask3(AccessRights accessRights)
        {
            if (accessRights.HasFlag(AccessRights.AccessDenied)) // если значение >= 64, то нет прав
                Console.WriteLine(AccessRights.AccessDenied);
            else
                Console.WriteLine(accessRights);
        }

        /// <summary>
        /// разные способы вывода даты и вещественных чисел для ведения логов
        /// </summary>
        /// <param name="dateTime">дата</param>
        /// <param name="value">вещественное чсило</param>
        /// <param name="valueInt">целое число</param>
        public static void Task4(DateTime dateTime, double value, int valueInt)
        {
            var years = new string[] { "yy", "yyyy" }; // вывод года
            var months = new string[] { "MM", "MMM", "MMMM" }; // месяца
            var days = new string[] { "dd", "ddd", "dddd" }; // дня
            var hours12 = new string[] { "hh" }; // часа в 12-часовом формате
            var hours24 = new string[] { "H", "HH" }; // часа в 24-часовом формате
            var minutes = new string[] { "mm" }; // минуты
            var seconds = new string[] { "ss" }; // секунды
            var partOfSeconds = new string[] { "ff", "fff", "ffff", "fffff", "ffffff", "fffffff" }; // доли секунды
            var separations = new string[] { string.Empty, "_", "-", ".", "|" }; // разделители
            for (int i = 0; i < 5; i++)
            {
                var result = string.Empty;
                var array = new string[][] { years, months, days, hours12, hours24, minutes, seconds, partOfSeconds };
                var randomCountOfParams = new Random().Next(2, array.Length); // количество параметров
                for (int j = 0; j < randomCountOfParams; j++)
                {
                    var randomIndex = new Random().Next(0, array.Length); // случайный параметр
                    result += array[randomIndex][new Random().Next(array[randomIndex].Length)];
                    var list = new List<string[]>(array);
                    list.RemoveAt(randomIndex); // удаление этого параметра для предотвращения повторов
                    array = list.ToArray();
                    if (j != randomCountOfParams - 1)
                        result += separations[new Random().Next(separations.Length)]; // добавление случайного разделителя
                }
                Console.WriteLine(result + ": " + dateTime.ToString(result));
            }

            var wordsForInt = new string[] { "D", "X", "F", "G", "N", "E" }; // параметры, которые подходят для вывода целых чисел
            string[] wordsForDouble = { "F", "G", "N", "E" }; // параметры, которые подходят только для вещественных чисел
            var numbers = new string[] { string.Empty, "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // добавление в конец параметра
            for (int i = 0; i < wordsForInt.Length; i++)
            {
                var wordInt = wordsForInt[i];
                var number = numbers[new Random().Next(numbers.Length)];
                Console.WriteLine(wordInt + number + ": " + valueInt.ToString(wordInt + number));
            }
            for (int i = 0; i < wordsForDouble.Length; i++)
            {
                var number = numbers[new Random().Next(numbers.Length)];
                var wordDouble = wordsForDouble[new Random().Next(wordsForDouble.Length)];
                Console.WriteLine(wordDouble + number + ": " + value.ToString(wordDouble + number));
            }
        }

        public static void Task5(string nameOfFile)
        {
            var logger = new Logger(nameOfFile);
            logger.WriteString("Some information");
            try
            {
                logger = new Logger(nameOfFile);
            }
            catch
            {
                Console.WriteLine("Сперва закройте файл!");
            }
            logger.Dispose();
            using (logger = new Logger(nameOfFile))
            {
                logger.WriteString("New some information");
            }
        }

        /// <summary>
        /// Дополнительное задание
        /// </summary>
        /// <remarks>Операция конкатенации быстрее у StringBuilder, а взятия подстроки - у string</remarks>
        public static void AdditionalTask()
        {
            var str = string.Empty;
            var strBuilder = new StringBuilder();
            var stopwatch = new Stopwatch();
            Console.WriteLine("Конкатенация строк:");
            stopwatch.Start();
            str += "a";
            str += "bc";
            str += "def";
            stopwatch.Stop();
            Console.WriteLine("string: " + stopwatch.ElapsedTicks);
            stopwatch.Restart();
            strBuilder.Append("a");
            strBuilder.Append("bc");
            strBuilder.Append("def");
            stopwatch.Stop();
            Console.WriteLine("StringBuilder: " + stopwatch.ElapsedTicks);
            Console.WriteLine("Получение подстроки:");
            stopwatch.Restart();
            var text = str.Substring(1, 4);
            stopwatch.Stop();
            Console.WriteLine("string: " + text + " " + stopwatch.ElapsedTicks);
            stopwatch.Restart();
            text = strBuilder.ToString(1, 4);
            stopwatch.Stop();
            Console.WriteLine("StringBuilder: " + text + " " + stopwatch.ElapsedTicks);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("\nЗадание 1\n");
            Task1();

            Console.WriteLine("\nЗадание 2\n");
            Task2();

            Console.WriteLine("\nЗадание 3\n");
            Task3();

            Console.WriteLine("\nЗадание 4\n");
            DateTime dateTime = DateTime.Parse("13 Apr 2019 08:00:30");
            Task4(dateTime, 12345.6789, 12345);

            Console.WriteLine("\nЗадание 5\n");
            Task5("tempLog.log");

            Console.WriteLine("\nДополнительное задание\n");
            AdditionalTask();
        }
    }
}