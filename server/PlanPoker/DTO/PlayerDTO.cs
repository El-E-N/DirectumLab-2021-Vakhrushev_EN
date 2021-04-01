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
        /// Токен для браузера.
        /// </summary>
        /// <remarks>Для подтверждения, что он нужный игрок.</remarks>
        public string Token { get; set; }

        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; set; }
    }
}
