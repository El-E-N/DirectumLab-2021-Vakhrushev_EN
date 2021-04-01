using System;

namespace DataService.Models
{
    /// <summary>
    /// Карта.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="id">Id карты, которы задает создатель.</param>
        /// <param name="value">Значение.</param>
        /// <param name="name">Название (для нечисловых).</param>
        public Card(Guid id, int? value, string name)
        {
            this.Id = id;
            this.Value = value;
            this.Name = name;
        }

        /// <summary>
        /// Ее Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Значение карты.
        /// </summary>
        /// <remarks>NULL для нечисловых значений.</remarks>
        public int? Value { get; set; }

        /// <summary>
        /// Ее название.
        /// </summary>
        public string Name { get; set; }
    }
}
