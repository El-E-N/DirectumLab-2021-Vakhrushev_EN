using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataService.Models
{
    /// <summary>
    /// Обсуждение.
    /// </summary>
    public class Discussion : Entity
    {
        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public Discussion()
        {
        }

        /// <summary>
        /// Конструктор обсуждения.
        /// </summary>
        /// <param name="id">Его id.</param>
        /// <param name="roomId">Id комнаты.</param>
        /// <param name="name">Название обсуждения.</param>
        /// <param name="startAt">Начало обсуждения.</param>
        /// <param name="endAt">Конец обсуждения.</param>
        /// <param name="voteIds">Голосования обсуждения.</param>
        public Discussion(Guid id, Guid roomId, string name, DateTime? startAt, DateTime? endAt, ICollection<Guid> voteIds)
        {
            this.Id = id;
            this.RoomId = roomId;
            this.Name = name;
            this.StartAt = startAt;
            this.EndAt = endAt;
            this.VoteIds = JsonSerializer.Serialize<ICollection<Guid>>(voteIds);
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
        public string VoteIds { get; set; }
    }
}
