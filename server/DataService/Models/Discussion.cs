using System;
using System.Collections.Generic;

namespace DataService.Models
{
    /// <summary>
    /// Обсуждение.
    /// </summary>
    public class Discussion : Entity
    {
        /// <summary>
        /// Конструктор обсуждения.
        /// </summary>
        /// <param name="id">Его id.</param>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название обсуждения.</param>
        public Discussion(Guid id, Guid roomId, string name)
        {
            this.Id = id;
            this.RoomId = roomId;
            if (name != string.Empty)
                this.Name = name;
            else
                this.Name = "Discussion" + this.Id;
            this.StartAt = DateTime.Now;
        }

        /// <summary>
        /// Id комнаты.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Название обсуждения.
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
        /// Id голосований из обсуждения.
        /// </summary>
        public List<Guid> VoteIds { get; }
    }
}
