using DataService.Models;
using System;

namespace PlanPoker.DTO
{
    /// <summary>
    /// DTO оценки.
    /// </summary>
    public class VoteDTO
    {
        /// <summary>
        /// Id оценки.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Карта.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// Id комнаты.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Id игрока.
        /// </summary>
        public Guid PlayerId { get; set; }

        /// <summary>
        /// Id обсуждения.
        /// </summary>
        public Guid DiscussionId { get; set; }
    }
}
