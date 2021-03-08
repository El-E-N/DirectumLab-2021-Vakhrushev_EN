using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// Тип прав.
/// </summary>
[Flags, Serializable]
public enum AccessRights : byte
{
    /// <summary>
    /// Просмотр.
    /// </summary>
    View = 1,

    /// <summary>
    /// Выполнение.
    /// </summary>
    Run = 2,

    /// <summary>
    /// Добавление.
    /// </summary>
    Add = 4,
 
    /// <summary>
    /// Изменение.
    /// </summary>
    Edit = 8,

    /// <summary>
    /// Утверждение.
    /// </summary>
    Ratify = 16,

    /// <summary>
    /// Удаление.
    /// </summary>
    Delete = 32,

    /// <summary>
    /// Нет доступа.
    /// </summary>
    /// <remarks>
    /// Этот флаг имеет максимальный приоритет.
    /// Если он установлен, остальные флаги игнорируются 
    /// </remarks>
    AccessDenied = 64
}

namespace Task_4
{
    public class Program
    {
        /// <summary>
        /// Проверка методов классов MeetingWithTypes и MeetingWithBlankEndTime
        /// </summary>
        public static void Task1()
        {
            MeetingWithTypes meetingWithTypes = new MeetingWithTypes();
            meetingWithTypes.Type = "совещание";
            Console.WriteLine(meetingWithTypes.Type);
            meetingWithTypes.Type = "некоторое событие";

            MeetingWithBlankEndTime meetingWithBlankEndTime = new MeetingWithBlankEndTime();
            Console.WriteLine(meetingWithBlankEndTime.EndTime);
            Console.WriteLine(meetingWithBlankEndTime.DurationTime);
            meetingWithBlankEndTime.EndTime = new DateTime(2021, 3, 8);
            Console.WriteLine(meetingWithBlankEndTime.EndTime);
            Console.WriteLine(meetingWithBlankEndTime.DurationTime);
        }

        /// <summary>
        /// Перевод данных о DataSet в String
        /// </summary>
        /// <param name="dataSet">Сам DataSet</param>
        /// <param name="separateOfRow">Разделитель для записей</param>
        /// <param name="separateOfColumn">Разделитель для колонок</param>
        /// <param name="separateOfTable">Разделитель для таблиц</param>
        /// <returns>Строка с информацией от DataSet</returns>
        public static string SeparationOfDataSet(DataSet dataSet, string separateOfRow, string separateOfColumn, string separateOfTable)
        {
            string allInfo = string.Empty;
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables[i].Rows.Count; j++)
                {
                    for (int k = 0; k < dataSet.Tables[i].Rows[j].ItemArray.Length; k++)
                    {
                        allInfo += dataSet.Tables[i].Rows[j].ItemArray[k];
                        if (k != dataSet.Tables[i].Rows[j].ItemArray.Length - 1)
                            allInfo += separateOfColumn;
                    }
                    if (j != dataSet.Tables[i].Rows.Count - 1)
                        allInfo += separateOfRow;
                }
                if (i != dataSet.Tables.Count - 1)
                    allInfo += separateOfTable;
            }
            return allInfo;
        }

        /// <summary>
        /// Создается DataSet для просмотра возможностей функции SeparationOfDataSet
        /// </summary>
        public static void Task2()
        {
            DataSet bookStore = new DataSet("BookStore");
            DataTable booksTable = new DataTable("Books");
            // добавляем таблицу в dataset
            bookStore.Tables.Add(booksTable);

            // создаем столбцы для таблицы Books
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

            DataColumn nameColumn = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
            priceColumn.DefaultValue = 100; // значение по умолчанию
            DataColumn discountColumn = new DataColumn("Discount", Type.GetType("System.Decimal"));
            discountColumn.Expression = "Price * 0.2";

            booksTable.Columns.Add(idColumn);
            booksTable.Columns.Add(nameColumn);
            booksTable.Columns.Add(priceColumn);
            booksTable.Columns.Add(discountColumn);
            // определяем первичный ключ таблицы books
            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

            DataRow row = booksTable.NewRow();
            row.ItemArray = new object[] { null, "Война и мир", 200 };
            booksTable.Rows.Add(row); // добавляем первую строку
            booksTable.Rows.Add(new object[] { null, "Отцы и дети", 170 }); // добавляем вторую строку
            DataTable booksTable1 = booksTable.Copy();
            booksTable1.TableName = "newName";
            bookStore.Tables.Add(booksTable1);
            booksTable.Rows.Add(new object[] { null, "Отцы и эти", 228 });

            Console.WriteLine(SeparationOfDataSet(bookStore, "---", "|||", "///"));
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
            string[] years = new string[] { "yy", "yyyy" }; // вывод года
            string[] months = new string[] { "MM", "MMM", "MMMM" }; // месяца
            string[] days = new string[] { "dd", "ddd", "dddd" }; // дня
            string[] hours12 = new string[] { "hh" }; // часа в 12-часовом формате
            string[] hours24 = new string[] { "H", "HH" }; // часа в 24-часовом формате
            string[] minutes = new string[] { "mm" }; // минуты
            string[] seconds = new string[] { "ss" }; // секунды
            string[] partOfSeconds = new string[] { "ff", "fff", "ffff", "fffff", "ffffff", "fffffff" }; // доли секунды
            string[] separations = new string[] { string.Empty, "_", "-", ".", "|" }; // разделители
            for (int i = 0; i < 5; i++)
            {
                string result = string.Empty;
                string[][] array = new string[][] { years, months, days, hours12, hours24, minutes, seconds, partOfSeconds };
                int randomCountOfParams = new Random().Next(2, array.Length); // количество параметров
                for (int j = 0; j < randomCountOfParams; j++)
                {
                    int randomIndex = new Random().Next(0, array.Length); // случайный параметр
                    result += array[randomIndex][new Random().Next(array[randomIndex].Length)];
                    List<string[]> list = new List<string[]>(array);
                    list.RemoveAt(randomIndex); // удаление этого параметра для предотвращения повторов
                    array = list.ToArray();
                    if (j != randomCountOfParams - 1)
                        result += separations[new Random().Next(separations.Length)]; // добавление случайного разделителя
                }
                Console.WriteLine(result + ": " + dateTime.ToString(result));
            }

            string[] wordsForInt = new string[] { "D", "X", "F", "G", "N", "E" }; // параметры, которые подходят для вывода целых чисел
            string[] wordsForDouble = { "F", "G", "N", "E" }; // параметры, которые подходят только для вещественных чисел
            string[] numbers = new string[] { string.Empty, "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // добавление в конец параметра
            for (int i = 0; i < wordsForInt.Length; i++)
            {
                string wordInt = wordsForInt[i];
                string number = numbers[new Random().Next(numbers.Length)];
                Console.WriteLine(wordInt + number + ": " + valueInt.ToString(wordInt + number));
            }
            for (int i = 0; i < wordsForDouble.Length; i++)
            {
                string number = numbers[new Random().Next(numbers.Length)];
                string wordDouble = wordsForDouble[new Random().Next(wordsForDouble.Length)];
                Console.WriteLine(wordDouble + number + ": " + value.ToString(wordDouble + number));
            }
        }

        public static void Task5(string nameOfFile)
        {
            Logger logger = new Logger(nameOfFile);
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
            logger = new Logger(nameOfFile);
            logger.WriteString("New some information");
            logger.Dispose();
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
        }
    }
}