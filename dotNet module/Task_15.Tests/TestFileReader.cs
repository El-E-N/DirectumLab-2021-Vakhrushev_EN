using NUnit.Framework;

namespace Task_15.Tests
{
    /// <summary>
    /// Содержит тесты для методов проекта 8.
    /// </summary>
    public partial class UnitTestsTask8
    {
        /// <summary>
        /// Тестирование считывания строк из FileReader.
        /// </summary>
        public class TestFileReader
        {
            /// <summary>
            /// Проверка работы FileReader. Считывает все данные построчно из файла и проверяет с содержимым файла.
            /// </summary>
            [Test]
            public void FileReaderReadeFileCorrectly()
            {
                var fileReader = new Task_8.FileReader("MyTextFile.txt");
                var actual = string.Empty;

                foreach (var line in fileReader)
                    actual += line;

                var expected = @"В этот лес завороженный,По пушинкам серебра,Я с винтовкой заряженнойНа охоту шел вчера.По дорожке чистой, гладкойЯ прошел, не наследил…
Кто ж катался здесь украдкой?Кто здесь падал и ходил?Подойду, взгляну поближе:Хрупкий снег изломан весь.Здесь вот когти, дальше — лыжи…
Кто-то странный бегал здесь.Кабы твердо знал я тайнуЗаколдованным речам,Я узнал бы хоть случайно,Кто здесь бродит по ночам.Из-за елки бы высокой
Подсмотрел я на кругу:Кто глубокий след далекийОставляет на снегу?.".Replace("\n", string.Empty).Replace("\r", string.Empty);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
