using System;

namespace PlanPoker.DTO
{
    /// <summary>
    /// DTO карты.
    /// </summary>
    public class CardDTO
    {
        /// <summary>
        /// Id карты.
        /// </summary>
        public Guid Id { get; set; }

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
