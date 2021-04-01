using System;
using System.Collections.Generic;

namespace DataService.Models
{
    /// <summary>
    /// Обсуждение.
    /// </summary>
    public class Discussion
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
            this.RoomID = roomId;
            if (name != string.Empty)
                this.Name = name;
            else
                this.Name = "Discussion" + this.Id;
            this.StartAt = DateTime.Now;
        }

        /// <summary>
        /// Его Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id комнаты.
        /// </summary>
        public Guid RoomID { get; set; }

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
        /// Id голосований из него.
        /// </summary>
        public List<Guid> VoteIDs { get; set; }
    }
}
