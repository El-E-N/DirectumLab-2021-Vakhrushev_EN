using System;

namespace DataService.Models
{
    /// <summary>
    /// Оценка.
    /// </summary>
    public class Vote
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
            this.CardID = cardId;
            this.RoomID = roomId;
            this.PlayerID = playerId;
            this.DiscussionID = discussionId;
        }

        /// <summary>
        /// Id оценки.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id карты.
        /// </summary>
        public Guid CardID { get; set;  }

        /// <summary>
        /// Id комнаты.
        /// </summary>
        public Guid RoomID { get; set; }

        /// <summary>
        /// Id игрока.
        /// </summary>
        public Guid PlayerID { get; set; }

        /// <summary>
        /// Id обсуждения.
        /// </summary>
        public Guid DiscussionID { get; set; }
    }
}
