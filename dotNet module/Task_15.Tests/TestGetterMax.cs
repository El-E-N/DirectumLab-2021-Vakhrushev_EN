using NUnit.Framework;

namespace Task_15.Tests
{
    /// <summary>
    /// Содержит тесты для методов проекта 8.
    /// </summary>
    public partial class UnitTestsTask8
    {
        /// <summary>
        /// Тестирование метода Max класса GetterMax.
        /// </summary>
        public class TestGetterMax
        {
            /// <summary>
            /// Получение максимального значения из 3 строк, где максимум на первой позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromStringsOnPositionNumber1()
            {
                var expected = "c";
                var actual = Task_8.GetterMax<string>.Max("c", "b", "a");
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            /// Получение максимального значения из 3 строк, где максимум на второй позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromStringsOnPositionNumber2()
            {
                var expected = "c";
                var actual = Task_8.GetterMax<string>.Max("b", "c", "a");
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            /// Получение максимального значения из 3 строк, где максимум на третьей позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromStringsOnPositionNumber3()
            {
                var expected = "c";
                var actual = Task_8.GetterMax<string>.Max("a", "b", "c");
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            /// Получение максимального значения из 3 целых чисел, где максимум на первой позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromIntegersOnPositionNumber1()
            {
                var expected = 2;
                var actual = Task_8.GetterMax<int>.Max(2, -1, -3);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            /// Получение максимального значения из 3 целых чисел, где максимум на второй позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromIntegersOnPositionNumber2()
            {
                var expected = 2;
                var actual = Task_8.GetterMax<int>.Max(-1, 2, -3);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            /// Получение максимального значения из 3 целых чисел, где максимум на третьей позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromIntegersOnPositionNumber3()
            {
                var expected = 2;
                var actual = Task_8.GetterMax<int>.Max(-1, -3, 2);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            /// Получение максимального значения из 3 вещественных чисел, где максимум на первой позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromDoublesOnPositionNumber1()
            {
                var expected = 3;
                var actual = Task_8.GetterMax<double>.Max(3, 2.5, 1.5);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            /// Получение максимального значения из 3 вещественных чисел, где максимум на второй позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromDoublesOnPositionNumber2()
            {
                var expected = 3;
                var actual = Task_8.GetterMax<double>.Max(1.5, 3, 2.5);
                Assert.AreEqual(expected, actual);
            }

            /// <summary>
            /// Получение максимального значения из 3 вещественных чисел, где максимум на третьей позиции.
            /// </summary>
            [Test]
            public void GetMaxValueFromDoublesOnPositionNumber3()
            {
                var expected = 3;
                var actual = Task_8.GetterMax<double>.Max(1.5, 2.5, 3);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
