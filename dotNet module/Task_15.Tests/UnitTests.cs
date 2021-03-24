using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;

namespace Task_15.Tests
{
    /// <summary>
    /// �������� ����� ��� ������� �������� 4, 8 � 12.
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
        /// DataSet ��� ������ �� ������.
        /// </summary>
        private static DataSet BookStore
        {
            get
            {
                var bookStore = new DataSet("BookStore");
                var booksTable = new DataTable("Books");
                // ��������� ������� � dataset
                bookStore.Tables.Add(booksTable);

                // ������� ������� ��� ������� Books
                var idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
                idColumn.Unique = true; // ������� ����� ����� ���������� ��������
                idColumn.AllowDBNull = false; // �� ����� ��������� null
                idColumn.AutoIncrement = true; // ����� ����������������������
                idColumn.AutoIncrementSeed = 1; // ��������� ��������
                idColumn.AutoIncrementStep = 1; // ���������� ��� ���������� ����� ������

                var nameColumn = new DataColumn("Name", Type.GetType("System.String"));
                var priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
                priceColumn.DefaultValue = 100; // �������� �� ���������
                var discountColumn = new DataColumn("Discount", Type.GetType("System.Decimal"));
                discountColumn.Expression = "Price * 0.2";

                booksTable.Columns.Add(idColumn);
                booksTable.Columns.Add(nameColumn);
                booksTable.Columns.Add(priceColumn);
                booksTable.Columns.Add(discountColumn);
                // ���������� ��������� ���� ������� books
                booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

                var row = booksTable.NewRow();
                row.ItemArray = new object[] { null, "����� � ���", 200 };
                booksTable.Rows.Add(row); // ��������� ������ ������
                booksTable.Rows.Add(new object[] { null, "���� � ����", 170 }); // ��������� ������ ������
                var booksTable1 = booksTable.Copy();
                booksTable1.TableName = "newName";
                bookStore.Tables.Add(booksTable1);
                booksTable.Rows.Add(new object[] { null, "���� � ���", 228 });
                return bookStore;
            }
        }

        /// <summary>
        /// �������� �������� DataSet � ������.
        /// </summary>
        [Test]
        public void ConvertDataSetToStringInTask4()
        {
            var result = "1|||����� � ���|||200|||40,0---2|||���� � ����|||170|||34,0---3|||���� � ���|||228|||45,6///1|||����� � ���|||200|||40,0---2|||���� � ����|||170|||34,0";
            Assert.That(Task_4.DataSetUtils.ConvertToString(BookStore, "---", "|||", "///"), 
                Is.EqualTo(result));
        }

        /// <summary>
        /// ��������� ������������� �������� �� 3 ���������, ��� �������� �� ������ �������.
        /// </summary>
        [Test]
        public void GetMaxValueOnPositionNumber1InTask8()
        {
            Assert.That(Task_8.GetterMax<string>.Max("c", "b", "a"), Is.EqualTo("c"));
        }

        /// <summary>
        /// ��������� ������������� �������� �� 3 ���������, ��� �������� �� ������ �������.
        /// </summary>
        [Test]
        public void GetMaxValueOnPositionNumber2InTask8()
        {
            Assert.That(Task_8.GetterMax<int>.Max(-1, 2, -3), Is.EqualTo(2));
        }

        /// <summary>
        /// ��������� ������������� �������� �� 3 ���������, ��� �������� �� ������� �������.
        /// </summary>
        [Test]
        public void GetMaxValueOnPositionNumber3InTask8()
        {
            Assert.That(Task_8.GetterMax<double>.Max(1.5, 2.5, 3), Is.EqualTo(3));
        }

        /// <summary>
        /// �������� ������ FileReader. ��������� ��� ������ ��������� �� ����� � ��������� � ���������� �����.
        /// </summary>
        [Test]
        public void FileReaderReadeFileCorrectlyInTask8()
        {
            var fileReader = new Task_8.FileReader("MyTextFile.txt");
            var allRows = string.Empty;

            foreach (var line in fileReader)
                allRows += line;

            var result = @"� ���� ��� ������������,�� �������� �������,� � ��������� ������������ ����� ��� �����.�� ������� ������, �������� ������, �� ��������
��� � ������� ����� ��������?��� ����� ����� � �����?�������, ������� �������:������� ���� ������� ����.����� ��� �����, ������ � ����
���-�� �������� ����� �����.���� ������ ���� � ������������������ �����,� ����� �� ���� ��������,��� ����� ������ �� �����.��-�� ���� �� �������
���������� � �� �����:��� �������� ���� ���������������� �� �����?.".Replace("\n", "").Replace("\r", "");
            Assert.That(allRows, Is.EqualTo(result));
        }

        /// <summary>
        /// ���������� ������� ����������� �������.
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