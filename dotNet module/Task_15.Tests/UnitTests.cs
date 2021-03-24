using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;

namespace Task_15.Tests
{
    /// <summary>
    /// Содержит тесты для методов проектов 4, 8 и 12.
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// SetUp.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// DataSet для одного из тестов.
        /// </summary>
        private static DataSet BookStore
        {
            get
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
                return bookStore;
            }
        }

        /// <summary>
        /// Проверка перевода DataSet в строку.
        /// </summary>
        [Test]
        public void ConvertDataSetToStringInTask4()
        {
            var result = "1|||Война и мир|||200|||40,0---2|||Отцы и дети|||170|||34,0---3|||Отцы и эти|||228|||45,6///1|||Война и мир|||200|||40,0---2|||Отцы и дети|||170|||34,0";
            Assert.That(Task_4.DataSetUtils.ConvertToString(BookStore, "---", "|||", "///"), 
                Is.EqualTo(result));
        }

        /// <summary>
        /// Получение максимального значения из 3 элементов, где максимум на первой позиции.
        /// </summary>
        [Test]
        public void GetMaxValueOnPositionNumber1InTask8()
        {
            Assert.That(Task_8.GetterMax<string>.Max("c", "b", "a"), Is.EqualTo("c"));
        }

        /// <summary>
        /// Получение максимального значения из 3 элементов, где максимум на второй позиции.
        /// </summary>
        [Test]
        public void GetMaxValueOnPositionNumber2InTask8()
        {
            Assert.That(Task_8.GetterMax<int>.Max(-1, 2, -3), Is.EqualTo(2));
        }

        /// <summary>
        /// Получение максимального значения из 3 элементов, где максимум на третьей позиции.
        /// </summary>
        [Test]
        public void GetMaxValueOnPositionNumber3InTask8()
        {
            Assert.That(Task_8.GetterMax<double>.Max(1.5, 2.5, 3), Is.EqualTo(3));
        }

        /// <summary>
        /// Проверка работы FileReader. Считывает все данные построчно из файла и проверяет с содержимым файла.
        /// </summary>
        [Test]
        public void FileReaderReadeFileCorrectlyInTask8()
        {
            var fileReader = new Task_8.FileReader("MyTextFile.txt");
            var allRows = string.Empty;

            foreach (var line in fileReader)
                allRows += line;

            var result = @"В этот лес завороженный,По пушинкам серебра,Я с винтовкой заряженнойНа охоту шел вчера.По дорожке чистой, гладкойЯ прошел, не наследил…
Кто ж катался здесь украдкой?Кто здесь падал и ходил?Подойду, взгляну поближе:Хрупкий снег изломан весь.Здесь вот когти, дальше — лыжи…
Кто-то странный бегал здесь.Кабы твердо знал я тайнуЗаколдованным речам,Я узнал бы хоть случайно,Кто здесь бродит по ночам.Из-за елки бы высокой
Подсмотрел я на кругу:Кто глубокий след далекийОставляет на снегу?.".Replace("\n", "").Replace("\r", "");
            Assert.That(allRows, Is.EqualTo(result));
        }

        /// <summary>
        /// Считывание сфойств переданного объекта.
        /// </summary>
        [Test]
        [Obsolete]
        public void GetObjectPropertiesInListOfDictionaryInTask12()
        {
            var listOfDictionary = Task_12.Program.ObjectPropertyInfo(new Task_12.User("MyName", 22, 12345));
            var result = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    { "Name", "Name" },
                    { "Value", "MyName" }
                },
                new Dictionary<string, string>
                {
                    { "Name", "Age" },
                    { "Value", "22" }
                },
                new Dictionary<string, string>
                {
                    { "Name", "ID" },
                    { "Value", "12345" }
                }
            };
            Assert.That(listOfDictionary, Is.EqualTo(result));
        }
    }
}