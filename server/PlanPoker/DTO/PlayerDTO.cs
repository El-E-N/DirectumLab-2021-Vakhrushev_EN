using System;

namespace PlanPoker.DTO
{
    /// <summary>
    /// DTO игрока.
    /// </summary>
    public class PlayerDTO
    {
        /// <summary>
        /// Id игрока.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; set; }
    }
}
