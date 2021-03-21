using System;

namespace Task_12
{
    /// <summary>
    /// Тестовый класс.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public static string Name { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        private int Age { get; set; }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Obsolete]
        public double ID { get; }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="id">Идентификатор.</param>
        [Obsolete]
        public User(string name, int age, int id)
        {
            Name = name;
            this.Age = age;
            this.ID = id;
        }

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        [Obsolete]
        public User()
        {
            this.Age = 1;
            this.ID = 1;
        }
    }
}
