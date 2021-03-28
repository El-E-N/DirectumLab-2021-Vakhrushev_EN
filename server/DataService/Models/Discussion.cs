using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public class Discussion
    {
        public Discussion(Guid id, Guid roomId, string name)
        {
            this.ID = id;
            this.RoomID = roomId;
            if (name != string.Empty)
                this.Name = name;
            else
                this.Name = "Discussion" + this.ID;
            this.StartAt = DateTime.Now;
        }

        public Guid ID { get; }

        public Guid RoomID { get; }

        public string Name { get; }

        /// <summary>
        /// Время начала обсуждения.
        /// </summary>
        public DateTime? StartAt { get; }

        /// <summary>
        /// время конца обсуждения.
        /// </summary>
        public DateTime? EndAt { get; set; }

        public List<Guid> VoteIDs { get; }
    }
}
