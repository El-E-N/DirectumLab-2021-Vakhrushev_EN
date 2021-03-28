using System;

namespace DataService.Models
{
    public class Vote
    {
        public Vote(Guid id, Guid cardId, Guid roomId, Guid playerId, Guid discussionId)
        {
            this.ID = id;
            this.CardID = cardId;
            this.RoomID = roomId;
            this.PlayerID = playerId;
            this.DiscussionID = discussionId;
        }

        public Guid ID { get; }

        public Guid CardID { get; set;  }

        public Guid RoomID { get; }

        public Guid PlayerID { get; }

        public Guid DiscussionID { get; }
    }
}
