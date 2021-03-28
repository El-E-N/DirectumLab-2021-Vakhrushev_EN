using System;

namespace DataService.Models
{
    public class Card
    {
        public Guid Id { get; }

        /// <summary>
        /// Значение карты.
        /// </summary>
        /// <remarks>NULL для нечисловых значений.</remarks>
        public int? Value { get; }

        public string Name { get; }
    }
}
