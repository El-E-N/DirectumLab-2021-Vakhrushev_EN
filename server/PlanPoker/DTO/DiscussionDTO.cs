using System;
using System.Collections.Generic;

namespace PlanPoker.DTO
{
    /// <summary>
    /// DTO обсуждения.
    /// </summary>
    public class DiscussionDTO
    {
        /// <summary>
        /// Его Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Его название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Время начала обсуждения.
        /// </summary>
        public DateTime? StartAt { get; set; }

        /// <summary>
        /// Время конца обсуждения.
        /// </summary>
        public DateTime? EndAt { get; set; }

        /// <summary>
        /// Голосования из него.
        /// </summary>
        public ICollection<VoteDTO> VoteList { get; set; }
    }
}
