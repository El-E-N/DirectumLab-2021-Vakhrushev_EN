using NUnit.Framework;
using System.Collections.Generic;

namespace Task_15.Tests
{
    /// <summary>
    /// Содержит тесты для методов проекта 12.
    /// </summary>
    public class UnitTestsTask12
    {
        /// <summary>
        /// Тестирование метода Max класса ObjectPropertyInfo.
        /// </summary>
        public class TestObjectPropertyInfo
        {         
            /// <summary>
            /// Считывание свойств переданного объекта.
            /// </summary>
            [Test]
            public void GetObjectPropertiesInListOfDictionary()
            {
                var actual = Task_12.Program.ObjectPropertyInfo(new Task_12.User("MyName", 22, 12345));
                var expected = new List<Dictionary<string, string>>
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
                Assert.AreEqual(expected, actual);
            }
        }
    }
}