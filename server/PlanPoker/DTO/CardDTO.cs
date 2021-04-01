using System;

namespace PlanPoker.DTO
{
    /// <summary>
    /// DTO карты.
    /// </summary>
    public class CardDTO
    {
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
