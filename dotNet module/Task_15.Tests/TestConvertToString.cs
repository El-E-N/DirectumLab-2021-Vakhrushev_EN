using NUnit.Framework;
using System;
using System.Data;

namespace Task_15.Tests
{
    /// <summary>
    /// Содержит тесты для методов проекта 4.
    /// </summary>
    public class UnitTestsTask4
    {
        /// <summary>
        /// Тестирование метода ConvertToString.
        /// </summary>
        public class TestConvertToString
        {
            /// <summary>
            /// DataSet для одного из тестов.
            /// </summary>
            /// <returns>Объект DataSet.</returns>
            private static DataSet GetBookStore()
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

            /// <summary>
            /// Проверка перевода DataSet в строку.
            /// </summary>
            [Test]
            public void ConvertDataSetToString()
            {
                var expected = "1|||Война и мир|||200|||40,0---2|||Отцы и дети|||170|||34,0---3|||Отцы и эти|||228|||45,6///1|||Война и мир|||200|||40,0---2|||Отцы и дети|||170|||34,0";
                var actual = Task_4.DataSetUtils.ConvertToString(GetBookStore(), "---", "|||", "///");
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
