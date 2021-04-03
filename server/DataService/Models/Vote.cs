using System;

namespace DataService.Models
{
    /// <summary>
    /// Оценка.
    /// </summary>
    public class Vote : Entity
    {
        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="id">Id оценки.</param>
        /// <param name="cardId">Id карты.</param>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="playerId">Id игрока.</param>
        /// <param name="discussionId">Id обсуждения.</param>
        public Vote(Guid id, Guid cardId, Guid roomId, Guid playerId, Guid discussionId)
        {
            this.Id = id;
            this.CardId = cardId;
            this.RoomId = roomId;
            this.PlayerId = playerId;
            this.DiscussionId = discussionId;
        }

        /// <summary>
        /// Id карты.
        /// </summary>
        public Guid CardId { get; set;  }

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
