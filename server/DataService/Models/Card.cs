using System;

namespace DataService.Models
{
    /// <summary>
    /// Карта.
    /// </summary>
    public class Card : Entity
    {
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="id">Id карты, которы задает создатель.</param>
        /// <param name="value">Значение.</param>
        /// <param name="name">Название (для нечисловых).</param>
        public Card(Guid id, double? value, string name)
        {
            this.Id = id;
            this.Value = value;
            this.Name = name;
        }

        /// <summary>
        /// Значение карты.
        /// </summary>
        /// <remarks>NULL для нечисловых значений.</remarks>
        public double? Value { get; set; }

        /// <summary>
        /// Название карты.
        /// </summary>
        public string Name { get; set; }
    }
}
